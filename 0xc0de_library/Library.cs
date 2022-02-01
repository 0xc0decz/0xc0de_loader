using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _0xc0de_library
{
    public class Library
    {
        public string GetTime()
        {
            DateTime time = DateTime.Now;
            string format = "HH:mm:ss";
            return time.ToString(format);
        }
        public void _msg(string line , string filename = null)
        {

            if (filename != null)
            {
                using (TextWriter tw = File.AppendText("Loader/" + filename))
                {
                    tw.WriteLine("[ " + GetTime() + " ] " + "0xc0de_LOG : " + line);
                    //tw.Flush();
                }
            }
            else
            {
                using (TextWriter tw = File.AppendText("Loader/Log.txt"))
                {
                    tw.WriteLine("[ " + GetTime() + " ] " + "0xc0de_LOG : " + line);
                    //tw.Flush();
                }
            }
            
        }

    }

     
}