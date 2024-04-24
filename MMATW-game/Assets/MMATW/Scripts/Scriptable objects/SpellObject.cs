using UnityEditor.SceneManagement;
using UnityEngine;

namespace MMATW.Scripts.Scriptable_objects
{
    [CreateAssetMenu(menuName = "Spell", fileName = "New Spell")]
    public class SpellObject : ScriptableObject
    {
        [Header("Properties:")]
        [SerializeField] private new string name;
        [SerializeField] private string description;
        [SerializeField] private GameObject prefab;
        
        [SerializeField] private Sprite uiIcon;

        [Header("Casting costs:")]
        [SerializeField] private int manaCost = 5;
        [SerializeField] private int staminaCost;
        [SerializeField] private int healthCost;

        [SerializeField] private int contactDamage;
        [SerializeField] private int lifeDuration;
    }
}