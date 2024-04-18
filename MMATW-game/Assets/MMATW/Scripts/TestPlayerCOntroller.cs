using UnityEngine;
using UnityEngine.EventSystems;

namespace MMATW.Scripts
{
    [SelectionBase]
    public class TestPlayerCOntroller : MonoBehaviour
    {
        
        [Header("References")] 
        private CharacterController _controller;

        [Header("Preferences")]
        [Tooltip("Sets player speed. Remember that the speed will be multiplied by deltatime.")]
        public float playerSpeed = 2;
        public float playerSprintSpeed = 4;
        public float stamina = 200;
        
        
        
        public float gravity = -9.81f;
        
        // Movement Vars
        public float rotationSpeed = 3;
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
            if(stamina < 200 && !Input.GetKey(KeyCode.LeftShift))
            {
                stamina += 0.25f;
            }
            _controller.Move(_moveDirection);
        }

        private void Gravity()
        {
            if (_isGrounded)
            {
                _velocity.y = 0;
            }
            _velocity.y -= gravity * Time.fixedDeltaTime;
            _controller.Move(Vector3.down * _velocity.y * Time.fixedDeltaTime);
        }
        
        private void Rotation()
        {
            Quaternion newRotation;
            newRotation = Quaternion.LookRotation(_moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
