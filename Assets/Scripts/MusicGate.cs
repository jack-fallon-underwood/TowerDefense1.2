using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGate : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource lastSource;

    [SerializeField] private AudioClip LastClip;
    public float differnece;
    [SerializeField] bool startingArea = false;

    // Start is called before the first frame update
    void Awake()
    {
      //LastClip = lastSource.GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if((other.tag == "Player") && !startingArea)
        {
            differnece = LastClip.length - lastSource.time;
            lastSource.loop = false; //i have the first gate false looping the old sound manager
           // Debug.Log(Part1.length);
            //Debug.Log(lastSource.time);
            audioSource.PlayDelayed(differnece);
          

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
