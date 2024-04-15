using UnityEngine;

namespace MMATW.Scripts
{
    public class TestPlayerCOntroller : MonoBehaviour
    {
        [Header("PLAYER STATS")] public int enemiesKilled = 0;
        [SerializeField] private int playerHealth;
        [SerializeField] private int maxPlayerHealth = 100;
        public bool isPlayerDead;

        [Header("INPUT / MOVEMENT")] public float movementSpeed;
        public float rotationSpeed;
        public float sprintMultiplier = 1f;
        public Transform lookTargetObject;
        public Transform aimLookTargetObject;

        [SerializeField] private float gravityValue = -9.81f;
        private CharacterController _controller;
        private bool _isWalking;
        private bool _isSprinting;
        private Vector3 _gravity;
        private bool _isPlayerGrounded;
        private Vector3 _moveDirection;
        private Vector3 _verticalDirection;

        [Header("CAMERA / AIMING")] private Quaternion _lookRotation;
        private float _initialFov;
        private Vector2 _mouseInput;
        private bool _isAiming;
        public float mouseSensetivity;

        [Header("CLAMP RANGES")] public float verticalMinRange;
        public float verticalMaxRange;
        private float _verticalRotation;
        private float _horizontalRotation;

        [Header("Shooting")] public GameObject projectileSpawner;
        [Space] public GameObject[] spellsList;
        [Space] public CoolDown castDelay;

        // [Header("ANIMATIONS")]
        // private Animator _animator;
        // private int _isWalkingHash;
        // private int _isJumpingHash;
        // private Vector2 _inputVector2;
        // private static readonly int IsWalking = Animator.StringToHash("isWalking");
        // private static readonly int IsJumping = Animator.StringToHash("isJumping");

        // [Header("AUDIO")]
        // private AudioSource _spellCasterSRC;


        // [Header("UI")] 
        // public GameObject gameUI;
        // public GameObject deathUI;

        // [SerializeField] private GameObject uiCroshair;
        // [SerializeField] private Slider uiHealthbar;



        private void Awake()
        {
            //_gameInput = new GameInput();

            // Get components
            _controller = GetComponent<CharacterController>();


            //     #region InputSystem stuff
            //     // Movement & Keyboard inputs
            //     _gameInput.Player.Movement.performed += ctx =>
            //     {
            //         _inputVector2 = ctx.ReadValue<Vector2>();
            //         _isMovePressed = true;
            //     };
            //     _gameInput.Player.Movement.canceled += ctx =>
            //     {
            //         _inputVector2 = Vector2.zero;
            //         _isMovePressed = false;
            //     };
            //     
            //     
            //     // Jumping
            //     _gameInput.Player.Jump.performed += JumpHandler;
            //     
            //     // Mouse inputs
            //     _gameInput.Camera.Mouse.performed += ctx => _mouseInput = ctx.ReadValue<Vector2>();
            //     _gameInput.Camera.Mouse.canceled += ctx => _mouseInput = Vector2.zero;
            //
            //     _gameInput.Player.Aiming.performed += ctx =>
            //     {
            //         _isAiming = true;
            //     };
            //     _gameInput.Player.Aiming.canceled += ctx =>
            //     {
            //         _isAiming = false;
            //     };
            //
            //     // Shooting
            //     _gameInput.Player.Shoot.performed += CastProjectile;
            //     #endregion
            // }

            void Start()
            {
                _gravity = new Vector3(0f, gravityValue, 0f);
                playerHealth = maxPlayerHealth;

                //SetHealthBar(playerHealth);
            }

            // private void OnEnable()
            // {
            //     _gameInput.Player.Enable();
            //     _gameInput.Camera.Enable();
            // }
            // private void OnDisable()
            // {
            //     _gameInput.Player.Disable();
            //     _gameInput.Camera.Disable();
            // }


            void Update()
            {
                Move();
                //Aiming();
                //Rotation();
                LookTargetRotation();

                // Gravity.
                if (_isPlayerGrounded && _verticalDirection.y < 0)
                {
                    _verticalDirection.y = -1f;
                }

                _verticalDirection.y += gravityValue * Time.fixedDeltaTime;

                // Move player.
                _controller.Move(_verticalDirection * Time.deltaTime);
            }

            void Move()
            {
                _isPlayerGrounded = _controller.isGrounded;

                var _inputVectorX = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));


                _moveDirection = Quaternion.Euler(0, lookTargetObject.transform.eulerAngles.y, 0) *
                                 new Vector3(_inputVectorX.x, 0f, _inputVectorX.y);
                _controller.Move(_moveDirection * (movementSpeed * Time.deltaTime));

                // #region MovementAnimations
                // _isWalking = _animator.GetBool(IsWalking);
                //
                //
                // if (!_isWalking && _isMovePressed)
                // {
                //     _animator.SetBool(IsWalking, true);
                // }
                //
                // if (_isWalking && !_isMovePressed)
                // {
                //     _animator.SetBool(IsWalking, false);
                // }

                // STOP JUMPING! AЪАЪАЪАЪ
                // if (_verticalDirection.y <= 0) _animator.SetBool(IsJumping, false);
                // #endregion
            }

            void LookTargetRotation()
            {
                _verticalRotation += -_mouseInput.y * mouseSensetivity * Time.deltaTime;
                _horizontalRotation += _mouseInput.x * mouseSensetivity * Time.deltaTime;
                var angles = lookTargetObject.transform.localEulerAngles;
                angles.z = 0;

                // Be careful, very scary and disgusting construction below:
                float verticalRotation = Mathf.Clamp(_verticalRotation, verticalMinRange, verticalMaxRange);
                if (_verticalRotation > verticalMaxRange)
                {
                    _verticalRotation = verticalMaxRange;
                }

                if (_verticalRotation < verticalMinRange)
                {
                    _verticalRotation = verticalMinRange;
                }

                _lookRotation = Quaternion.Euler(0, lookTargetObject.transform.rotation.y, 0);

                lookTargetObject.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
                lookTargetObject.transform.rotation = Quaternion.Euler(verticalRotation, _horizontalRotation, 0);

                aimLookTargetObject.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
                aimLookTargetObject.transform.rotation = Quaternion.Euler(verticalRotation, _horizontalRotation, 0);
            }

            // void Rotation()
            // {
            //     Quaternion newRotation;
            //     
            //     if (_isAiming)
            //     {
            //         Quaternion yAxis = Quaternion.Euler(0, _horizontalRotation, 0);
            //         newRotation = Quaternion.Slerp(transform.rotation, yAxis,
            //             Time.deltaTime * rotationSpeed); // Rotate in camera look direction while aiming.
            //         transform.rotation = newRotation;
            //     }
            //     else
            //     {
            //         if (_inputVector2.sqrMagnitude == 0) return; // if player is moving.
            //         newRotation = Quaternion.LookRotation(_moveDirection);
            //         transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
            //     }
            // }

            // void Aiming()
            // {
            //     // Manipulations with camera FOV.
            //     // TODO: Add smoothing.
            //     if (_isAiming)
            //     {
            //         cinemachineCamera.m_Lens.FieldOfView = _initialFov - 15;
            //         cinemachineCamera.Follow = aimLookTargetObject;
            //         uiCroshair.SetActive(true);
            //         
            //         projectileSpawner.SetActive(true);
            //         
            //     }
            //     else
            //     {
            //         cinemachineCamera.m_Lens.FieldOfView = _initialFov;
            //         cinemachineCamera.Follow = lookTargetObject;
            //         uiCroshair.SetActive(false);
            //         
            //         projectileSpawner.SetActive(false);
            //     }
            // }

            void CastProjectile()
            {
                var spawnTransform = projectileSpawner.transform;
                var spawnPos = spawnTransform.position;
                var spawnPosRotation = spawnTransform.rotation;

                if (Input.GetMouseButtonDown(0))
                {
                    castDelay.StartCooldown();
                    //_spellCasterSRC.Play();
                    Instantiate(spellsList[0], spawnPos, spawnPosRotation); // Just a template for adding more spells.
                }
            }


            #region Outside interactions

            // There is methods that can be initiated from outside. Like takeing damage or healing.
            void TakeDamage(int damage)
            {
                playerHealth -= damage;
                //SetHealthBar(playerHealth);


                if (playerHealth <= 0)
                {
                    KillPlayer();
                }
            }

            void HealHealth(int healamount)
            {
                if (playerHealth <= 0) return;
                if (playerHealth >= 100) return;

                playerHealth += healamount;
                //SetHealthBar(playerHealth);
            }

            #endregion

            // void SetHealthBar(int health)
            // {
            //     uiHealthbar.value = health;
            // }
            //
            void KillPlayer()
            {
                print("PLAYER ARE DEAD!");
                isPlayerDead = true;

                // gameUI.SetActive(false);
                // deathUI.SetActive(true);
                //
                // _gameInput.Player.Disable();
                //
                // _controller.enabled = false;
                // cinemachineCamera.enabled = false;
            }
        }
    }
}
