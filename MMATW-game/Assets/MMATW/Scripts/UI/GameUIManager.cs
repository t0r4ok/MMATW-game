using System;
using UnityEngine;
using UnityEngine.UI;

namespace MMATW.Scripts.UI
{
    public class GameUIManager : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private Slider uiHealthBar;
        [SerializeField] private Slider uiStaminaBar;
        [SerializeField] private Slider uiManaBar;

        private void Start() // Subscribing to events.
        {
            GlobalEventManager.OnHealthChange += UpdateHealthUI;
            GlobalEventManager.OnStaminaChange += UpdateStaminaUI;
            GlobalEventManager.OnManaChange += UpdateManaUI;
        }

        private void OnDestroy() // Unsubscribing from events.
        {
            GlobalEventManager.OnHealthChange -= UpdateHealthUI;
            GlobalEventManager.OnStaminaChange -= UpdateStaminaUI;
            GlobalEventManager.OnManaChange -= UpdateManaUI;
        }


        #region PlayerStatUpdates
        private void UpdateHealthUI(int playerHealth)
        {
            if (uiHealthBar != null) uiHealthBar.value = playerHealth;;
        }
        
        private void UpdateStaminaUI(float playerStamina)
        {
            if (uiStaminaBar != null) uiStaminaBar.value = playerStamina;
        }
        
        private void UpdateManaUI(int playerMana)
        {
            if (uiManaBar != null) uiManaBar.value = playerMana;
        }
        #endregion
        
    }
}