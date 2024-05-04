using UnityEngine;

namespace MMATW.Scripts.Scriptable_objects
{
    public abstract class SpellObject : ScriptableObject
    {
        [Header("UI:")]
        [SerializeField] private new string name = "Spell Name";
        [SerializeField] private string description = "Spell description";
        
        [SerializeField] private Sprite uiIcon;
        
        [Header("Casting costs:")]
        public int manaCost = 5;
        public int staminaCost;
        public int healthCost;
        
        public virtual void Cast(GameObject parent, Transform pos) {}
    }
}