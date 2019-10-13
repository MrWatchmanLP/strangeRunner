using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int mult = 1;
    public TextMeshProUGUI scoreText;
    public static TextMeshProUGUI ScoreText;

    private void Start()
    {
        ScoreText = scoreText;
    }

    public static void AddScore()
    {
        Player.score += 10 * mult;
        mult = 1;
        ScoreText.text = "SCORE: " + Player.score.ToString();
    }
}
