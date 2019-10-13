using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public static float speed;
    public static bool grounded = true;
    public static float score = -10;
    public float step = 50;
    public static Vector3 MyGravity;
    public static int counter = 0;
    public static bool alive = true;
    public AudioClip hurt;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI distanceScoreText;
    public TextMeshProUGUI distancehighScoreText;
    public TextMeshProUGUI distanceText;
    public GameObject gameOverScreen;
    public GameObject gameScreen;
    public Transform particles;

    void Start()
    {
        Physics.gravity = new Vector3(0f, -9.47f, 0f);
        score = -10;
        alive = true;
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward;
        Physics.gravity *= 40;
        MyGravity = Physics.gravity;
    }

    void Update()
    {
        if(alive == true)
        {
            speed = (transform.position.z / step) + 5;
            rb.velocity = Vector3.forward * speed;
            if (Input.GetMouseButtonDown(0) && grounded)
            {
                if (counter % 2 == 0)
                {
                    Physics.gravity = MyGravity * -1 * (speed / 6);
                }
                else
                {
                    Physics.gravity = MyGravity * (speed / 6);
                }
                counter++;
            }
            distanceText.text = "Distance: " + ((int)transform.position.z).ToString();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Die()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        alive = false;
        if((int)score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            scoreText.text = "Your score: " + PlayerPrefs.GetInt("HighScore").ToString();
            highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            scoreText.text = "Your score: " + score.ToString();
            highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
        if ((int)transform.position.z > PlayerPrefs.GetInt("HighDistance"))
        {
            PlayerPrefs.SetInt("HighDistance", (int)transform.position.z);
            distanceScoreText.text = "Your distance: " + PlayerPrefs.GetInt("HighDistance").ToString();
            distancehighScoreText.text = "Highscore distance: " + PlayerPrefs.GetInt("HighDistance").ToString();
        }
        else
        {
            distanceScoreText.text = "Your distance: " + ((int)transform.position.z).ToString();
            distancehighScoreText.text = "HighDistance: " + PlayerPrefs.GetInt("HighDistance").ToString();
        }
        AudioManager.IncreasePitch(-1f);
        AudioManager.PlaySound(hurt);
        Instantiate(particles, transform.position, Quaternion.identity, this.transform);
        GetComponent<MeshRenderer>().material.color = Color.red;
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
