using MMATW.Scripts.Player;
using MMATW.Scripts.UI;
using UnityEngine;

namespace MMATW.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public int value = 100;
        private float _currentValue;

        private PlayerMovement _playerMovement;
        private DeathCounter _deathCounter;
        private void Start()
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _currentValue = value;
        }
        public void TakeDamage(int damage)
        {
            _currentValue -= damage;
            if (_currentValue <= 0)
            {
                _deathCounter.enemyDeath += 1;
                Destroy(gameObject);
                _deathCounter.DrawUI();
            }
        }
    }
}