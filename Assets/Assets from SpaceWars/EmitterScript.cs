using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject[] asteroid = new GameObject[3];

    public float launchDelay;
    float nextLaunchTime;


    // Update is called once per frame
    void Update()
    {
        var Asteroid = asteroid[Random.Range(0, asteroid.Length)];
        //GameObject Asteroid = Random.Range (asteroid[3]);

        if (Time.time > nextLaunchTime)
        {
            var shiftX = Random.Range(-transform.localScale.x/2 , transform.localScale.x / 2); // точка вылета астероидов
            var position = transform.position + new Vector3(shiftX, 0, 0);
            Instantiate(Asteroid, position, Quaternion.identity);
            nextLaunchTime = Time.time + launchDelay;

        }


    }
}
