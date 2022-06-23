using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirMouvement : MonoBehaviour
{
    public float speed = 0.5f;
    
    // Update is called once per frame
    void Update()
    {
        float power = speed * Time.deltaTime;
        transform.Translate(Vector3.right * power);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.gameObject.tag == "Ennemie") || (collider.gameObject.tag == "Background"))
        {
            Destroy(this.gameObject);
        }

    }
}
