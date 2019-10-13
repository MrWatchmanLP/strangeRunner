using UnityEngine;
using TMPro;

public class ClearHiscore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI distanceText;

    public void Clear()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("HighDistance", 0);
        scoreText.text = "";
        distanceText.text = "";
    }

    private void Start()
    {
        scoreText.text = "HI-score " + PlayerPrefs.GetInt("HighScore").ToString();
        distanceText.text = "HI-distance " + PlayerPrefs.GetInt("HighDistance").ToString();
    }
}
