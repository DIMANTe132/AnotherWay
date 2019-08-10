using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {
    public AudioSource music;
	void Start ()
    {
        if (PlayerPrefs.HasKey("volume"))
            music.volume = 1;
    }
	
	void Update ()
    {
        music.volume = PlayerPrefs.GetFloat("volume");
    }
}
