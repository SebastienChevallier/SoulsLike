using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed;
    public float jumpForce;
    public float moveMultiply;
    [SerializeField] float acceleration = 10f;

    [Header("Character Settings")]
    public SO_Player playerStats;
    public int costSlash;
    public int costJump;
    public int costRoll;
    public int costSpecial;

    [Header("Rotation Settings")]
    public float rotationSpeed;

    [Header("Booleans")]
    public bool canMove = true;
    public bool isInvincible = false;
    public bool canRotate = true;
    public bool isRoll = false;
    public bool isGrounded = false;
    public bool canAttack;

    [Header("Roll Settings")]
    public AnimationCurve curve;
    public float rollForce;
    public float delayToMove = 1;

    [Header("Special Settings")]
    public AnimationCurve dashCurve;
    public float dashForce;

    [Header("Weapons")]
    public GameObject weapon;
    public List<GameObject> weapons;
    public string weaponType;

    [Header("Other Settings")]
    public float tauxGrav = 0.1f;    
    public Transform mainCamera;
    public Vector3 movDir;
    Rigidbody rb;
    private Animator animPerso;    
    private float delayTime = 2f;
    private int compteurCombo = 0;
    private float currentTime = 0;
    private float coolDownStart = 0f;
    private float regenCooldown = 0.1f; // 2 = two seconds 


    private Quaternion target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animPerso = transform.GetChild(0).GetComponent<Animator>();
    }
    void Start()
    {       
        CheckWeapon();
    }

    private void FixedUpdate()
    {
        CheckWeapon();
        if (!canMove)
        {
            rotationSpeed = 0.5f;
        }
        else
        {
            rotationSpeed = 25;
        }
        RegenStamina();

        Move();
        rb.velocity += new Vector3(0, Physics.gravity.y * tauxGrav * Time.deltaTime, 0);
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, -transform.up, 0.15f);
        animPerso.SetBool("isGrounded", isGrounded);
        SetDir();
        ControlSpeed();
        jumpLogic();
        Roll();
        Slash();
        Special();
    }
    private void SetDir()
    {
        
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
        if (isGrounded && Input.GetButtonDown("Fire1") && playerStats.stamina > costJump && !isRoll)
        {
            playerStats.UseStamina(costJump);
            rb.AddForce(new Vector3(rb.velocity.x, jumpForce, rb.velocity.z), ForceMode.Impulse);
            isGrounded = false;
            animPerso.Play("Jump");
            weapon.GetComponent<Weapon>().compteurCoup = 1;
        }
    }     

    void Roll()
    {       
        if (Input.GetButtonDown("Jump") && canMove && !isRoll && playerStats.stamina > costRoll)
        {
            playerStats.UseStamina(costRoll);
            isRoll = true;
            animPerso.Play("Roll");
            currentTime = 0;
            weapon.GetComponent<Weapon>().compteurCoup = 1;
        }

        currentTime += Time.deltaTime;
        float percent = currentTime / delayToMove;

        if (isRoll)
        {
            rb.AddForce((transform.GetChild(0).forward * rollForce) * curve.Evaluate(percent), ForceMode.Force);
            //transform.position = Vector3.Lerp(transform.GetChild(0).position, transform.GetChild(0).position + transform.GetChild(0).forward * rollForce, curve.Evaluate(percent));
        }
    }    
        

    void RegenStamina()
    {
        if (Time.time > coolDownStart + regenCooldown && canMove && !isRoll && canAttack)
        {
            playerStats.GainStamina();
            coolDownStart = Time.time;
        }
    }
    
    void Slash()
    {       

        if (Input.GetButtonDown("Fire2") && canAttack && !isRoll && canMove && playerStats.stamina > costSlash)
        {
            playerStats.UseStamina(costSlash);

            if (delayTime < Time.time)
            {
                compteurCombo = 0;
            }

            delayTime = Time.time + 2f;
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
        }
    }
       
    void Special()
    {
        if(Input.GetButtonDown("Fire3") && canAttack && !isRoll && canMove && playerStats.stamina > costSpecial)
        {
            playerStats.UseStamina(costSpecial);
            animPerso.Play("Special");
            currentTime = 0;
        }
        /*
        currentTime += Time.deltaTime;
        float percent = currentTime / 1f;

        if (!canMove)
        {
            //curve.Evaluate(percent)
            transform.position = Vector3.Lerp(transform.GetChild(0).position, transform.GetChild(0).position + transform.GetChild(0).forward * dashForce, dashCurve.Evaluate(percent));
        }*/
    }

    #region accesseurs
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

    
    public void CanAttack()
    {
        canAttack = true;                      
        weapon.GetComponent<Weapon>().compteurCoup = 0;        
    }
    public void CantAttack()
    {
        canAttack = false;
    }

    public void IsRoll()
    {
        isRoll = true;
        playerStats.isRolling = true;
    }
    public void IsntRoll()
    {
        isRoll = false;
        playerStats.isRolling = false;
    }
    #endregion

    public void CheckWeapon()
    {
        foreach(GameObject obj in weapons)
        {
            if (obj.CompareTag(weaponType))
            {
                obj.SetActive(true);
                obj.GetComponent<Weapon>().ChangeAnimator();
                weapon = obj;
            }
            else
            {
                obj.SetActive(false);
            }
        }
    }




}
