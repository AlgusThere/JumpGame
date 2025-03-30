using Unity.VisualScripting;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] GameObject[] characters;

    public int selectedCharacter = 0;

    public static CharacterSelect instance = null;

    bool isStartCharacterOnStage;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        //PlayerPrefs.GetInt("selectedCharacter");
        //characters[selectedCharacter].SetActive(true);
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
        if(selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void OnClickApplyButton()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }
}
