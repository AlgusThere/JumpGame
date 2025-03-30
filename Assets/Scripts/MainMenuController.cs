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

    public int selectedCharacter = 0;

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
        PlayerPrefs.GetInt("selectedCharacter");
    }

    public void ClickStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickCustomizeButton()
    {
        startPanel.SetActive(false);
        customizePanel.SetActive(true);
        //PlayerPrefs.GetInt("selectedCharacter");
        characters[selectedCharacter].SetActive(true);
    }
    public void OnClickNextCharacterButton()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void OnClickPreviousCharacterButton()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void OnClickApplyButton()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        customizePanel.SetActive(false);
        startPanel.SetActive(true);
        characters[selectedCharacter].SetActive(false);
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
