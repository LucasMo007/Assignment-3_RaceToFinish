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
    //void LateUpdate()
    //{
    //    if (target == null) return;

    //    // --- 修改部分开始 ---
    //    // 不再使用固定的偏移方向，而是将 offset 乘以角色的旋转角度 (target.rotation)
    //    // 这样 offset 就会相对于角色旋转
    //    Vector3 rotatedOffset = target.rotation * offset;

    //    // 最终期望位置 = 角色位置 + 旋转后的偏移方向 * 臂长
    //    Vector3 desiredPosition = target.position + rotatedOffset.normalized * springArmLength;
    //    // --- 修改部分结束 ---

    //    // 剩下的射线检测（碰撞）和平滑跟随代码保持不变
    //    Vector3 direction = desiredPosition - target.position;
    //    RaycastHit hit;
    //    if (Physics.Raycast(target.position, direction.normalized, out hit, springArmLength, collisionLayers))
    //    {
    //        desiredPosition = hit.point - direction.normalized * collisionBuffer;
    //    }

    //    transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, 1f / followLag);

    //    // 始终注视角色稍微靠上的位置
    //    transform.LookAt(target.position + Vector3.up * 1.5f);
    //}
}
