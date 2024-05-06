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
        public bool _isVisible;

        public float boostSpeed;
        public float boostDistance;

        public int damage;
        public float attackColldown;
        private float _attackColldown;

        
        // This script may not work or work with bugs. Will need to be tested.
        
        enum BehaviourMode
        {
            SearchForPlayer,
            AlwaysChasePlayer
        }
        
        
        private void Start()
        {
            _attackColldown = attackColldown;
            InitComponentLinks();
            PickNewPatrolPoint();
        }

        private void InitComponentLinks()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            playerAtributes = GetComponent<PlayerAttributes>();
        }

        private void Update()
        {
            _attackColldown -= Time.deltaTime;
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
            ChaseUpdate();
            PatrolUpdate();
            BoostSpeedUpdate();
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
            if (_isPlayerNoticed) return;
            
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
            if (!_isPlayerNoticed && _navMeshAgent.remainingDistance == 0)
            {
                PickNewPatrolPoint();
            }
        }

        public void PickNewPatrolPoint()
        {
            _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
        }
        private void BoostSpeedUpdate()
        {
            _navMeshAgent.speed = 5;
            if (_isPlayerNoticed)
            {
                _navMeshAgent.destination = player.transform.position;
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance > boostDistance)
                {
                    _navMeshAgent.speed = boostSpeed;
                }
            }

        }
    }
}
