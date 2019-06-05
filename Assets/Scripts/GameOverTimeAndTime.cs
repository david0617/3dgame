using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTimeAndTime : MonoBehaviour
{
    public int TimerS, TimerM, points;
    public Text TimerDisplay, PointDisplay;
    public GameObject YW, GO;
    private string GameTimerDisplay, GamepointDisplay;
    // Start is called before the first frame update
    void Start()
    {
        YW.SetActive(false);
        GO.SetActive(false);
        StartCoroutine(k());

    }

    IEnumerator k()
    {
        yield return new WaitForSeconds(1);
        NextScenes NS = GameObject.Find("NextScene").GetComponent<NextScenes>();
        if (NS.gameover == true)
        {
            GO.SetActive(true);
        }
        else
        {
            YW.SetActive(true);
        }
        TimerM = NS.timerM;
        points = NS.point;
        TimerS = NS.timerS;

        PointDisplay.text = "point: " + points;
        TimerDisplay.text = "Game Time: " + TimerM + ":" + TimerS;
    }
}
