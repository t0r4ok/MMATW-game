using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MMATW.Scripts
{
    [SelectionBase]
    public class TestPlayerCOntroller : MonoBehaviour
    {
        
        [Header("References")] 
        private CharacterController _controller;
        
        
        
        public float gravity = -9.81f;
        
        // Movement Vars
        private Vector3 _inputs;
        private Vector3 _velocity;
        private bool _isGrounded;
        
        
        
        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            
        }
        
    }
}
