using UnityEngine.AI;
using UnityEngine;
using System.Collections.Generic;

namespace MMATW.Scripts.Player
{
    public class EnemyAI : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private bool _isPlayerNoticed;

        public List<Transform> patrolPoints;
        public PlayerMovement player;
        public PlayerAtributes playerAtributes;

        public float vievAngle;
        public bool _isVisible;
        public int damage;
        public float attackColldown;
        private float _attackColldown;

        private void Start()
        {
            _attackColldown = attackColldown;
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
            _attackColldown -= Time.deltaTime;
            NoticePlayerUpdate();
            ChaseUpdate();
            PatrolUpdate();
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out PlayerMovement playerMovement))
            {
                if (_isVisible)
                {
                    if (_attackColldown <= 0)
                    {
                        playerAtributes.DamagePlayer(damage);
                        _attackColldown = attackColldown;
                    }
                }
            }
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
            _isVisible = false;

            if (Vector3.Angle(transform.forward, direction) < vievAngle)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
                {
                    if (hit.collider.gameObject == player.gameObject)
                    {
                        _isPlayerNoticed = true;
                        _isVisible = true;
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
