using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Weapon : MonoBehaviour
{
    public int damage;
    public int damageSlash;
    public int damageSpecial;
    private GameObject _player;
    public GameObject fx_Blood;
    public SO_Player sO_Player;

    private CamShake camShakeComp;
    private AudioSource audioSource;
    
    public RuntimeAnimatorController animatorController;
    

    // Start is called before the first frame update
    void Awake()
    {
        _player = GameObject.Find("Player");
        camShakeComp = _player.transform.GetChild(1).GetComponent<CamShake>();
        audioSource = _player.GetComponent<AudioSource>();
    }

   


    private void OnTriggerEnter(Collider other)
    {        
        if (!_player.GetComponent<MovementScript>().canAttack && _player.GetComponent<MovementScript>().isGrounded && !_player.GetComponent<MovementScript>().isRoll && !_player.GetComponent<MovementScript>().isHit)
        {                        
            if (other.CompareTag("Mob"))
            {
                if (other.TryGetComponent<Boss>(out Boss script))
                {
                    script.minotor.TakeDamage(damage);
                }
                else
                {
                    other.GetComponent<Dummy>().so_Dummy.TakeDamage(damage);
                }
                audioSource.PlayOneShot(sO_Player.HitAudio);
                
                Instantiate(fx_Blood, other.ClosestPoint(transform.position), Quaternion.identity);
                camShakeComp.shakeDuration = 0.1f;                
            }
        }
        
    }

    public void ChangeAnimator()
    {
        _player.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = animatorController;         
        
    }
}
