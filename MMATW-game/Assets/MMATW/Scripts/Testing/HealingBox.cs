using System;
using MMATW.Scripts.Player;
using UnityEngine;

namespace MMATW.Scripts.Testing
{
    public class HealingBox : MonoBehaviour
    {
        public CoolDown coolDown;
        [SerializeField] private int healAmount = 3;
        [SerializeField] private int damageAmount = 3;
        [SerializeField] private WorkMode mode = new WorkMode();

        private enum WorkMode
        {
            Damage,
            Heal
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            if (coolDown.IsInCooldown) return;
            var player = other.GetComponent<PlayerAtributes>();
            
            switch (mode)
            {
                case WorkMode.Heal:
                    player.HealPlayer(healAmount);
                    break;
                case WorkMode.Damage:
                    player.DamagePlayer(damageAmount);
                    break;
            }
        }
    }
}
