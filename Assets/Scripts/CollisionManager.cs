using TMPro;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    public int score = 0;
    int highScore;

    public static CollisionManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("scoreText");
        highScoreText.text = "HIGH SCORE: " + highScore.ToString();
        scoreText.text = score.ToString();
    }

    private void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Bum":
                Debug.Log("Crashed!");
                //Time.timeScale = 0;
                Destroy(gameObject);
                break;
            case "Point":
                Debug.Log("New point!");
                score++;
                Destroy(other.gameObject);
                scoreText.text = score.ToString();
                if (score > highScore)
                {
                    PlayerPrefs.SetInt("scoreText", score);
                }
                break;
            default:
                break;

        }
    }
}
