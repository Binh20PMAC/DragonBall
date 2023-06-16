using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
    private Image player_health_UI;
    private Image enemy_health_UI;
    private Image player_energy_UI;
    private Image enemy_energy_UI;
    public Gradient gradient;
    private float player_energy = 15f;
    private float enemy_energy = 15f;
    private const float max_energy = 100f;
    void Awake()
    {
        player_health_UI =GameObject.FindWithTag("HealthUI").GetComponent<Image>();
        enemy_health_UI =GameObject.FindWithTag("EnemyHealthUI").GetComponent<Image>();
        player_energy_UI = GameObject.FindWithTag("EnergyUI").GetComponent<Image>();
        enemy_energy_UI = GameObject.FindWithTag("EnemyEnergyUI").GetComponent<Image>();
        DisplayEnergy(player_energy, true);
        DisplayEnergy(enemy_energy, false);
    }
    public void DisplayHealth(float value, bool isPlayer)
    {
        value /= 100f;
        if (value < 0f)
            value = 0f;

        if (isPlayer && player_health_UI != null)
        {
            player_health_UI.fillAmount = value;
        }
        else if (!isPlayer && enemy_health_UI != null)
        {
            enemy_health_UI.fillAmount = value;
        }
    }
    public void DisplayEnergy(float value,bool isPlayer)
    {
        value /= 100f; // Chia giá tr? n?ng l??ng cho 100 ?? n?m trong kho?ng t? 0 -> 1
        if (value < 0f)
            value = 0f;

        if (isPlayer && player_energy_UI != null)
        {
            player_energy_UI.fillAmount = value;
            player_energy_UI.color = gradient.Evaluate(value);
            player_energy = value * max_energy; // L?u tr? giá tr? n?ng l??ng ng??i ch?i
        }
        else if (!isPlayer && enemy_energy_UI != null)
        {
            enemy_energy_UI.fillAmount = value;
            enemy_energy_UI.color = gradient.Evaluate(value);
            enemy_energy = value * max_energy; // L?u tr? giá tr? n?ng l??ng ??i th?
        }
    }
}

