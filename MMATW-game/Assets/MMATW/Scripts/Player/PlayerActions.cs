using System;
using UnityEngine;

namespace MMATW.Scripts.Player
{
        // Name of this script ma not be so obvious, but there will be all player actions such as shooting,
        // interacting with object, preparing spells, clearing prepared spells etc. 
    public class PlayerActions : MonoBehaviour
    { 
        [SerializeField] private Vector3 shootRotation;
        
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F)) Shoot();
            
            
            
        }

        private void Shoot()
        {
            
        }

        private void PrepareSpell()
        {
            
        }

        private void ClearSpell()
        {
            
        }
        
        private void Interact()
        {
            
        }
        
        private void KillPlayer()
        {
            print("PLAYER IS DEAD!");
        }
        
        
    }
}