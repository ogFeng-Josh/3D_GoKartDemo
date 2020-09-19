using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPickUpBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyBox()
    {
        gameObject.SetActive(false);
        Invoke("SpawnBox", 5);
    }

    public void SpawnBox()
    {
        gameObject.SetActive(true);
    }
}
