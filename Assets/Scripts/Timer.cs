using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int timeS, timeM, time;
    public bool endLess, key;
    public Text timerDisplay;
    // Use this for initialization
    void Start()
    {
        if (endLess)
        {
            timeS = 0;
            timeM = 0;
            StartCoroutine(Times());
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeM.ToString();
        timeS.ToString();
        timerDisplay.text = timeM + ":" + timeS;
        if (timeS == 0 && timeM == 0)
        {
            key = true;
            StopCoroutine(Timers());
        }
    }
    private IEnumerator Timers()
    {
        yield return new WaitForSeconds(time);
        if (timeS == 0 && timeM == 0)
        {
            key = true;
            StopCoroutine(Timers());
        }
        else if (timeS == 1 && timeM > 0)
        {
            timeM -= 1;
            timeS = 59;
        }
        else
        {
            timeS--;
        }
        StartCoroutine(Timers());
    }

    public void OnTriggerEnter(Collider go)
    {
        Key k = go.gameObject.GetComponent<Key>();
        if (k != null)
        {
            StartCoroutine(Timers());
        }
    }

    private IEnumerator Times()
    {
        yield return new WaitForSeconds(time);
        timeS++;
        if (timeS == 59)
        {
            timeM++;
            timeS = 0;
        }
        StartCoroutine(Times());
    }
}
