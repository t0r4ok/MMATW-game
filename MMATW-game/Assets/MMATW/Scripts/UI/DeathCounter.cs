using TMPro;
using UnityEngine;

namespace MMATW.Scripts.UI
{
    public class DeathCounter : MonoBehaviour
    {
        public int enemyDeaths = 0;

        public void SetCounter()
        {   
            
        }
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
