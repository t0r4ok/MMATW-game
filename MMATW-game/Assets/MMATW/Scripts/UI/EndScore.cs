using TMPro;
using UnityEngine;

namespace MMATW.Scripts.UI
{
    public class EndScore : MonoBehaviour
    {
        public GameUIManager gameUIManager;
        [SerializeField] private TextMeshProUGUI uiEndScore;
        void Start()
        {
            gameUIManager = FindObjectOfType<GameUIManager>();
            uiEndScore.text = gameUIManager.enemyDeaths.ToString();

        }
    }
}