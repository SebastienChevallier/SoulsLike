using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!_player.GetComponent<MovementScript>().canMove)
        {
            if (other.CompareTag("Mob"))
            {
                other.GetComponent<Dummy>().so_Dummy.TakeDamage(damage);
            }
        }
    }
}
