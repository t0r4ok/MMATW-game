using MMATW.Scripts.UI;
using UnityEngine;

namespace MMATW.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int maxValue = 100;
        private float _currentValue;
        
        
        private void Start()
        {
            _currentValue = maxValue;
        }
        public void TakeDamage(int damage)
        {
            _currentValue -= damage;
            if (_currentValue <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            GlobalEventManager.onEnemyDeath?.Invoke(1);
            Destroy(gameObject);
        }
    }
}