using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject RightArmAttackPoint;
   void RightArmAttackOn()
    {
        RightArmAttackPoint.SetActive(true);
    } 
    void RightArmAttackOff()
    {
        if (RightArmAttackPoint.activeInHierarchy)
        {
            RightArmAttackPoint.SetActive(false);
        }
    }
}
