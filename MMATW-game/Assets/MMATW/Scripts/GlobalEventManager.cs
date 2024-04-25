using UnityEngine;
using UnityEngine.Events;

namespace MMATW.Scripts
{
    public class GlobalEventManager : MonoBehaviour
    {
        public static UnityEvent<int> OnHealthChange;
        public static UnityEvent<int> OnManaChange;
        public static UnityEvent<int> OnStaminaChange;

        private void Awake()
        {
            
        }

        public static void SendHealthChanged(int playerHealth)
        {
            OnHealthChange.Invoke(playerHealth);
        }
        public static void SendStaminaChanged(int playerStamina)
        {
            OnStaminaChange.Invoke(playerStamina);
        }
        public static void SendManahChanged(int playerMana)
        {
            OnStaminaChange.Invoke(playerMana);
        }
    }
}