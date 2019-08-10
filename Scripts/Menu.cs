using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Settings;
    public GameObject MainChoice;
    public GameObject ExitChoice;
    private int NumberOfLevel;
    private string GoToBack;
    private static int Level;

    public void Continue()
    {
        if (!PlayerPrefs.HasKey("NumberOfLevel"))
            Debug.Log("Еще нет ни одного сохранения");
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("NumberOfLevel"));
            Debug.Log("Загружен уровень: " + PlayerPrefs.GetInt("NumberOfLevel"));
            Dialogue_System.Level = PlayerPrefs.GetInt("SavePhrase");
            Debug.Log("Загружена фраза: " + PlayerPrefs.GetInt("SavePhrase"));
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Options()
    {
        PlayerPrefs.SetInt("GoToBack", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        MainChoice.SetActive(!MainChoice.activeSelf);
        ExitChoice.SetActive(!ExitChoice.activeSelf);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            MainChoice.SetActive(!MainChoice.activeSelf);
            ExitChoice.SetActive(!ExitChoice.activeSelf);
        }
    }
    public void ExitNo()
    {
        MainChoice.SetActive(!MainChoice.activeSelf);
        ExitChoice.SetActive(!ExitChoice.activeSelf);
    }
    public void ExitYes()
    {
        Debug.Log("Выход из игры..");
        Application.Quit();
    }
}