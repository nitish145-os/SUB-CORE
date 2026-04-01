using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSContrlooer : MonoBehaviour
{
    public float MouseSence = 100f;
    public Transform CarmaTranform;
    public Transform PayerBody;
    public bool isCarmaAvalible = true; 
    [HideInInspector] public float xRotation = 0f;

    public bool externalRotationLock = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (isCarmaAvalible && !externalRotationLock){
            float mouseX = Input.GetAxis("Mouse X") * MouseSence * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSence * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            CarmaTranform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            PayerBody.Rotate(Vector3.up * mouseX);
        }
        if (!isCarmaAvalible)
        {
            Cursor.lockState = CursorLockMode.None;
            
        }

    }
    public void ForceLookDirection(Vector3 worldDirection)
{
    worldDirection.Normalize();

    // Get target rotation in world space
    Quaternion targetRot = Quaternion.LookRotation(worldDirection);
    Vector3 euler = targetRot.eulerAngles;

    // ----- YAW (left/right) goes to player body -----
    float targetYaw = euler.y;
    PayerBody.rotation = Quaternion.Euler(0f, targetYaw, 0f);

    // ----- PITCH (up/down) goes to camera -----
    float targetPitch = euler.x;

    // Convert Unity 0-360 range to -180 to 180
    if (targetPitch > 180f) targetPitch -= 360f;

    targetPitch = Mathf.Clamp(targetPitch, -90f, 90f);
    xRotation = targetPitch;

    CarmaTranform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
}
}
