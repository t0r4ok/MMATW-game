using UnityEngine;
using UnityEngine.SceneManagement;

namespace MMATW.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public GameObject pauseMenu;
        public GameObject mainManu;

        public void Quit()
        {
            Application.Quit();
        }

        public void StartGame()
        {
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
