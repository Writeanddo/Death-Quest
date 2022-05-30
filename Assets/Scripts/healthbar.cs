using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{


    public Slider slider;
    

    public void setMaxHealth(float health)
    {
        slider.value = health;
        slider.maxValue = health;
    }
    public void sethealth(float health)
    {
        slider.value = health;
    }
    
}
