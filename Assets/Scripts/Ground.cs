using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, Player.speed);
        }
    }
}
