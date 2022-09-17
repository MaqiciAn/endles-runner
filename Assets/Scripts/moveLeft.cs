using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    int score;
    private float speed = 25;
    private PlayerController playerControllerScript;
    private float leftBound = -7f;
    void Start()
    {
        score = 0;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.Translate(Vector3.left * 75 * Time.deltaTime);
        }
        ScoreMethod();
    }
    void ScoreMethod()
    {
        if(Input.GetKeyDown(KeyCode.Z) && transform.position.x <playerControllerScript.transform.position.x)
        {
            score=score+2;
            Debug.Log(score);
        }
        else if(transform.position.x < playerControllerScript.transform.position.x)
        {
            score=score+1;
            Debug.Log(score);
        }
    }
}
