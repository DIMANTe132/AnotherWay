using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour {
    private int Level;
    public void Startlevel1()
    {
        Dialogue_System.Level = 0;
        SceneManager.LoadScene(3);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if(Input.GetKeyUp (KeyCode.Escape))
            SceneManager.LoadScene(0);
    }
}
