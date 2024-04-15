using UnityEngine;

namespace MMATW.Scripts
{
    [System.Serializable]
    public class CoolDown : MonoBehaviour
    {
        [SerializeField] private float cooldownTime;
        private float _nextCDtime;

        public bool IsInCooldown => Time.time < _nextCDtime;
        public void StartCooldown() => _nextCDtime = Time.time + cooldownTime;
    }
}
