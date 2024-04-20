using UnityEngine;
using UnityEngine.SceneManagement;

namespace MMATW.Scripts.Player
{
    public class GameManager : MonoBehaviour
    {
        public PlayerMovement player;
        public EnemyAI enemy;

        public GameObject pauseMenu;
        public GameObject mainManu;

        public void Quit()
        {
            Application.Quit();
        }

        public void StartGame()
        {
            enemy = GetComponent<EnemyAI>();
            player = GetComponent<PlayerMovement>();
            SceneManager.LoadScene("SampleScene");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!mainManu)
                {
                    pauseMenu.SetActive(true);
                }
            }
        }

        public void ExitToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
