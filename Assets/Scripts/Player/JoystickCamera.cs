using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCamera : MonoBehaviour
{
    [SerializeField]
    float sensitivityX = 8f;
    [SerializeField]
    float sensitivityY = 0.5f;
    float xRotation = 0f;


    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    [SerializeField] float minXClamp = 0f;


    private void FixedUpdate()
    {      
        transform.Rotate(Vector3.up, Input.GetAxis("JoystickHorizontal") * sensitivityX * Time.deltaTime);
        xRotation += Input.GetAxis("JoystickVertical");
        xRotation = Mathf.Clamp(xRotation, minXClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        targetRotation.z = 0;
        playerCamera.eulerAngles = targetRotation;


    }


}
