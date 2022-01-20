using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinActSript : MonoBehaviour
{
    public ParticleSystem effect;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        effect.Play();
        Destroy(gameObject.transform.GetChild(0).gameObject);
        Destroy(gameObject, 0.5f);
    }
}
