using UnityEngine;

public class Catcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().Die();
        }
    }
}
