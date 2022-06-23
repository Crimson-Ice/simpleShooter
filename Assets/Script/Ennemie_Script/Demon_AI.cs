using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_AI : MonoBehaviour
{
    public float speed;
    public GameObject target;
    float timer = 0f;
    public Transform Shoot_sprite;
    public bool Canfire = true;
    public Rigidbody2D rb;
    private Vector3 dir;

    public SpriteRenderer spriteRenderer;


    public Animator anim;
    private string currentState;

    void Start()
    {
        target = GameObject.Find("Hero");
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;

        if(timer > 2f)
        {
            ChangeAnimatorState("idle_Demon");
            Fire();
            StartCoroutine(wait());
        }
        else
        {
            ChangeAnimatorState("Move_Demon");
            Move();
        }
    }

    void ChangeAnimatorState(string newstate)
    {
        //enpêche qu'une animation ce stop elle meme 
        if (currentState == newstate) return;

        //joue l'animation voulue
        anim.Play(newstate);

        //met l'animation jouer a l'animation actuelle
        currentState = newstate;
    }

    void Move()
    {
        dir = target.transform.position - transform.position;
        //rb.MovePosition(transform.position + dir * speed * Time.fixedDeltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        Flip();
    }

    void Fire()
    {
        if(Canfire)
        {
            var shoot = Instantiate(Shoot_sprite) as Transform;
            shoot.position = transform.position;

            //calcul l'angle du gameobject en fonction de la cible
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //change l'angle du gameeobject
            shoot.rotation = Quaternion.Euler(0f, 0f, angle);
            Canfire = false;
        }
        
    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        timer = 0f;
        Canfire = true;
    }

    void Flip()
    {
        if (target.transform.position.x - transform.position.x > 0.1)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}
