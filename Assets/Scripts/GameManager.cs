using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject character;

    [Header("Texts")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverScoreText;

    int randomRangeNumber;
    int currentScore;

    bool isEqual = true;
    bool gamePanelIsActive;

    //PipeSpawner pipeSpawner;
    //CollisionManager scored;

    void Start()
    {
        //pipeSpawner = GetComponent<PipeSpawner>();
        //scored = GetComponent<CollisionManager>();
        //currentScore = scored.score;

        Time.timeScale = 0;
        startPanel.SetActive(true);
        randomRangeNumber = Random.Range(1, 5);
        Debug.Log("Alýnan sayý: " + randomRangeNumber);
    }


    void Update()
    {
        CharacterDestroyed();
        TimeChanger();

        if(Input.GetKeyDown(KeyCode.Escape) && gamePanelIsActive)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }

    private void CharacterDestroyed()
    {
        if (character.IsDestroyed())
        {
            gamePanel.SetActive(false);
            gameOverPanel.SetActive(true);
            gamePanelIsActive = false;
            gameOverScoreText.text = scoreText.text;
        }
    }

    private void TimeChanger()
    {
        currentScore = CollisionManager.instance.score;

        if (randomRangeNumber == currentScore && isEqual == true)
        {
            //pipeSpawner.maxTime--;
            PipeSpawner.instance.maxTime -= 1;
            Debug.Log(PipeSpawner.instance.maxTime);
            isEqual = false;
        }
    }

    public void ClickStartButton()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        gamePanelIsActive = true;
        Time.timeScale = 1;
    }

    public void ClickTryAgainButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinueButton()
    {
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
        gamePanelIsActive = true;
        Time.timeScale = 1;
    }

    public void ExitAppButton()
    {
        Application.Quit();
    }
}
