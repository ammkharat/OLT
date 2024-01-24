using System;
using System.IO;
using System.Net;
using System.Text;

namespace Com.Suncor.Olt.Integration.Handlers
{
    public class MessageSender
    {
        /// <summary>
        ///     Perform a http post to the specified URL
        /// </summary>
        /// <param name="postData">Data to post to the URL</param>
        /// <param name="targetUrl">Destination URL</param>
        /// <returns>A string containing the HTTP response data</returns>
        public string SyncSubmit(string postData, string targetUrl)
        {
            var result = string.Empty;
            var strPost = postData; //URLEncode(PostData);

            var objRequest = (HttpWebRequest) WebRequest.Create(targetUrl);
            objRequest.Method = "POST";
            objRequest.ProtocolVersion = HttpVersion.Version10;
            objRequest.ContentLength = Encoding.Default.GetByteCount(strPost);
            objRequest.ContentType = "application/text";

            StreamWriter myWriter = null;
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream(), Encoding.Default);
                myWriter.Write(strPost);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (myWriter != null)
                    myWriter.Close();
            }

            HttpWebResponse objResponse = null;
            try
            {
                var iRunningDataLen = 0;
                StreamReader sr;

                objRequest.Timeout = 180000; // 3 mins
                objResponse = (HttpWebResponse) objRequest.GetResponse();
                    // timeout throws exception, trapped at higer level.

                var iTotalDataLen = (int) objResponse.ContentLength;

                while (iRunningDataLen < iTotalDataLen)
                {
                    using (sr = new StreamReader(objResponse.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                        iRunningDataLen = iRunningDataLen + result.Length;

                        // Close and clean up the StreamReader
                        sr.Close();
                    }

                    // Process 'Continuation Packets'
                    if (iRunningDataLen < iTotalDataLen)
                    {
                        objResponse = (HttpWebResponse) objRequest.GetResponse();
                            // timeout throws exception, trapped at higer level.				}
                        using (sr = new StreamReader(objResponse.GetResponseStream()))
                        {
                            result = result + sr.ReadToEnd();
                            iRunningDataLen = iRunningDataLen + result.Length;

                            // Close and clean up the StreamReader
                            sr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                if (objResponse != null)
                {
                    objResponse.Close();
                }
            }
            return result;
        }
    }
}