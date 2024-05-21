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
            var sm = _spellManager;
            
            if (Input.GetKeyDown(KeyCode.E)) Interact(); // Don't do anything.
            
            // Spell preparation (crafting)
            if (Input.GetKeyDown(KeyCode.Z) && sm.essenceToUse[0]) sm.AddEssense(sm.essenceToUse[0]);
            if (Input.GetKeyDown(KeyCode.X) && sm.essenceToUse[1]) sm.AddEssense(sm.essenceToUse[1]);
            if (Input.GetKeyDown(KeyCode.C) && sm.essenceToUse[2]) sm.AddEssense(sm.essenceToUse[2]);
            
            if (Input.GetKeyDown(KeyCode.Alpha1)) Dash();
            if (Input.GetKeyDown(KeyCode.Mouse0)) PerformSpellCast();
            if (Input.GetKeyDown(KeyCode.T)) _spellManager.ClearSpell();
        }

        /*
        TODO: 1. Add cast delay
        TODO: 2. Add more spells. [DONE] 
        TODO: 3. Hope that all this piece of sh... code will work as intended and wont broke at some point. [Will never be done]
        TODO: 4. Try not to lose our minds. [Lost mine already]
        */
        
        
        // ReSharper disable Unity.PerformanceAnalysis
        private void PerformSpellCast()
        {
            var spell = _spellManager.selectedSpell;
            if (spell == null) return;
            
            Vector3 direction = transform.position;
            direction = Vector3.Scale(direction, new Vector3(0f, transform.rotation.y, 0f));
            direction.Normalize();
            
            
            if (_attributes.playerMana >= spell.manaCost && _attributes.playerHealth >= spell.healthCost &&
                _attributes.playerStamina >= spell.staminaCost)
            {
                _attributes.TakeMana(spell.manaCost);
                _attributes.TakeStamina(spell.staminaCost);
                _attributes.TakeStamina(spell.healthCost);


                spell.Cast(_spellCaster.transform, _spellCaster.transform.position, direction);
            }
        }
        
        
        
        private void Interact()
        {
            return;
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