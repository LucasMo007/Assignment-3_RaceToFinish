using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Transform respawnPoint;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reset velocity
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Teleport to respawn point
            collision.gameObject.transform.position = respawnPoint.position;
        }
    }
}
