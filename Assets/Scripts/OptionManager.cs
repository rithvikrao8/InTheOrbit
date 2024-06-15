using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    public GameObject Sound;
    public GameObject Sliders;
    public GameObject Control;


    public void showSound()
    {
        Sound.SetActive(true);
        Sliders.SetActive(true);
        Control.SetActive(false);
    }

    public void showControl()
    {
        Sound.SetActive(false);
        Sliders.SetActive(false);
        Control.SetActive(true);
    }


}
