using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpider_shoot_move : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject ShootEffect; // particul de mort de l'ennemie

    private Vector3 Point;
    private Vector3 normalizeDirection;

    // Update is called once per frame
    void Start()
    {
        GameObject hero = GameObject.Find("Hero");

        Point = hero.transform.position;
        normalizeDirection = (new Vector3(Point.x, transform.position.y, transform.position.z) - transform.position).normalized;
    }

    void Update()
    {
        float power = speed * Time.deltaTime;

        transform.position += normalizeDirection * power;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.gameObject.tag == "Background") || (collider.gameObject.tag == "Player"))
        {
            Destroy(this.gameObject);
            Instantiate(ShootEffect, transform.position, ShootEffect.transform.rotation);
        }

    }
}
