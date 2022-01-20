using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float minSpeed, maxSpeed;
    public float rotationSpeed;
    public GameObject AsteroidExplosion;
    public GameObject PlayerExplosion;
    public float xSpread; //0..1
    Rigidbody asteroid;


    // Start is called before the first frame update
    void Start()
    {
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        var speed = Random.Range(minSpeed, maxSpeed);

        var xSpeed = speed * Random.Range(-xSpread, xSpread);

        asteroid.velocity = new Vector3(xSpeed, 0, -speed);

        asteroid.transform.localScale *= Random.Range(0.5f, 2.0f); //50%-200%

    }

    // Update is called once per frame
    void Update()
    {
        



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            return; // ������ �� ������
        }

        if (other.tag == "GameBoundary")
        {
            return; // ������ �� ������
        }


        if (other.tag == "Player")
        {
           
           Instantiate(PlayerExplosion, other.transform.position, Quaternion.identity); // �������� ������

        }

        Instantiate(AsteroidExplosion, transform.position, Quaternion.identity);

        Destroy(other.gameObject); // ����������� ���� � ��� �������� ����������
        Destroy(gameObject); // ����������� ���������


    }


}
