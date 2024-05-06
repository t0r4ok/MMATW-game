using System.Collections.Generic;
using MMATW.Scripts.Scriptable_objects;
using UnityEditor.UI;
using UnityEngine;

namespace MMATW.Scripts.Player
{
        // Name of this script ma not be so obvious, but there will be all player actions such as shooting,
        // interacting with object, preparing spells, clearing prepared spells etc. 
    public class PlayerActions : MonoBehaviour
    {
        [Header("Spells:")] 
        public SpellObject selectedSpell;
        [Space]
        public List<SpellObject> spells;
        
        [Header("Spell-Actions")]
        [SerializeField] private SpellObject dash;

        [Header("Other:")]
        [SerializeField] private GameObject _spellCaster;
        
        private PlayerAttributes _attributes;
        private GameObject _projectileSpawner;
        

        private void Awake()
        {
            _attributes = GetComponent<PlayerAttributes>();
            selectedSpell = spells[0]; // Just for testing.
        }
        
        private void Update()
        {
            Dash(); 
            
            if (Input.GetKeyDown(KeyCode.F)) PerformSpellCast();
        }

        /*
        TODO: 1. Add cast delay
        TODO: 2. Add more spells.
        TODO: 3. Hope that all this piece of sh... code will work as intended and wont broke at some point.
        TODO: 4. Try not to lose our minds. 
        */
        
        
        // ReSharper disable Unity.PerformanceAnalysis
        private void PerformSpellCast()
        {
            if (selectedSpell == null) return;
            
            Vector3 direction = transform.position;
            direction = Vector3.Scale(direction, new Vector3(0f, transform.rotation.y, 0f));
            direction.Normalize();
            
            
            if (_attributes.playerMana >= selectedSpell.manaCost)
            {
                _attributes.TakeMana(selectedSpell.manaCost);
                selectedSpell.Cast(_spellCaster.transform, _spellCaster.transform.position, direction);
            }
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

        // ReSharper disable Unity.PerformanceAnalysis
        private void Dash()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && _attributes.playerMana >= 40)
            {
                dash.Cast(transform, transform.position, Vector3.zero);
            }
        }
    }
}