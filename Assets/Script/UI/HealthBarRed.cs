using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarRed : MonoBehaviour
{
    public Hero_Health Life;
    public Slider slider;

    void Update()
    {
       
    }

    public void MaxSetHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }


    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
