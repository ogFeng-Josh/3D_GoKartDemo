using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawner : MonoBehaviour
{
    public List<GameObject> karts = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       int randomNum = Random.Range(0, karts.Count);
        Debug.Log(randomNum);
       Instantiate(karts[randomNum], transform.position, transform.rotation);
    }
}
