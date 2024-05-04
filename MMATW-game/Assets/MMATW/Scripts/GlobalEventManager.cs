using System;

namespace MMATW.Scripts
{
    public class GlobalEventManager
    {
        
        public static Action<int> OnHealthChange;
        public static Action<float> OnStaminaChange;
        public static Action<int> OnManaChange;
        
    }
}