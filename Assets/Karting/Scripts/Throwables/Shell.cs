using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 40.0f;
    public int timeToLive = 5;
    public ParticleSystem destroyEvent;
    GameObject hitKart;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        Invoke("DestroyShell", timeToLive);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Kart" || collision.gameObject.tag == "AIKart")
        {
            hitKart = collision.gameObject;
            DestroyShell();
            freezeKart();
            Invoke("unfreezeKart", 1);
        }
    }

    void freezeKart()
    {
        Rigidbody kartRB = hitKart.GetComponent<Rigidbody>();
        kartRB.velocity = Vector3.zero;
        kartRB.constraints = RigidbodyConstraints.FreezeAll;
    }
    void unfreezeKart()
    {
        Rigidbody kartRB = hitKart.GetComponent<Rigidbody>();
        kartRB.constraints = RigidbodyConstraints.None;
    }

    void DestroyShell()
    {
        rb.velocity = Vector3.zero;
        rb.freezeRotation = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        destroyEvent.Play();
        Invoke("deleteObject", destroyEvent.duration);
    }

    void deleteObject()
    {
        Destroy(gameObject);
    }
}
