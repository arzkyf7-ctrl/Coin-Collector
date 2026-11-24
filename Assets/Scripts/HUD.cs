using System;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    [SerializeField] private Slider healthbar;
    private int maxHealth;
    private void SetupHealthBar(GameObject player)
    {
        if (healthbar == null || player == null)
        {
            return;
        }
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            return;
        }
        maxHealth = playerHealth.MaxHealth;
        healthbar.minValue = 0f;
        healthbar.maxValue = 1f;
        healthbar.value = 1f;
    }
    private void UpdateHealthBar(int currentHealth)
    {
        if (healthbar == null || maxHealth <= 0)
        {
            return;
        }
        healthbar.value = Mathf.Clamp01((float)currentHealth / maxHealth);
    }
    private void OnEnable()
    {
        GameController.OnPlayerSpawned += SetupHealthBar;
        PlayerHealth.OnPlayerTakeDamage += UpdateHealthBar;
    }
    private void OnDisable()
    {
        GameController.OnPlayerSpawned -= SetupHealthBar;
        PlayerHealth.OnPlayerTakeDamage -= UpdateHealthBar;
    }
}
