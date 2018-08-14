using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public bool gameEnded;
    public Transform player;


    // Update is called once per frame
    private void Start()
    {
        transform.position = new Vector3(0 ,0 ,-2.5f); //CHANGED
        gameEnded = false;
    }
    void Update()
    {
        if (!gameEnded)
        {
            if ((player.transform.GetChild(0).position.x + player.transform.GetChild(1).position.x) / 2 < transform.GetChild(2).position.x || (player.transform.GetChild(0).position.x + player.transform.GetChild(1).position.x) / 2 > transform.GetChild(3).position.x)
            {
                if ((player.transform.GetChild(0).position.x + player.transform.GetChild(1).position.x) / 2 < transform.GetChild(2).position.x)
                    transform.position += new Vector3(-0.018f, 0, 0);
                else if ((player.transform.GetChild(0).position.x + player.transform.GetChild(1).position.x) / 2 > transform.GetChild(3).position.x)
                    transform.position += new Vector3(0.018f, 0, 0);
            }

            if (((player.GetChild(0).position.y + player.GetChild(1).position.y) / 2) < transform.position.y - 2)
                transform.position = new Vector3(transform.position.x, ((player.GetChild(0).position.y + player.GetChild(1).position.y) / 2) + 2, -2);
            else
                transform.position += new Vector3(0, -0.020f, 0);//new Vector3(player.transform.GetChild(0).position.x, player.transform.GetChild(0).position.y, -2);

        }

    }
    IEnumerator GoToPlayer()
    {
        //Vector3 initialPos = obj.transform.position;
        Vector3 targetPos = new Vector3 (transform.position.x , ((player.GetChild(0).position.y + player.GetChild(1).position.y) / 2), -2); //((player.GetChild(0).position.x + player.GetChild(1).position.x) / 2)
        float currentTime = 0;
        float totalTime = 1.5f;
        while (currentTime < totalTime)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, currentTime / totalTime);

            yield return new WaitForEndOfFrame();
            currentTime = currentTime + Time.deltaTime;
        }
    }
    /*
    IEnumerator FollowPlayerX()
    {
        float currentTime = 0;
        float totalTime = 1.5f;
        Vector3 targetPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        Vector3 targetPos1 = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);

        if ((player.transform.GetChild(0).position.x + player.transform.GetChild(1).position.x) / 2 < xMargin - 2 || (player.transform.GetChild(0).position.x + player.transform.GetChild(1).position.x) / 2 > xMargin) {
            while (currentTime < totalTime)
            {
                if (((player.transform.GetChild(0).position.x + player.transform.GetChild(1).position.x) / 2) < xMargin - 2)
                {
                    transform.position = Vector3.Lerp(transform.position, targetPos, currentTime / totalTime);
                    xMargin -= 1;
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, targetPos1, currentTime / totalTime);
                    xMargin += 1;
                } 
                yield return new WaitForEndOfFrame();
                currentTime += Time.deltaTime;
            }
        }
    }*/
}
