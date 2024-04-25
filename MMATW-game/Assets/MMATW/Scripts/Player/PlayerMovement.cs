using UnityEngine;

namespace MMATW.Scripts.Player
{
    [SelectionBase]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerAtributes))]
    [RequireComponent(typeof(PlayerActions))]
    public class PlayerMovement : MonoBehaviour
    {

        [Header("References")]
        private CharacterController _controller;
        private PlayerAtributes _attributes;
        [Header("Preferences")]
        [Tooltip("Sets player speed. Remember that the speed will be multiplied by deltatime.")]
        public float playerSpeed = 5;
        public float playerSprintSpeed = 10;

        public float jumpForce = 3;
        public float gravity = -9.81f;

        [Header("Movement Vars:")]
        public float rotationSpeed = 10;
        public bool isWalking;
        [HideInInspector] public bool isGrounded;
        private Vector3 _inputs;
        private Vector3 _velocity;
        private float _horizontalRotation;
        private Vector3 _moveDirection;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _attributes = GetComponent<PlayerAtributes>();
        }

        private void Update()
        {
            Move();
            Gravity();
            Rotation();

            isGrounded = _controller.isGrounded;

            
            // don't look at this!
            if (!isWalking && _inputs.sqrMagnitude >= 0.19f)
            {
                isWalking = true;
            }
            if (isWalking && _inputs.sqrMagnitude <= 0.19f )
            {
                isWalking = false;
            }
        }

        private void Move()
        {
            _inputs = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            _moveDirection = _inputs * (Time.deltaTime * playerSpeed);
            
            // sprint
            if (Input.GetKey(KeyCode.LeftShift) && _attributes.stamina > 0)
            {
                _moveDirection = _inputs * (Time.deltaTime * playerSprintSpeed);
                _attributes.stamina -= 5;
            }
            
            _controller.Move(_moveDirection);
        }
        public void Dash()
        {
            _moveDirection = _inputs * (Time.deltaTime * playerSprintSpeed * 125);
            _attributes.mana -= 40;
            _controller.Move(_moveDirection);
        }
        private void Jump()
        {
            if (Input.GetKey(KeyCode.Space) && isGrounded && _attributes.stamina >= 20)
            {
                _velocity.y = -jumpForce;
                _attributes.stamina -= 20;
            }
        }

        private void Gravity()
        {
            if (isGrounded)
            {
                _velocity.y = 0;
            }
            Jump(); // Why do we just jump all of a sudden ? Well, screw it, I don't care as long as it works. 
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
