using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLoggerServiceLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            FTP ftp = new FTP();
            //ftp.CheckForAuthentication("ftp://ftpservice.prodapt.com/LogAnalitics", "W1008", "W1008");
            //ftp.IsFTPAuthentic(@"ftp://ftpservice.prodapt.com/LogAnalitics/", "W1008", "W1008", method);

            const string ftpurl = "ftp://ftpservice.prodapt.com/";

            StringBuilder url = new StringBuilder("ftp://ftpservice.prodapt.com/LogAnalitics");
            string user = "W1008";

            string pass = "W1008";

            List<string> list = new List<string>();

            List<string> dics = new List<string>();

            if (ftp.IsAuthenticFTP(url.ToString(), user, pass))
            {
                list = ftp.GetFilesInFtpDirectory(url.ToString(), user, pass);
            }


            if (list.Count() <= 0 || null != list)
            {
                foreach (string item in list)
                {
                    if (item.ToString().EndsWith(".csv") || item.ToString().EndsWith(".txt") || item.ToString().EndsWith(".html") || item.ToString().EndsWith(".json"))
                        dics.Add(item);
                    else
                    {
                        StringBuilder modifiedURL = new StringBuilder(ftpurl);
                        //modifiedURL.Append("//");
                        modifiedURL.Append(item);

                        List<string> files = ftp.GetFilesInFtpDirectory(modifiedURL.ToString(), user, pass);

                        foreach (string file in files)
                        {
                            modifiedURL = new StringBuilder(ftpurl);

                            if (file.ToString().EndsWith(".csv") || file.ToString().EndsWith(".txt") || file.ToString().EndsWith(".html") || file.ToString().EndsWith(".json"))
                                dics.Add(file);
                                                        
                            else
                            {
                                //modifiedURL.Append(file);
                                //Dictionary<string, string> innerfiles = ftp.LoadFilesFromFtpDirectory(modifiedURL.ToString(), user, pass);


                            }

                        }

                    }


                }

            }
            //List<string> list =  ftp.GetFilesInFtpDirectory("ftp://ftpservice.prodapt.com/LogAnalitics", "W1008", "W1008");

            //List<string> list1 = ftp.GetFilesInFtpDirectory("ftp://ftpservice.prodapt.com/LogAnalitics/AirportLog", "W1008", "W1008");
        }
    }
}
