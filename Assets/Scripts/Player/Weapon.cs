using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Weapon : MonoBehaviour
{
    public int damage;
    public int compteurCoup = 0;
    private GameObject _player;
    public GameObject fx_Blood;

    private CamShake camShakeComp;
    
    public RuntimeAnimatorController animatorController;
    

    // Start is called before the first frame update
    void Awake()
    {
        _player = GameObject.Find("Player");
        camShakeComp = _player.transform.GetChild(1).GetComponent<CamShake>();
    }

    private void OnTriggerStay(Collider other)
    {        
        if (!_player.GetComponent<MovementScript>().canAttack && _player.GetComponent<MovementScript>().isGrounded && compteurCoup < 1)
        {
            
            if (other.CompareTag("Mob"))
            {
                
                other.GetComponent<Dummy>().so_Dummy.TakeDamage(damage);
                Instantiate(fx_Blood, other.ClosestPoint(transform.position), Quaternion.identity);
                camShakeComp.shakeDuration = 0.1f;
                compteurCoup = 1;
            }
        }
        
    }

    public void ChangeAnimator()
    {
        _player.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = animatorController;         
        
    }
}
