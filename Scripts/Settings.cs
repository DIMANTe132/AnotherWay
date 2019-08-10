using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    public Slider slider;
    public float OldValume;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volume");
        OldValume = slider.value;
        if (!PlayerPrefs.HasKey("volume"))
            slider.value = 1;
    }

    public void BackToGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("GoToBack"));
        Dialogue_System.Level = PlayerPrefs.GetInt("SavePhrase");
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("GoToBack"));
            Dialogue_System.Level = PlayerPrefs.GetInt("SavePhrase");
        }
        if (OldValume != slider.value)
        {
            PlayerPrefs.SetFloat("volume", slider.value);
            OldValume = slider.value;
        }
    }
}
