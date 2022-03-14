using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed;
    public float jumpForce;
    public float moveMultiply;

    public int Base_PV = 100;
    public int Actual_PV = 100;

    public int Base_Stamina = 100;
    public int Actual_Stamina = 100;
    public float rotationSpeed;
    public float rollForce;
    private Animator animPerso;
    public bool canMove = true;
    public bool isInvincible = false;
    public bool canRotate = true;
    public AnimationCurve curve;
    public GameObject weapon;

    public List<GameObject> weapons;
    public string weaponType;

    
    [SerializeField] float acceleration = 10f;
    public float tauxGrav = 0.1f;




    //other Variables
    Rigidbody rb;
    public Transform mainCamera;
    public bool isGrounded = false;
    public Vector3 movDir;
    private float activeGrav;

    private Quaternion target;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animPerso = transform.GetChild(0).GetComponent<Animator>();
        CheckWeapon();
    }

    private void FixedUpdate()
    {
        if(animPerso.GetCurrentAnimatorStateInfo(0).IsName("Slash1") || animPerso.GetCurrentAnimatorStateInfo(0).IsName("Slash2") || animPerso.GetCurrentAnimatorStateInfo(0).IsName("Slash3"))
        {
            rotationSpeed = 2;
        }
        else
        {
            rotationSpeed = 25;
        }

        Move();
        rb.velocity += new Vector3(0, Physics.gravity.y * tauxGrav * Time.deltaTime, 0);
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, -transform.up, 0.1f);
        SetDir();
        ControlSpeed();
        jumpLogic();
        Roll();
        Slash();
    }
    private void SetDir()
    {
        activeGrav = 9.8f;
        Vector3 mouveY = mainCamera.forward * Input.GetAxis("Vertical");
        Vector3 mouveX = mainCamera.right * Input.GetAxis("Horizontal");        
        movDir = mouveX + mouveY;
        
        animPerso.SetFloat("Blend", movDir.magnitude);

        if (movDir != Vector3.zero && canRotate)
        {
            target = Quaternion.LookRotation(new Vector3(movDir.x * 60.0f, 0f, movDir.z * 60.0f));
        }
        
    }

    void ControlSpeed()
    {
        walkSpeed = Mathf.Lerp(walkSpeed, walkSpeed, acceleration * Time.deltaTime);
    }

    private void Move()
    {
        if (isGrounded && canMove)
        {
            //rb.AddForce(movDir.normalized * walkSpeed * movementMultiplier, ForceMode.Acceleration);
            rb.velocity = new Vector3(movDir.x * walkSpeed, 0, movDir.z * walkSpeed);
        }
        if(movDir != Vector3.zero && canRotate)
        {
            transform.GetChild(0).rotation = Quaternion.Slerp(transform.GetChild(0).rotation, target, Time.deltaTime * rotationSpeed);
        }
            
    }

    void jumpLogic()
    {        
        if (isGrounded && Input.GetButtonDown("Fire1"))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
            animPerso.Play("Jump");
        }
    }

    private float currentTime = 0;
    private float delayToMove = 1;

    void Roll()
    {
        if (Input.GetButtonDown("Jump") && canMove)
        {             
            animPerso.Play("Roll");
            currentTime = 0;
        }

        currentTime += Time.deltaTime;
        float percent = currentTime / delayToMove;

        if (!canMove)
        {            
            //curve.Evaluate(percent)
            transform.position = Vector3.Lerp(transform.GetChild(0).position, transform.GetChild(0).position + transform.GetChild(0).forward * rollForce, curve.Evaluate(percent));
        }
    }

    private float delayTime = 1.5f;
    private int compteurCombo = 0;
    void Slash()
    {    
        if (Input.GetButtonDown("Fire2") && canMove)
        {
            if (delayTime < Time.time)
            {
                compteurCombo = 0;
            }
            
            
            delayTime = Time.time + 1.5f;
            compteurCombo++;

            if(compteurCombo == 1)
            {
                animPerso.Play("Slash1");
            }else if(compteurCombo == 2)
            {
                animPerso.Play("Slash2");
            }
            else
            {
                animPerso.Play("Slash3");
                compteurCombo = 0;
            }
            Debug.Log(delayTime);
            Debug.Log(Time.unscaledTime);

        }
    }
       

    public void CanMove()
    {
        canMove = true;        
    }
    public void CantMove()
    {       
        canMove = false;      
    }

    public void CantRotate()
    {
        canRotate = false;
        
    }
    public void CanRotate()
    {
        canRotate = true;
    }

    public void Invincible()
    {
        isInvincible = true;
    }
    public void vincible()
    {
        isInvincible = false;
    }

    void CheckWeapon()
    {
        foreach(GameObject obj in weapons)
        {
            if (obj.CompareTag(weaponType))
            {
                obj.SetActive(true);
                obj.GetComponent<Weapon>().ChangeAnimator();
            }
            else
            {
                obj.SetActive(false);
            }
        }
    }

}
