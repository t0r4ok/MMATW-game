using MMATW.Scripts.Interfaces;
using UnityEngine;

namespace MMATW.Scripts.Scriptable_objects
{
    public abstract class SpellObject : ScriptableObject
    {
        [Header("Properties:")]
        [SerializeField] private new string name = "Spell Name";
        [SerializeField] private string description = "Spell description";
        
        [SerializeField] private Sprite uiIcon;
        
        [Header("Casting costs:")]
        [SerializeField] private int manaCost = 5;
        [SerializeField] private int staminaCost;
        [SerializeField] private int healthCost;
        
        public virtual void Cast(GameObject parent) {}
    }
}