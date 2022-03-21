using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dummy : MonoBehaviour
{
    public SO_Ennemis so_Dummy;

    private float currentTime = 0;

    public GameObject fireball;
    public float fireballCD;

    private Transform player;
    public Transform spell;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        spell = GameObject.Find("Spell").GetComponent<Transform>();
    }

    void Update()
    {
        transform.GetChild(0).GetComponent<TextMeshPro>().text = so_Dummy.life.ToString();
        if (LockCollider.looking)
        {
            transform.LookAt(player, Vector3.up);
            Fireball();
        }
    }

    private void Fireball()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime >= fireballCD)
        {
            Instantiate(fireball, spell.position, spell.rotation);
            currentTime = 0;
        }
    }
}