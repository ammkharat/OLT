using System.IO;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class StreamExtensions
    {
        public static void CopyStream(this Stream input, Stream output)
        {
            var buffer = new byte[16*1024];

            while (true)
            {
                var read = input.Read(buffer, 0, buffer.Length);
                if (read > 0)
                {
                    output.Write(buffer, 0, read);
                }
                else
                {
                    break;
                }
            }
        }
    }
}