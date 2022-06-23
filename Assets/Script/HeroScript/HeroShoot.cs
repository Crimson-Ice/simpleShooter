

using UnityEngine;

public class HeroShoot : MonoBehaviour
{
    public Transform Tir; //PreFab du Tir
    public GameObject TirPosition;//Objet empty
    public AmmoBar ammoBar;

    public float shootingRate = 0.25f; //Vitesse d'attack
    private float shootCooldown; //cooldown d'attack

    public float Reload; //cooldown du rechargement
    public int NbBalles; //Nombre de balles dans le chargeur
    public int MaxBalles = 5;

    public GameObject ShootEffect; // particul de mort de l'ennemie

    void Start()
    {
        shootCooldown = 0f;
        Reload = 0f;
        NbBalles = MaxBalles; // Met au nombre de balle le nombre de balle max
        ammoBar.MaxSetAmmo(MaxBalles); //Met a interface ammo le maxballe  
    }

    void Update()
    {
        //Fait diminier shootColldown par rapport au temps qui passe
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime; 
        }

        if (Reload > 0)
        {
            Reload -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Attack(); //Si le left click est clicker alors Attack

        }
    }

    void Attack()
    {
        if (chargeurNotEmpty)
        {
            if (NbBalles == 0)
            {
                NbBalles = 5;
                ammoBar.SetAmmo(NbBalles);
                Reload = 0.75f;
            }

            if (CanAttack)
            {
                NbBalles = NbBalles - 1;
                ammoBar.SetAmmo(NbBalles);
                shootCooldown = shootingRate; //Met le cooldown a 0,25 sec
                var TirTransform = Instantiate(Tir) as Transform; //crée un transform Tir dans la scene
                TirTransform.position = TirPosition.transform.position; // Met le Tir a la position d'un empty devant le canon
                TirTransform.rotation = transform.rotation; //Met la rotation du Tir comme la rotation du canon

                Instantiate(ShootEffect, TirPosition.transform.position, Quaternion.Euler(transform.rotation.z, ShootEffect.transform.rotation.x, ShootEffect.transform.rotation.z));
            }
        }
    }

    //Fais en sorte que le bolléen change quand le cooldown est égal à 0 ducoup permet d'attaquer ou non
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
    public bool chargeurNotEmpty
    {
        get
        {
            return Reload <= 0f;
        }
    }
}
