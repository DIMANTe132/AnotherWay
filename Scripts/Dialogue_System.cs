using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Dialogue_System : MonoBehaviour
{
    public TextAsset asset;

    public static int Level;
    private int SavePhrase;
    private int i;

    public Text dialogue_Text;

    Dialogue_Settings dialogue;

    public GameObject[] buttons;
    public GameObject NextButton;

    void Start ()
    {
        i = Level;
        Level = 0;
        dialogue = Dialogue_Settings.Load(asset);
        PlayerPrefs.SetInt("SavePhrase", i);
        Debug.Log("Звучит и сохраняется фраза под номером: " + PlayerPrefs.GetInt("SavePhrase"));
        PlayerPrefs.SetInt("NumberOfLevel", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Вы перешли и сохранили " + PlayerPrefs.GetInt("NumberOfLevel") + " сцена");
        StopAllCoroutines();
        StartCoroutine(TypeDialogueText(dialogue.nodes[i].text));
    }
	
	
	void Update ()
    {
        if (dialogue.nodes[i].end != "true")
        {
            NextButton.SetActive(false);
            for (int j = 0; j < dialogue.nodes[i].answers.Length; j++)
            {
                buttons[j].SetActive(true);
                buttons[j].GetComponent<ButtonManager>().end = "";
                buttons[j].GetComponentInChildren<Text>().text = dialogue.nodes[i].answers[j].anstext;
                buttons[j].GetComponent<ButtonManager>().curI = dialogue.nodes[i].answers[j].n;
                if(dialogue.nodes[i].answers[j].end == "true")
                {
                    buttons[j].GetComponent<ButtonManager>().end = dialogue.nodes[i].answers[j].end;
                    buttons[j].GetComponent<ButtonManager>().level = dialogue.nodes[i].answers[j].level;
                }
            }
        }
        else
        {
            NextButton.SetActive(true);
            for (int j = 0; j < buttons.Length; j++)
                buttons[j].SetActive(false);
        }
    }

    public void Next(int nextNode, string end, string level)
    {
        if(i <= dialogue.nodes.Length-1)
        {
            if (dialogue.nodes[i].end == "true")
            {
                i++;
                PlayerPrefs.SetInt("SavePhrase", i);
                Debug.Log("Звучит и сохраняется фраза под номером: " + PlayerPrefs.GetInt("SavePhrase"));
                PlayerPrefs.SetInt("NumberOfLevel", SceneManager.GetActiveScene().buildIndex);
                Debug.Log("Вы перешли и сохранили " + PlayerPrefs.GetInt("NumberOfLevel") + " сцена");
            }
            else
            {
                if (end != "true")
                {
                    i = nextNode;
                }
                else
                {
                    SceneManager.LoadScene(level);
                }
            }
        }

        StopAllCoroutines();
        StartCoroutine(TypeDialogueText(dialogue.nodes[i].text));
    }

    IEnumerator TypeDialogueText(string dial)
    {
        dialogue_Text.text = "";
        foreach(char letter in dial.ToCharArray())
        {
            dialogue_Text.text += letter;
            yield return null;
        }
    }


    public void NextB()
    {
        Next(0, "", "");
    }
}
