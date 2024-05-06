using MMATW.Scripts.Scriptable_objects;
using UnityEngine;

namespace MMATW.Scripts.Spells
{
    [CreateAssetMenu(menuName = "Spells/Projectile", fileName = "New Projectile Spell")]
    public class Projectile : SpellObject
    {
        public GameObject spellPrefab;

        public int damage = 5;
        public float projectileVelocity;
        
        
        public override void Cast(Transform parent, Vector3 position, Vector3 direction)
        {
            Instantiate(spellPrefab, position, parent.transform.rotation);
            base.Cast(parent, position, direction);
        }
    }
}