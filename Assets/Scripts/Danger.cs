using UnityEngine;

public class Danger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
            collision.transform.GetComponent<Player>().Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.GetComponent<Player>().Die();
        }
    }
}
