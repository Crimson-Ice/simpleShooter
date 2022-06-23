using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpider_AI : MonoBehaviour
{
    public float speed = 0.5f;
    float timer = 0f;
    float timer2 = 0f;

    public int pos;
    public int count = 0;

    private Vector3 Point;
    private Vector3 normalizeDirection;
    public bool reverse = false;

    public Transform Tir_ennemie; //PreFab du Tir
    public GameObject TirPosition; //Objet empty
    public Animator animator; // animateur

    void Start()
    {
        pos = Random.Range(0, 2);
   
        if(pos == 0)
        {
            Point = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        }
        else
        {
            Point = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        }
        normalizeDirection = (Point - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer > 1f)
        {
            animator.SetBool("IsMove", false); //joue l'annimation idle
            StartCoroutine(wait());
        }
        else
        {
            animator.SetBool("IsMove", true); //joue l'annimation movement
            Move();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Background")
        {
            reverse = true;
        }
    }

    IEnumerator wait()
    {
        Shoot();
        yield return new WaitForSeconds(1f);
        timer = 0f;
        count = 0;
    }

    void Shoot()
    {
        if (count < 3) // conteur de tir (doit tirer trois fois pas plus)
        {
            timer2 += 1 * Time.deltaTime;
            if (timer2 > 0.2f)
            {
                count += 1;
                var TirTransform = Instantiate(Tir_ennemie) as Transform; //crée un transform Tir dans la scene
                TirTransform.position = TirPosition.transform.position; // Met le Tir a la position d'un empty
                timer2 = 0f;
            }
        }
    }

    void Move()
    {
        transform.position += normalizeDirection * speed * Time.deltaTime;

        if (reverse == true)
        {
            normalizeDirection = normalizeDirection * (-1);
            reverse = false;
        }
        
    }
}
