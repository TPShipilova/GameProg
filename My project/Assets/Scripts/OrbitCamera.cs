// OrbitCamera.cs
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 20f;
    public float heightOffset = 3f;
    public float rotationSpeed = 100f;
    public float zoomSpeed = 50f;
    public float minDist = 5f, maxDist = 40f;

    private float currentX = 0f, currentY = 20f;

    void LateUpdate()
    {
        if (target == null) return;

        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            currentY = Mathf.Clamp(currentY, -80f, 80f);
        }
        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance, minDist, maxDist);

        Quaternion rot = Quaternion.Euler(currentY, currentX, 0);
        Vector3 dir = rot * Vector3.back;
        Vector3 targetPos = target.position + Vector3.up * heightOffset;
        transform.position = targetPos + dir * distance;
        transform.LookAt(targetPos);
    }
}