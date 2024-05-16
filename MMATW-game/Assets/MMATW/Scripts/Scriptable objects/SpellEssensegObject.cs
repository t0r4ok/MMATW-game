using UnityEngine;

namespace MMATW.Scripts.Scriptable_objects
{
    [CreateAssetMenu(menuName = "Spells/essences/essence", fileName = "New essence Spell")]
    public class SpellEssensegObject : ScriptableObject
    {
        [Header("UI:")]
        [SerializeField] private new string name = "Spell Name";
        [SerializeField] private string description = "Spell description";
        
        [SerializeField] private Sprite uiIcon;
    }
}