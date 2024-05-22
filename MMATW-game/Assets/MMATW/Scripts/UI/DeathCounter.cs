using TMPro;
using UnityEngine;

namespace MMATW.Scripts.UI
{
    public class DeathCounter : MonoBehaviour
    {
        public TextMeshProUGUI textMeshProUGUI;
        public int enemyDeath = 0;

        public void DrawUI()
        {
            textMeshProUGUI.text = enemyDeath.ToString();
        }
    }
}
