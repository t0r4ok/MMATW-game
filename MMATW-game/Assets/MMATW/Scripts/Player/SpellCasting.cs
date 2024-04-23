using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMATW.Scripts.Player
{
    public class SpellCasting : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerAtributes _attributes;
        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _attributes = GetComponent<PlayerAtributes>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && _attributes.mana >= 40)
            {
                _playerMovement.Dash();
            }

            if (_attributes.mana < _attributes.maxMana)
            {
                _attributes.mana += _attributes.manaRegenerationSpeed;
            }

        }
    }

}