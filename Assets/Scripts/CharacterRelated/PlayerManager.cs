using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : MonoBehaviour {

    public GameObject playerPrefab;

    [SyncVar] int playerCount;

    public List<GameObject> playerObjs = new List<GameObject>();

    bool pk = false;
    bool p1 = false;
    bool p2 = false;
    bool p3 = false;
    bool p4 = false;

    GameObject cam;
    int camCheck = 0;

	// Use this for initialization
	void Start ()
    {
        // Called when the object first is initialized
        Debug.Log("PlayerManagerStart");
    }

    // Update is called once per frame
    void Update () {}
}