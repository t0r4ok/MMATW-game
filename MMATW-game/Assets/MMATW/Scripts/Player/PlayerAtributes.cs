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
        
        
        [Header("Attributes")] 
        public float stamina = 200;
        public float staminaRegenerationSpeed = 0.25f;
        public float maxStamina = 200;
        [SerializeField] private int playerHealth;
        [SerializeField] private int maxHealth = 100;


        private bool _isDashReady;
        private int _dashAmount;
        private UnityEvent<int> _onHealthChenge;
        
        
        private void Awake()
        {
            playerHealth = maxHealth;
            uiHealthBar.maxValue = maxHealth;

            uiStaminaBar.maxValue = maxStamina;
        }
        
        private void Update()
        {
            UpdateUI();
        }

        // Regions helps to easily hide some code block at one click instead of closing them all one by one. 
        #region ActionsWithPlayer
        // TODO: Make all this shit work with Events to improve performance.
        public void DamagePlayer(int damage)
        {
            playerHealth -= damage;
            
            
            playerHealth = Mathf.Clamp(playerHealth, 0, maxHealth);
        }

        public void HealPlayer(int healAmount)
        {
            playerHealth += healAmount;
            
            playerHealth = Mathf.Clamp(playerHealth, 0, maxHealth);
        }
        #endregion


        private void UpdateUI()
        {
            if (uiHealthBar != null) uiHealthBar.value = playerHealth;;
            if (uiStaminaBar != null) uiStaminaBar.value = stamina;
        }
    }
}
