using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Lock : MonoBehaviour
{
    public SO_Player _Player;
    public SO_Ennemis _Mob;

    public GameObject lockImage;
    public GameObject lifeMob;
    // Update is called once per frame
    void Update()
    {
        if (_Player.isLock)
        {
            lockImage.SetActive(true);
        }
        else if(!_Player.isLock)
        {
            lockImage.SetActive(false);
        }
    }
}
