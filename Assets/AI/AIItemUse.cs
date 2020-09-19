using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class AIItemUse : MonoBehaviour
{
    public bool holdingItem = false;
    public int itemID = 0;
    public GameObject banana;
    public GameObject shell;
    public Transform shellSpawnPoint;
    public MultiplicativeKartModifier boostStats;
    [Range(0, 5)]
    public float duration = 1f;
    public float distance;
    private KartMovement kart;
    // Start is called before the first frame update
    void Start()
    {
        kart = GetComponent<KartMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(itemID)
        {
            case 0: //no item
                break;
            case 1: //mushroom
                //use immediately
                Debug.Log("Mushroom Used!");
                itemID = 0;
                holdingItem = false;
                kart.StartCoroutine(KartModifier(kart, duration));
                break;
            case 2: //banana
                //throw immediately
                Debug.Log("Banana Used!");
                Instantiate(banana, transform.position - transform.forward * distance, transform.rotation);
                holdingItem = false;
                itemID = 0;
                break;
            case 3: //shell
                //send out raycast to search for nearby karts. if kart is in line of shell, throw shell.
                
                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red,2);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f))
                {
                    if (hit.transform.gameObject.tag == "Kart" || hit.transform.gameObject.tag == "AIKart")
                    {
                        Instantiate(shell, shellSpawnPoint);
                        holdingItem = false;
                        itemID = 0;
                    }
                }

                break;
            default:
                break;
        }
    }

    IEnumerator KartModifier(KartGame.KartSystems.KartMovement kart, float lifetime)
    {
        kart.AddKartModifier(boostStats);
        yield return new WaitForSeconds(lifetime);
        kart.RemoveKartModifier(boostStats);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUpBox") && !holdingItem)
        {
            itemID = UnityEngine.Random.Range(1, 4); //minimum, maximum number of powerups : 0 = nothing, 1 = mushroom, 2 = banana, 3 = shell
            Debug.Log(gameObject.name + " picked up item.");
            holdingItem = true;
            other.gameObject.GetComponent<RespawnPickUpBox>().DestroyBox();
        }
    }

}
