using System;
using System.Collections;
using UnityEngine;

namespace MMATW.Scripts.Spells.Controllers
{
    public class ProjectileSpellController : MonoBehaviour
    {
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


        private void OnCollisionEnter(Collision other)
        {
            FlashAway();
            
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
