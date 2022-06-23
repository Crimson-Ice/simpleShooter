using UnityEngine;

public class HeroMouvements : MonoBehaviour
{

    public float WalkSpeed;
    public Rigidbody2D rb;
    private Vector3 dir;

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.Z))
        {
            moveY += 1f;
        }

        //si on vas vers le bas
        if (Input.GetKey(KeyCode.S))
        {
            moveY -= 1f;
        }

        //si on va a gauche
        if (Input.GetKey(KeyCode.Q))
        {
            moveX -= 1f;
        }

        //si on va a droite
        if (Input.GetKey(KeyCode.D))
        {
            moveX += 1f;
        }

        dir = new Vector3(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + dir * WalkSpeed * Time.fixedDeltaTime);
    }
}