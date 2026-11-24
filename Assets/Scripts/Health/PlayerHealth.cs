using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    public int CurrentHealth { get; private set; }
    public int MaxHealth { get; private set; }
    public static Action<int> OnPlayerTakeDamage;
    void Awake()
    {
        CurrentHealth = health;
        MaxHealth = health;
    }
    public void TakeDamage(int damageAmount)
    {
        Debug.Log("TakeDamage: " + damageAmount);
        CurrentHealth -= damageAmount;
        OnPlayerTakeDamage?.Invoke(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
