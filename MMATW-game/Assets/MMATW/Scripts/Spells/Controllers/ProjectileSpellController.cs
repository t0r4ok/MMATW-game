using System;
using System.Collections;
using MMATW.Scripts.Enemy;
using UnityEngine;

namespace MMATW.Scripts.Spells.Controllers
{
    public class ProjectileSpellController : MonoBehaviour
    {
        public Projectile spell;
        private Rigidbody _rb;
        
        
        void Start()
        {
            _rb = GetComponent<Rigidbody>();

            StartCoroutine(LifeCycle());
        }

        private void Update()
        {
            _rb.AddForce(transform.forward);
            
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player")) return;
            
            if (collision.gameObject.GetComponent<EnemyHealth>()) spell.OnHit(collision.gameObject);
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
