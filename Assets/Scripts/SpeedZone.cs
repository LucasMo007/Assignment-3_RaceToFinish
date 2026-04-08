using UnityEngine;

public class SpeedZone : MonoBehaviour
{
    public float speedMultiplier = 2f; // >1 for speed up, <1 for slow down

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<PlayerMovement>().SetSpeedMultiplier(speedMultiplier);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<PlayerMovement>().SetSpeedMultiplier(1f);
            Debug.Log("Exited speed zone, reset to 1");
        }
    }
}
