using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using MMATW.Scripts.Scriptable_objects;
using UnityEngine;

namespace MMATW.Scripts.Player
{
    public class SpellManager : MonoBehaviour
    {
        [Header("Spells:")] 
        public SpellObject selectedSpell;
        [Space]
        public List<SpellObject> spells;

        [Header("Crafting")] 
        public List<SpellEssensegObject> craftingSlots;
        public List<SpellEssensegObject> essenseToUse;
        
        
        public void ClearSpell()
        {
            var l = craftingSlots.Count;
            for (int i = 0; i < l; i++) craftingSlots[i] = null;
        }

        public void AddEssense(SpellEssensegObject essense)
        {
            // Люблю лапшу... хочу лапшу....
            if (!craftingSlots[0]) craftingSlots[0] = essense;
            else if (!craftingSlots[1]) craftingSlots[1] = essense;
            else if (!craftingSlots[2]) craftingSlots[2] = essense;
            else print("All slots are filled!");
        }
    }
}
