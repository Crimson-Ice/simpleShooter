using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public HeroShoot Ammo;
    public Slider slider;

    public void MaxSetAmmo(int ammo)
    {
        slider.maxValue = ammo;
        slider.value = ammo;
    }


    public void SetAmmo(int ammo)
    {
        slider.value = ammo;
    }
}
