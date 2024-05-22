using System;
using MMATW.Scripts.Enemy;
using System.Collections;
using UnityEngine;

namespace MMATW.Scripts.Spells.Controllers
{
    public class ProjectileSpellController : MonoBehaviour
    {
        private Rigidbody _rb;
        private Projectile _projectile;
        private EnemyHealth _enemyHealth;
        
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _projectile = GetComponent<Projectile>();

            StartCoroutine(LifeCycle());
        }

        private void Update()
        {
            _rb.AddForce(transform.forward);
            
        }


        private void OnCollisionEnter(Collision other)
        {
            FlashAway();
            if(other.GetComponent<EnemyHealth>() != null)
            {

            }
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();

            _enemyHealth.DealDamage(_projectile.damage);
            
            // Damage logic goes here!
        }

        private IEnumerator LifeCycle()
        {
            yield return new WaitForSeconds(3f);
            
            FlashAway();
        }

        private void FlashAway()
        {
            // FlashAway animation and SFX goes here!
            
            Destroy(gameObject);
        }
        
        
        
    }
}
