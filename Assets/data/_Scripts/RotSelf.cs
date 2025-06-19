using UnityEngine;

public class RotSelf : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up;  // 旋转轴，默认绕Y轴
    public float rotationSpeed = 45f;          // 旋转速度（度/秒）

    void Update()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime, Space.World);
    }
}
