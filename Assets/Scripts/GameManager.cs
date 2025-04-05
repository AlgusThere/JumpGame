using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] public GameObject character;

    [Header("Character")]
    [SerializeField] GameObject[] characters;

    [Header("Texts")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverScoreText;

    //GameObject clone;

    public int randomRangeNumber;
    public int randomRangeNumber1;
    //int randomRangeNumber1;
    //int randomRangeNumber2;
    public int currentScore;
    public int selectedCharacter;

    public CinemachineCamera cam;

    bool isEqual = true;
    bool isEqual1 = true;
    //bool isEqual1 = true;
    //bool isEqual2 = true;
    bool gamePanelIsActive;
    public bool isPausePanelActive = false;
    public bool isPausePanelActivePhone = false;

    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    //PipeSpawner pipeSpawner;
    //CollisionManager scored;

    void Start()
    {
        //pipeSpawner = GetComponent<PipeSpawner>();
        //scored = GetComponent<CollisionManager>();
        //currentScore = scored.score;

        //clone = Instantiate(character, spawnPoint.position, Quaternion.identity);
        //clone.SetActive(true);

        SetActiveGamePanel();
        SetActiveSelectedCharacter();

        Time.timeScale = 0;
        randomRangeNumber = 10/*Random.Range(1, 2)*/;
        randomRangeNumber1 = 50/*Random.Range(3, 4)*/;
        //randomRangeNumber1 = Random.Range(3, 4);
        //randomRangeNumber2 = Random.Range(5, 6);
        Debug.Log("Alýnan sayý: " + randomRangeNumber);
        Debug.Log("Alýnan sayý: " + randomRangeNumber1);
        //Debug.Log("Alýnan sayý: " + randomRangeNumber1);
        //Debug.Log("Alýnan sayý: " + randomRangeNumber2);
    }

    private void SetActiveGamePanel()
    {
        gamePanel.SetActive(true);
        gamePanelIsActive = true;
    }

    private void SetActiveSelectedCharacter()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        character = characters[selectedCharacter];
        character.SetActive(true);
        cam.Follow = character.transform;
        cam.LookAt = character.transform;
    }

    void Update()
    {
        CharacterDestroyed();
        TimeChanger();

        if (Input.GetKeyDown(KeyCode.Escape) && gamePanelIsActive)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            isPausePanelActive = true;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && Time.timeScale == 0 && isPausePanelActive == false)
        {
            Time.timeScale = 1;
        }
    }

    public void PauseButton()
    {
        isPausePanelActivePhone = true;

        if (isPausePanelActivePhone == true)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            isPausePanelActive = true;
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
            PipeSpawner.instance.maxTime -= 0.5f;
            Debug.Log(PipeSpawner.instance.maxTime);
            isEqual = false;
        }
        else if (randomRangeNumber1 == currentScore && isEqual1 == true)
        {
            //pipeSpawner.maxTime--;
            PipeSpawner.instance.maxTime -= 0.5f;
            Debug.Log(PipeSpawner.instance.maxTime);
            isEqual1 = false;
        }

        //else if (randomRangeNumber1 == currentScore && isEqual1)
        //{
        //    PipeSpawner.instance.maxTime -= 0.5f;
        //    Debug.Log(PipeSpawner.instance.maxTime);
        //    isEqual1 = false;
        //}
        //else if (randomRangeNumber2 == currentScore && isEqual2)
        //{
        //    PipeSpawner.instance.maxTime -= 0.5f;
        //    Debug.Log(PipeSpawner.instance.maxTime);
        //    isEqual2 = false;
        //}
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
        isPausePanelActive = false;
        isPausePanelActivePhone = false;
        Time.timeScale = 1;
    }

    public void ExitAppButton()
    {
        Application.Quit();
    }
}
