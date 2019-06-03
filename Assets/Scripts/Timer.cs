using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int timeS, timeM;
    public int kTimeS, kTimeM;
    public bool key, display;
    public Text timerDisplay, keyTimerDisplay;
    public GameObject keyTimerDisplayObj;
    // Use this for initialization
    void Start()
    {
        timeM = 0;
        timeS = 0;
        StartCoroutine(Times());
        keyTimerDisplayObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeM.ToString();
        timeS.ToString();
        timerDisplay.text = timeM + ":" + timeS;
        keyTimerDisplay.text = kTimeM + ":" + kTimeS;
        if (display == false)
        {
            keyTimerDisplayObj.SetActive(false);
        }
        PlayerHealth ph = gameObject.GetComponent<PlayerHealth>();
        if (ph.currenthealth <= 0)
        {
        StopAllCoroutines();
        }
    }
    private IEnumerator Timers()
    {
        yield return new WaitForSeconds(1);
        if (kTimeS == 0 && kTimeM == 0)
        {
            key = true;
            display = false;
            StopCoroutine(Timers());
        }
        else if (kTimeS == 0 && kTimeM > 0)
        {
            kTimeM--;
            kTimeS = 59;
        }
        else
        {
            kTimeS--;
        }
        StartCoroutine(Timers());
    }

    public void OnTriggerEnter(Collider go)
    {
        Key k = go.gameObject.GetComponent<Key>();
        if (k != null)
        {
            StartCoroutine(Timers());
            display = true;
            keyTimerDisplayObj.SetActive(true);
        }
    }

    private IEnumerator Times()
    {
        yield return new WaitForSeconds(1);
        timeS++;
        if (timeS == 59)
        {
            timeM++;
            timeS = 0;
        }
        StartCoroutine(Times());
    }
}
