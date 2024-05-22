using System.ComponentModel;
using UnityEngine;

namespace MMATW.Scripts.Scriptable_objects
{
    public abstract class SpellObject : ScriptableObject
    {
        [Header("UI:")]
        public new string name = "Spell Name";
        public string description = "Spell description";
        
        public Sprite uiIcon;
        
        [Header("Casting costs:")]
        
        [Description("How much mana will be taken from player?")]
        public int manaCost = 5;
        [Description("How much stamina will be taken from player?")]
        public int staminaCost;
        
        [Description("How much health will be taken from player?")]
        public int healthCost;
        
        public virtual void Cast(Transform parent, Vector3 position, Vector3 direction) {}
    }
}