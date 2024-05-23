using UnityEngine;

namespace MMATW.Scripts.UI
{
    public class MenuManager : MonoBehaviour
    {
        public GameObject pauseMenu;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!pauseMenu)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
