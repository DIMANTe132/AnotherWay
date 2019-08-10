using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    public int curI;
    public string end;
    public string level;
    public Dialogue_System d;
	
	void Start () {
        d = GetComponentInParent<Dialogue_System>();
	}
	
	public void next()
    {
        d.Next(curI, end, level);
    }
}
