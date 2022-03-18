using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMovement : MonoBehaviour
{
    private float currentTime;
    public float spellDuration;
    public float spellSpeed;

    public Rigidbody rb;


    void Start()
    {
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
}