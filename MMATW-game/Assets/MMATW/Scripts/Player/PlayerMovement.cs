using UnityEngine;

namespace MMATW.Scripts.Player
{
    [SelectionBase]
    public class PlayerMovement : MonoBehaviour
    {
        
        [Header("References")] 
        private CharacterController _controller;

        [Header("Preferences")]
        [Tooltip("Sets player speed. Remember that the speed will be multiplied by deltatime.")]
        public float playerSpeed = 5;
        public float playerSprintSpeed = 10;

        public float stamina = 200;
        public float staminaRegenerationSpeed = 0.25f;
        public float maxStamina = 200;

        public float jumpForce = 3;
        public float gravity = -9.81f;
        
        // Movement Vars
        public float rotationSpeed = 10;
        private Vector3 _inputs;
        private Vector3 _velocity;
        private bool _isGrounded;
        private float _horizontalRotation;
        private Vector3 _moveDirection;
        
        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move();
            Gravity();
            Rotation();
            
            _isGrounded = _controller.isGrounded;
        }

        private void Move()
        {
            _inputs = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            _moveDirection = _inputs * (Time.deltaTime * playerSpeed);
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
            {
                _moveDirection = _inputs * (Time.deltaTime * playerSprintSpeed);
                stamina -= 0.25f;
            }
            if(stamina < maxStamina && !Input.GetKey(KeyCode.LeftShift) && _isGrounded)
            {
                stamina += staminaRegenerationSpeed;
            }
            /*if (Input.GetKeyDown(KeyCode.Q) && stamina >= 100)
            {
                _moveDirection = _inputs * (Time.deltaTime * playerSprintSpeed * 125);
            }*/
            _controller.Move(_moveDirection);
        }
        private void Jump()
        {
            if (Input.GetKey(KeyCode.Space) && _isGrounded && stamina >= 20)
            {
                _velocity.y = -jumpForce;
                stamina -= 20;
            }
        }

        private void Gravity()
        {
            if (_isGrounded)
            {
                _velocity.y = 0;
            }
            Jump();
            _velocity.y -= gravity * Time.fixedDeltaTime;
            _controller.Move(Vector3.down * (_velocity.y * Time.fixedDeltaTime));
        }
        
        private void Rotation()
        {
            Quaternion newRotation;
            
            if (_inputs.sqrMagnitude == 0) return;
            
            newRotation = Quaternion.LookRotation(_moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
