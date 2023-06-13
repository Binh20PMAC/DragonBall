using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject RightArmAttackPoint;
    //Khi GameObject cham
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
    //!!!!!!////////
    void TagRightArm()
    {
        RightArmAttackPoint.tag = "RightArm";
    } 
    void UnTagRightArm()
    {
        RightArmAttackPoint.tag = "Untagged";
    }
}
