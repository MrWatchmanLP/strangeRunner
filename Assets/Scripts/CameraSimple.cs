using UnityEngine;

public class CameraSimple : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z);
    }
}
