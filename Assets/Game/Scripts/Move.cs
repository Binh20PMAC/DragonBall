using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed;
    public bool walking;
    public Transform playerTrans;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
 
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
        }
        Movement();
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            walking = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
        }

    }
}
