using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public sealed  class LogToFile : ILog
    {
        
       private static readonly Lazy<LogToFile> log = new Lazy<LogToFile>(() => new LogToFile());
        private  LogToFile()
        {

            
        }
       
        public  static LogToFile GetInstance
        {
            get
            {
                return log.Value;
            }
            
        }
        public  void Log(Exception ex)
        {  

            string folderName = "LogFiles";
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + folderName;
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToString("dddd, dd MMMM yyyy"));


            string logFilePath = string.Format(@"{0}\{1}", fullPath, fileName);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("---------------------------------");
            stringBuilder.AppendLine(DateTime.Now.ToString());
            stringBuilder.AppendLine(ex.Message);
            if (!Directory.Exists(fullPath)) { Directory.CreateDirectory(fullPath); }
            using (StreamWriter writer = new StreamWriter(logFilePath))
            {
                writer.Write(stringBuilder.ToString());
                writer.Flush();
            }

        } 
    }
}
