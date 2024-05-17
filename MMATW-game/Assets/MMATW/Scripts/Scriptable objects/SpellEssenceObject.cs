using UnityEngine;

namespace MMATW.Scripts.Scriptable_objects
{
    [CreateAssetMenu(menuName = "Spells/essences/essence", fileName = "New essence")]
    public class SpellEssenceObject : ScriptableObject
    {
        [Header("Properties:")]
        public int essenceId = 0;

        
        [Header("UI:")]
        [SerializeField] private new string name = "essence Name";
        [SerializeField] private string description = "essence description";
        
        [SerializeField] private Sprite uiIcon;
    }
}