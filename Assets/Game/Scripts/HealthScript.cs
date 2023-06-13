using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public Animator playerAnim;
    public float health = 100f;
    private bool characterDied;
    public bool is_Player;
   
    public void ApplyDamege(float damage,bool knockDown)
    {
        if (characterDied)
            return;
        health -= damage;
        if(health <= 0f)
        {
            playerAnim.SetTrigger("died");
            characterDied = true;
            if (is_Player)
            {

            }return;
        }
        if (!is_Player)
        {
            if (knockDown)
            {
                if (Random.Range(0, 2) > 0)
                {
                    playerAnim.SetTrigger("died");
                }
            }
            else
            {
                if (Random.Range(0, 3) > 1)
                {
                    playerAnim.SetTrigger("hit");
                }
            }
        }
    }
}
