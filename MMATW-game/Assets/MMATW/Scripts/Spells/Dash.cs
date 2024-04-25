using MMATW.Scripts.Player;
using MMATW.Scripts.Scriptable_objects;
using UnityEngine;

namespace MMATW.Scripts.Spells
{
    public class Dash : SpellObject
    {
        
        public override void SpellAction(GameObject parent)
        {
            var playerMovement = parent.GetComponent<PlayerMovement>();
            
            // This realization is kinda cringe, but i don't care and won't rewrite it. I'm already lost my mind.
            playerMovement.Dash();
        }
    }
}