using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shotScript : MonoBehaviour
{
    
    private Rigidbody shotBody;
    [SerializeField, Range(0, 10)] private float shotSpeed;
    private void Start()
    {
        shotBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        shotBody.AddRelativeForce(-Vector3.up * shotSpeed, ForceMode.VelocityChange);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ShotZone")) { Destroy(gameObject); }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy")) { Destroy(gameObject); }
        if (collision.gameObject.CompareTag("Player")) { Destroy(gameObject); }
        if (collision.gameObject.CompareTag("plane")) { Destroy(gameObject); }
    }

}
