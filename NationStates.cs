using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace NationStates_AutoTelegram
{
    class NationStates
    { 
        // API version
        public const int apiVersion = 4;

        // Delay constants (in ticks, or 100 nanosecond intervals)
        public const int apiDelay = 6000000; 
        public const int nonRecruitmentTelegramDelay = 300000000;
        public const int recruitmentTelegramDelay = 1800000000;

        // Time of last API request or telegram sending
        public DateTime lastAPIRequest;
        public DateTime lastTelegramSending;

        // BackgroundWorker
        private BackgroundWorker worker;
        private DoWorkEventArgs e;
        public volatile Boolean paused;

        // Telegram data
        private String clientKey;
        private String telegramID;
        private String secretKey;
        private Boolean isRecruitmentTG;

        // User agent
        private String userAgent;

        // Nations to telegram 
        public List<String> telegramList;
        private int telegramListIndex;

        // Recruitment
        private String lastRecruitedNation;

        // Path to nation daily dump files
        private String nationDailyDataDump;

        public NationStates(BackgroundWorker worker, DoWorkEventArgs e, String clientKey, String telegramID, String secretKey, Boolean isRecruitmentTG)
        {
            this.lastAPIRequest = new DateTime(0);
            this.lastTelegramSending = new DateTime(0);

            this.worker = worker;
            this.e = e;
            this.paused = false;

            this.clientKey = clientKey;
            this.telegramID = telegramID;
            this.secretKey = secretKey;
            this.isRecruitmentTG = isRecruitmentTG;

            userAgent = "NationStates AutoTelegram " + Application.ProductVersion + " (maintained by Auralia, currently used by client key " + clientKey + ")";

            telegramList = new List<String>();
            telegramListIndex = 0;

            nationDailyDataDump = null;
        }

        public void addAllNations()
        {
            try
            {
                addToTelegramList(getAll());
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public void removeAllNations()
        {
            try
            {
                removeFromTelegramList(getAll());
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public void addAllNew()
        {
            try
            {
                addToTelegramList(getNew());
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public void removeAllNew()
        {
            try
            {
                removeFromTelegramList(getNew());
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public void addAllMembers()
        {
            try
            {
                addToTelegramList(getMembers());
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public void removeAllMembers()
        {
            try
            {
                removeFromTelegramList(getMembers());
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public void addAllDelegates()
        {
            try
            {
                addToTelegramList(getDelegates());
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public void removeAllDelegates()
        {
            try
            {
                removeFromTelegramList(getDelegates());
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public void addNations(List<String> nations)
        {
            try
            {
                if (nations.Count == 0)
                    return;

                addToTelegramList(nations);
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public void removeNations(List<String> nations)
        {
            try
            {
                if (nations.Count == 0)
                    return;

                removeFromTelegramList(nations);
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public void addRegions(List<String> regions)
        {
            try
            {
                if (regions.Count == 0)
                    return;

                // Use API to get list of nations in regions and pass to addNations or removeNations
                for (int i = 0; i < regions.Count; i++)
                {
                    regions[i] = toID(regions[i]);

                    while (DateTime.Now.Ticks - lastAPIRequest.Ticks < apiDelay) { }

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?region=" + HttpUtility.UrlEncode(regions[i]) + "&q=nations+delegate&v=" + apiVersion);
                    request.Method = "GET";
                    request.UserAgent = userAgent;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();

                    lastAPIRequest = DateTime.Now;

                    XmlDocument regionXML = new XmlDocument();
                    regionXML.Load(responseStream);

                    XmlNodeList nationsXMLNodes = regionXML.GetElementsByTagName("NATIONS");
                    addNations(nationsXMLNodes[0].InnerText.Split(':').ToList());
                }
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public void removeRegions(List<String> regions)
        {
            try
            {
                if (regions.Count == 0)
                    return;

                // Use API to get list of nations in regions and pass to addNations or removeNations
                for (int i = 0; i < regions.Count; i++)
                {
                    regions[i] = toID(regions[i]);

                    while (DateTime.Now.Ticks - lastAPIRequest.Ticks < apiDelay) { }

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?region=" + HttpUtility.UrlEncode(regions[i]) + "&q=nations+delegate&v=" + apiVersion);
                    request.Method = "GET";
                    request.UserAgent = userAgent;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();

                    lastAPIRequest = DateTime.Now;

                    XmlDocument regionXML = new XmlDocument();
                    regionXML.Load(responseStream);

                    XmlNodeList nationsXMLNodes = regionXML.GetElementsByTagName("NATIONS");
                    removeNations(nationsXMLNodes[0].InnerText.Split(':').ToList());
                }
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public void addTags(List<String> tags)
        {
            try
            {
                if (tags.Count == 0)
                    return;

                // Use API to get list of regions by tag and nations in region and pass to addRegions or removeRegions
                foreach (String tag in tags)
                {
                    while (DateTime.Now.Ticks - lastAPIRequest.Ticks < apiDelay) { }

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?q=regionsbytag;tags=" + HttpUtility.UrlEncode(tag) + "&v=" + apiVersion);
                    request.Method = "GET";
                    request.UserAgent = userAgent;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();

                    lastAPIRequest = DateTime.Now;

                    XmlDocument regionsXML = new XmlDocument();
                    regionsXML.Load(responseStream);

                    XmlNodeList regionsXMLNodes = regionsXML.GetElementsByTagName("REGIONS");
                    addRegions(regionsXMLNodes[0].InnerText.Split(',').ToList());
                }
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public void removeTags(List<String> tags)
        {
            try
            {
                if (tags.Count == 0)
                    return;

                // Use API to get list of regions by tag and nations in region and pass to addRegions or removeRegions
                foreach (String tag in tags) 
                {
                    while (DateTime.Now.Ticks - lastAPIRequest.Ticks < apiDelay) { }

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?q=regionsbytag;tags=" + HttpUtility.UrlEncode(tag) + "&v=" + apiVersion);
                    request.Method = "GET";
                    request.UserAgent = userAgent;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();

                    lastAPIRequest = DateTime.Now;

                    XmlDocument regionsXML = new XmlDocument();
                    regionsXML.Load(responseStream);

                    XmlNodeList regionsXMLNodes = regionsXML.GetElementsByTagName("REGIONS");
                    removeRegions(regionsXMLNodes[0].InnerText.Split(',').ToList());
                }
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to create list of recipients! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                throw new Exception();
            }
        }

        public Boolean sendNextTelegram()
        {
            if (telegramListIndex >= telegramList.Count)
            {
                return false;
            }
            else
            {
                sendTelegram(telegramList[telegramListIndex], false);
                telegramListIndex += 1;

                return true;
            }
        }

        public Boolean sendNextRecruitmentTelegram()
        {
            if (lastRecruitedNation == null)
            {
                lastRecruitedNation = toID(getNew()[0]);
            }
            else
            {
                String newNation = toID(getNew()[0]);
                if (!lastRecruitedNation.Equals(newNation))
                {
                    sendTelegram(newNation, true);
                    lastRecruitedNation = newNation;
                }
                else
                {
                    System.Threading.Thread.Sleep(1000); // New nations are only created every few minutes, and NationStates should not be bombarded with newnation API requests in the meantime
                }
            }

            return true;
        }

        private Boolean sendTelegram(String recipient, Boolean isRecruitmentMode)
        { 
            try
            {
                if (isRecruitmentTG)
                {
                    while (DateTime.Now.Ticks - lastTelegramSending.Ticks < recruitmentTelegramDelay) { }
                }
                else
                {
                    while (DateTime.Now.Ticks - lastTelegramSending.Ticks < nonRecruitmentTelegramDelay) { }
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?a=sendTG&client=" + HttpUtility.UrlEncode(clientKey) + "&tgid=" + HttpUtility.UrlEncode(telegramID) + "&key=" + HttpUtility.UrlEncode(secretKey) + "&to=" + HttpUtility.UrlEncode(toID(recipient)));
                request.Method = "GET";
                request.UserAgent = userAgent;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader responseStreamReader = new StreamReader(responseStream);
                String responseText = responseStreamReader.ReadToEnd();

                if (!responseText.Contains("queued"))
                    throw new Exception("NationStates reported an error: " + responseText);

                response.Close();

                lastTelegramSending = DateTime.Now;

                if (!isRecruitmentMode)
                {
                    worker.ReportProgress((int)((((double)telegramListIndex + 1) / telegramList.Count) * 100), new Log("Telegram queued for " + fromID(recipient) + "."));
                }
                else
                {
                    worker.ReportProgress(-1, new Log("Telegram queued for " + fromID(recipient) + "."));
                }
                
                return true;
            }
            catch (Exception ex)
            {
                lastTelegramSending = DateTime.Now;

                if (!isRecruitmentMode)
                {
                    worker.ReportProgress((int)((((double)telegramListIndex + 1) / telegramList.Count) * 100), new Log("Failed to queue telegram for " + fromID(recipient) + "! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                }
                else
                {
                    worker.ReportProgress(-1, new Log("Failed to queue telegram for " + fromID(recipient) + "! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));
                }

                return false;
            }
        }

        private void addToTelegramList(String nation)
        {
            if (!telegramList.Contains(toID(nation)))
            {
                telegramList.Add(toID(nation));
            } 
        }

        private void addToTelegramList(List<String> nations)
        {
            for (int i = 0; i < nations.Count; i++)
            {
                if (!telegramList.Contains(toID(nations[i]))) 
                {
                    telegramList.Add(nations[i]);
                }
            }
        }

        private void removeFromTelegramList(String nation)
        {
            while (telegramList.Contains(toID(nation)))
            {
                telegramList.Remove(toID(nation));
            }
        }

        private void removeFromTelegramList(List<String> nations)
        {
            for (int i = 0; i < nations.Count; i++)
            {
                while (telegramList.Contains(toID(nations[i])))
                {
                    telegramList.Remove(toID(nations[i]));
                }   
            }
        }

        private List<String> getAll()
        {
            // Download nations daily data dump
            if (!File.Exists(nationDailyDataDump))
            {

                downloadNationDailyDump(null);
            }

            // Load all nations from dump
            XmlDocument nationsXML = new XmlDocument();
            nationsXML.Load(nationDailyDataDump);

            XmlNodeList versionXMLNode = nationsXML.GetElementsByTagName("NATIONS");
            if (!versionXMLNode[0].Attributes[0].InnerText.Equals(apiVersion))
                throw new Exception("Nation daily data dump wrong version (required: " + apiVersion + ", found: " + versionXMLNode[0].Attributes[0].InnerText + ")");

            // Add or remove nations to or from telegram list
            XmlNodeList nameXMLNodes = nationsXML.GetElementsByTagName("NAME");

            List<String> nations = new List<String>();
            for (int i = 0; i < nameXMLNodes.Count; i++)
            {
                nations.Add(nameXMLNodes[i].InnerText);
            }

            return nations;
        }

        private List<String> getMembers()
        {
            while (DateTime.Now.Ticks - lastAPIRequest.Ticks < apiDelay) { }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?wa=1&q=members&v=" + apiVersion);
            request.Method = "GET";
            request.UserAgent = userAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            lastAPIRequest = DateTime.Now;

            XmlDocument membersXML = new XmlDocument();
            membersXML.Load(responseStream);

            XmlNodeList membersXMLNodes = membersXML.GetElementsByTagName("MEMBERS");

            List<String> members = membersXMLNodes[0].InnerText.Split(',').ToList();
            for (int i = 0; i < members.Count; i++)
            {
                members[i] = toID(members[i]);
            }
            return members;
        }

        private List<String> getDelegates()
        {
            while (DateTime.Now.Ticks - lastAPIRequest.Ticks < apiDelay) { }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?wa=1&q=delegates&v=" + apiVersion);
            request.Method = "GET";
            request.UserAgent = userAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            lastAPIRequest = DateTime.Now;

            XmlDocument delegatesXML = new XmlDocument();
            delegatesXML.Load(responseStream);

            XmlNodeList delegatesXMLNodes = delegatesXML.GetElementsByTagName("DELEGATES");

            List<String> delegates = delegatesXMLNodes[0].InnerText.Split(',').ToList();
            for (int i = 0; i < delegates.Count; i++)
            {
                delegates[i] = toID(delegates[i]);
            }
            return delegates;
        }

        private List<String> getNew()
        {
            while (DateTime.Now.Ticks - lastAPIRequest.Ticks < apiDelay) { }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?q=newnations&v=" + apiVersion);
            request.Method = "GET";
            request.UserAgent = userAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            lastAPIRequest = DateTime.Now;

            XmlDocument newNationsXML = new XmlDocument();
            newNationsXML.Load(responseStream);

            XmlNodeList newNationsXMLNodes = newNationsXML.GetElementsByTagName("NEWNATIONS");

            List<String> newNations = newNationsXMLNodes[0].InnerText.Split(',').ToList();
            for (int i = 0; i < newNations.Count; i++)
            {
                newNations[i] = toID(newNations[i]);
            }
            return newNations;
        }

        private String toID(String text)
        {
            return text.Trim().ToLower().Replace(' ', '_');
        }

        private String fromID(String text)
        {
            return text.Trim().ToLower().Replace('_', ' ');
        }

        private void downloadNationDailyDump(String path)
        {
            try
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    throw new Exception("Process cancelled.");
                }
                else
                {
                    while (paused) { }
                }

                if (path == null)
                    path = Path.GetTempPath();

                DirectoryInfo pathInfo = new DirectoryInfo(path);
                if (!pathInfo.Exists)
                    throw new DirectoryNotFoundException("Temporary directory does not exist");

                while (DateTime.Now.Ticks - lastAPIRequest.Ticks < apiDelay) { }

                WebClient webClient = new WebClient();
                webClient.DownloadFile("http://www.nationstates.net/pages/nations.xml.gz", pathInfo.FullName + "nations.xml.gz");

                lastAPIRequest = DateTime.Now;

                FileStream open = new FileStream(pathInfo.FullName + "nations.xml.gz", FileMode.Open);
                GZipStream gzip = new GZipStream(open, CompressionMode.Decompress);

                File.Delete(pathInfo.FullName + "nations.xml");
                FileStream save = new FileStream(pathInfo.FullName + "nations.xml", FileMode.CreateNew);
                gzip.CopyTo(save);

                open.Close();
                gzip.Close();
                save.Close();

                File.Delete(pathInfo.FullName + "nations.xml.gz");

                nationDailyDataDump = pathInfo.FullName + "nations.xml";
            }
            catch (Exception ex)
            {
                worker.ReportProgress(-1, new Log("Failed to download nation daily dump! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")"));

                throw new Exception("Failed to download nation daily dump");
            }
        }
    }
}