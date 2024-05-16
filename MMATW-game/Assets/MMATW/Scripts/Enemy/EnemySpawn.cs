using System;
using System.Collections;
using UnityEngine;

{
    public class EnemySpawner : MonoBehaviour
    {
        public Transform[] spawnPosition;
        public GameObject[] enemyType;
        [SerializeField] private float spawnCooldown;
        [SerializeField] private int maxEnemiesOnMap;



        private void Start()
        {
            StartCoroutine(SpawnEnemy(maxEnemiesOnMap, spawnCooldown));
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator SpawnEnemy(int maxEnemiesOnMap, float spawnCooldown)
        {
            while (true) // Repeat indefinitely. 
            {
                if (playerStamina < maxStamina && !_movement.isWalking)
                {
                    RestoreStamina(regenAmount);
                }
                yield return new WaitForSeconds(spawnCooldown);
            }
        }
        {
            GameObject[] enemycount = GameObject.FindGameObjectsWithTag("Enemy");

            if (spawnCooldown.IsInCooldown && enemycount.Length > maxEnemiesOnMap) return;

            Instantiate(enemyType[Random.Range(0, enemyType.Length)], spawnPosition[Random.Range(0, spawnPosition.Length)]);
            spawnCooldown.StartCooldown();
        }
    }
}