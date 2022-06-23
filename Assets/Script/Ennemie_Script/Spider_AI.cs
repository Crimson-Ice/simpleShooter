using UnityEngine;
using System.Collections;

public class Spider_AI : MonoBehaviour
{
    float speed = 5f;
    float timer = 0f;
    float timer2 = 0f;
    bool ChargeEsquive = true;
    public GameObject target;
    public Vector2 cible;
    bool arrived = false;
    bool touch = false;
    int tour;

    public Animator animator;

    void Start()
    {

        target = GameObject.Find("Hero"); //Trouve le jouer 
        tour = Random.Range(1, 3); // entre 1 et 2 pour savoir dans quel direction va l'ennemie (enbigue)
    }

    void Update()
    {

        if ((ChargeEsquive)&&(Vector2.Distance(transform.position, target.transform.position) > 3f))
        {
            animator.SetBool("IsMove", false); //joue l'annimation idle
            timer += 1 * Time.deltaTime;

            if (timer > 0.5f) //cooldown entre chaque esquive / déplacement latéral
            {
                ChargeEsquive = false;
                animator.SetBool("IsMove", true); //joue l'annimation de movement
                StartCoroutine(esquive()); //déplacement latéral
            }
        }

        if (arrived) // si l'ennemie est assez proche du hero
        {
            animator.SetBool("IsMove", false); //joue l'annimation idle
            timer2 += 1 * Time.deltaTime;

            if (timer2 > 0.5f) // cooldown entre chaque mouvement vers le joueur
            {
                arrived = false;
                animator.SetBool("IsMove", true); //joue l'annimation de movement
                StartCoroutine(NormalMovement()); //movement vers le joueur
            }
        }

    }

    IEnumerator NormalMovement()
    {
        touch = false;
        while (!touch)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime); // tant qu'il n'a pas touché le joueuer avance vers lui

            if(Vector2.Distance(transform.position, target.transform.position) > 3f)
            {
                animator.SetBool("IsMove", false);
                touch = true;
            }

            if (Vector2.Distance(transform.position, target.transform.position) < 1f)
            {
                animator.SetBool("IsMove", false); //joue l'annimation idle
                touch = true; // à touché le joueur
            }
            yield return null;
        }
        if (touch)
        {
            yield return new WaitForSeconds(0.1f); //si touché attend 1 sec
            arrived = false; // reset les valeur
            timer2 = 0f;
        }
    }

    IEnumerator esquive()
    {
        arrived = false;
        while (!arrived) // tant qu'il n'est pas arrivé vers le point de l'esquive c'est adire pas loin du joueur
        {
            //décale le déplacement de l'ennemie et fonction de x et y et deux posibilité en fonction du tour
            if (transform.position.y < target.transform.position.y)
            {
                if (transform.position.x <= target.transform.position.x)
                {
                    if(tour % 2 == 0)
                    {
                        Vector2 cible = new Vector2(target.transform.position.x, target.transform.position.y + 30f);
                        transform.position = Vector2.MoveTowards(transform.position, cible, speed * Time.deltaTime);
                    }
                    else
                    {
                        Vector2 cible = new Vector2(target.transform.position.x + 30f, target.transform.position.y);
                        transform.position = Vector2.MoveTowards(transform.position, cible, speed * Time.deltaTime);
                    }
                }
                else
                {
                    if (tour % 2 == 0)
                    {
                        Vector2 cible = new Vector2(target.transform.position.x - 30f, target.transform.position.y);
                        transform.position = Vector2.MoveTowards(transform.position, cible, speed * Time.deltaTime);
                      
                    }
                    else
                    {
                        Vector2 cible = new Vector2(target.transform.position.x, target.transform.position.y + 30f);
                        transform.position = Vector2.MoveTowards(transform.position, cible, speed * Time.deltaTime);
                    }
                    
                }
            }
            else
            {
                if (transform.position.x < target.transform.position.x)
                {
                    if (tour % 2 == 0)
                    {
                        Vector2 cible = new Vector2(target.transform.position.x + 30f, target.transform.position.y);
                        transform.position = Vector2.MoveTowards(transform.position, cible, speed * Time.deltaTime);

                    }
                    else
                    {
                        Vector2 cible = new Vector2(target.transform.position.x, target.transform.position.y - 30f);
                        transform.position = Vector2.MoveTowards(transform.position, cible, speed * Time.deltaTime);
                    }
                }
                else
                {
                    if (tour % 2 == 0)
                    {
                        Vector2 cible = new Vector2(target.transform.position.x, target.transform.position.y - 30f);
                        transform.position = Vector2.MoveTowards(transform.position, cible, speed * Time.deltaTime);

                    }
                    else
                    {
                        Vector2 cible = new Vector2(target.transform.position.x - 30f, target.transform.position.y);
                        transform.position = Vector2.MoveTowards(transform.position, cible, speed * Time.deltaTime);
                    }
                }
            }

            if (Vector2.Distance(transform.position, target.transform.position) < 3f) // est assé pret du joueur donc arrived
            {
                animator.SetBool("IsMove", false); //joue l'annimation idle
                arrived = true;
                tour = Random.Range(1, 3);
            }
            yield return null;
        }
        if (arrived)
        {
            yield return new WaitForSeconds(0.1f); // si arrived alors cooldown
            ChargeEsquive = true; //reset valeur
            timer = 0f;
        }
    }
}

