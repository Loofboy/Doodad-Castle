using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public Animator SlimeAnims;
    public Rigidbody rb;
    public Vector3 bab = new Vector3(0,0,0);
    Vector3 vel = new Vector3(-10, 0, 0);
    float timepass = 3;
    float currenttime;
    // Start is called before the first frame update
    void Start()
    {
        currenttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //bab = rb.velocity;
        if (Time.time - currenttime > timepass)
        {
            SlimeAnims.SetTrigger("Jump");
        }
        //if (SlimeAnims.GetBool("IsJumping"))
        //{
        //   rb.velocity = vel;
        //    vel = -vel;
        //}
    }

    public void MoveToSide()
    {
        rb.velocity = vel;
        vel = -vel;
    }

    public void SetIsJumpingTrue()
    {
        SlimeAnims.SetBool("IsJumping", true);
    }

    public void SetIsJumpingFalse()
    {
        SlimeAnims.SetBool("IsJumping", false);
    }

}
