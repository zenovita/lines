using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameScreen : MonoBehaviour {

    public Text highscore;
    public Text combo;
	// Use this for initialization
	void Start () {
        combo.text = FindObjectOfType<ComboManager>().combo.ToString();
        combo.enabled = false;
        highscore.text = HighscoreManager.highscore.ToString();
        Application.targetFrameRate = 60;
        
	}
	
}
