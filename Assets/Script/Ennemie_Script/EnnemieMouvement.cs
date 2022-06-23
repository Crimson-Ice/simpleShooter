using UnityEngine;

public class EnnemieMouvement : MonoBehaviour
{
    public GameObject Target;
    public int speed;
    public Ennemie_Health ennemie_Health;
    private float ReculDuration;
    public bool CanRecul = true;

    void Start()
    {
        Target = GameObject.Find("Hero"); //Trouve le jouer 
    }

    void Update()
    {
        Vector2 dir = Target.transform.position - transform.position; // direction de d�placement donc vers le jouer

        if (ReculDuration > 0f)
        {
            ReculDuration -= Time.deltaTime; // r�duit le temps de reculcooldown
        }

        if (ennemie_Health.Recul) //si l'ennemie est touch� le fait reculer
        {
            if (CanRecul) //si il est touch� alors il a un reculcooldwn de 0.2 sec donc petite distance
            {
                ReculDuration = 0.05f;
                CanRecul = false;
            }

            //dir = new Vector3(ennemie_Health.Recul.x, ennemie_Health.Recul.y, ennemie_Health.Recul.z);

            transform.Translate(dir.normalized * (speed + 20) * Time.deltaTime * (-1), Space.World); //inverse le sens de d�placement (vers le jouer) et il faudrais
            // essayer de faire ca part rapport a l'endroit ou est touch� l'ennemie

            if (ReculDuration <= 0f) //si le cooldown recul est a 0 et peux potentiellement remettre du recul
            {
                ennemie_Health.Recul = false;
                CanRecul = true;
            }
        }
        else //mouvement normaux des ennemie donc vers le joueur
        {
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
