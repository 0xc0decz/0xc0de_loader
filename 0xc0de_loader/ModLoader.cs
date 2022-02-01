using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using _0xc0de_library;

namespace _0xc0de_loader
{
    public class ModLoader
    {
      
        public void Load()
        {
            Bridge._library._msg("ModLoader successfully Load");
            ModConfigInit();
            Check();
        }
        public void ModConfigInit()
        {
            Bridge._ModConfig.ModFolder = "Mods";
            Bridge._ModConfig.ModPath = "Loader/" + Bridge._ModConfig.ModFolder;
        }

        static void Check()
        {
          
            if (!Directory.Exists(Bridge._ModConfig.ModPath))
            {
                Bridge._config.lib._msg("Mods Folder not exists - " + Bridge._ModConfig.ModPath);
                FolderCreate();
              
            }
            else
            {
                string[] dllsFiles = Directory.GetFiles(Bridge._ModConfig.ModPath, " *.dll");
                int fileCount = Directory.GetFiles(Bridge._ModConfig.ModPath, "*.dll", SearchOption.TopDirectoryOnly)
                    .Length;
                Bridge._library._msg("Mods in Folder : " + fileCount);
            }
            
            
        }

        static void FolderCreate()
        {
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(Bridge._ModConfig.ModPath);
                Bridge._library._msg("Mods Directory successfully created ( " + Bridge._ModConfig.ModFolder + " )");
            }
            catch (Exception e)
            {
                Bridge._library._msg("Error when try create Mods Folder  - " + e);
                
            }
           
        }
      

    }


    public class ModConfig
    {
        public string ModFolder;
        public string ModPath;

    }
}
