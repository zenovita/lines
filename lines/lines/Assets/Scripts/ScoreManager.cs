using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    bool canScore;
    float endTime = 0f;

    public GameObject player;
    public GameObject holder;
    public GameObject otherHolder;
    public Vector3 position;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canScore = true;
        position = collision.transform.position;
        //Debug.Log(position);
        if (collision.tag == "Collectable")
        {
            LevelManager.exp += 3;
            FindObjectOfType<LevelManager>().loader.GetComponent<Image>().fillAmount = (LevelManager.exp / FindObjectOfType<LevelManager>().condition);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canScore = true;
        position = collision.transform.position;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canScore = false;
        //Debug.Log(canScore);
    }


    private void Update()
    {
        if (!canScore)
        {
#if UNITY_ANDROID

            if(Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began && !canScore)
                {
                    player.GetComponent<PlayerMovement>().enabled = false;
                    holder.GetComponent<Rigidbody2D>().isKinematic = false;
                    otherHolder.GetComponent<Rigidbody2D>().isKinematic = false;
                    Time.timeScale = 0.5f;
                    Invoke("LoadEndScreen", 0.5f);
                    //FindObjectOfType<CameraMovement>().gameEnded = true;
                }
            }
            
#endif
    
        }
#if UNITY_EDITOR

        
        if (Input.GetMouseButtonDown(0) && !canScore)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            holder.GetComponent<Rigidbody2D>().isKinematic = false;
            otherHolder.GetComponent<Rigidbody2D>().isKinematic = false;
            Time.timeScale = 0.5f;
            Invoke("LoadEndScreen", 0.5f);
            Debug.Log("GameFinished");
            //FindObjectOfType<CameraMovement>().gameEnded = true;
        }
#endif
        }

    void LoadEndScreen()
    {
        SceneManager.LoadScene("GameOver");
    }
}
