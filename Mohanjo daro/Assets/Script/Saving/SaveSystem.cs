using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem 
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/save/";

    public static void Init()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }
    public static void save(string savestring)
    {
        int savenumber = 1;
        while(File.Exists(SAVE_FOLDER +"save_" +savenumber+ ".txt"))
        { savenumber++; }
        File.WriteAllText(SAVE_FOLDER + "save_"+ savenumber+ ".txt", savestring); 
    }
    public static string load()
    {

        DirectoryInfo directoryInfo=new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] savefile = directoryInfo.GetFiles();
        FileInfo mostrecentfile = null;
        foreach(FileInfo files in savefile)
        {
            if (mostrecentfile == null)
            {
                mostrecentfile = files;
            }
            else
            {
                if (files.LastWriteTime > mostrecentfile.LastWriteTime)
                {
                    mostrecentfile = files;
                }
            }
          
        }

        if(mostrecentfile!=null)
        {
            string savestring = File.ReadAllText(mostrecentfile.FullName);
            return savestring;
        }
        else { return null; }

        //if (File.Exists(SAVE_FOLDER + "save.txt")){
        //    string savestring = File.ReadAllText(SAVE_FOLDER + "save.txt");
        //    return savestring;
        //}else{
        //    return null;
        //}
    }
}
