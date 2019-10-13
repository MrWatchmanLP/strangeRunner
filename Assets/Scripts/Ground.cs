using UnityEngine;

public class Ground : MonoBehaviour
{
    public float multiplier = 1;

    private void OnCollisionEnter(Collision collision)
    {
        Physics.gravity = Vector3.zero;
        ScoreManager.AddScore();
    }

    private void OnCollisionStay(Collision collision)
    {
        Player.grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Player.grounded = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
