using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject character;

    void Start()
    {
        Time.timeScale = 0;
        startPanel.SetActive(true);
    }

    
    void Update()
    {
        if(character.IsDestroyed())
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void ClickStartButton()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        Time.timeScale = 1;
    }
}
