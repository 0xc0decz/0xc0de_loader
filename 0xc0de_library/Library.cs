using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using _0xc0de_library.AssemblyMod;


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

        public void _msg1(string format, object arg0 , object arg1 = null, object arg2 = null , object arg3 = null)
        {
            using (TextWriter tw = File.AppendText("Loader/Log.txt"))
            {
                format = String.Format(format, arg0,arg1,arg2,arg3);
                tw.WriteLine(format);
                //tw.Flush();
            }
        }
       

    }

     
}