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

    int randomRangeNumber;
    int currentScore;
    public int selectedCharacter;

    public CinemachineCamera cam;

    bool isEqual = true;
    bool gamePanelIsActive;

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

        gamePanel.SetActive(true);
        gamePanelIsActive = true;

        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        character = characters[selectedCharacter];
        character.SetActive(true);
        cam.Follow = character.transform;
        cam.LookAt = character.transform;


        //clone = Instantiate(character, spawnPoint.position, Quaternion.identity);
        //clone.SetActive(true);


        Time.timeScale = 0;
        randomRangeNumber = Random.Range(1, 5);
        Debug.Log("Al�nan say�: " + randomRangeNumber);
    }


    void Update()
    {
        CharacterDestroyed();
        TimeChanger();

        if (Input.GetKeyDown(KeyCode.Escape) && gamePanelIsActive)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0)
        {
            Time.timeScale = 1;
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
