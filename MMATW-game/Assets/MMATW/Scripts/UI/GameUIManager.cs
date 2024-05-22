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
        [SerializeField] private Image uiSpellImage;
        
        [SerializeField] private Image uiEssenceImage0;
        [SerializeField] private Image uiEssenceImage1;
        
        private void Start() // Subscribing to events.
        {
            GlobalEventManager.OnHealthChange += UpdateHealthUI;
            GlobalEventManager.OnStaminaChange += UpdateStaminaUI;
            GlobalEventManager.OnManaChange += UpdateManaUI;
            GlobalEventManager.OnSpellChange += UpdateSpellUI;
            
            GlobalEventManager.OnEssenceChange0 += UpdateEssenceUI_First;
            GlobalEventManager.OnEssenceChange1 += UpdateEssenceUI_Second;
        }

        private void OnDestroy() // Unsubscribing from events.
        {
            GlobalEventManager.OnHealthChange -= UpdateHealthUI;
            GlobalEventManager.OnStaminaChange -= UpdateStaminaUI;
            GlobalEventManager.OnManaChange -= UpdateManaUI;
            GlobalEventManager.OnSpellChange -= UpdateSpellUI;
            
            GlobalEventManager.OnEssenceChange0 -= UpdateEssenceUI_First;
            GlobalEventManager.OnEssenceChange1 -= UpdateEssenceUI_Second;
        }


        #region PlayerStatUpdates
        private void UpdateHealthUI(int playerHealth)
        {
            if (uiHealthBar) uiHealthBar.value = playerHealth;;
        }
        
        private void UpdateStaminaUI(float playerStamina)
        {
            if (uiStaminaBar) uiStaminaBar.value = playerStamina;
        }
        
        private void UpdateManaUI(int playerMana)
        {
            if (uiManaBar) uiManaBar.value = playerMana;
        }

        private void UpdateSpellUI(Sprite img)
        {
            if (uiSpellImage) uiSpellImage.sprite = img;
        }

        // Sorry.
        private void UpdateEssenceUI_First(Sprite img)
        {
            if (uiEssenceImage0) uiEssenceImage0.sprite = img;
        }
        private void UpdateEssenceUI_Second(Sprite img)
        {
            if (uiEssenceImage1) uiEssenceImage1.sprite = img;
        }
        #endregion
        
    }
}