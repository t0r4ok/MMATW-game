using UnityEngine;

namespace MMATW.Scripts.Player
{
    public class PlayerAtributes : MonoBehaviour
    {
        [Header("Atributes")] 
        [SerializeField] private int playerHealth;
        [SerializeField] private int maxHealth = 100;

        private bool _isDashReady;
        private int _dashAmount;
        
        private void Awake()
        {
            playerHealth = maxHealth;
        }

        public void DamagePlayer(int damage)
        {
            playerHealth -= damage;
            Debug.Log($"Player damaged by {damage}:yellow:b HP!");
        }

        public void HealPlayer(int healAmount)
        {
            playerHealth -= healAmount;
            Debug.Log($"Player healed by {healAmount}:green:b HP!");
        }
        
        
        
    }
}
