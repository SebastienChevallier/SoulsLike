using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public Slider sliderLife;
    public Slider sliderStamina;
    public SO_Player _Player;
    public TMP_Text textpotion;

    public GameObject panelLock;

    // Update is called once per frame
    private void Start()
    {
        sliderLife.maxValue = _Player.maxLife;
        sliderStamina.maxValue = _Player.maxStamina;
        textpotion.text = _Player.nbHeal.ToString();
    }
    void Update()
    {
        sliderLife.value = _Player.life;
        sliderStamina.value = _Player.stamina;

        textpotion.text = _Player.nbHeal.ToString();

        if (_Player.isLock)
        {
            panelLock.SetActive(true);
        }
        else
        {
            panelLock.SetActive(false);
        }
    }
}
