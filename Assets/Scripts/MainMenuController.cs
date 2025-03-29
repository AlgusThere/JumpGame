using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject customizePanel;
    [SerializeField] GameObject[] characters;

    [Header("Other")]
    [SerializeField] Transform spawnPoint;

    [Header("Texts")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverScoreText;

    int currentScore;
    public int selectedCharacter;

    public static MainMenuController instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        startPanel.SetActive(true);
    }

    public void ClickStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickCustomizeButton()
    {
        startPanel.SetActive(false);
        customizePanel.SetActive(true);
    }

    public void ClickApplyButton()
    {
        customizePanel.SetActive(false);
        startPanel.SetActive(true);
    }

    public void ExitAppButton()
    {
        Application.Quit();
    }
}
