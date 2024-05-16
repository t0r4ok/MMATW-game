using UnityEngine;

namespace MMATW.Scripts.Player
{
    public class SpellCaster : MonoBehaviour
    {
        public Transform targetPoint;

        void Update()
        {
            SetTargetPos();
            
            
        }

        private void SetTargetPos()
        {
            var startPos = transform.position;
            var endPos = transform.up * 10; 
            Debug.DrawRay (startPos, endPos);
            
            RaycastHit hit;
            if (Physics.Raycast(startPos, endPos, out hit))
            {
                targetPoint.position = hit.point;
            }
        }
        
        
        
    }
}