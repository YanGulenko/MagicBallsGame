using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipscript : MonoBehaviour
{
    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;
    public GameObject Laser; //Снаряд
    public GameObject laserGun; //Точка, с которой будут отправляться снаряды\
    public GameObject laserGun1;
    public GameObject laserGun2;
    public float shotDelay; // кулдаун выстрела


    Rigidbody ship;
    float nextShotTime;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float correctX = Mathf.Clamp(ship.position.x, xMin, xMax);
        float correctZ = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(correctX, 0, correctZ);

        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);

        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {

            Laser.transform.localScale = new Vector3(1f, 1f, 1f);
            Instantiate(Laser, laserGun.transform.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }

        if (Time.time > nextShotTime && Input.GetButton("Fire2"))
        {

            Laser.transform.localScale = new Vector3(-0.4f, -0.4f, -0.4f);
           Instantiate(Laser, laserGun1.transform.position, Quaternion.Euler(0, 45, 0)); 
            Laser.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
           Instantiate(Laser, laserGun2.transform.position, Quaternion.Euler(0, -45, 0)); 
            nextShotTime = Time.time + shotDelay / 2;
        }


    }
}
   
