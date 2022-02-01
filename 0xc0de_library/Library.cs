﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

        public void _msg(string line, string filename = null)
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

        public void CreateDir(string path , string foldername)
        {
            var di = Directory.CreateDirectory(path + "/" + foldername);
        }

        public int GetAllFile(string path, string name = null, string ext = null)
        {
            int fileCount = 0;
            if (name != null && ext == null)
            {
                fileCount = Directory.GetFiles(path, name + ".dll", SearchOption.TopDirectoryOnly)
                    .Length;
            }

            if (name == null && ext != null)
            {
                fileCount = Directory.GetFiles(path,  "*." + ext, SearchOption.TopDirectoryOnly)
                    .Length;
            }

            if (name != null && ext != null)
            {
                fileCount = Directory.GetFiles(path, name + "." + ext, SearchOption.TopDirectoryOnly)
                    .Length;
            }

            if (name == null && ext == null)
            {
                fileCount = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
                    .Length;
            }


            return fileCount;
        }




    }

    public class Libs
    {

        Library library = new Library();
        public void Init()
        {
            Load();
        }

        public void Load()
        {
            LibsDirectory = "Loader/Libs/";
           CheckLibs();
            GetLibs();
        }

        public void GetLibs()
        {
            var di = new DirectoryInfo(LibsDirectory);
            var files = di.GetFiles("*.dll");
            foreach (var file in files)
            {
                //Bridge._library._msg(file.Name);
                var assembly = Assembly.LoadFile(LibsDirectory + file.Name);

                if (assembly != null)
                {
                    
                }

            }
        }

        public string LibsDirectory { get; set; }

        public void CheckLibs()
        {
            if (!Directory.Exists(LibsDirectory))
            {
                
                library._msg("Libs Folder not exists - " + LibsDirectory);
                CreateLibs();
            }
        }

        public void CreateLibs()
        {
            try
            {
                var di = Directory.CreateDirectory(LibsDirectory);
                library._msg("Libs Directory successfully created ( " + LibsDirectory + " )");
            }
            catch (Exception e)
            {
                library._msg("Error when try create Libs Folder  - " + e);
            }
        }

    }
}