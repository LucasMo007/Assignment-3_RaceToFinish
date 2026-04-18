using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Transform respawnPoint;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            
            collision.gameObject.transform.position = respawnPoint.position;
        }
    }
}
