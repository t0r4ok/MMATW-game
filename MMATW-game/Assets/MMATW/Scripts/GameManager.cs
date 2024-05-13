using UnityEngine;
using UnityEngine.SceneManagement;

namespace MMATW.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public GameObject pauseMenu;
        public GameObject mainMenu;
        public GameObject settingsMenu;

        public GameObject mainManu;
        
        // TODO: Separate this GameManager to specific managers. Like SceneManager, GlobalEventManager and so on and so forth.
        // It's just that it can become somewhat problematic to work with, transferring it to other scenes, etc.
        
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
            if (!mainManu && Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(true);
            }
        }

        public void ExitToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
