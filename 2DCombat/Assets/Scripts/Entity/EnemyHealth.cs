using Cinemachine;
using System;
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

    [SerializeField] private AudioClip damageClip;
    public string HurtClipName;

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
        // Sound

        PlayRandomSFX();
       
        Die();
    }

    private void PlayRandomSFX()
    {
        int randomIndex = UnityEngine.Random.Range(1, 5);
        string clipName = HurtClipName + randomIndex;
        SoundManager.Instance.PlaySFXFromString(clipName, 1f);
    }

    public void Die()
    {
        if(CurrentHealth <= 0)
        {          
            Destroy(gameObject);
        }
    }
}
