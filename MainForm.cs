using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            if (MessageBox.Show("You must read and understand the NationStates mass telegramming and scripting rules before using this program. By clicking OK, you agree that the author of the Software is not responsible for any breaches of NationStates rules resulting from your use of this program.", "Disclaimer", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
            {
                this.Close();
            }

            // Load version
            nameVersionLabel.Text = "NationStates AutoTelegram " + Application.ProductVersion;

            // Select client key text box
            clientKeyTextBox.Select();
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
            if (startButton.Text.Equals("Start"))
            {
                // Sanity checks
                if (!Regex.IsMatch(clientKeyTextBox.Text, "^[A-Z0-9]+$", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("The client key field is empty or contains unacceptable characters.", "");
                }
                else if (!Regex.IsMatch(telegramIDTextBox.Text, "^[0-9]+$", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("The telegram ID field is empty or contains unacceptable characters.", "");
                }
                else if (!Regex.IsMatch(secretKeyTextBox.Text, "^[A-Z0-9]+$", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("The secret key field is empty or contains unacceptable characters.", "");
                }
                else if (!Regex.IsMatch(recipientsTextBox.Text, "^.+$", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("The recipient list field is empty.", "");
                }
                else
                {
                    List<String> recipientData = recipientsTextBox.Text.Split(',').ToList<String>();
                    foreach (String entry in recipientData)
                    {
                        if (!Regex.IsMatch(entry.Trim(), "^([+-])?(nation|region|tag|special|recruitment):([\\w\\s]+)$", RegexOptions.IgnoreCase))
                        {
                            MessageBox.Show("The recipient list field contains invalid data.", "");
                            return;
                        }
                        else if (Regex.IsMatch(entry.Trim(), "^([+-])?special:([\\w\\s]+)$", RegexOptions.IgnoreCase) && !Regex.IsMatch(entry.Trim(), "^([+-])?special:(\\s+)?(all|members|delegates|new)$", RegexOptions.IgnoreCase))
                        {
                            MessageBox.Show("The recipient list field contains invalid data.", "");
                            return;
                        }
                        else if (Regex.IsMatch(entry.Trim(), "^([+-])?recruitment:([\\w\\s]+)$", RegexOptions.IgnoreCase) && !Regex.IsMatch(entry.Trim(), "^([+-])?recruitment:(\\s+)?(new)$", RegexOptions.IgnoreCase))
                        {
                            MessageBox.Show("The recipient list field contains invalid data.", "");
                            return;
                        }
                    }

                    // Reset
                    logTextBox.Clear();
                    progressBar.Value = 0;
                    startButton.Text = "Pause";
                    cancelButton.Enabled = true;

                    backgroundWorker.RunWorkerAsync(recipientsTextBox.Text.Split(',').ToList<String>());
                }
            }
            // Pause/resume functionality
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

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ns = new NationStates(backgroundWorker, e, clientKeyTextBox.Text, telegramIDTextBox.Text, secretKeyTextBox.Text, recruitmentRadioButton.Checked);

            backgroundWorker.ReportProgress(-1, new Log("Creating list of recipients (this may take a while)..."));

            List<String> nationsInclude = new List<String>(), regionsInclude = new List<String>(), tagsInclude = new List<String>(), nationsExclude = new List<String>(), regionsExclude = new List<String>(), tagsExclude = new List<String>();
            Boolean allInclude = false, membersInclude = false, delegatesInclude = false, newInclude = false, allExclude = false, membersExclude = false, delegatesExclude = false, newExclude = false;
            Boolean recruitment = false;

            List<String> recipientData = (List<String>) e.Argument;

            // Generate list of recipients
            foreach (String entry in recipientData)
            {
                Match match = Regex.Match(entry.Trim(), "^([+-])?(nation|region|tag|special|recruitment):([\\w\\s]+)$", RegexOptions.IgnoreCase);
                if (match.Groups[2].ToString().ToLower().Equals("nation"))
                {
                    if (match.Groups[1].ToString().Equals("+") || match.Groups[1].ToString().Equals(""))
                    {
                        nationsInclude.Add(match.Groups[3].ToString().Trim());
                    }
                    else if (match.Groups[1].ToString().Equals("-"))
                    {
                        nationsExclude.Add(match.Groups[3].ToString().Trim());
                    }
                }
                else if (match.Groups[2].ToString().ToLower().Equals("region"))
                {
                    if (match.Groups[1].ToString().Equals("+") || match.Groups[1].ToString().Equals(""))
                    {
                        regionsInclude.Add(match.Groups[3].ToString().Trim());
                    }
                    else if (match.Groups[1].ToString().Equals("-"))
                    {
                        regionsExclude.Add(match.Groups[3].ToString().Trim());
                    }
                }
                else if (match.Groups[2].ToString().ToLower().Equals("tag"))
                {
                    if (match.Groups[1].ToString().Equals("+") || match.Groups[1].ToString().Equals(""))
                    {
                        tagsInclude.Add(match.Groups[3].ToString().Trim());
                    }
                    else if (match.Groups[1].ToString().Equals("-"))
                    {
                        tagsExclude.Add(match.Groups[3].ToString().Trim());
                    }
                }
                else if (match.Groups[2].ToString().ToLower().Equals("special"))
                {
                    if (match.Groups[1].ToString().Equals("+") || match.Groups[1].ToString().Equals(""))
                    {
                        if (match.Groups[3].ToString().Trim().ToLower().Equals("all"))
                        {
                            allInclude = true;
                        }
                        else if (match.Groups[3].ToString().Trim().ToLower().Equals("members"))
                        {
                            membersInclude = true;
                        }
                        else if (match.Groups[3].ToString().Trim().ToLower().Equals("delegates"))
                        {
                            delegatesInclude = true;
                        }
                        else if (match.Groups[3].ToString().Trim().ToLower().Equals("new"))
                        {
                            newInclude = true;
                        }
                    }
                    else if (match.Groups[1].ToString().Equals("-"))
                    {
                        if (match.Groups[3].ToString().Trim().ToLower().Equals("all"))
                        {
                            allExclude = true;
                        }
                        else if (match.Groups[3].ToString().Trim().ToLower().Equals("members"))
                        {
                            membersExclude = false;
                        }
                        else if (match.Groups[3].ToString().Trim().ToLower().Equals("delegates"))
                        {
                            delegatesExclude = false;
                        }
                        else if (match.Groups[3].ToString().Trim().ToLower().Equals("new"))
                        {
                            newExclude = false;
                        }
                    }
                }
                else if (match.Groups[2].ToString().ToLower().Equals("recruitment"))
                {
                    if (match.Groups[3].ToString().Trim().ToLower().Equals("new"))
                    {
                        recruitment = true;
                    }
                }
            }

            try
            {
                if (allInclude)
                {
                    ns.addAllNations();
                }
                if (membersInclude)
                {
                    ns.addAllMembers();
                }
                if (delegatesInclude)
                {
                    ns.addAllDelegates();
                }
                if (newInclude)
                {
                    ns.addAllNew();
                }

                ns.addNations(nationsInclude);
                ns.addRegions(regionsInclude);
                ns.addTags(tagsInclude);

                if (allExclude)
                {
                    ns.removeAllNations();
                }
                if (membersExclude)
                {
                    ns.removeAllMembers();
                }
                if (delegatesExclude)
                {
                    ns.removeAllDelegates();
                }
                if (newExclude)
                {
                    ns.removeAllNew();
                }

                ns.removeNations(nationsExclude);
                ns.removeRegions(regionsExclude);
                ns.removeTags(tagsExclude);
            }
            catch (Exception)
            {
                e.Result = "ERROR";
                return;
            }

            backgroundWorker.ReportProgress(-1, new Log("Sending telegrams..."));

            // Send normal telegrams
            while (ns.sendNextTelegram()) 
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    while (ns.paused)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }

            backgroundWorker.ReportProgress(0, new Log("Sending recruitment telegrams..."));

            // Send recruitment telegrams
            while (recruitment && ns.sendNextRecruitmentTelegram())
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    while (ns.paused)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }

            e.Result = "SUCCESS";
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change progress bar percentage, if applicable
            if (e.ProgressPercentage != -1)
                progressBar.Value = e.ProgressPercentage;

            if (e.UserState is Log)
            {
                // Add log entry to ListView
                logTextBox.Text += (logTextBox.Text.Equals("") ? "" : "\n") + ((Log)e.UserState).entry;

                // Ensure new entry is visible
                logTextBox.Select(logTextBox.TextLength - 1, 0);
                logTextBox.ScrollToCaret();
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Final log entry
            if (e.Cancelled)
                logTextBox.Text += "\n" + new Log("Cancelled by user.").entry;
            else if (((String)e.Result).Equals("ERROR"))
                logTextBox.Text += "\n" + new Log("Cancelled due to errors.").entry;
            else if (((String)e.Result).Equals("SUCCESS"))
                logTextBox.Text += "\n" + new Log("Completed.").entry;

            // Ensure new entry is visible
            logTextBox.Select(logTextBox.TextLength - 1, 0);
            logTextBox.ScrollToCaret();

            // Set progress bar value
            progressBar.Value = 100;

            // Reset
            startButton.Text = "Start";
            cancelButton.Enabled = false;
        }
    }

    class Log
    {
        public String entry;

        public Log(String entry)
        {
            this.entry = DateTime.Now.ToLongTimeString() + ": " + entry;
        }
    }
}