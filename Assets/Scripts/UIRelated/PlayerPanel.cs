using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanel : MonoBehaviour
{
    private bool loadSaveNewMask = true;
    private bool maskLoad = false;
    private bool maskSave = false;
    private bool maskNew = false;
    [SerializeField] private GameObject lSNM, load, save, nnew;

    public SaveManager saveManager;

    // Start is called before the first frame update
    void Start()
    {
        //foreach file in XX
       // {
       //     SaveManager.Load()
       // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mLoad()
    {
        if(load.activeSelf)
        {
            lSNM.SetActive(true);
            load.SetActive(false);
        }
        else
        {
            load.SetActive(true);
            lSNM.SetActive(false);
        } 
    }

    public void mSave()
    {
        if(save.activeSelf)
        {
            lSNM.SetActive(true);
            save.SetActive(false);
        }
        else
        {
            save.SetActive(true);
            lSNM.SetActive(false);
        } 
    }

    public void mNew()
    {
        if(nnew.activeSelf)
        {
            lSNM.SetActive(true);
            nnew.SetActive(false);
        }
        else
        {
            nnew.SetActive(true);
            lSNM.SetActive(false);
        } 
    }
}
