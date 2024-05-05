using UnityEngine;

namespace MMATW.Scripts.Spells.Controllers
{
    public class ProjectileSpellController : MonoBehaviour
    {
        private Rigidbody _rb;
        
        
        
        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            _rb.AddForce(0, 0, 5);
        }
    }
}
