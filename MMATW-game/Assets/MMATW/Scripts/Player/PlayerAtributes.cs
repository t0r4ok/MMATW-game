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
        }

        public void HealPlayer(int healAmount)
        {
            playerHealth -= healAmount;
        }
        
        
        
    }
}
