using UnityEngine;
using UnityEngine.SceneManagement;

namespace MMATW.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Texture2D cursor;

        public GameObject pauseMenu;
        public GameObject mainMenu;
        public GameObject settingsMenu;

        public GameObject mainManu;
        
        
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
