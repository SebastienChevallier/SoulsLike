using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCamera : MonoBehaviour
{
    [SerializeField]
    float sensitivityX = 8f;

    [SerializeField]
    float xRotation = 0f;


    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    [SerializeField] float minXClamp = 0f;

    public Transform lockCible;
    public LayerMask mask;
    public float camDistance;
    public LayerMask maskCam;
    public float lerpTime = 5f;
    public AnimationCurve curve;

    public bool islocked;


    private void FixedUpdate()
    {
        CameraRotation();
        CameraColision();
        

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
            transform.eulerAngles = targetRotation;
        }
    }

    void CameraLock()
    {
        if (Input.GetButtonDown("Lock"))
        {
            if (islocked)
            {
                islocked = false;
            }
            else
            {
                islocked = true;
            }
        }else if(islocked)
        {           
            transform.LookAt(lockCible.position);
        }
        
    }

    void CameraColision()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.forward, out hit, camDistance, maskCam))
        {            
            playerCamera.position = Vector3.Lerp(playerCamera.position, hit.point + playerCamera.forward * 0.1f, curve.Evaluate( Time.deltaTime * lerpTime));
        }
        else
        {
            playerCamera.localPosition = new Vector3(0f, 0, -6f);
        }
    }
}
