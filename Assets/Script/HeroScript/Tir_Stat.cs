using UnityEngine;

/// <summary>
/// Script qui gère le comportemnt des Tirs (stat etc...)
/// </summary>

public class Tir_Stat : MonoBehaviour
{
    public int Damage = 1;

    //Bool pour savoir si le tir est ami ou ennemie
    public bool isEnemyShot = false;

    void Start()
    {
        //Destruction du tir programmé
        Destroy(gameObject, 2);
    }
}
