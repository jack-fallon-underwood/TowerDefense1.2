using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour {

    //Use to visualize the center of the camera
    [SerializeField] GameObject MEDIUM;
    [SerializeField] UIManager uiManager;
    private List<Vector3> targets = new List<Vector3>();

    private Vector3 average = Vector3.zero;
 

    
    private Vector3 meanPlayerPosition = new Vector3(0,0,-10);
    private Vector3 meanPlayerPotFlower = new Vector3(0,0,0); //variable for debugging
    private Vector3 tempMin = new Vector3 (0,0,-10);
    private Vector3 tempMax = new Vector3 (0,0,-10);

    private float meanX=0, meanY=0, p=0;

    [SerializeField] private GameObject[] Players;

    private List<GameObject> pooledPlayers = new List<GameObject>();

    //Count players and puts them in your equations 
    int playerCount = 0;
    public int NetObject()
    {
      
        foreach (GameObject dude in Players)
        {
            if(dude.activeInHierarchy)
            {
                pooledPlayers.Add(dude);
                playerCount++;
            }
        }
        return playerCount;
    }


    private float targetZoom;
    private float zoomFactor = 0.1f;
    [SerializeField] private float zoomLerpSpeed = 3.0f;

    /// <summary>
    /// The camera's target in our case it s the player
    /// </summary> OUTDATED
    private Transform target;

    /// <summary>
    /// The minimum and maximum value of the camera
    /// </summary>
    private float xMax, xMin, yMin, yMax;

    /// <summary>
    /// A reference to the ground tilemap
    /// </summary>
  //  [SerializeField]
    //private Tilemap tilemap;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
        Camera cam = Camera.main;
        target = cam.transform;
        targetZoom = cam.orthographicSize;
        cam.orthographicSize = 10;

        //Count players and puts them in your equations 
        NetObject();
        
    
        //Calculates the min and max postion, legacy code
      //  Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
      //  Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);


      targets.Add(GameObject.FindGameObjectWithTag("Player").transform.position);


       

	}

    private void LateUpdate()
    {
        average = Vector3.zero;

        targets.Clear();

    targets.Add(GameObject.FindGameObjectWithTag("Player").transform.position);
    
    /*if(uiManager.BossBattle == true){
    targets.Add(GameObject.FindGameObjectWithTag("Enemy/Boss").transform.position);
    }*/

        for (int i = 0; i < targets.Count; i++)
        {
            average += targets[i];


        }

        average.x = average.x/targets.Count;
        average.y = average.y/targets.Count;
        average.z = -20; //average.z/targets.Count;


        
        //Debug.Log(Vector3.Cross(average,new Vector3 (0,1,0)).z);


        Camera cam = Camera.main;
        
        //Find and puts the camera transform at the average center of all players
        AveragePlayerPositions(pooledPlayers);

        //Changes camera position to average player posittion
        //transform.position = meanPlayerPosition;
        
        transform.position = average;
    

        //Changes camera position tracker, for debuging
        //MEDIUM.transform.position = meanPlayerPotFlower;

        //Variables for the most extreme active players
        int cameraMargin = 5;
        xMin = MinPlayerPosition(pooledPlayers).x +cameraMargin;
   
        yMin = MinPlayerPosition(pooledPlayers).y +cameraMargin;

        xMax = MaxPlayerPosition(pooledPlayers).x +cameraMargin;
        
        yMax = MaxPlayerPosition(pooledPlayers).y +cameraMargin;


        //Once players are more than VAR units away from eachother, scroll data turns positive 
        int VAR = 5;
        float scrollData;
        scrollData = ( (Mathf.Max((Mathf.Abs(yMax-yMin)),(Mathf.Abs(xMax-xMin)))) - VAR);
        scrollData = 1;
        


        //Zoom factor determined upstairs
        targetZoom = scrollData * Mathf.Abs(Vector3.Cross(average,new Vector3 (0,1,0)).z);
       // Debug.Log("tragetzoom"+targetZoom);
  
        //MIN MAX zooms for the camera
        targetZoom = Mathf.Clamp(targetZoom, 7.08f, 20f);

        //Chaning the actual zoom size
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);



        //Makes sure the camera doesn't go further than our players
        //transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), -10);

    }

   

    private Vector3 AveragePlayerPositions(List <GameObject> couch)
    {
        p = 0;
        meanX = 0;
        meanY = 0;
        foreach (GameObject gamer in couch)
        {
           
            p++;

            meanX=meanX+gamer.transform.position.x;
            meanY=meanY+gamer.transform.position.y;

        }
        meanX=meanX/p;
        meanY=meanY/p;
        meanPlayerPosition = new Vector3(meanX,meanY,-10);
        meanPlayerPotFlower = new Vector3(meanX,meanY,0);
        return meanPlayerPosition;
    }

    private Vector3 MinPlayerPosition(List <GameObject> couch)
    {
        if (playerCount >= 1)
        {
            if (playerCount >= 2)
            {
                tempMin = (Vector3.Min(couch[0].transform.position,couch[1].transform.position));
                
                if (playerCount >= 3)
                {
                    tempMin = (Vector3.Min(tempMin,couch[2].transform.position));
                    
                    if (playerCount == 4)
                    {
                        tempMin = (Vector3.Min(tempMin,couch[3].transform.position));
                      
                        return tempMin;
                    }
                    return tempMin;
                }
                return tempMin;
            }
            return couch[0].transform.position;
        }
        return meanPlayerPosition;
    }

    private Vector3 MaxPlayerPosition(List <GameObject> couch)
    {
        if (playerCount >= 1)
        {
            if (playerCount >= 2)
            {
                tempMax = (Vector3.Max(couch[0].transform.position,couch[1].transform.position));

                if (playerCount >= 3)
                {
                    tempMax = (Vector3.Max(tempMax,couch[2].transform.position));

                    if (playerCount >= 4)
                    {
                        tempMax = (Vector3.Max(tempMax,couch[3].transform.position));
                        return tempMax;
                    }
                    return tempMax;
                }
                return tempMax;
            }
            return couch[0].transform.position;
        }
        return meanPlayerPosition;
    }


}
