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
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if(player.gravity < 1.0f)
        {
            player.gravity += 0.05f;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        player.gravity = -1.5f;
    }
}

