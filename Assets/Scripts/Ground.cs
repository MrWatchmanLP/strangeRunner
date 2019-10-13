using UnityEngine;

public class Ground : MonoBehaviour
{
    public float multiplier = 1;
    public AudioClip ground;
    public AudioClip jump;

    private void OnCollisionEnter(Collision collision)
    {
        Physics.gravity = Vector3.zero;
        ScoreManager.AddScore();
        AudioManager.PlaySound(ground);
    }

    private void OnCollisionStay(Collision collision)
    {
        Player.grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Player.grounded = false;
        transform.GetChild(0).gameObject.SetActive(false);
        AudioManager.PlaySound(jump);
    }
}
