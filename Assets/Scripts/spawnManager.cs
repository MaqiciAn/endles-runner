using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    Vector3 spawnPos = new Vector3(40, 0, 0);
    private float delayTime = 2f;
    private float repeatDelay = 2f;
    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("spawner", delayTime, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawner()
    {
        int index = Random.Range(0, 2);
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab[index], spawnPos, obstaclePrefab[index].transform.rotation);
        }
        
    }
}
