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


        private void OnCollisionEnter(Collision collision)
        {
            if(!collision.gameObject.GetComponent<EnemyHealth>()) FlashAway();;
            
            
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            enemy.DealDamage(_projectile.damage);
            FlashAway();
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
