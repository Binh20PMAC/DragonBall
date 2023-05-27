using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRb;
    public Transform playerTrans;

    public float w_speed, wb_speed, rn_speed, olw_speed;
    public bool walking;
    public float jumpForce = 5f;
    public bool isOnGround = true;

    private bool isJump = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerRb.velocity = transform.forward * w_speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRb.velocity = -transform.forward * wb_speed * Time.deltaTime;
        }
    }
    void Update()
    {
        Movement();

    }
    IEnumerator WaitForSecondTouchGround()
    {
<<<<<<< HEAD
        yield return new WaitForSeconds(0f);
=======
        yield return new WaitForSeconds(1f);
>>>>>>> 1e7db8823daa39ad27d3dee16728863084c31ad5
        playerAnim.SetTrigger("idle");
        playerAnim.ResetTrigger("jump");
        isOnGround = true;
        isJump = false;
    }

    IEnumerator WaitForSecondReadyJump()
    {
        playerAnim.SetTrigger("jump");
        playerAnim.ResetTrigger("idle");
        isOnGround = false;
        isJump = true;
        yield return new WaitForSeconds(0.5f);
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
 
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.D) && !isJump)
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            walking = true;
            
        }
        if (Input.GetKeyUp(KeyCode.D) && !isJump)
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            walking = false;
            
        }
        if (Input.GetKeyDown(KeyCode.A)&& !isJump)
        {
            playerAnim.SetTrigger("walkback");
            playerAnim.ResetTrigger("idle");
            
        }
        if (Input.GetKeyUp(KeyCode.A)&& !isJump)
        {
            playerAnim.ResetTrigger("walkback");
            playerAnim.SetTrigger("idle");
        }
        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                w_speed = w_speed + rn_speed;
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("walk");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Debug.Log("1");
                w_speed = 120;
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            }
        }
<<<<<<< HEAD
        if(walking==false)
        {
            w_speed = 120;
        }
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            StartCoroutine(WaitForSecondReadyJump());
        }  
        if(Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.SetTrigger("attack1");
            playerAnim.SetTrigger("attack2");
            playerAnim.ResetTrigger("idle");
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            playerAnim.ResetTrigger("attack1");
            playerAnim.ResetTrigger("attack2");
            playerAnim.SetTrigger("idle");
        }
=======
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            StartCoroutine(WaitForSecondReadyJump());
        }  
>>>>>>> 1e7db8823daa39ad27d3dee16728863084c31ad5
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isJump)
        {
            StartCoroutine(WaitForSecondTouchGround());
        }
    }
}
