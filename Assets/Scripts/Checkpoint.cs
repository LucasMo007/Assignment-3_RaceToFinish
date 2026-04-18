using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Update respawn point to this checkpoint
            Spikes[] allSpikes = FindObjectsByType<Spikes>(FindObjectsSortMode.None);
            foreach (Spikes spike in allSpikes)
            {
                spike.respawnPoint = transform;
            }
            Debug.Log("Checkpoint reached: " + gameObject.name);
        }
    }
}
