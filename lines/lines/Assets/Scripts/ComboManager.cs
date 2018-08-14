using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour {


    // DO IT WITH RAYCASTS
    Vector2 worldPoint;


    public int combo;
    public bool canCombo;
    public GameObject comboPoint1; // black
    public GameObject comboPoint2; // white

    

    // Use this for initialization
    void Start () {
        combo = 0;
	}

    // Update is called once per frame
    private void Update()
    {
        if(PlayerMovement.changeComboPoint)
            worldPoint = comboPoint1.transform.position;
        else
            worldPoint = comboPoint2.transform.position;
        Debug.Log(worldPoint);

        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        if (hit.collider.gameObject.tag == "Line")
        {
            canCombo = true;
            Debug.Log("It works!  --  " + PlayerMovement.changeComboPoint);
        }
        else
            canCombo = false;

        if (Input.GetMouseButtonDown(0))
        {
            if (canCombo)
            {
                FindObjectOfType<ComboManager>().combo++;
                if (FindObjectOfType<ComboManager>().combo >= 2)
                {
                    FindObjectOfType<GameScreen>().combo.text = "Perfect!!";
                    FindObjectOfType<GameScreen>().combo.enabled = true;
                }
                //Debug.Log(FindObjectOfType<ComboManager>().combo);
            }
            else
            {
                FindObjectOfType<ComboManager>().combo = 0;
                FindObjectOfType<GameScreen>().combo.enabled = false;
                //Debug.Log(FindObjectOfType<ComboManager>().combo);
            }
        }
        
    }
}
