using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimChange : MonoBehaviour
{

    public Animator animator;
    private int animIndex;
    private int animIndexChun;
    
    private void ChangeAnim()
    {
        animIndex = Random.Range(0, 3);
        animator.SetInteger("state", animIndex);
    
    }
    private void ChangeAnimChun()
    {
        animIndexChun = Random.Range(0, 2);
        animator.SetInteger("stateChun", animIndexChun);

    }
    public void JumpCancle()
    {
        animator.SetInteger("ps", 0);
    }
    public void ButtonCancle()
    {
        animator.SetInteger("buttonState", 0);
    }
    
}
