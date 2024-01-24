using System;
using System.IO;
using System.Net;
using System.Text;

namespace TestTool
{

	/// <summary>
	/// Support Class providing programatic http post support.
	/// </summary>
	public class Submit
	{
        /// <summary>
        /// Perform a http post to the specified URL
        /// </summary>
        /// <param name="postData">Data to post to the URL</param>
        /// <param name="strTargetUrl">Destination URL</param>
        /// <returns>A string containing the HTTP response data</returns>
		public static string SyncSubmit(string postData, string strTargetUrl)
		{
            String result = string.Empty;
            String strPost = postData; //URLEncode(PostData);
      
			HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(strTargetUrl);
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
                if(myWriter != null)
				    myWriter.Close();
			}

            try
            {
                int iRunningDataLen = 0;

                objRequest.Timeout = 180000;		// 3 mins
                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse(); // timeout throws exception, trapped at higer level.

                int iTotalDataLen = (int)objResponse.ContentLength;

                while (iRunningDataLen < iTotalDataLen)
                {
                    StreamReader sr;
                    using (sr = new StreamReader(objResponse.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                        iRunningDataLen = iRunningDataLen + result.Length;
                    }

                    // Process 'Continuation Packets'
                    if (iRunningDataLen < iTotalDataLen)
                    {
                        objResponse = (HttpWebResponse)objRequest.GetResponse(); // timeout throws exception, trapped at higer level.				}
                        using (sr = new StreamReader(objResponse.GetResponseStream()))
                        {
                            result = result + sr.ReadToEnd();
                            iRunningDataLen = iRunningDataLen + result.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

			return result;
		}
	}
}