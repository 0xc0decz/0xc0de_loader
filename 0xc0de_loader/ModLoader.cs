using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
                ModChecker();
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

        static void ModChecker()
        {
            int fileCount = Directory.GetFiles(Bridge._ModConfig.ModPath, "*.dll", SearchOption.TopDirectoryOnly)
                .Length;
   


            DirectoryInfo di = new DirectoryInfo(Bridge._ModConfig.ModPath);
            FileInfo[] files = di.GetFiles("*.dll");
            string str = "";
            foreach (FileInfo file in files)
            {
                Bridge._library._msg(file.Name);
                Assembly assembly = Assembly.LoadFile(file.Name);
                if (assembly != null)
                {

                    foreach (Attribute attr in Attribute.GetCustomAttributes(assembly))
                    {
                        if (attr.GetType() == typeof(AssemblyMod.ModIDAttribute))
                        {
                            Bridge._library._msg1("Assembly ModID is \"{0}\".",
                                ((AssemblyMod.ModIDAttribute) attr).Title);

                        }
                        else if (attr.GetType() == typeof(AssemblyMod.ModNameAttribute))
                        {
                            Bridge._library._msg1("Assembly Name is \"{0}\".",
                                ((AssemblyMod.ModNameAttribute) attr).Title);


                        }
                        else if (attr.GetType() == typeof(AssemblyMod.ModVersionAttribute))
                        {
                            Bridge._library._msg1("Assembly Version is \"{0}\".",
                                ((AssemblyMod.ModVersionAttribute)attr).Version);


                        }

                    }
                }


            }



           /* for (int i = 0; i < fileCount; i++)
            {
                Assembly assembly = Assembly.LoadFile(Bridge._ModConfig.ModPath + "")
            }*/

        }
      

    }


    public class ModConfig
    {
        public string ModFolder;
        public string ModPath;

    }
}
