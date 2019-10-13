using UnityEngine;

public class RiskBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.mult = 5;
    }
}
