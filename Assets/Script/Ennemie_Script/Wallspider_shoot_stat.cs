using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallspider_shoot_stat : MonoBehaviour
{
    public int Damage = 1;

    //Bool pour savoir si le tir est ami ou ennemie
    public bool isEnemyShot = true;

    void Start()
    {
        //Destruction du tir programmé
        Destroy(gameObject, 3);
    }
}
