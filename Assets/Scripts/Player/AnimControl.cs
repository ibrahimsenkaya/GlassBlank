using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimControl : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
       anim  = transform.GetComponent<Animator>();
    }

    public void Walk()
    {
        //anim.SetBool("Walk", false);
        //transform.Rotate(0, 0, 0);


      
    }
    public void Put()
    {
        
        anim.SetBool("Put", true);

    }
    public void Putted()
    {
        anim.SetBool("Put", false);
    }
    public void Jump()
    {
        anim.SetBool("Jump", false);
    }
    public void JumpLeft()
    {
        anim.SetBool("Left", false);
    }
    public void JumpRight()
    {
        anim.SetBool("Right", false);
    }
}
