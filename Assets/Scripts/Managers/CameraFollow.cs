using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour {

    //Use to visualize the center of the camera
    [SerializeField] UIManager uiManager;

    public List<Player> Players = new List<Player>();
    private Vector3 average = Vector3.zero;
    private Vector3 meanPlayerPosition = new Vector3(0, 0, -20);
  
    private Vector3 tempMin = new Vector3(0, 0, -10);
    private Vector3 tempMax = new Vector3(0, 0, -10);
    private float meanX = 0, meanY = 0, p = 0;
    [SerializeField] private float targetZoom;
    [SerializeField] private float zoomFactor = 0.001f;
    [SerializeField] private float zoomLerpSpeed = .030f;
    [SerializeField] int cameraMargin;
    /// <summary>
    /// The minimum and maximum value of the camera
    /// </summary>
    private float xMax, xMin, yMin, yMax;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Camera cam = Camera.main;

        targetZoom = cam.orthographicSize;
        cam.orthographicSize = 10;
    }



    private void LateUpdate()
    {
        Camera cam = Camera.main;
        //average player position 
        average = Vector3.zero;
        for (int i = 0; i < Players.Count; i++)
        {
            average += Players[i].transform.position;
            
        }

        if (Players.Count >= 1)
        {
            average.x = average.x / Players.Count;
            average.y = average.y / Players.Count;
            average.z = -20; //average.z/targets.Count;
        }

        

        //Debug.Log(Vector3.Cross(average,new Vector3 (0,1,0)).z);

        //Changes camera position to average player posittion 
        transform.position = average;

 
        switch (Players.Count)
        {
            
            case 1:
                tempMin = average;
                tempMax = average;
                break;
            case 2:
                tempMin = (Vector3.Min(Players[0].transform.position, Players[1].transform.position));
                tempMax = (Vector3.Max(Players[0].transform.position, Players[1].transform.position));
                break;
            case 3:
                tempMin = (Vector3.Min(Players[0].transform.position, Players[1].transform.position));
                tempMin = (Vector3.Min(tempMin, Players[2].transform.position));
                tempMax = (Vector3.Max(Players[0].transform.position, Players[1].transform.position));
                tempMax = (Vector3.Max(tempMax, Players[2].transform.position));

                break;
            case 4:
                tempMin = (Vector3.Min(Players[0].transform.position, Players[1].transform.position));
                tempMin = (Vector3.Min(tempMin, Players[2].transform.position));
                tempMin = (Vector3.Min(tempMin, Players[3].transform.position));
                tempMax = (Vector3.Max(Players[0].transform.position, Players[1].transform.position));
                tempMax = (Vector3.Max(tempMax, Players[2].transform.position));
                tempMax = (Vector3.Max(tempMax, Players[3].transform.position));

                defaullt:
                tempMin = new Vector3(400, 300, 200);
                tempMax = new Vector3(400, 300, 200);
                break;
        }


        //Variables for the most extreme active players
       
        xMin = tempMin.x - cameraMargin;

        yMin = tempMin.y - cameraMargin;

        xMax = tempMax.x + cameraMargin;

        yMax = tempMax.y + cameraMargin;


        //Once players are more than VAR units away from eachother, scroll data turns positive 
        int VAR = 7;
        float scrollData;
        scrollData = ((Mathf.Max((Mathf.Abs(yMax - yMin)), (Mathf.Abs(xMax - xMin)))) - VAR);
        //scrollData = 1;

        //Zoom factor determined upstairs
        targetZoom = scrollData * Mathf.Abs(Vector3.Cross(average, new Vector3(0, 1, 0)).z);
  

        //MIN MAX zooms for the camera
        targetZoom = Mathf.Clamp(targetZoom, 10.8f, 16.2f);

        //Chaning the actual zoom size
        //Debug.Log(cam.orthographicSize + " " + targetZoom + " " + Time.deltaTime + " " + zoomLerpSpeed);
      
            cam.orthographicSize = 10;
       

       cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);

      

    }        
}