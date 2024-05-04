using System.Collections.Generic;
using MMATW.Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace MMATW.Scripts.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [Header("Base settings:")]
        [SerializeField] private BehaviourMode behaviourMode;
        
        
        [Header("Properties:")]
        private NavMeshAgent _navMeshAgent;
        private bool _isPlayerNoticed;

        public List<Transform> patrolPoints;
        public PlayerMovement player;
        public PlayerAttributes playerAtributes;

        public float vievAngle;
        public int damage;

        enum BehaviourMode
        {
            SearchForPlayer,
            AlwaysChasePlayer
        }
        
        
        private void Start()
        {
            InitComponentLinks();
            PickNewPatrolPoint();
        }

        private void InitComponentLinks()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            EnemyLogicMain();
        }
        
        private void EnemyLogicMain()
        {
            switch (behaviourMode) // I hope this will work...
            {
                case BehaviourMode.AlwaysChasePlayer:
                    _navMeshAgent.destination = player.transform.position;
                    break;
                case BehaviourMode.SearchForPlayer:
                    SearchForPlayer();
                    break;
            }
        }

        private void SearchForPlayer()
        {
            NoticePlayerUpdate();
            PatrolUpdate();
        }
        
        
        private void NoticePlayerUpdate()
        {
            if (_isPlayerNoticed) return;
            
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
            if (!_isPlayerNoticed && _navMeshAgent.remainingDistance == 0)
            {
                PickNewPatrolPoint();
            }
        }

        public void PickNewPatrolPoint()
        {
            _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
        }
    }
}
