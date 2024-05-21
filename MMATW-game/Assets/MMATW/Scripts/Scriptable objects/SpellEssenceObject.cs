using UnityEngine;
using UnityEngine.UI;

namespace MMATW.Scripts.Scriptable_objects
{
    [CreateAssetMenu(menuName = "Spells/essences/essence", fileName = "New essence")]
    public class SpellEssenceObject : ScriptableObject
    {
        [Header("Properties:")]
        public int essenceId = 0;

        
        [Header("UI:")]
        public new string name = "essence Name";
        public string description = "essence description";
        
        public Sprite uiIcon;
    }
}