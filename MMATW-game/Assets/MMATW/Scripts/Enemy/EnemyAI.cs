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

        public Transform[] patrolPoints;
        public PlayerAttributes player;

        public float viewAngle;
        public bool isVisible;

        public float boostSpeed;
        public float boostDistance;

        public int damage;
        public float attackColldown;
        private float _attackColldown;

        public Animator animator;
        private static readonly int AnimIsMoving = Animator.StringToHash("Is Moving");
        private static readonly int AnimIsAttack = Animator.StringToHash("Is Attack");


        // This script may not work or work with bugs. Will need to be tested.

        private enum BehaviourMode
        {
            SearchForPlayer,
            AlwaysChasePlayer
        }
        
        
        private void Start()
        {
            if (!player) player = (PlayerAttributes)FindObjectOfType(typeof(PlayerAttributes));

            if (patrolPoints == null)
            {
                var spawner = FindObjectOfType<EnemySpawner>();
                patrolPoints = spawner.patrolPoints;
            }
            
            _attackColldown = attackColldown;
            InitComponentLinks();
            PickNewPatrolPoint();
        }

        private void InitComponentLinks()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            _attackColldown -= Time.deltaTime;
            animator.SetBool(AnimIsMoving, true);
            if (_navMeshAgent.isStopped)
            {
                animator.SetBool(AnimIsMoving, false);
            }
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
            animator.SetBool(AnimIsAttack, false);
            if (other.TryGetComponent(out PlayerMovement playerMovement))
            {
                if (isVisible)
                {
                    if (_attackColldown <= 0)
                    {
                        player.DamagePlayer(damage);
                        _attackColldown = attackColldown;
                        animator.SetBool(AnimIsAttack, true);
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
            isVisible = false;

            if (Vector3.Angle(transform.forward, direction) < viewAngle)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
                {
                    if (hit.collider.gameObject == player.gameObject)
                    {
                        _isPlayerNoticed = true;
                        isVisible = true;
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
            _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Length)].position;
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
