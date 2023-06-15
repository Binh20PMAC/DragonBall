using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject RightArmAttackPoint;
    public GameObject LeftArmAttackPoint;
    public GameObject RightLegAttackPoint;
    public GameObject LeftLegAttackPoint;
    public GameObject RightForeArmAttackPoint;
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
    void LeftTArmAttackOn()
    {
        LeftArmAttackPoint.SetActive(true);
    } 
    void LeftArmAttackOff()
    {
        if (LeftArmAttackPoint.activeInHierarchy)
        {
            LeftArmAttackPoint.SetActive(false);
        }
    } 
    void LeftTLegAttackOn()
    {
        LeftLegAttackPoint.SetActive(true);
    } 
    void LeftLegAttackOff()
    {
        if (LeftLegAttackPoint.activeInHierarchy)
        {
            LeftLegAttackPoint.SetActive(false);
        }
    } 
    void RightLegAttackOn()
    {
        RightLegAttackPoint.SetActive(true);
    } 
    void RightLegAttackOff()
    {
        if (RightLegAttackPoint.activeInHierarchy)
        {
            RightLegAttackPoint.SetActive(false);
        }
    }    
    void RightForeArmAttackOn()
    {
        RightForeArmAttackPoint.SetActive(true);
    } 
    void RightForeArmAttackOff()
    {
        if (RightForeArmAttackPoint.activeInHierarchy)
        {
            RightForeArmAttackPoint.SetActive(false);
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
