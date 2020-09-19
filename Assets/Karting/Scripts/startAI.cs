using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class startAI : MonoBehaviour
{
    GameObject[] AIKarts;

    public void AIStart()
    {
        AIKarts = GameObject.FindGameObjectsWithTag("AIKart");
        foreach (GameObject kart in AIKarts)
        {
            kart.GetComponent<CarAIControl>().enabled = true;
        }
    }
}
