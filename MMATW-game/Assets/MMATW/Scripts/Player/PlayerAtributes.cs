using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace MMATW.Scripts.Player
{
    public class PlayerAtributes : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private Slider uiHealthBar;
        [SerializeField] private Slider uiStaminaBar;
        
        
        [Header("Atributes")] 
        [SerializeField] private int playerHealth;
        [SerializeField] private int maxHealth = 100;

        [SerializeField] public float stamina = 200;
        [SerializeField] public float staminaRegenerationSpeed = 0.25f;
        [SerializeField] public float maxStamina = 200;

        private bool _isDashReady;
        private int _dashAmount;

        private void Awake()
        {
            playerHealth = maxHealth;
            uiHealthBar.maxValue = maxHealth;

            uiStaminaBar.maxValue = maxStamina;
        }

        public void DamagePlayer(int damage)
        {
            playerHealth -= damage;
            Debug.Log($"Player damaged by {damage} HP!");
            UpdateUI();
            
            playerHealth = Mathf.Clamp(playerHealth, 0, maxHealth);
        }

        public void HealPlayer(int healAmount)
        {
            playerHealth += healAmount;
            Debug.Log($"Player healed by {healAmount} HP!");
            UpdateUI();

            playerHealth = Mathf.Clamp(playerHealth, 0, maxHealth);
        }

        private void Update()
        {
            uiStaminaBar.value = stamina;
        }

        private void UpdateUI()
        {
            if (uiHealthBar == null) return;
            
            uiHealthBar.value = playerHealth;
            uiStaminaBar.value = stamina;
        }
        
    }
}
