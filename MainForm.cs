using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;

namespace NationStates_AutoTelegram
{
    public partial class MainForm : Form
    {
        NationStates ns;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Show disclaimer
            if (MessageBox.Show("Make sure you have read and understood the NationStates mass telegramming and scripting rules before using this program.\n\nBy clicking OK, you agree that the author of this program is not responsible for any breaches of NationStates rules resulting from your use of this program.", "Disclaimer", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                this.Close();

            // Load version
            nameVersionLabel.Text = "NationStates AutoTelegram " + Application.ProductVersion;

            // Select telegram text box
            telegramTextBox.Select();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Don't close if currently sending telegrams
            if (backgroundWorker.IsBusy)
            {
                e.Cancel = true;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text.Equals("Start")) // Button changes from Start to Pause/Resume
            {
                // Confirm validity of settings
                if (usernameTextBox.Text.Equals(""))
                {
                    MessageBox.Show("Username field cannot be left blank.", "");
                }
                else if (passwordTextBox.Text.Equals(""))
                {
                    MessageBox.Show("Password field cannot be left blank.", "");
                }
                else if (!(Regex.IsMatch(emailTextBox.Text, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", RegexOptions.IgnoreCase)))
                { // Regex borrowed from Microsoft <http://msdn.microsoft.com/en-us/library/01escwtf.aspx>
                    MessageBox.Show("A valid email address must be provided.", "");
                }
                // Start process
                else
                {
                    // Reset
                    progressBar.Value = 0;
                    startButton.Text = "Pause";
                    cancelButton.Enabled = true;

                    backgroundWorker.RunWorkerAsync();
                }
            }
            else if (startButton.Text.Equals("Pause"))
            {
                startButton.Text = "Resume";
                ns.paused = true;
            }
            else if (startButton.Text.Equals("Resume"))
            {
                startButton.Text = "Pause";
                ns.paused = false;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = false;

            backgroundWorker.CancelAsync();
        }

        private void listView_Resize(object sender, EventArgs e)
        {
            // Resize listview column to full width of window
            listView.Columns[0].Width = -2;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            save.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            try
            {
                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(new FileStream(save.FileName, FileMode.Create, FileAccess.Write));
                    sw.WriteLine("Version: " + Application.ProductVersion);
                    foreach (ListViewItem i in listView.Items) // Save contents of ListView
                    {
                        sw.WriteLine(i.Text);
                    }
                    sw.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Log could not be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker) sender;

            ns = new NationStates(worker, e, usernameTextBox.Text, passwordTextBox.Text, emailTextBox.Text, telegramTextBox.Text);

            if (!ns.login())
            {
                e.Result = "ERROR";
                return;
            }

            worker.ReportProgress(-1, new Log(DateTime.Now.ToLongTimeString() + ": Adding recipients (this may take a while)...", Log.Information));

            // Add recipients
            if (nationsIncludeAllNationsCheckBox.Checked && !ns.addAllNations() ||
                nationsIncludeAllWACheckBox.Checked && !ns.addAllWA() || 
                nationsIncludeAllDelegatesCheckBox.Checked && !ns.addAllDelegates() || 
                !nationsIncludeTextBox.Text.Equals("") && !ns.addNations(nationsIncludeTextBox.Text, nationsIncludeLimitWACheckBox.Checked, nationsIncludeLimitDelegatesCheckBox.Checked) ||
                !regionsIncludeTextBox.Text.Equals("") && !ns.addRegions(regionsIncludeTextBox.Text, regionsIncludeLimitWACheckBox.Checked, regionsIncludeLimitDelegatesCheckBox.Checked) ||
                !tagsIncludeTextBox.Text.Equals("") && !ns.addTags(tagsIncludeTextBox.Text, tagsIncludeLimitWACheckBox.Checked, tagsIncludeLimitDelegatesCheckBox.Checked) ||
                nationsExcludeAllWACheckBox.Checked && !ns.removeAllWA() ||
                nationsExcludeAllDelegatesCheckBox.Checked && !ns.removeAllDelegates() ||
                !nationsExcludeTextBox.Text.Equals("") && !ns.removeNations(nationsExcludeTextBox.Text, nationsExcludeLimitWACheckBox.Checked, nationsExcludeLimitDelegatesCheckBox.Checked) ||
                !regionsExcludeTextBox.Text.Equals("") && !ns.removeRegions(regionsExcludeTextBox.Text, regionsExcludeLimitWACheckBox.Checked, regionsExcludeLimitDelegatesCheckBox.Checked) ||
                !tagsExcludeTextBox.Text.Equals("") && !ns.removeTags(tagsExcludeTextBox.Text, tagsExcludeLimitWACheckBox.Checked, tagsExcludeLimitDelegatesCheckBox.Checked))
            {
                e.Result = "ERROR";
                return;
            }

            worker.ReportProgress(-1, new Log(DateTime.Now.ToLongTimeString() + ": Sending telegrams...", Log.Information));

            while (ns.sendNextTelegram()) { }

            if (!e.Cancel)
            {
                e.Result = "SUCCESS";
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change progress bar percentage, if applicable
            if (e.ProgressPercentage != -1)
                progressBar.Value = e.ProgressPercentage;

            // Add log entry to ListView
            listView.Items.Add(((Log)e.UserState).entry, ((Log)e.UserState).type);
            listView.EnsureVisible(listView.Items.Count - 1);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ns.logout();

            if (e.Cancelled)
                listView.Items.Add(DateTime.Now.ToLongTimeString() + ": Process cancelled by user.", Int32.Parse(Log.Error.ToString()));
            else if (((String)e.Result).Equals("ERROR"))
                listView.Items.Add(DateTime.Now.ToLongTimeString() + ": Process cancelled due to errors.", Int32.Parse(Log.Error.ToString()));
            else if (((String)e.Result).Equals("SUCCESS"))
                listView.Items.Add(DateTime.Now.ToLongTimeString() + ": Process completed.", Int32.Parse(Log.Information.ToString()));

            listView.EnsureVisible(listView.Items.Count - 1);
            progressBar.Value = 100;

            // Reset
            startButton.Text = "Start";
            cancelButton.Enabled = false;
        }

        private void nationToolStripButton_Click(object sender, EventArgs e)
        {
            telegramTextBox.SelectedText = "%NATION%";
        }

        private void regionToolStripButton_Click(object sender, EventArgs e)
        {
            telegramTextBox.SelectedText = "%REGION%";
        }

        private void clearToolStripButton_Click(object sender, EventArgs e)
        {
            telegramTextBox.Clear();
        }

        private void nationsIncludeAllDelegatesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (nationsIncludeAllDelegatesCheckBox.Checked)
            {
                MessageBox.Show("If you are running a proposal endorsement campaign, remember to exclude the No GA Campaigning or No SC Campaigning tags, as appropriate. You are required to do this under NationStates rules.");
            }
        }

        private void nationsIncludeLimitDelegatesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (nationsIncludeLimitDelegatesCheckBox.Checked)
            {
                MessageBox.Show("If you are running a proposal endorsement campaign, remember to exclude the No GA Campaigning or No SC Campaigning tags, as appropriate. You are required to do this under NationStates rules.");
            }
        }

        private void regionsIncludeLimitDelegatesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (regionsIncludeLimitDelegatesCheckBox.Checked)
            {
                MessageBox.Show("If you are running a proposal endorsement campaign, remember to exclude the No GA Campaigning or No SC Campaigning tags, as appropriate. You are required to do this under NationStates rules.");
            }
        }

        private void tagsIncludeLimitDelegatesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (tagsIncludeLimitDelegatesCheckBox.Checked)
            {
                MessageBox.Show("If you are running a proposal endorsement campaign, remember to exclude the No GA Campaigning or No SC Campaigning tags, as appropriate. You are required to do this under NationStates rules.");
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                if (tabControl.SelectedTab == textTabPage || tabControl.SelectedTab == senderTabPage || tabControl.SelectedTab == recipientsTabPage)
                {
                    MessageBox.Show("This tab page cannot be shown while telegrams are being sent.");

                    tabControl.SelectedTab = sendTabPage;
                }
            }
        }
    }
}