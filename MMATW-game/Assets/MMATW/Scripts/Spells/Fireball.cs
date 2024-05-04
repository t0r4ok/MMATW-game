using MMATW.Scripts.Scriptable_objects;
using UnityEngine;

namespace MMATW.Scripts.Spells
{
    [CreateAssetMenu(menuName = "Spells/Fireball", fileName = "New Fireball Spell")]
    public class Fireball : SpellObject
    {
        [SerializeField] private GameObject prefab;
        
        
        public override void Cast(GameObject parent, Transform pos)
        {
            Instantiate(prefab, pos);
        }
    }
}