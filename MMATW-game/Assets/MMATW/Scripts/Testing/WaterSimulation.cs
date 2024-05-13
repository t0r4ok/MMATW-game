using MMATW.Scripts.Player;
using UnityEngine;

public class WaterSimulation: MonoBehaviour
{
    public float Density = 15;

    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            other.attachedRigidbody.AddForce(Vector3.up * Density);
        }
        /*PlayerMovement player = other.GetComponent<PlayerMovement>();
        float NewX = player.transform.position.x;
        float NewY = player.transform.position.y;
        float NewZ = player.transform.position.z;
        other.transform.position = new Vector3(NewX, NewY + 0.5f, NewZ);*/
    }
}

