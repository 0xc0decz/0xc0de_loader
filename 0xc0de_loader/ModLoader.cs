using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using _0xc0de_library.AssemblyMod;

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
                int fileCount = Directory.GetFiles(Bridge._ModConfig.ModPath, "*.dll", SearchOption.TopDirectoryOnly)
                    .Length;
                Bridge._library._msg("Mods in Folder : " + fileCount);
                ModChecker();
                
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
            string str2 = "";
            string str3 = "";
            string str4 = "";
            foreach (FileInfo file in files)
            {
                //Bridge._library._msg(file.Name);
                Assembly assembly = Assembly.LoadFile(file.Name);
                
                if (assembly != null)
                {
                    
                    foreach (Attribute attr in Attribute.GetCustomAttributes(assembly))
                    {
                       
                        if (attr.GetType() == typeof(ModIDAttribute))
                        {
                          //  Bridge._library._msg("ModID : " + ((ModIDAttribute)attr).Title);
                          str2 = ((ModIDAttribute)attr).Title;

                        }
                        else if (attr.GetType() == typeof(ModNameAttribute))
                        {
                            //Bridge._library._msg("ModID : " + ((ModNameAttribute)attr).Title);
                           str3 = ((ModNameAttribute)attr).Title;


                        }
                        else if (attr.GetType() == typeof(ModVersionAttribute))
                        {
                            //Bridge._library._msg("ModID : " + ((ModVersionAttribute)attr).Version);
                            str4 = ((ModVersionAttribute)attr).Version;


                        }

                        

                    }
                    Bridge._library._msg("[ MODID : " + str2 + " ][ MODNAME : " + str3 + " ][ VERSION : " + str4 + " ]");
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
