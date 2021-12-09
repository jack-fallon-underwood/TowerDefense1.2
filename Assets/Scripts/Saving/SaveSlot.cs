using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlot : MonoBehaviour
{

    public SaveData saveFile;
    private static int saveSlot;

    private string file1 = "slot1.txt";
    private string file2 = "slot2.txt";
    private string file3 = "slot3.txt";
    private string file4 = "slot4.txt";
    private string file5 = "slot5.txt";
    private string file6 = "slot6.txt";
    private string file7 = "slot7.txt";
    private string file8 = "slot8.txt";

    // Start is called before the first frame update
    void Start()
    {
        saveSlot = 1 + transform.GetSiblingIndex();
        switch(saveSlot)
        {
            case 1: SaveManager.Load("slot1.txt");
                break;
            case 2: SaveManager.Load("slot2.txt");
                break;
            case 3: SaveManager.Load("slot3.txt");
                break;
            case 4: SaveManager.Load("slot4.txt");
                break;
            case 5: SaveManager.Load("slot5.txt");
                break;
            case 6: SaveManager.Load("slot6.txt");
                break;
            case 7: SaveManager.Load("slot7.txt");
                break;
            case 8: SaveManager.Load("slot8.txt");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool GetSaveDataInUse()
    {
        return saveFile.InUse;
    }

    public string GetSaveDataName()
    {
        return saveFile.CharacterName;
    }

}
