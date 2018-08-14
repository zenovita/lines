using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public static float exp;
    public Text levelText;
    public Text nextLText;
    public Image loader;
    public float condition;
    int level;
    int nextLevel;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Level"))
            level = PlayerPrefs.GetInt("Level");
        else
            level = 0;
        nextLevel = level + 1;
        exp = 0;
        condition = (level * 5) + 5;
        levelText.text = level.ToString();
        nextLText.text = nextLevel.ToString();
        loader.GetComponent<Image>().fillAmount = 0f;
    }

    // Update is called once per frame
    void Update () {
        if (exp > condition)
        {
            level++;
            nextLevel++;
            levelText.text = level.ToString();
            nextLText.text = nextLevel.ToString();
            PlayerPrefs.SetInt("Level", level);
            condition += (level * 5) + 5;
            loader.GetComponent<Image>().fillAmount = 0;
            PlayerPrefs.SetFloat("Experience", 0f);
            exp = 0;
        }
    }
}
