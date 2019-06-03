 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScenes : MonoBehaviour
{
    static public int timeRM, timeRS, pointS;
    public int timerM, timerS, point;

    void Start()
    {
        timerM = timeRM;
        timerS = timeRS;
        point = pointS;
        print("M " + timerM);
        print("S " + timerS);
        print("point " + point);
    }
    void Update()
    {
//        Pointdisplay Pointdisplay = GameObject.Find("player").GetComponent<Pointdisplay>();
//        Timer timer = GameObject.Find("player").GetComponent<Timer>();
//        timeRM = timer.timeM;
//        timeRS = timer.timeS;
//        pointS = Pointdisplay.point;
    }

    public void next()
    {
        Pointdisplay Pointdisplay = GameObject.Find("player").GetComponent<Pointdisplay>();
        Timer timer = GameObject.Find("player").GetComponent<Timer>();
        timeRM = timer.timeM;
        timeRS = timer.timeS;
        pointS = Pointdisplay.point;
    }
}
