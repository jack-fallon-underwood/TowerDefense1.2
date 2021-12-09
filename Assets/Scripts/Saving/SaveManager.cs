using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{
    public GameObject SaveSlot1, SaveSlot2, SaveSlot3, SaveSlot4, SaveSlot5, SaveSlot6, SaveSlot7, SaveSlot8;
    public void Awake()
    {
        //SaveSlot1 = GameObject.Find("SaveSlot01");
        //SaveSlot2 = GameObject.Find("SaveSlot02");
        //SaveSlot3 = GameObject.Find("SaveSlot03");
        //SaveSlot4 = GameObject.Find("SaveSlot04");
        //SaveSlot5 = GameObject.Find("SaveSlot05");
        //SaveSlot6 = GameObject.Find("SaveSlot06");
        //SaveSlot7 = GameObject.Find("SaveSlot07");
        //SaveSlot8 = GameObject.Find("SaveSlot08");
    }
    


    public static SaveData data;

    private string file1 = "slot1.txt";
    private string file2 = "slot2.txt";
    private string file3 = "slot3.txt";
    private string file4 = "slot4.txt";
    private string file5 = "slot5.txt";
    private string file6 = "slot6.txt";
    private string file7 = "slot7.txt";
    private string file8 = "slot8.txt";


    public void Save(string file)
    {
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);
    }

    public static void Load(string file)
    {
        data = new SaveData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }

    public void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName); 
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using(StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private static string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if(File.Exists(path))
        {
            using(StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
            Debug.LogWarning("File not found!");
        
        return "";
    }

    private static string GetFilePath (string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}
