using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, Idamagable
{
    // Ã¼·Â

    [field: SerializeField] public int CurrentHealth { get; set; }
    [field:SerializeField] public int MaxHealth { get; set; } = 3;
    public bool HasTakenDamgage { get; set ; } 

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void Damage(int amount)
    {
        HasTakenDamgage = true;
        CurrentHealth -= amount;

        Die();
    }
    
    public void Die()
    {
        if(CurrentHealth <= 0)
        {          
            Destroy(gameObject);
        }
    }
}
