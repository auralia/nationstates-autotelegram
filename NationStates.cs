using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.IO.Compression;
using System.ComponentModel;

namespace NationStates_AutoTelegram
{
    class NationStates
    { 
        // Portions of login and telegram sending code borrowed from Coffee and Crack <http://forum.nationstates.net/viewtopic.php?p=8502718>

        // Delay constants (in ticks, or 100 nanosecond intervals)
        public const int apiDelay = 6000000;
        public const int telegramDelay = 200000000;

        // Time of last API request or telegram sending
        public DateTime lastAPIRequest;
        public DateTime lastTelegramSending;

        // BackgroundWorker
        private BackgroundWorker worker;
        private DoWorkEventArgs e;
        public volatile Boolean paused;

        // Account and telegram info
        private String username;
        private String password;
        private String email;
        private String telegram;
        
        // User agent and cookie container (for API requests and sending telegrams)
        private String userAgent;
        private CookieContainer cookies;

        // Nations to telegram
        public List<String> telegramList;
        private int telegramListIndex;

        // Path to nation and region daily dump files
        private String nationDailyDataDump;

        public NationStates(BackgroundWorker worker, DoWorkEventArgs e, String username, String password, String email, String telegram)
        {
            this.lastAPIRequest = new DateTime(0);
            this.lastTelegramSending = new DateTime(0);

            this.worker = worker;
            this.e = e;
            this.paused = false;

            this.username = username;
            this.password = password;
            this.email = email;
            this.telegram = telegram;

            userAgent = "NationStates AutoTelegram " + Application.ProductVersion + " " +
                        "Program author (not responsible for use): Auralia (federal.republic.of.auralia@gmail.com) " +
                        "Current user (responsible for use): " + username + " (" + email + ")";
            cookies = new CookieContainer();

            telegramList = new List<String>();
            telegramListIndex = 0;

            nationDailyDataDump = null;
        }

        public Boolean login()
        {
            try
            {
                pauseAndCancelCheck();

                worker.ReportProgress(Log.NoChange, new Log(DateTime.Now.ToLongTimeString() + ": Logging in to NationStates...", Log.Information));

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/");
                request.CookieContainer = cookies;
                request.Method = "POST";
                request.UserAgent = userAgent;
                request.ContentType = "application/x-www-form-urlencoded";

                Stream requestStream = request.GetRequestStream();
                StreamWriter requestStreamWriter = new StreamWriter(requestStream);
                requestStreamWriter.Write("logging_in=1&nation=" + HttpUtility.UrlEncode(toID(username)) + "&password=" + HttpUtility.UrlEncode(password) + "&autologin=no&submit=Login");
                requestStreamWriter.Close();
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();

                if (cookies.GetCookies(new Uri("http://www.nationstates.net")).Count == 0)
                    throw new Exception("Cookies missing.");

                return true;
            }
            catch (Exception ex)
            {
                if (!e.Cancel)
                {
                    worker.ReportProgress(100, new Log(DateTime.Now.ToLongTimeString() + ": Failed to login to NationStates! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Error));
                }
                    
                return false;
            }
        }

        public void logout()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/logout");
                request.CookieContainer = cookies;
                request.Method = "GET";
                request.UserAgent = userAgent;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                // Do nothing
            }
        }

        public Boolean addAllNations()
        {
            return addRemoveAllNations(true);
        }

        public Boolean removeAllNations()
        {
            return addRemoveAllNations(false);
        }

        public Boolean addRemoveAllNations(Boolean add)
        {
            try
            {
                pauseAndCancelCheck();

                // Download nations daily data dump
                if (!File.Exists(nationDailyDataDump))
                {
                    downloadNationDailyDump(null);
                }

                // Load all nations from dump
                XmlDocument nationsXML = new XmlDocument();
                nationsXML.Load(nationDailyDataDump);

                XmlNodeList versionXMLNode = nationsXML.GetElementsByTagName("NATIONS");
                if (!versionXMLNode[0].Attributes[0].InnerText.Equals("3"))
                    throw new Exception("Nation daily data dump wrong version.");

                // Add or remove nations to or from telegram list
                XmlNodeList nameXMLNodes = nationsXML.GetElementsByTagName("NAME");
                
                List<String> nations = new List<String>();
                for (int i = 0; i < nameXMLNodes.Count; i++)
                {
                    nations.Add(nameXMLNodes[i].InnerText);
                }

                if (add)
                {
                    
                    addToTelegramList(nations);
                }
                else
                {
                    removeFromTelegramList(nations);
                }

                return true;
            }
            catch (Exception ex)
            {
                if (!e.Cancel)
                {
                    if (add)
                    {
                        worker.ReportProgress(100, new Log(DateTime.Now.ToLongTimeString() + ": Failed to add all nations to telegram list! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Error));
                    }
                    else
                    {
                        worker.ReportProgress(100, new Log(DateTime.Now.ToLongTimeString() + ": Failed to remove all nations from telegram list! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Error));
                    }
                }
                    
                return false;
            }
        }

        public Boolean addAllWA()
        {
            return addRemoveAllWA(true);
        }

        public Boolean removeAllWA()
        {
            return addRemoveAllWA(false);
        }

        public Boolean addRemoveAllWA(Boolean add)
        {
            try
            {
                pauseAndCancelCheck();

                // Use API to get list of WA members and add or remove members to or from telegram list
                if (add)
                {
                    addToTelegramList(getWA());
                }
                else
                {
                    removeFromTelegramList(getWA());
                }

                return true;
            }
            catch (Exception ex)
            {
                if (!e.Cancel)
                {
                    if (add)
                    {
                        worker.ReportProgress(100, new Log(DateTime.Now.ToLongTimeString() + ": Failed to add all World Assembly members to telegram list! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Error));
                    }
                    else
                    {
                        worker.ReportProgress(100, new Log(DateTime.Now.ToLongTimeString() + ": Failed to remove all World Assembly members from telegram list! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Error));
                    }
                }
                    
                return false;
            }
        }

        public Boolean addAllDelegates()
        {
            return addRemoveAllDelegates(true);
        }

        public Boolean removeAllDelegates()
        {
            return addRemoveAllDelegates(false);
        }

        public Boolean addRemoveAllDelegates(Boolean add)
        {
            try
            {
                pauseAndCancelCheck();

                // Use API to get list of delegates and add or remove delegates to or from telegram list
                if (add)
                {
                    addToTelegramList(getDelegates());
                }
                else
                {
                    removeFromTelegramList(getDelegates());
                }

                return true;
            }
            catch (Exception ex)
            {
                if (!e.Cancel)
                {
                    if (add)
                    {
                        worker.ReportProgress(100, new Log(DateTime.Now.ToLongTimeString() + ": Failed to add all regional delegates to telegram list! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Error));
                    }
                    else
                    {
                        worker.ReportProgress(100, new Log(DateTime.Now.ToLongTimeString() + ": Failed to remove all regional delegates from telegram list! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Error));
                    }
                }

                return false;
            }
        }

        public Boolean addNations(String nations, Boolean wa, Boolean del)
        {
            return addRemoveNations(nations, wa, del, true);
        }

        public Boolean removeNations(String nations, Boolean wa, Boolean del)
        {
            return addRemoveNations(nations, wa, del, false);
        }

        public Boolean addRemoveNations(String nations, Boolean wa, Boolean del, Boolean add)
        {
            try
            {
                pauseAndCancelCheck();

                if (!wa && !del)
                {
                    // Add or remove nations to or from telegram list
                    if (add)
                    {
                        addToTelegramList(nations.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList());
                    }
                    else
                    {
                        removeFromTelegramList(nations.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList());
                    }
                }
                else if (wa && !del)
                {
                    // Use API to get list of WA members and add or remove corresponding members to or from telegram list

                    List<String> nationsList = nations.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    for (int i = 0; i < nationsList.Count; i++)
                    {
                        nationsList[i] = toID(nationsList[i]);
                    }

                    List<String> membersList = getWA();
                    for (int i = 0; i < membersList.Count; i++)
                    {
                        membersList[i] = toID(membersList[i]);
                    }

                    if (add)
                    {
                        addToTelegramList(nationsList.Intersect(membersList).ToList());
                    }
                    else
                    {
                        removeFromTelegramList(nationsList.Intersect(membersList).ToList());
                    }
                }
                else
                {
                    // Use API to get list of delegates and add or remove corresponding delegates to or from telegram list

                    List<String> nationsList = nations.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    for (int i = 0; i < nationsList.Count; i++)
                    {
                        nationsList[i] = toID(nationsList[i]);
                    }

                    List<String> delegatesList = getDelegates();
                    for (int i = 0; i < delegatesList.Count; i++)
                    {
                        delegatesList[i] = toID(delegatesList[i]);
                    }

                    if (add)
                    {
                        addToTelegramList(nationsList.Intersect(delegatesList).ToList());
                    }
                    else
                    {
                        removeFromTelegramList(nationsList.Intersect(delegatesList).ToList());
                    }
                }
                
                return true;
            }
            catch (Exception ex)
            {
                if (!e.Cancel)
                {
                    if (add)
                    {
                        worker.ReportProgress(100, new Log(DateTime.Now.ToLongTimeString() + ": Failed to add specified nations to telegram list! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Error));
                    }
                    else
                    {
                        worker.ReportProgress(100, new Log(DateTime.Now.ToLongTimeString() + ": Failed to remove specified nations from telegram list! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Error));
                    }
                }
                    
                return false;
            }
        }

        public Boolean addRegions(String regions, Boolean wa, Boolean del)
        {
            return addRemoveRegions(regions, wa, del, true);
        }

        public Boolean removeRegions(String regions, Boolean wa, Boolean del)
        {
            return addRemoveRegions(regions, wa, del, false);
        }

        public Boolean addRemoveRegions(String regions, Boolean wa, Boolean del, Boolean add)
        {
            try
            {
                pauseAndCancelCheck();

                // Use API to get list of nations in regions and pass to addNations or removeNations

                List<String> regionsList = regions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                for (int i = 0; i < regionsList.Count; i++)
                {
                    regionsList[i] = toID(regionsList[i]);

                    while (DateTime.Now.Ticks - lastAPIRequest.Ticks < apiDelay) { }

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?region=" + HttpUtility.UrlEncode(regionsList[i]) + "&q=nations+delegate&v=3");
                    request.Method = "GET";
                    request.UserAgent = userAgent;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();

                    lastAPIRequest = DateTime.Now;

                    XmlDocument regionXML = new XmlDocument();
                    regionXML.Load(responseStream);

                    // Unless delegate is true, in which case just add the delegate nation to the telegram list
                    if (del)
                    {
                        XmlNodeList delegateXMLNodes = regionXML.GetElementsByTagName("DELEGATE");

                        if (add)
                        {
                            if (!delegateXMLNodes[0].InnerText.Equals("0"))
                            {
                                addToTelegramList(delegateXMLNodes[0].InnerText);
                            }
                        }
                        else
                        {
                            if (!delegateXMLNodes[0].InnerText.Equals("0"))
                            {
                                removeFromTelegramList(delegateXMLNodes[0].InnerText);
                            }
                        }
                    }
                    else
                    {
                        XmlNodeList nationsXMLNodes = regionXML.GetElementsByTagName("NATIONS");

                        if (add)
                        {
                            addNations(nationsXMLNodes[0].InnerText.Replace(":", ","), wa, del);
                        }
                        else
                        {
                            removeNations(nationsXMLNodes[0].InnerText.Replace(":", ","), wa, del);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                if (!e.Cancel)
                {
                    if (add)
                    {
                        worker.ReportProgress(100, new Log(DateTime.Now.ToLongTimeString() + ": Failed to add specified regions to telegram list! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Error));
                    }
                    else
                    {
                        worker.ReportProgress(100, new Log(DateTime.Now.ToLongTimeString() + ": Failed to remove specified regions from telegram list! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Error));
                    }
                }
                    
                return false;
            }
        }

        public Boolean addTags(String tags, Boolean wa, Boolean del)
        {
            return addRemoveTags(tags, wa, del, true);
        }

        public Boolean removeTags(String tags, Boolean wa, Boolean del)
        {
            return addRemoveTags(tags, wa, del, false);
        }
        
        public Boolean addRemoveTags(String tags, Boolean wa, Boolean del, Boolean add)
        {
            try
            {
                pauseAndCancelCheck();

                // Use API to get list of regions by tag and nations in region and pass to addRegions or removeRegions

                String[] tagsArray = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                String tagsFormatted = "";
                for (int i = 0; i < tagsArray.Length; i++)
                {
                    tagsArray[i] = toID(tagsArray[i]);
                    tagsFormatted += tagsArray[i] + ",";
                }
                tagsFormatted = tagsFormatted.Remove(tagsFormatted.Length - 1);

                while (DateTime.Now.Ticks - lastAPIRequest.Ticks < apiDelay) { }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?q=regionsbytag;tags=" + HttpUtility.UrlEncode(tagsFormatted) + "&v=3");
                request.Method = "GET";
                request.UserAgent = userAgent;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();

                lastAPIRequest = DateTime.Now;

                XmlDocument regionsXML = new XmlDocument();
                regionsXML.Load(responseStream);

                XmlNodeList regionsXMLNodes = regionsXML.GetElementsByTagName("REGIONS");

                if (add)
                {
                    addRegions(regionsXMLNodes[0].InnerText, wa, del);
                }
                else
                {
                    removeRegions(regionsXMLNodes[0].InnerText, wa, del);
                }

                return true;
            }
            catch (Exception ex)
            {
                if (!e.Cancel)
                {
                    if (add)
                    {
                        worker.ReportProgress(100, new Log(DateTime.Now.ToLongTimeString() + ": Failed to add specified tags to telegram list! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Error));
                    }
                    else
                    {
                        worker.ReportProgress(100, new Log(DateTime.Now.ToLongTimeString() + ": Failed to remove specified tags from telegram list! (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Error));
                    }
                }
                
                return false;
            }
        }

        public Boolean sendNextTelegram()
        {
            pauseAndCancelCheck();

            if (telegramListIndex >= telegramList.Count)
            {
                return false;
            }
            else
            {
                sendTelegram(telegramList[telegramListIndex], telegram);
                telegramListIndex += 1;

                return true;
            }
        }

        private Boolean sendTelegram(String recipient, String message)
        { 
            try
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    throw new Exception();
                }
                else
                {
                    while (paused) { }
                }

                String newMessage = message;
                if (newMessage.IndexOf("%NATION") != -1)
                {
                    String name = getNationName(recipient);
                    if (name != null)
                        newMessage = newMessage.Replace("%NATION%", name);
                    else
                        throw new Exception("Nation name could not be retrieved.");
                }
                if (message.IndexOf("%REGION%") != -1)
                {
                    String name = getNationRegion(recipient);
                    if (name != null)
                        newMessage = newMessage.Replace("%REGION%", name);
                    else
                        throw new Exception("Region name could not be retrieved.");
                }

                while (DateTime.Now.Ticks - lastTelegramSending.Ticks < telegramDelay) { }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/nation=" + HttpUtility.UrlEncode(toID(recipient)));
                request.CookieContainer = cookies;
                request.Method = "GET";
                request.UserAgent = userAgent;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader responseStreamReader = new StreamReader(responseStream);

                String chk = responseStreamReader.ReadToEnd();
                String chkPrefix = "<input type=\"hidden\" name=\"chk\" value=\"";
                chk = chk.Substring(chk.IndexOf(chkPrefix) + chkPrefix.Length);
                chk = chk.Substring(0, chk.IndexOf("\">"));

                responseStreamReader.Close();
                responseStream.Close();
                response.Close();

                request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/nation=" + HttpUtility.UrlEncode(toID(recipient)) + "#s");
                request.CookieContainer = cookies;
                request.Method = "POST";
                request.UserAgent = userAgent;
                request.ContentType = "application/x-www-form-urlencoded";

                Stream requestStream = request.GetRequestStream();
                StreamWriter requestStreamWriter = new StreamWriter(requestStream);
                String req = "chk=" + chk + "&message=" + HttpUtility.UrlEncodeUnicode(newMessage) + "&send=+Send+";
                requestStreamWriter.Write(req);
                requestStreamWriter.Close();
                requestStream.Close();

                response = (HttpWebResponse)request.GetResponse();
                responseStream = response.GetResponseStream();
                responseStreamReader = new StreamReader(responseStream);

                if (!responseStreamReader.ReadToEnd().ToUpper().Contains("TELEGRAM HAS BEEN WIRED"))
                    throw new Exception("NationStates did not report that the telegram was wired to the recipient. The nation may be part of a registered school class.");

                response.Close();

                lastTelegramSending = DateTime.Now;

                worker.ReportProgress((int)((((double)telegramListIndex) / telegramList.Count) * 100), new Log(DateTime.Now.ToLongTimeString() + ": Telegram sent to " + recipient.Replace("_", " ").ToUpper() + ".", Log.Information));
                return true;
            }
            catch (Exception ex)
            {
                lastTelegramSending = DateTime.Now;

                if (!e.Cancel)
                    worker.ReportProgress((int)((((double)telegramListIndex) / telegramList.Count) * 100), new Log(DateTime.Now.ToLongTimeString() + ": Telegram could not be sent to " + recipient.Replace("_", " ").ToUpper() + ". (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Warning));

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

        private List<String> getWA()
        {
            while (DateTime.Now.Ticks - lastAPIRequest.Ticks < apiDelay) { }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?wa=1&q=members&v=3");
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

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?wa=1&q=delegates&v=3");
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

        private String toID(String text)
        {
            return text.Trim().ToLower().Replace(' ', '_');
        }

        private String fromID(String text)
        {
            return text.Trim().ToLower().Replace('_', ' ');
        }

        private String getNationName(String nation)
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

                while (DateTime.Now.Ticks - lastAPIRequest.Ticks < apiDelay) { }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?nation=" + HttpUtility.UrlEncode(toID(nation)) + "&q=name&v=3");
                request.Method = "GET";
                request.UserAgent = userAgent;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();

                lastAPIRequest = DateTime.Now;

                XmlDocument nameXML = new XmlDocument();
                nameXML.Load(responseStream);

                XmlNodeList nameXMLNodes = nameXML.GetElementsByTagName("NAME");

                return nameXMLNodes[0].InnerText;
            }
            catch (Exception ex)
            {
                if (!e.Cancel)
                {
                    worker.ReportProgress(-1, new Log(DateTime.Now.ToLongTimeString() + ": Name could not be retrieved for " + nation + "! Telegram will not be sent. (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Warning));
                    return null;
                }
                else
                {
                    throw ex;
                }
            }
        }

        private String getNationRegion(String nation)
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

                while (DateTime.Now.Ticks - lastAPIRequest.Ticks < apiDelay) { }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.nationstates.net/cgi-bin/api.cgi?nation=" + HttpUtility.UrlEncode(toID(nation)) + "&q=region&v=3");
                request.Method = "GET";
                request.UserAgent = userAgent;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();

                lastAPIRequest = DateTime.Now;

                XmlDocument regionXML = new XmlDocument();
                regionXML.Load(responseStream);

                XmlNodeList regionXMLNodes = regionXML.GetElementsByTagName("REGION");

                return regionXMLNodes[0].InnerText;
            }
            catch (Exception ex)
            {
                if (!e.Cancel)
                {
                    worker.ReportProgress(-1, new Log(DateTime.Now.ToLongTimeString() + ": Region could not be retrieved for " + nation + ". Telegram will not be sent. (" + ex.GetType() + ": " + ex.Message + " - " + ex.StackTrace + ")", Log.Warning));
                    return null;
                }
                else
                {
                    throw ex;
                }
            }
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
                    throw new DirectoryNotFoundException("Temporary directory does not exist.");

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
                worker.ReportProgress(-1, new Log(DateTime.Now.ToLongTimeString() + ": Could not download nation daily dump! (Exception: " + ex.Message + ")", Log.Error));

                throw new Exception("Could not download nation daily dump.");
            }
        }

        private void pauseAndCancelCheck()
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;

                throw new Exception("Process cancelled.");
            }
            else
            {
                while (paused)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }

    class Log
    {
        public const int Information = 0;
        public const int Warning = 1;
        public const int Error = 2;

        public const int NoChange = -1;

        public String entry;
        public int type;

        public Log(String entry, int type)
        {
            this.entry = entry;
            this.type = type;
        }
    }
}