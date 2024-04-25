using UnityEngine;

namespace MMATW.Scripts.Interfaces
{
    public interface ISpell
    {
        void Cast(Transform parent, Vector3 position, Vector3 direction);
    }
}