using UnityEngine;

public class TorqueTrap : MonoBehaviour
{
    public Vector3 torqueAxis = Vector3.up; 
    public float torqueForce = 50f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = false;
    }

    void FixedUpdate()
    {
        rb.AddTorque(torqueAxis * torqueForce);
    }
}
