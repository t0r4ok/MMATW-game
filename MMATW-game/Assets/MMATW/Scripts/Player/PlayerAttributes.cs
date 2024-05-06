using System.Collections;
using UnityEngine;


namespace MMATW.Scripts.Player
{
    public class PlayerAttributes : MonoBehaviour
    {
        private PlayerMovement _movement;
        
        [Header("Attributes")] 
        // TBA
        
        [Header("Health:")]
        public int playerHealth; // shouldn't be changed in inspector. Just for testing.
        public int maxHealth = 100;
        [SerializeField] private float healthRegenDelay = 0.5f;
        [SerializeField] private int healthRegenAmount = 5;
        
        [Header("Mana:")]
        public int playerMana; // shouldn't be changed in inspector. Just for testing.
        public int maxMana = 100;
        [SerializeField] private float staminaRegenDelay = 0.5f;
        [SerializeField] private int manaRegenAmount = 5;
        
        [Header("Stamina:")]
        public float playerStamina; // shouldn't be changed in inspector. Just for testing.
        public float maxStamina = 100f;
        [SerializeField] private float manaRegenDelay = 0.5f;
        [SerializeField] private float staminaRegenAmount = 5f;
        
        //[Header("Other")]
        private bool _isDashReady;
        private int _dashAmount;
        
        
        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            
            playerHealth = maxHealth;
            playerStamina = maxStamina;
            playerMana = maxMana;
        }

        private void Start()
        {
            StartCoroutine(RegenMana(manaRegenAmount, manaRegenDelay));
            StartCoroutine(RegenStamina(staminaRegenAmount, staminaRegenDelay));
        }
        

        // Regions helps to easily hide some code block at one click instead of closing them all one by one. 
        // You can use this actions to manipulate with player's stats (HP, MP, STM).
        #region ActionsWithPlayer
        // TODO: Make all this shit work with Events.
        public void HealPlayer(int healAmount)
        {
            playerHealth += healAmount;
            
            playerHealth = Mathf.Clamp(playerHealth, 0, maxHealth);
            GlobalEventManager.OnHealthChange?.Invoke(playerHealth);
        }
        
        public void DamagePlayer(int damage)
        {
            playerHealth -= damage;
            
            
            playerHealth = Mathf.Clamp(playerHealth, 0, maxHealth);
            GlobalEventManager.OnHealthChange?.Invoke(playerHealth);
        }

        
        public void RestoreMana(int restoreAmount)
        {
            playerMana += restoreAmount;
            
            playerMana = Mathf.Clamp(playerMana, 0, maxMana);
            GlobalEventManager.OnManaChange?.Invoke(playerMana);
        }
        public void TakeMana(int decreaseAmount) // Take some mana from player.
        {
            playerMana -= decreaseAmount;
            
            playerMana = Mathf.Clamp(playerMana, 0, maxMana);
            GlobalEventManager.OnManaChange?.Invoke(playerMana);
        }
        
        
        public void RestoreStamina(float restoreAmount)
        {
            playerStamina += restoreAmount;
            
            playerStamina = Mathf.Clamp(playerStamina, 0, maxStamina);
            GlobalEventManager.OnStaminaChange?.Invoke(playerStamina);
        }
        
        public void TakeStamina(float decreaseAmount) // Take some stamina from player.
        {
            playerStamina -= decreaseAmount;
            
            playerStamina = Mathf.Clamp(playerStamina, 0, maxStamina);
            GlobalEventManager.OnStaminaChange?.Invoke(playerStamina);
        }
        #endregion

        #region SideAutoActions

        

        private IEnumerator RegenStamina(float regenAmount, float regenDelay)
        {
            while (true) // Repeat indefinitely. 
            {
                if (playerStamina < maxStamina && !_movement.isWalking)
                {
                    RestoreStamina(regenAmount);
                }
                print($"Stamina regenerated: {regenAmount}");
                yield return new WaitForSeconds(regenDelay);
            }
        }

        private IEnumerator RegenMana(int regenAmount, float regenDelay)
        {
            while (true) // Repeat indefinitely. 
            {
                if (playerMana < maxMana) // TODO: Make a states to casting.
                {
                    RestoreMana(regenAmount);
                }
                print($"Mana regenerated: {regenAmount}");
                yield return new WaitForSeconds(regenDelay);
            }
        }
        #endregion
    }
}
