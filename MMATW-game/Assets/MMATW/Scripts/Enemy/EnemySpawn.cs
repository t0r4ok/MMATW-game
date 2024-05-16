using System.Collections;
using UnityEngine;
using Random = System.Random;

{
    public class EnemySpawner : MonoBehaviour
    {
        public Transform[] spawnPosition;
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
            GameObject[] enemycount = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemycount.Length >= maxEnemiesOnMap) yield break;
            

            yield return new WaitForSeconds(spawnCooldown); // Cooldown
            
            
            Instantiate(enemyType[Random.Range(0, enemyType.Length)], spawnPosition[Random.Range(0, spawnPosition.Length)]);
        }
    }
}