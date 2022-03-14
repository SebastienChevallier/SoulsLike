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

    private Transform lockCible;
    public LayerMask mask;

    private bool islocked;


    private void FixedUpdate()
    {
        CameraRotation();
        

    }

    private void Update()
    {
        CameraLock();
    }

    void CameraRotation()
    {
        if (Input.GetAxis("JoystickHorizontal") > 0.01f || Input.GetAxis("JoystickVertical") > 0.01f || Input.GetAxis("JoystickHorizontal") < -0.01f || Input.GetAxis("JoystickVertical") < -0.01f)
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

    void CameraLock()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            RaycastHit hit;  

            // Cast a sphere wrapping character controller 10 meters forward
            // to see if it is about to hit anything.
            if (Physics.SphereCast(transform.position, 100, transform.forward, out hit, 50, mask))
            {
                lockCible = hit.transform;
                islocked = true;
            }
        }else if (islocked)
        {
            transform.LookAt(lockCible);
        }
        
    }
}
