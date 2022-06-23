using UnityEngine;

/// <summary>
/// Script qui gène la vie des ennmie et leur destruction
/// </summary>

public class Ennemie_Health : MonoBehaviour
{
    public int Vie;  //Nombre de point de vie de l'ennemie
    public bool isEnnemy = true; //dit que c'est un ennemie
    public GameObject DeathEffect; // particul de mort de l'ennemie
    private GameObject button;

    public bool Recul = false; //booléen pour le recul 

    void OnTriggerEnter2D(Collider2D collider)
    {
        //toucher
        // Est-ce un tir ?
        Tir_Stat Tir = collider.gameObject.GetComponent<Tir_Stat>();
        if (Tir != null)
        {
            //pas null
            // Tir allié
            if (Tir.isEnemyShot != isEnnemy)
            {
                //est un ennmie

                Vie -= Tir.Damage;

                // Destruction du projectile
                // On détruit toujours le gameObject associé
                // sinon c'est le gameobject du script qui serait détruit avec ""this""


                if (Vie <= 0)
                {
                    // Destruction !
                    Instantiate(DeathEffect, transform.position, transform.rotation); //fait apparaitre les particul de mort qui l'ennemie a 0 pv
                    Destroy(gameObject);
                    button = GameObject.Find("Button 1_0");
                    button.GetComponent<Initvague>().enleveNbEnnemie();

                    //GameObject vague = GameObject.Find("Button 1_0"); //recupère le button avec le script des vague dedans
                    //vague.GetComponent<Initvague>().enleveNbEnnemie(); //quand l'ennmie meurt enlèle 1 au nombre d'ennmie actif

                }
            }
        }
    }
}
