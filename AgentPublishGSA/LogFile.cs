using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AgentPublishGSA
{

    public class LogFile
    {
        private static LogFile log;
        public static LogFile Log
        {
            get
            {
                if (log == null)
                {
                    log = new LogFile();
                }
                return log;
            }
        }
        private string path = @"c:\temp\GSA\GSALog.txt";
        public LogFile()
        {
        }

        public void Write(String msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now).Append(" ").Append(msg);

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(sb.ToString());
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(sb.ToString());
                }
            }
        }


    }
}
