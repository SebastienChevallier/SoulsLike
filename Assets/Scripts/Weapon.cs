using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Weapon : MonoBehaviour
{
    public int damage;
    private GameObject _player;
    
    public RuntimeAnimatorController animatorController;
    

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        
    }
    private void OnEnable()
    {
        ChangeAnimator();
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

    public void ChangeAnimator()
    {
        _player.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = animatorController;
    }
}
