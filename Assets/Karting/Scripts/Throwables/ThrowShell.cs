using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ThrowShell : MonoBehaviour
{
    public AudioSource shellSound;
    public GameObject shell;
    public Transform spawnPoint;
    public KeyCode keyBind = KeyCode.Space;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyBind))
        {
            Instantiate(shell, spawnPoint);
            shellSound.Play();
        }
    }
}
