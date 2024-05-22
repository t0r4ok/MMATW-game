using System.Collections.Generic;
using MMATW.Scripts.Scriptable_objects;
using UnityEngine;

namespace MMATW.Scripts.Player
{
    /// <summary>
    /// Пожулау, напишу по-русски.
    /// Это спелл менеджер. тут находится вся логика выборка способностей персонажа. Если нужно добавить новое
    /// заклинание, то нужно вручную сдесь прописывать всю логику для его активации.
    /// </summary>
    ///
    /// Почему так всрато, криво, с костылями и лапшой вместо более адекватной реализации ? Потому что у меня нет
    /// времени сделать всё это в срок, а другие, судя по всему, вообще не понимаю, что за хрень я тут написал и
    /// как она работает. 
    
    
    public class SpellManager : MonoBehaviour
    {
        [Header("Spells:")] 
        public SpellObject selectedSpell;
        [Space]
        public List<SpellObject> spells;

        [Header("Crafting")] 
        public List<SpellEssenceObject> craftingSlots;
        public List<SpellEssenceObject> essenceToUse;

        private int _fireEssence = 0;
        private int _waterEssence = 0;
        private int _electroEssence = 0;
        
        // Clears spellcrafring slots and selected spells.
        public void ClearSpell()
        {
            var l = craftingSlots.Count;
            for (int i = 0; i < l; i++)
            {
                craftingSlots[i] = null;
            }

            selectedSpell = null;
            GlobalEventManager.OnSpellChange?.Invoke(null); // TODO: Add image for empty slot.
            GlobalEventManager.OnEssenceChange0?.Invoke(null); // TODO: Add image for empty slot.
            GlobalEventManager.OnEssenceChange1?.Invoke(null); // TODO: Add image for empty slot.

            _fireEssence = 0;
            _electroEssence = 0;
            _waterEssence = 0;

        }

        public void AddEssense(SpellEssenceObject essence)
        {
            switch (essence.essenceId)
            {
                case 0:
                    _fireEssence++;
                    break;
                case 1:
                    _waterEssence++;
                    break;
                case 2:
                    _electroEssence++;
                    break;
            }

            if (!craftingSlots[0])
            {
                craftingSlots[0] = essence;
                GlobalEventManager.OnEssenceChange0?.Invoke(essence.uiIcon);
            }
            else if (!craftingSlots[1])
            {
                craftingSlots[1] = essence;
                GlobalEventManager.OnEssenceChange1?.Invoke(essence.uiIcon);
            }
            else print("All slots are filled!");

            SelectSpell();
        }


        // Sorry...
        private void SelectSpell()
        {
            // Actual spell selection starts here!
            if (!craftingSlots[0] || !craftingSlots[1]) return;
            if (_fireEssence == 2)
            {
                selectedSpell = spells[0];
                GlobalEventManager.OnSpellChange?.Invoke(spells[0].uiIcon);
            }
            else if (_waterEssence == 2)
            {
                selectedSpell = spells[1];
                GlobalEventManager.OnSpellChange?.Invoke(spells[1].uiIcon);
            }
            else if (_electroEssence == 2)
            {
                selectedSpell = spells[2];
                GlobalEventManager.OnSpellChange?.Invoke(spells[2].uiIcon);
            }
            else
            {
                ClearSpell();
                print("Wrong craft!");
            }
        }
    }
}
