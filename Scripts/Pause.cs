using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public  GameObject PausePanel;
    public  GameObject GamePanel;
    public  void GamePause()
    {
        PausePanel.SetActive(!PausePanel.activeSelf);
        GamePanel.SetActive(!GamePanel.activeSelf);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PausePanel.SetActive(!PausePanel.activeSelf);
            GamePanel.SetActive(!GamePanel.activeSelf);
        }
    }
    public void Continue()
    {
        PausePanel.SetActive(!PausePanel.activeSelf);
        GamePanel.SetActive(!GamePanel.activeSelf);
    }
    public void Settings()
    {
        PlayerPrefs.SetInt("GoToBack", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}