using System.Collections.Generic;
using MMATW.Scripts.Scriptable_objects;
using UnityEngine;

namespace MMATW.Scripts.Player
{
        // Name of this script ma not be so obvious, but there will be all player actions such as shooting,
        // interacting with object, preparing spells, clearing prepared spells etc. 
    public class PlayerActions : MonoBehaviour
    {

        
        [Header("Spell-Actions")]
        [SerializeField] private SpellObject dash;

        [Header("Other:")]
        [SerializeField] private GameObject _spellCaster;
        
        private PlayerAttributes _attributes;
        private GameObject _projectileSpawner;
        private SpellManager _spellManager;

        private void Awake()
        {
            _attributes = GetComponent<PlayerAttributes>();
            _spellManager = GetComponent<SpellManager>();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) Dash();
            if (Input.GetKeyDown(KeyCode.F)) PerformSpellCast();

            PrepareSpell();
            if (Input.GetKeyDown(KeyCode.T)) _spellManager.ClearSpell();

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
            var spell = _spellManager.selectedSpell;
            if (spell == null) return;
            
            Vector3 direction = transform.position;
            direction = Vector3.Scale(direction, new Vector3(0f, transform.rotation.y, 0f));
            direction.Normalize();
            
            
            if (_attributes.playerMana >= spell.manaCost)
            {
                _attributes.TakeMana(spell.manaCost);
                spell.Cast(_spellCaster.transform, _spellCaster.transform.position, direction);
            }
        }
        
        private void Interact()
        {
            
        }
        private void PrepareSpell()
        {
            // Даже оправдываться не буду. 
            var sm = _spellManager;
            if (Input.GetKeyDown(KeyCode.Z) && sm.essenseToUse[1]) sm.AddEssense(sm.essenseToUse[1]);   
        }
        
        private void KillPlayer()
        {
            print("PLAYER IS DEAD!");
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void Dash()
        {
            if (_attributes.playerMana < 40) return;
            
            dash.Cast(transform, transform.position, Vector3.zero);
        }
    }
}