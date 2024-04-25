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
        
        private void Awake()
        {
            GlobalEventManager.OnHealthChange.AddListener(UpdateHealthUI);
            GlobalEventManager.OnManaChange.AddListener(UpdateStaminaUI);
            GlobalEventManager.OnStaminaChange.AddListener(UpdateManaUI);
        }


        #region PlayerStatUpdates
        private void UpdateHealthUI(int playerHealth)
        {
            if (uiHealthBar) uiHealthBar.value = playerHealth;;
            
        }
        private void UpdateStaminaUI(int playerStamina)
        {
            if (uiStaminaBar) uiStaminaBar.value = playerStamina;
        }
        private void UpdateManaUI(int playerMana)
        {
            if (uiManaBar) uiStaminaBar.value = playerMana;
        }

        

        #endregion
        
    }
}