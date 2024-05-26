using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.MMATW.Scripts.UI
{
    public class BackToMenuBTN : MonoBehaviour
    {
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}