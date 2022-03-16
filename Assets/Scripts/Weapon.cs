using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Weapon : MonoBehaviour
{
    public int damage;
    private GameObject _player;
    public GameObject fx_Blood;
    
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
                Debug.Log("touch");
                other.GetComponent<Dummy>().so_Dummy.TakeDamage(damage);
                Instantiate(fx_Blood, other.ClosestPoint(transform.position), Quaternion.identity);
            }
        }
    }

    public void ChangeAnimator()
    {
        if(_player.GetComponent<MovementScript>().weaponType == tag)
        {
            
            _player.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = animatorController;
        }       
        
    }
}
