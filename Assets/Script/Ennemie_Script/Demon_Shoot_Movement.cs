using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_Shoot_Movement : MonoBehaviour
{
    public float speed = 40f;
    public GameObject target;
    private Vector3 Point;
    private Vector3 normalizeDirection;

    public GameObject ShootEffect; // particul de mort de l'ennemie

    void Start()
    {
        target = GameObject.Find("Hero");
        Point = target.transform.position;
        normalizeDirection = (Point - transform.position).normalized;
        Destroy(gameObject, 3);
    }

    void Update()
    {
        transform.position += normalizeDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.gameObject.tag == "Background")||(collider.gameObject.tag == "Player"))
        {
            Destroy(this.gameObject);
            Instantiate(ShootEffect, transform.position, ShootEffect.transform.rotation);
        }

    }
}

