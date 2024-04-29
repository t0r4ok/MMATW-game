using System.Collections.Generic;
using MMATW.Scripts.Scriptable_objects;
using UnityEngine;

namespace MMATW.Scripts.Player
{
        // Name of this script ma not be so obvious, but there will be all player actions such as shooting,
        // interacting with object, preparing spells, clearing prepared spells etc. 
    public class PlayerActions : MonoBehaviour
    {
        [Header("Properties:")] 
        public List<SpellObject> spells;
        
        private Vector3 _shootRotation;
        [SerializeField] private SpellObject dash;
        
        private PlayerAttributes _attributes;
        
        private void Awake()
        {
            _attributes = GetComponent<PlayerAttributes>();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F)) Shoot();
            
            if (Input.GetKeyDown(KeyCode.Alpha1) && _attributes.playerMana >= 40)
            {
                dash.Cast(gameObject);
            }
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
            
        }
    }
}