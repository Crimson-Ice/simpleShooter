using UnityEngine;

public class CameraMouvement : MonoBehaviour
{
    public GameObject Target;
    public float timeoffset;
    public Vector3 posOffSet;

    private Vector3 velocity;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z), ref velocity, timeoffset);
    }
}
