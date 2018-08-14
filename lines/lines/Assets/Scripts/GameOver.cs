using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour {


    public Button restart;
    public Text showHighscore;
    public Text showPercentage;
    public Text levelText;
    int showThis;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
        restart.onClick.AddListener(RestartGame);
        showHighscore.text = HighscoreManager.highscore.ToString();
        showThis = (int)PlayerMovement.percentage;
        showPercentage.text = showThis.ToString();
        levelText.text = PlayerPrefs.GetInt("Level").ToString();
	}
	
    void RestartGame()
    {
        HighscoreManager.highscore = 0;
        SceneManager.LoadScene("GameScene");
    }
	
}
