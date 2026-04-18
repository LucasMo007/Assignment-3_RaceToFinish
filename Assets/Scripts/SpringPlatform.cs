using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    public float spring = 50f;
    public float damper = 5f;

    private SpringJoint springJoint;

    void Start()
    {
        
        GameObject anchor = new GameObject("SpringAnchor");
        anchor.transform.position = transform.position;
        Rigidbody anchorRb = anchor.AddComponent<Rigidbody>();
        anchorRb.isKinematic = true;

       
        springJoint = gameObject.AddComponent<SpringJoint>();
        springJoint.connectedBody = anchorRb;
        springJoint.spring = spring;
        springJoint.damper = damper;
        springJoint.minDistance = 0f;
        springJoint.maxDistance = 0.5f;
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.connectedAnchor = Vector3.zero;
        springJoint.anchor = Vector3.zero;
    }
}
