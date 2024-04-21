using UnityEngine;
using UnityEngine.SceneManagement;

namespace MMATW.Scripts.Player
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Texture2D cursor;

        public GameObject pauseMenu;
        public GameObject mainMenu;
        public GameObject settingsMenu;

        private void Start()
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        }

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
                if (!mainMenu)
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
