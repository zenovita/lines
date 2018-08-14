using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    float side = 1f;
    Transform child;
    Transform otherChild;
    bool gameStarted;

    public GameObject player;
    public GameObject oldRecord;

    public static float percentage;
    public static bool changeComboPoint;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("OldRecordX"))
        {
            Instantiate(oldRecord, new Vector3(PlayerPrefs.GetFloat("OldRecordX"), PlayerPrefs.GetFloat("OldRecordY"), PlayerPrefs.GetFloat("OldRecordZ")), Quaternion.identity);
        }
    }


    private void Start()
    {
        child = player.transform.GetChild(0);
        otherChild = player.transform.GetChild(1);
        gameStarted = true;
        changeComboPoint = false;
    }
    // Update is called once per frame
    void Update () {

        player.transform.GetChild(1).GetChild(0).transform.position = player.transform.GetChild(1).transform.position;
        player.transform.GetChild(0).GetChild(0).transform.position = player.transform.GetChild(0).transform.position;

        ////// SAVING OLD RECORD //////
        PlayerPrefs.SetFloat("OldRecordX", player.transform.GetChild(1).position.x);
        PlayerPrefs.SetFloat("OldRecordY", player.transform.GetChild(1).position.y);
        PlayerPrefs.SetFloat("OldRecordZ", player.transform.GetChild(1).position.z);
        ///////////////////////////////
        
#if UNITY_ANDROID
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //StartCoroutine(SmoothMove(player));
                //player.transform.GetChild(1).GetComponent<Rigidbody2D>().AddForce(new Vector2(10 * side,0));

                Transform temp = child;
                child = otherChild;
                otherChild = temp;

                if (side == 1)
                {
                    player.transform.GetChild(1).GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    player.transform.GetChild(1).GetComponent<DistanceJoint2D>().enabled = false;
                    //player.transform.GetChild(1).GetComponent<PolygonCollider2D>().enabled = false;
                    //player.transform.GetChild(0).GetComponent<PolygonCollider2D>().enabled = true;
                    player.transform.GetChild(0).GetComponent<DistanceJoint2D>().enabled = true;

                    player.transform.GetChild(1).GetComponent<Rigidbody2D>().isKinematic = true;
                    player.transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
                    player.transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 1;
                    
                }
                else
                {
                    player.transform.GetChild(0).GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    player.transform.GetChild(0).GetComponent<DistanceJoint2D>().enabled = false;
                    //player.transform.GetChild(1).GetComponent<PolygonCollider2D>().enabled = true;
                    //player.transform.GetChild(0).GetComponent<PolygonCollider2D>().enabled = false;
                    player.transform.GetChild(1).GetComponent<DistanceJoint2D>().enabled = true;

                    player.transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = true;
                    player.transform.GetChild(1).GetComponent<Rigidbody2D>().isKinematic = false;
                    player.transform.GetChild(1).GetComponent<Rigidbody2D>().gravityScale = 1;
                    
                    
                }

                if (child.position.x < otherChild.position.x)
                    otherChild.GetComponent<Rigidbody2D>().AddForce(new Vector2(330f, 0));
                else
                    otherChild.GetComponent<Rigidbody2D>().AddForce(new Vector2(-330f, 0));


                //player.transform.position = player.transform.GetChild(1).transform.position;
                //player.transform.RotateAround(player.transform.position, Vector3.right, 180f);

                //player.transform.GetChild(1).GetComponent<DistanceJoint2D>().enabled = false;
                //transform.position = transform.position - (new Vector3(0, 2f, 0));
                side *= -1;
                if (!gameStarted)
                {
                    HighscoreManager.highscore += 1;
                    FindObjectOfType<GameScreen>().highscore.text = HighscoreManager.highscore.ToString();
                    LevelManager.exp += 1;
                    FindObjectOfType<LevelManager>().loader.GetComponent<Image>().fillAmount = (LevelManager.exp / FindObjectOfType<LevelManager>().condition);
                    percentage = (LevelManager.exp / FindObjectOfType<LevelManager>().condition) * 100f;
                    //Debug.Log(LevelManager.exp / FindObjectOfType<LevelManager>().condition);
                }
                gameStarted = false;
                ChangeComboPoint();
            }
        }
        #endif
        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            //StartCoroutine(SmoothMove(player));
            //player.transform.GetChild(1).GetComponent<Rigidbody2D>().AddForce(new Vector2(10 * side,0));
            
            Transform temp = child;
            child = otherChild;
            otherChild = temp;

            if (side == 1)
            {
                player.transform.GetChild(1).GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player.transform.GetChild(1).GetComponent<DistanceJoint2D>().enabled = false;
                //player.transform.GetChild(1).GetComponent<PolygonCollider2D>().enabled = false;
                //player.transform.GetChild(0).GetComponent<PolygonCollider2D>().enabled = true;
                player.transform.GetChild(0).GetComponent<DistanceJoint2D>().enabled = true;

                player.transform.GetChild(1).GetComponent<Rigidbody2D>().isKinematic = true;
                player.transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
                player.transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 1;
                
                
            }
            else
            {
                player.transform.GetChild(0).GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player.transform.GetChild(0).GetComponent<DistanceJoint2D>().enabled = false;
                //player.transform.GetChild(1).GetComponent<PolygonCollider2D>().enabled = true;
                //player.transform.GetChild(0).GetComponent<PolygonCollider2D>().enabled = false;
                player.transform.GetChild(1).GetComponent<DistanceJoint2D>().enabled = true;

                player.transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = true;
                player.transform.GetChild(1).GetComponent<Rigidbody2D>().isKinematic = false;
                player.transform.GetChild(1).GetComponent<Rigidbody2D>().gravityScale = 1;
                
                
            }

            if (child.position.x < otherChild.position.x)
                otherChild.GetComponent<Rigidbody2D>().AddForce(new Vector2(250f, 0));
            else
                otherChild.GetComponent<Rigidbody2D>().AddForce(new Vector2(-250f, 0));


            //player.transform.position = player.transform.GetChild(1).transform.position;
            //player.transform.RotateAround(player.transform.position, Vector3.right, 180f);

            //player.transform.GetChild(1).GetComponent<DistanceJoint2D>().enabled = false;
            //transform.position = transform.position - (new Vector3(0, 2f, 0));
            side *= -1;
            if (!gameStarted)
            {
                HighscoreManager.highscore += 1;
                FindObjectOfType<GameScreen>().highscore.text = HighscoreManager.highscore.ToString();
                LevelManager.exp += 1;
                FindObjectOfType<LevelManager>().loader.GetComponent<Image>().fillAmount = (LevelManager.exp / FindObjectOfType<LevelManager>().condition);
                percentage = (LevelManager.exp / FindObjectOfType<LevelManager>().condition) * 100;
                //Debug.Log(LevelManager.exp / FindObjectOfType<LevelManager>().condition);

                /*if (FindObjectOfType<ComboManager>().canCombo)
                {
                    FindObjectOfType<ComboManager>().combo++;
                    if (FindObjectOfType<ComboManager>().combo >= 2)
                    {
                        FindObjectOfType<GameScreen>().combo.text = FindObjectOfType<ComboManager>().combo.ToString();
                        FindObjectOfType<GameScreen>().combo.enabled = true;
                    }
                        
                    //Debug.Log(FindObjectOfType<ComboManager>().combo);
                }
                else
                {
                    FindObjectOfType<ComboManager>().combo = 0;
                    FindObjectOfType<GameScreen>().combo.enabled = false;
                    //Debug.Log(FindObjectOfType<ComboManager>().combo);
                }*/
            }
            gameStarted = false;
            ChangeComboPoint();
            // distance

        }
#endif
        
        //transform.Translate(new Vector3(-0.06f, 0, 0));
        //player.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(300, 0));
    }
    void ChangeComboPoint()
    {
        changeComboPoint = !changeComboPoint;
    }
    IEnumerator SmoothMove(GameObject obj)
    {
        Vector3 initialPos = obj.transform.position;
        Vector3 targetPos = obj.transform.position - (Vector3.up);
        float currentTime = 0;
        float totalTime = 0.4f;
        while (currentTime < totalTime)
        {
            obj.transform.position = Vector3.Lerp(initialPos, targetPos, currentTime / totalTime);

            yield return new WaitForEndOfFrame();
            currentTime = currentTime + Time.deltaTime;
        }
    }
}
