using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            Time.timeScale = 0.5f;
            Invoke("LoadEndScreen", 0.5f);
        }
        else
        {
            if(collision.gameObject.transform.parent)
                Destroy(collision.gameObject.transform.parent.gameObject);
            else
                Destroy(collision.gameObject);
        }
    }

    void LoadEndScreen()
    {
        SceneManager.LoadScene("GameOver");
    }
}
