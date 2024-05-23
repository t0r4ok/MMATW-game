using System.Collections;
using UnityEngine;


namespace MMATW.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public Transform[] spawnPosition;
        public Transform[] patrolPoints;

        
        public GameObject[] enemyType;
        [SerializeField] private float spawnCooldown;
        [SerializeField] private int maxEnemiesOnMap;
        
        private void Start()
        {
            StartCoroutine(SpawnEnemy(spawnCooldown));
        }

        // TODO: Добавить более адыкватную проверку на кол-во врагов. решарпер ругается.
        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator SpawnEnemy(float spawnCooldown)
        {
            while (true) // Infinite loop to keep spawning enemies
            {
                GameObject[] enemycount = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemycount.Length >= maxEnemiesOnMap)
                {
                    Debug.Log($"Too many enemies to spawn more! Current amount is: {enemycount.Length}");
                }
                else
                {
                    // Spawn a new enemy
                    Instantiate(enemyType[Random.Range(0, enemyType.Length)],
                        spawnPosition[Random.Range(0, spawnPosition.Length)].position,
                        Quaternion.identity);

                    Debug.Log($"Spawned enemy. Current amount: {enemycount.Length + 1}");
                }

                yield return new WaitForSeconds(spawnCooldown); // Cooldown before next spawn check
            }
        }
    }
}