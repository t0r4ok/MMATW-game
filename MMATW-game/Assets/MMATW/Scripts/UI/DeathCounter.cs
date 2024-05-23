using UnityEngine;
using UnityEngine.SceneManagement;

namespace MMATW.Scripts.UI
{
    public class DeathCounter : MonoBehaviour
    {
        public int enemyDeathsToWin = 15;

        public GameUIManager gameUIManager;

        public void SetCounter()
        {
            gameUIManager = GetComponent<GameUIManager>();
        }

        public void Update()
        {
            if(gameUIManager.enemyDeaths >= enemyDeathsToWin)
            {
                SceneManager.LoadScene("WinScene");
            }
        }
    }
}
