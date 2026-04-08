using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public int keyLevel = 1; // 1 for first door, 2 for second door

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
