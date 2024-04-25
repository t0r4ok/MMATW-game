using System;
using MMATW.Scripts.Scriptable_objects;
using UnityEngine;

namespace MMATW.Scripts.Player
{
        // Name of this script ma not be so obvious, but there will be all player actions such as shooting,
        // interacting with object, preparing spells, clearing prepared spells etc. 
    public class PlayerActions : MonoBehaviour
    { 
        [SerializeField] private Vector3 shootRotation;
        [SerializeField] private SpellObject dash;
        
        private PlayerAtributes _attributes;
        
        
        
        
        private void Awake()
        {
            _attributes = GetComponent<PlayerAtributes>();
        }
        
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

        private void ManaCheck()
        {
        }

        private void Dash()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && _attributes.mana >= 40)
            {
                dash.SpellAction(gameObject);
            }
        }
        
        
    }
}