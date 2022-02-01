
using System;
using System.IO;
using _0xc0de_library;
using _0xc0de_library.INI;


namespace _0xc0de_loader
{
    public static class Loader
    {
       
        public static void Main(string[] args)
        {
            Config cfg = new Config();
            cfg.Load();
        }
    }

    public class Config
    {
        Library lib = new Library();
        Data _cd = new Data();
        public void Load()
        {

            CreateData();
            Check();

        }
        public void Check()
        {
            if(!File.Exists(_cd.PathIniFile) || !Directory.Exists(_cd.FolderName))
            {
               
                    lib._msg("Loader Config file or Loader Folder not exist");
                    CreateConfig();

            }
            else
            {
                lib._msg("Loader Config file loaded successfully ( " + _cd.PathIniFile + " )");
            }
        }

        public void CreateConfig()
        {
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(_cd.FolderName); //Create INI FILE
                lib._msg("Loader Directory successfully created ( " + _cd.FolderName + " )");
                try
                {
                    FileStream configStream = File.Create(_cd.PathIniFile); //Create INI FILE
                    configStream.Close();
                    lib._msg("Loader Config file successfully created ( " + _cd.PathIniFile + " )");
                }
                catch (Exception e)
                {
                    lib._msg("Error when try create Loader Config file  - " + e);
                }
            }
            catch (Exception e)
            {
                lib._msg("Error when try create Loader Folder  - " + e);
                
            }
          
            

            try
            {
                IniFile inif = new IniFile(_cd.PathIniFile);
                inif.Section(_cd.Section[0]).Set(_cd.Key0[0], _cd.Key1[0]);

               

                inif.Save(_cd.PathIniFile);

            }
            catch (Exception e)
            {
                lib._msg("Error when try insert DATA - " + e);
            }

        }

        public void CreateData()
        {
            _cd.FolderName = "Loader";
            _cd.FileName = "0xc0de_config.ini";
            _cd.PathIniFile = _cd.FolderName + "/" + _cd.FileName;

            _cd.Section[0] = "config_loader";
            _cd.Key0[0] = "Debug";
            _cd.Key1[0] = "false";
      
        }

        class Data
        {
            public string FolderName;
            public string FileName;
            public string PathIniFile;
            public string [] Section = new string[256];
            public string [] Key0 = new string[256];
            public string [] Key1 = new string[256];

        }

    }

    
}
