using System.Collections;
using UnityEngine;
public enum ComboState
{
    none,
    attack1,
    attack2,
    attack3,
    attack4,
    attack5,
}

public class Move : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRb;
    public Transform playerTrans;
    public Transform targetEnemy;
    private bool activateTimerToReset;
    private float default_combo_timer = 0.4f;
    private float current_combo_timer;
    private ComboState current_combo_state;

    public float w_speed, wb_speed, rn_speed;
    public bool walking;
    public float jumpForce = 5f;
    public bool isOnGround = true;
    private bool isJump = false;
    public bool isFlipped = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        current_combo_timer = default_combo_timer;
        current_combo_state = ComboState.none;
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        playerRb.velocity = transform.forward * w_speed * Time.deltaTime;

    //    }
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        playerRb.velocity = -transform.forward * wb_speed * Time.deltaTime;
    //    }
    //}
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(w_speed*Time.deltaTime, 0, 0, 0);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-w_speed * Time.deltaTime, 0, 0, 0);
        }

        Movement();
        ComboAttacks();
        ResetComboState();
        //xoay nhan vat
        if (targetEnemy != null)
        {
            Vector3 targetDirection = targetEnemy.position - playerTrans.transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

            // Xoay "CharacterContainer"
            if (angle > 90 || angle < -90)
            {
                playerTrans.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                isFlipped = true;
            }
            else
            {
                playerTrans.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                isFlipped=false;
            }
        }
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.D) && !isJump)
        {
            if (isFlipped)
            {
                playerAnim.SetTrigger("walkback");
                walking = false;
            }
            else
            {
                playerAnim.SetTrigger("walk");
                walking = true;
            }
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.D) && !isJump)
        {
            if (isFlipped)
            {
                playerAnim.ResetTrigger("walkback");
                walking = true;
            }
            else
            {
                playerAnim.ResetTrigger("walk"); 
                walking = false;
            }
            playerAnim.SetTrigger("idle");
        }
        if (Input.GetKeyDown(KeyCode.A)&& !isJump)
        {
            if (isFlipped)
            {
                playerAnim.SetTrigger("walk");
            }
            else
            {
                playerAnim.SetTrigger("walkback");
            }
            playerAnim.ResetTrigger("idle");
            
        }
        if (Input.GetKeyUp(KeyCode.A)&& !isJump)
        {
            if (isFlipped)
            {
                playerAnim.ResetTrigger("walk");
            }
            else
            {
                playerAnim.ResetTrigger("walkback");
            }
            playerAnim.SetTrigger("idle");
        }
        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (isFlipped)
                {
                    w_speed = w_speed + rn_speed;
                    playerAnim.SetTrigger("run");
                    playerAnim.ResetTrigger("walk");
                }
                else
                {
                    w_speed = w_speed + rn_speed;
                    playerAnim.SetTrigger("run");
                    playerAnim.ResetTrigger("walk");
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                //Debug.Log("1");
                //w_speed = 120;
                w_speed = 3f;
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            }
        }
        if(walking==false)
        {
            //w_speed = 120;
            w_speed = 3f;
        }
        if (isJump)
        {
            walking = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            StartCoroutine(WaitForSecondReadyJump());
        }
        //
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerAnim.SetTrigger("ki");
        }
    }
    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (current_combo_state == ComboState.attack3 ||
                current_combo_state == ComboState.attack4 ||
                current_combo_state == ComboState.attack5)
                return;
            current_combo_state++;
            activateTimerToReset = true;
            current_combo_timer = default_combo_timer;
            if (current_combo_state == ComboState.attack1)
            {
                playerAnim.SetTrigger("attack1");
            } 
            if (current_combo_state == ComboState.attack2)
            {
                playerAnim.SetTrigger("attack2");
            }
            if (current_combo_state == ComboState.attack3)
            {
                playerAnim.SetTrigger("attack3");
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (current_combo_state == ComboState.attack5 ||
                current_combo_state == ComboState.attack3)
                return;
            if(current_combo_state == ComboState.none||
                current_combo_state==ComboState.attack1||
                current_combo_state == ComboState.attack2)
            {
                current_combo_state = ComboState.attack4;
            }
            else if(current_combo_state == ComboState.attack4)
            {
                current_combo_state++;
            }
            activateTimerToReset = true;
            current_combo_timer = default_combo_timer;
            if (current_combo_state == ComboState.attack4)
            {
                playerAnim.SetTrigger("attack4");
            }
            if (current_combo_state == ComboState.attack5)
            {
                playerAnim.SetTrigger("attack5");
            }
        }
    }
    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            current_combo_timer -= Time.deltaTime;
            if(current_combo_timer <= 0f)
            {
                current_combo_state = ComboState.none;
                activateTimerToReset = false;
                current_combo_timer = default_combo_timer;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isJump)
        {
            StartCoroutine(WaitForSecondTouchGround());
        }
    }
    IEnumerator WaitForSecondTouchGround()
    {
        yield return new WaitForSeconds(0f);
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
        //playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        playerRb.AddForce(transform.up * jumpForce);
    }
}
