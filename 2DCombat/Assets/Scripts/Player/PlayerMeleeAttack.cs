using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private float attckCD = 0.15f;

    RaycastHit2D[] hits;

    private void Update()
    {
        if(InputUser.Instance.control.Attack.MeleeAttack.WasPressedThisFrame())
        {
            Attack();
                
        }
    }

    private void Attack()
    {
        // 모든 몬스터?

        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0, attackableLayer);

        for(int i =0; i< hits.Length; i++)
        {
            Idamagable enemyHealth = hits[i].collider.GetComponent<Idamagable>();

            if(enemyHealth != null)
            {
                enemyHealth.Damage(damageAmount);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }

}
