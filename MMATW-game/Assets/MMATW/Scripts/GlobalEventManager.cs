using System;

namespace MMATW.Scripts
{
    public class GlobalEventManager
    {
        
        public static Action<int> OnHealthChange;
        public static Action<float> OnStaminaChange;
        public static Action<int> OnManaChange;
        
        // -- Decided not to use this and invoke events right in the attributes instead. --
        // public void SendHealthChanged(int playerHealth)
        // {
        //    OnHealthChange?.Invoke(playerHealth);
        // }
        // public void SendStaminaChanged(int playerStamina)
        // {
        //     OnStaminaChange?.Invoke(playerStamina);
        // }
        // public void SendManahChanged(int playerMana)
        // {
        //     OnManaChange?.Invoke(playerMana);
        // }
    }
}