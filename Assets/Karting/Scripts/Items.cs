using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using KartGame.KartSystems;
using UnityEngine.Audio;


public class Items : MonoBehaviour
{
    public GameObject mushroomIcon, bananaIcon, shellIcon;
    public bool holdingItem = false;
    private int itemID = 0;
    public GameObject banana;
    public MultiplicativeKartModifier boostStats;
    [Range (0, 5)]
    public float duration = 1f;
    public float distance;
    private KartMovement kart; // gets the script for the player's kart to motify speed
    // Start is called before the first frame update

    public AudioSource shellSound;
    public AudioSource itemPickup;
    public AudioSource bananaSplat;

    


    void Start()
    {
      mushroomIcon.SetActive(false);
      bananaIcon.SetActive(false);
      shellIcon.SetActive(false);
      kart = GetComponent<KartMovement>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.RightShift)) // button to use the Items
      {
        UsePowerUp(itemID);
      }
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.CompareTag("PickUpBox") && !holdingItem)
      {
        itemID = UnityEngine.Random.Range(1,4); //minimum, maximum number of powerups : 0 = nothing, 1 = mushroom, 2 = banana, 3 = shell
        Debug.Log("Picked up item");
        PlayItemPickup();
        holdingItem = true;
        if(itemID == 1)
        {
          mushroomIcon.SetActive(true);
        }
        else if(itemID == 2)
        {
          bananaIcon.SetActive(true);
        }
        else if(itemID == 3)
        {
          shellIcon.SetActive(true);
        }
      }
    }


    void UsePowerUp(int item)
    {
      if(item == 0)
      {
        Debug.Log("no power up collected");
      }
      else if(item == 1)
      {
        GetMushroom();
        Debug.Log("used the mushroom");
        itemID = 0;
        holdingItem = false;
        mushroomIcon.SetActive(false);
      }
      else if(item == 2)
      {
        GetBanana();
        Debug.Log("used the banana");
        itemID = 0;
        holdingItem = false;
        bananaIcon.SetActive(false);
      }
      else if(item == 3)
      {
        GetShell();
        Debug.Log("used the shell");
        PlayShell();
        itemID = 0;
        holdingItem = false;
        shellIcon.SetActive(false);
      }
    }

    void GetMushroom()
    {
      // increase the players speed for a few seconds
      kart.StartCoroutine(KartModifier(kart, duration));
    }

    IEnumerator KartModifier(KartGame.KartSystems.KartMovement kart, float lifetime)
    {
        kart.AddKartModifier(boostStats);
        yield return new WaitForSeconds(lifetime);
        kart.RemoveKartModifier(boostStats);
    }

    void GetBanana()
    {
      Instantiate(banana, transform.position - transform.forward * distance, transform.rotation);
        
      //create bana on track behind where the player is
    }

    void GetShell()
    {
        //Inster your code here
    }

    void PlayShell() //play sound effect when shell is shot 
    {
        shellSound.Stop();
        shellSound.Play();
    }

    void PlayItemPickup() //play sound effect when item is picked up
    {
        itemPickup.Stop();
        itemPickup.Play();
    }

    void PlayBanana() //play sound effect when item is picked up
    {
        bananaSplat.Stop();
        bananaSplat.Play();
    }

}
