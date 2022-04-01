using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Lock : MonoBehaviour
{
    public SO_Player _Player;
    public SO_Ennemis _Mob;

    public GameObject lockImage;
    public GameObject lifeMob;

    // Update is called once per frame
    void Update()
    {
        UpdateSlider();
    }

    public void UpdateSlider()
    {
        lifeMob.GetComponent<Slider>().value = _Mob.life / _Mob.maxLife;
    }
}
