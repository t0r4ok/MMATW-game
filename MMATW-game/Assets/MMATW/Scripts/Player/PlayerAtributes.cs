using System.Collections;
using UnityEngine;


namespace MMATW.Scripts.Player
{
    public class PlayerAtributes : MonoBehaviour
    {
        private PlayerMovement _movement;
        
        [Header("Attributes")] 
        // TBA
        
        [Header("Health:")]
        public int playerHealth;
        [SerializeField] private int maxHealth = 100;
        
        [Header("Mana:")]
        public int mana = 200;
        public int maxMana = 200;
        [SerializeField] private int manaRegenerationAmount = 5;
        
        [Header("Stamina:")]
        public int stamina = 200;
        public int maxStamina = 200;
        [SerializeField] private int staminaRegenerationSpeed = 5;
        
        //[Header("Other")]
        private bool _isDashReady;
        private int _dashAmount;
        
        
        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            
            playerHealth = maxHealth;
            stamina = maxStamina;
        }

        private void Start()
        {
            StartCoroutine(RegenMana());
            StartCoroutine(RegenStamina());
        }
        

        // Regions helps to easily hide some code block at one click instead of closing them all one by one. 
        #region ActionsWithPlayer
        // TODO: Make all this shit work with Events.
        public void DamagePlayer(int damage)
        {
            playerHealth -= damage;
            
            
            playerHealth = Mathf.Clamp(playerHealth, 0, maxHealth);
        }

        public void HealPlayer(int healAmount)
        {
            playerHealth += healAmount;
            
            playerHealth = Mathf.Clamp(playerHealth, 0, maxHealth);
            
            GlobalEventManager.SendHealthChanged(playerHealth);
        }
        #endregion


        private IEnumerator RegenMana()
        {
            yield return new WaitForSeconds(3f);
            
            if (mana < maxMana) // TODO: Make a states to casting.
            {
                mana += manaRegenerationAmount;
            }
            GlobalEventManager.SendManahChanged(mana); // Yep, every call. I thought that it would be more stable. 
        }

        private IEnumerator RegenStamina()
        {
            yield return new WaitForSeconds(0.3f);
            
            if (stamina < maxStamina && !_movement.isWalking)
            {
                stamina += staminaRegenerationSpeed;
            }
            GlobalEventManager.SendStaminaChanged(stamina); // Yep, every call. I thought that it would be more stable. 
        }
        
    }
}
