using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
    private Image health_UI;
    private Image enemyHealthUI;
     void Awake()
    {
        health_UI =GameObject.FindWithTag("HealthUI").GetComponent<Image>();
        enemyHealthUI =GameObject.FindWithTag("EnemyHealthUI").GetComponent<Image>();
    }

    public void DisplayHealth(float value, bool isPlayer)
    {
        value /= 100f;
        if (value < 0f)
            value = 0f;

        if (isPlayer && health_UI != null)
        {
            health_UI.fillAmount = value;
        }
        else if (!isPlayer && enemyHealthUI != null)
        {
            enemyHealthUI.fillAmount = value;
        }
    }
}
