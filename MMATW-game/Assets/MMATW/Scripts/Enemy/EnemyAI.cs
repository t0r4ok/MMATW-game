using System.Collections.Generic;
using MMATW.Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace MMATW.Scripts.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private bool _isPlayerNoticed;

        public List<Transform> patrolPoints;
        public PlayerMovement player;
        public PlayerAtributes playerAtributes;

        public float vievAngle;
        public int damage;

        private void Start()
        {
            InitComponentLinks();
            PickNewPatrolPoint();
        }

        private void InitComponentLinks()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            playerAtributes = GetComponent<PlayerAtributes>();
        }

        private void Update()
        {
            NoticePlayerUpdate();
            ChaseUpdate();
            PatrolUpdate();
        }

        private void ChaseUpdate()
        {
            if (_isPlayerNoticed)
            {
                _navMeshAgent.destination = player.transform.position;
            }
        }

        private void NoticePlayerUpdate()
        {
            var direction = player.transform.position - transform.position;
            _isPlayerNoticed = false;

            if (Vector3.Angle(transform.forward, direction) < vievAngle)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
                {
                    if (hit.collider.gameObject == player.gameObject)
                    {
                        _isPlayerNoticed = true;
                    }
                }
            }
        }

        private void PatrolUpdate()
        {
            if (_navMeshAgent.remainingDistance == 0)
            {
                if (!_isPlayerNoticed)
                {
                    PickNewPatrolPoint();
                }
            }
        }

        public void PickNewPatrolPoint()
        {
            _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
        }
    }
}
