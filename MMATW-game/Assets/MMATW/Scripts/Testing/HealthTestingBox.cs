using System;
using System.Collections;
using MMATW.Scripts.Player;
using UnityEngine;

namespace MMATW.Scripts.Testing
{
    public class HealthTestingBox : MonoBehaviour
    {
        [SerializeField] private int healAmount = 3;
        [SerializeField] private int damageAmount = 3;
        [SerializeField] private WorkMode mode = new WorkMode();

        private enum WorkMode
        {
            Damage,
            Heal
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
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
