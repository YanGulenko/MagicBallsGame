using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SettingsScript : MonoBehaviour
{
    public AudioSource click;
    public AudioSource gt;
    public Slider s1;
    public Slider s2;
   

    // Start is called before the first frame update
    void Start()
    {
        
            s1.value = MenuScript.sl1;
            s2.value = MenuScript.sl2;
    }
    private void Update()
    {
        gt.volume = s1.value;
        click.volume = s2.value;
    }
   
}
