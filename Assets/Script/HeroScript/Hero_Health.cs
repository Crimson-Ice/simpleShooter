using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero_Health : MonoBehaviour
{
    public int Hp ; // 5 hp pour le joueur
    public int MaxHp = 100; //Vie maximun du joueur
    public HealthBar Hpbar;
    public HealthBarRed HpBarRed;

    void Start()
    {
        Hp = MaxHp;
        Hpbar.MaxSetHealth(MaxHp); // met le hpbar dans l'interface a max health
        HpBarRed.MaxSetHealth(MaxHp);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //toucher
        //verifie si l'object est un ennemie(erreur sinon)
        if (collider.gameObject.tag == "Ennemie")
        {
            //retire de la vie
            TakeDamage(10); //Le hero prend 10 damage

            Ennemie_Health Ennemie = collider.gameObject.GetComponent<Ennemie_Health>();
            Ennemie.Recul = true; //ennemie prend du recul
        }
        else if (collider.gameObject.tag == "Ennemie_Shoot")
        {
            TakeDamage(10);
        }

        if (Hp <= 0)
        {
            //relance le jeu si le joueur n'a pu de vie
            Restart();
        }
    }

    void TakeDamage(int damage)
    {
        Hp = Hp - damage; // vie - damage
        Hpbar.SetHealth(Hp); // fait descendre la hpbar dans l'interface
    }

    void Restart()
    {
        //relance la scene de base
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
