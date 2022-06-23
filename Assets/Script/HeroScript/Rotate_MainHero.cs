using UnityEngine;

public class Rotate_MainHero : MonoBehaviour
{
    public float RotationSpeed = 5;
    
    void Update()
    {
        //calcule Direction = Destination = Source
        Vector3 Direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) - transform.position;
        //Crée un trai entre la souris et le gameobject
        Debug.DrawRay(transform.position, Direction, Color.green);
        //calcule l'angle en utilisant la methode de tangent inverse
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        //change l'angle du gameeobject
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
