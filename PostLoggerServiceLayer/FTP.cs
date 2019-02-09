using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PostLoggerServiceLayer
{
    public class FTP
    {

        public FTP()
        {

        }

        public List<string> GetFilesInFtpDirectory(string url, string username, string password)
        {
            List<string> files = new List<string>();

            // Get the object used to communicate with the server.
            var request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(username, password);

            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line) == false)
                        {
                            //yield return line.Split(new[] { ' ', '\t' }).Last();

                            files.Add(line);


                        }
                    }
                }
            }
            return files;
        }

        public Dictionary<string,string> LoadFilesFromFtpDirectory(string url, string username, string password)
        {
            Dictionary<string,string> files = new Dictionary<string, string>();

            // Get the object used to communicate with the server.
            var request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.UseBinary = true;
            request.Credentials = new NetworkCredential(username, password);

            using (var response = (FtpWebResponse)request.GetResponse())
            {
                FileStream outputStream = new FileStream(@"./url/",FileMode.OpenOrCreate);

                using (var responseStream = response.GetResponseStream())
                {
                    long cl = response.ContentLength;
                    int bufferSize = 2048;
                    int readCount;
                    byte[] buffer = null;

                    readCount = responseStream.Read(buffer, 0, bufferSize);
                    while (readCount > 0)
                    {
                        outputStream.Write(buffer, 0, readCount);
                        readCount = responseStream.Read(buffer, 0, bufferSize);
                    }
                    files.Add(url, response.StatusDescription);
                    
                }
            }
            return files;
        }
        public bool IsAuthenticFTP(string ftprul, string userid, string password)
        {

            try
            {
                // FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://Hostname.com/");    
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftprul);
                //request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;


                request.Credentials = new NetworkCredential(userid, password);
                request.KeepAlive = false;
                request.UseBinary = true;
                request.UsePassive = true;


                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                Console.WriteLine(reader.ReadToEnd());

                Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);

                reader.Close();
                response.Close();

                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
                return false;
            }

        }


    }
}
