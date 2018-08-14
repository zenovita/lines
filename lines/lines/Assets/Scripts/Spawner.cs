using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    bool started;
    bool side = true;
    Vector3 nextSpawnLocation;
    Vector3 endPoint;
    Vector3 startPoint;

    public GameObject clone;
    public GameObject[] obj;
    public GameObject[] lines;
    public GameObject line;
    public GameObject spawner;
    public GameObject collectable;
    public float spawnMin = 1f;
    public float spawnMax = 2f;

    // Use this for initialization
    void Start()
    {
        nextSpawnLocation = new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z + 2); // new Vector3(Random.Range(-3f, 1f), spawner.transform.position.y, 0);
        started = false;
        //Spawn();
    }
    private void Update()
    {
        
        #if UNITY_ANDROID
            if(Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Spawn();
                    Spawn();
                }
            }
        #endif
        #if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                Spawn();
                Spawn();
            }
        #endif
        
    }

    //DOUBLE SPAWN USER CATCHES THE SPAWNER 
    private void Spawn()
    {
        int randomLine = Random.Range(0,3);
        if(side)
            clone = Instantiate(lines[randomLine], nextSpawnLocation, Quaternion.Euler(new Vector3(0, 0, Random.Range(0f, 45f))));
        else
            clone = Instantiate(lines[randomLine], nextSpawnLocation, Quaternion.Euler(new Vector3(0, 0, Random.Range(315f, 360f))));
        //Debug.Log(clone.transform.GetChild(0).name); // end point 
        //Debug.Log(clone.transform.GetChild(1).name); // start point
        //Debug.Log(spawner.transform.position.y);

        if (started)
        {
            startPoint = clone.transform.GetChild(0).position;
            Vector3 moveThatMuch = endPoint - startPoint;
            clone.transform.position = clone.transform.position + moveThatMuch;

            if (clone.transform.GetChild(1).position.x < -2.3f || clone.transform.GetChild(1).position.x > 2.3f)
            {
                if (clone.transform.GetChild(1).position.x < -2.3f)
                    clone.transform.position -= new Vector3(endPoint.x + 0.5f, 0, 0);
                if (clone.transform.GetChild(1).position.x > 2.3f)
                    clone.transform.position -= new Vector3(endPoint.x - 0.5f, 0, 0); 
            }

            float randomNum = Random.Range(0, 10);
            if (randomNum < 2)
            {
                if (randomNum < 1)
                    Instantiate(collectable, new Vector3(clone.transform.position.x + 1, clone.transform.position.y, clone.transform.position.z), Quaternion.identity);
                else
                    Instantiate(collectable, new Vector3(clone.transform.position.x - 1, clone.transform.position.y, clone.transform.position.z), Quaternion.identity);

            }

        }
        else
            started = true;

        endPoint = clone.transform.GetChild(1).position;
        side = !side;
        

        //Vector3 offset = clone.transform.up * (clone.transform.localScale.y / 2f) * -1f;
        //Vector3 pos = clone.transform.position + offset; //This is the position
        //nextSpawnLocation = pos;
        //Invoke("Spawn", 0.4f);
    }
}
