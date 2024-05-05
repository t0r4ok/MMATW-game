using UnityEngine;

namespace MMATW.Scripts.Spells.Controllers
{
    public class ProjectileSpellController : MonoBehaviour
    {
        private Rigidbody _rb;
        
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
        
        void Update()
        {
            _rb.AddForce(0, 0, 5);
        }
    }
}
