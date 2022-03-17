using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Slider sliderLife;
    public Slider sliderStamina;
    public SO_Player _Player;

    // Update is called once per frame
    private void Start()
    {
        sliderLife.maxValue = _Player.maxLife;
        sliderStamina.maxValue = _Player.maxStamina;
    }
    void Update()
    {
        sliderLife.value = _Player.life;
        sliderStamina.value = _Player.stamina;
    }
}
