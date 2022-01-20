using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossScript : MonoBehaviour
{
    public ParticleSystem bossEffect;
    public Image bossHP;
    public Transform playerTransform;
    private float bossHPmax = 1;
    public GameObject WinGameWindow;
    public GameObject WinEffects;
    public GameObject shot;
    [SerializeField, Range(0, 50)] private float timeDelay;
    private float realTime;
    void Start()
    {
        bossHP.fillAmount = bossHPmax;
        realTime = timeDelay;
    }
    void Update()
    {
        transform.LookAt(playerTransform); 
        if (bossHP.fillAmount == 0) 
        { 
            Destroy(gameObject);  
            bossEffect.Play();  
            WinGameWindow.SetActive(true); 
            WinEffects.SetActive(true); 
        }
    }
    private void FixedUpdate()
    {
        if (realTime <= 0) { realTime = timeDelay; }
        else { realTime = realTime - 1f; }
        if (realTime <= 0) { Instantiate(shot, transform.position, Quaternion.LookRotation(-transform.up, -transform.forward)); }
    }
    private void OnCollisionEnter(Collision collision)
    {    
        if (collision.gameObject.layer == 6) { bossHP.fillAmount = bossHP.fillAmount - 0.1f; }
    }
}
