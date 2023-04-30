using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FoldersCreater
{
    public static void CheckFolders()
    {
        if (!Directory.Exists($"{Application.persistentDataPath}/Info"))
        {
            Directory.CreateDirectory($"{Application.persistentDataPath}/Info");
        }
    }
}
