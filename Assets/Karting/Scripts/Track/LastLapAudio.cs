using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.Track;

//Require a box collider as this uses on trigger enter...
[RequireComponent(typeof(BoxCollider))]
public class LastLapAudio : MonoBehaviour
{
    private TrackManager tm;
    private bool hasRan = false;
    private int lapCounter = 0;
    public GameObject normalMusic;
    public GameObject lastLapMusic;


    private void Start()
    {
        //Find and set trackmanager so we can compare the players current lap to total laps in the race
        tm = GameObject.FindGameObjectWithTag("TrackManager").GetComponent<TrackManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Check to see if this trigger has ran- it should only run once
        if (!hasRan)
        {
            //Check tag of other object to make sure it's a player...
            if (other.CompareTag("Player"))
            {
                //Compare the players internal lap tracking to the total number of laps on the track manager
                if (tm.raceLapTotal == other.GetComponent<IRacer>().GetCurrentLap())
                {
                    //Turn off normal music
                    normalMusic.SetActive(false);
                    //Turn on final lap music
                    lastLapMusic.SetActive(true);
                    //Set has ran to true
                    hasRan = true;
                }
            }
        }
    }
}
