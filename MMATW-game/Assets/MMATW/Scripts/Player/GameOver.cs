using UnityEngine.SceneManagement;
using UnityEngine;

namespace MMATW.Scripts.Player
{
    public class GameOver : MonoBehaviour
    {
        private PlayerAttributes _playerAttributes;

        public bool _gameOverSceneIsOpen;

        void Start()
        {
            _playerAttributes = GetComponent<PlayerAttributes>();
        }

        void Update()
        {
            if (_playerAttributes.playerHealth <= 0)
            {
                _gameOverSceneIsOpen = true;
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
}
