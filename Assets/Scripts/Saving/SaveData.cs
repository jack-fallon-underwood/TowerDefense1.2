using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using UnityEngine.UI;


public class SaveData
{   
    public bool InUse;
    public string CharacterName = "";
    public string instrument;

    public int endurance;
    public int maxHealth;
    public int physicalDmg;
    public int magicDmg;
    public int attackSpd;
    private int helmetD;
    private int shieldD;
    private int bootsD;
    private float movementSpd;
    private Stat exp3;
    public int MyLevel;
}

[Serializable] 
public class PlayerData
{
    public int MyLevel {get; set;}

    //public PlayerData(int level)
    //{
    //    this.MyLevel = level;
    //}
}
