using MMATW.Scripts.Interfaces;
using MMATW.Scripts.Scriptable_objects;
using UnityEngine;

namespace MMATW.Scripts.Spells
{
    [CreateAssetMenu(menuName = "Spells/Fireball", fileName = "New Fireball Spell")]
    public class FireBall : ProjectileSPell, ISpell
    {
        public override void Cast(Transform parent, Vector3 position, Vector3 direction)
        {
            base.Cast(parent, position, direction);
        }
        
        
    }
}