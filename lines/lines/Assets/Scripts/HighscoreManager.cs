using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighscoreManager : MonoBehaviour {

    public static int highscore;
    public static int combo;

    private void Start()
    {
        highscore = 0;
        combo = 0;
    }
}
