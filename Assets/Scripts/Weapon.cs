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
    void Awake()
    {
        _player = GameObject.Find("Player");
        
    }    

    private void OnTriggerEnter(Collider other)
    {
        
        if (!_player.GetComponent<MovementScript>().canAttack)
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
        _player.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = animatorController;         
        
    }
}
