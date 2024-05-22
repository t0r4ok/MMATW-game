using System;
using UnityEngine;

namespace MMATW.Scripts
{
    public class GlobalEventManager
    {
        
        public static Action<int> OnHealthChange;
        public static Action<float> OnStaminaChange;
        public static Action<int> OnManaChange;
        
        public static Action<Sprite> OnSpellChange;
        
        public static Action<Sprite> OnEssenceChange0;
        public static Action<Sprite> OnEssenceChange1;
    }
        
}