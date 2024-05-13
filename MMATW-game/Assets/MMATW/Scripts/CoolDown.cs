using UnityEngine;

namespace MMATW.Scripts
{
    [System.Serializable]
    public class CoolDown : MonoBehaviour
    {
        // Think twice before using this script. Maybe you can just use Coroutine? 
        
        [SerializeField] private float cooldownTime;
        private float _nextCDtime;
        public bool IsInCooldown => Time.time < _nextCDtime;
        public void StartCooldown() => _nextCDtime = Time.time + cooldownTime;
    }
}
