using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Developer
{
    [MenuItem("Developers/ClearSaves")]

    public static void ClearSaves()
    {
        PlayerPrefs.DeleteAll();
        //
        Debug.Log("All saves has been cleared");
    }
}
