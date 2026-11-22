using System;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    [SerializeField] private Slider healthbar;
    private int maxHealth;
    private void setupHealthBar(GameObject player)
    {
        healthbar.value = healthbar.maxValue;
        maxHealth = player.GetComponent<PlayerHealth>().maxHealth;
    }
    private void updateHealthBar(int currentHealth)
    {
        healthbar.value = (float) currentHealth/ maxHealth;
        healthbar.value = Mathf.Clamp01(healthbar.value);
    }
    private void OnEnable() 
    {
        GameController.OnPlayerSpawned += setupHealthBar;
        PlayerHealth.OnPlayerTakeDamage += updateHealthBar;
    }
    private void OnDisable()
    {
        GameController.OnPlayerSpawned -= setupHealthBar;
        PlayerHealth.OnPlayerTakeDamage -= updateHealthBar;
    }
}
