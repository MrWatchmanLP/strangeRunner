using UnityEngine;

public class GravityBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Player.counter % 2 == 1)
        {
            Physics.gravity = Player.MyGravity * -1;
        }
        else
        {
            Physics.gravity = Player.MyGravity;
        }
    }
}
