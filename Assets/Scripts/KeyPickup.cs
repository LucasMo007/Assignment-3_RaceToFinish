using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public int keyLevel = 1; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerKeys playerKeys = other.GetComponentInParent<PlayerKeys>();
            if (playerKeys != null)
            {
                playerKeys.AddKey(keyLevel);
                Destroy(gameObject);
            }
        }
    }
}
