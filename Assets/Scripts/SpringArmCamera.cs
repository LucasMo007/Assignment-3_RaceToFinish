using UnityEngine;

public class SpringArmCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform target; 

    [Header("Spring Arm Settings")]
    public Vector3 offset = new Vector3(5f, 3f, 0f); 
    public float springArmLength = 8f;
    public float followLag = 5f; 

    [Header("Collision")]
    public float collisionBuffer = 0.3f;
    public LayerMask collisionLayers;

    private Vector3 currentVelocity;

    void LateUpdate()
    {
        if (target == null) return;

      
        Vector3 desiredPosition = target.position + offset.normalized * springArmLength;

      
        Vector3 direction = desiredPosition - target.position;
        RaycastHit hit;
        if (Physics.Raycast(target.position, direction.normalized, out hit, springArmLength, collisionLayers))
        {
            desiredPosition = hit.point - direction.normalized * collisionBuffer;
        }

        
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, 1f / followLag);

       
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
