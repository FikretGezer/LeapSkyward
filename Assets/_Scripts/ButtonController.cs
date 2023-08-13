using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject[] itemsOnMenu;
    [SerializeField] private GameObject[] itemsInGame;
    [SerializeField] private Transform inGameCanvas;

    private GameObject gamePanel;
    private GameObject pausePanel;
    private GameObject endGamePanel;

    public static ButtonController Instance;
    private void Awake() {
        if(Instance == null) Instance = this;

        Time.timeScale = 1f;

        gamePanel = inGameCanvas.GetChild(0).gameObject;
        pausePanel = inGameCanvas.GetChild(1).gameObject;
        endGamePanel = inGameCanvas.GetChild(2).gameObject;
    }
    public void EnableEndGameMenu()
    {
        gamePanel.SetActive(false);
        pausePanel.SetActive(false);
        endGamePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Play()
    {
        DisableOrEnable(itemsOnMenu, false);
        DisableOrEnable(itemsInGame, true);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        gamePanel.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void DisableOrEnable(GameObject[] objects, bool activation)
    {
        foreach(var obj in objects)
        {
            obj.SetActive(activation);
        }
    }
}
