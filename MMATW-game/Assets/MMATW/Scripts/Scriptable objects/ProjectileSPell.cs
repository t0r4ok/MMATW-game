using UnityEngine;

namespace MMATW.Scripts.Scriptable_objects
{
    public class ProjectileSPell : SpellObject
    {

        public int damage;
        public float projectileVelocity;
        public GameObject spellPrefab;
        public GameObject onDestroyEffect;
        
        
        public override void Cast(Transform parent, Vector3 position, Vector3 direction) {
            Quaternion lookAt = Quaternion.FromToRotation(new Vector3(1f, 0f, 0f), direction);
            Instantiate(spellPrefab, position, lookAt);
            base.Cast(parent, position, direction);
        }

        public virtual void OnHit(GameObject target) {
            target.SendMessage("TakeHit", damage);
        }
    }
}