using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Hero_Health Life;
    public TMP_Text Hp_text;
    public Slider slider;
    public Slider slider2;

    void Update()
    {
        Hp_text.text = Life.Hp.ToString() + "/" + Life.MaxHp.ToString();
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
