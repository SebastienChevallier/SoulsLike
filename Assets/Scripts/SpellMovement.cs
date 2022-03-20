using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMovement : MonoBehaviour
{
    private float currentTime;
    public float spellDuration;
    public float spellSpeed;
    public SO_Player player;

    public Rigidbody rb;

    private CamShake camShakeComp;


    void Start()
    {
        camShakeComp = GameObject.Find("CamAnchor").GetComponent<CamShake>();
        currentTime = 0;
        transform.rotation = GameObject.Find("SphereTrigger").GetComponent<Transform>().rotation;
        rb.velocity = transform.forward * spellSpeed;
    }

    void Update()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime >= spellDuration)
            Destroy(transform.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            camShakeComp.shakeDuration = 0.1f;
            player.TakeDamage(10);
            if (!player.isRolling)
            {
                Destroy(transform.gameObject);
            }
            
        }
        
    }
}