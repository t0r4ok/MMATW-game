using System;
using UnityEngine;

namespace MMATW.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Atributes")] 
        [SerializeField] private int playerHealth;
        [SerializeField] private int maxHealth = 100;

        private bool _isDashReady;
        private int _dashAmount;
        
        private void Awake()
        {
            playerHealth = maxHealth;
        }
    }
}
