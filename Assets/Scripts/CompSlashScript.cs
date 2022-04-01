using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompSlashScript : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private CamShake camShakeComp;
    private GameObject _player;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
        camShakeComp = _player.transform.GetChild(1).GetComponent<CamShake>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mob"))
        {
            other.GetComponent<Dummy>().so_Dummy.TakeDamage(300);
            
            camShakeComp.shakeDuration = 0.1f;
            Destroy(this);
        }
    }
}
