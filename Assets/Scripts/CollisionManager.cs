using TMPro;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    int score = 0;
    int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("scoreText");
        highScoreText.text = "En yüksek skor: " + highScore.ToString();
        scoreText.text = score.ToString();
        //PlayerPrefs.GetString("pointText");
    }

    private void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        //if(other.gameObject.tag == "Bum")
        //{
        //    Debug.Log("Crashed!");
        //    Time.timeScale = 0;
        //}

        switch (other.gameObject.tag)
        {
            case "Bum":
                Debug.Log("Crashed!");
                Time.timeScale = 0;
                break;
            case "Point":
                Debug.Log("New point!");
                score++;
                Destroy(other.gameObject);
                scoreText.text = score.ToString();
                if(score > highScore)
                {
                    PlayerPrefs.SetInt("scoreText", score);
                }
                    break;
            default:
                break;

        }
    }
}
