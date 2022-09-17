using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public Transform startingPoint;
    public float lerpSpeed;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerControllerScript.gameOver = true;
        StartCoroutine(PlayIntro());
    }

    void Update()
    {
        
    }

    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerControllerScript.transform.position;
        Vector3 endPos = startingPoint.position;
        float JourneyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float FractionOfJourney = distanceCovered / JourneyLength;
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

        while (FractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            FractionOfJourney = distanceCovered / JourneyLength;
            playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos, FractionOfJourney);
            yield return null;
        }
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1f);
        playerControllerScript.gameOver = false;
    }
}
