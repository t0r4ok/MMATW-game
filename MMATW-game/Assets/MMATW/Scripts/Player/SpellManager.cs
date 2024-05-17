using System.Collections.Generic;
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
        public List<SpellEssenceObject> craftingSlots;
        public List<SpellEssenceObject> essenseToUse;

        
        public void ClearSpell()
        {
            var l = craftingSlots.Count;
            for (int i = 0; i < l; i++) craftingSlots[i] = null;
        }

        public void AddEssense(SpellEssenceObject essense)
        {
            // Люблю лапшу... хочу лапшу....
            if (!craftingSlots[0]) craftingSlots[0] = essense;
            else if (!craftingSlots[1]) craftingSlots[1] = essense;
            else print("All slots are filled!");

            SelectSpell();
        }

        
        // Sorry...
        private void SelectSpell()
        {
            int fireEssence = 0;
            int waterEssence = 0;
            int electroEssence = 0;

            
            foreach (var essence in craftingSlots)
            {
                if (essence == null) return;
                
                int eId = essence.essenceId;
                
                switch (eId)
                {
                    case 0:
                        fireEssence++;
                        break;
                    case 1:
                        waterEssence++;
                        break;
                    case 2:
                        electroEssence++;
                        break;
                }
                
                // Actual spell selection starts here!
                if (fireEssence == 2) selectedSpell = spells[0];
                if (waterEssence == 2) selectedSpell = spells[1];
                if (electroEssence == 2) selectedSpell = spells[3];
            }
        }
        
    }
}
