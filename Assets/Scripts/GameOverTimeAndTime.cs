using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTimeAndTime : MonoBehaviour
{
    public int TimerS, TimerM, points;
    public Text TimerDisplay, PointDisplay;
    private string GameTimerDisplay, GamepointDisplay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(k());
    }

    IEnumerator k()
    {
        yield return new WaitForSeconds(1);
        NextScenes NS = GameObject.Find("NextScene").GetComponent<NextScenes>();
        TimerM = NS.timerM;
        points = NS.point;
        TimerS = NS.timerS;

        PointDisplay.text = "point: " + points;
        TimerDisplay.text = "Game Time: " + TimerM + ":" + TimerS;
    }
}
