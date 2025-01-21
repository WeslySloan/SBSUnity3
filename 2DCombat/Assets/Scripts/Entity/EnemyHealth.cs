using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class EnemyHealth : MonoBehaviour, Idamagable
{
    // Ã¼·Â

    [field: SerializeField] public int CurrentHealth { get; set; }
    [field:SerializeField] public int MaxHealth { get; set; } = 3;
    public bool HasTakenDamgage { get; set ; }

    private CinemachineImpulseSource _impulseSource;
    [SerializeField] private ScreenShakeSO profile;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Damage(int amount)
    {
        HasTakenDamgage = true;
        CurrentHealth -= amount;
        CameraShakeManager.Instance.CameraShakeFromProfile(_impulseSource, profile);
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
