using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;
    public bool isPlayer,isEnemy;
    public GameObject hit_FX;
    void Update()
    {
        DetectCollision();
    }
    void DetectCollision()
    {
        Collider[]hit=Physics.OverlapSphere(transform.position,radius,collisionLayer); 
        if (hit.Length > 0)
        {
           // print("Hit the" + hit[0].gameObject.name);
            if (isPlayer)
            {
                Vector3 hitFX_Pos=hit[0].transform.position;
                hitFX_Pos.y += 1.3f;
                if (hit[0].transform.forward.x > 0)
                {
                    hitFX_Pos.x += 0.3f;
                }
                else if (hit[0].transform.forward.x < 0)
                {
                    hitFX_Pos.x -= 0.3f;
                }
                Instantiate(hit_FX,hitFX_Pos,Quaternion.identity);
            }
            gameObject.SetActive(false);
        }
    }
}
