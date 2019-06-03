using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pointdisplay : MonoBehaviour
{
    public Text Pointdisplays;
    private string pointsdisplay;
    public int point;
    private bool goPoint;
    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        goPoint = true;
        StartCoroutine(time());
    }
    // Update is called once per frame
    void Update()
    {
     PlayerHealth ph = gameObject.GetComponent<PlayerHealth>();
        if (ph.currenthealth <= 0)
        {
        StopAllCoroutines();
        }
    }
    public IEnumerator time()
    {
        yield return new WaitForSeconds(1);
        point++;
        pointsdisplay = point.ToString();
        Pointdisplays.text = "point: " + pointsdisplay;
        StartCoroutine(time());
    }
    public void add(int addpoint)
    {
        point = addpoint + point;
        addpoint = 0;
        pointsdisplay = point.ToString();
        Pointdisplays.text = "point: " + pointsdisplay;
    }
    public IEnumerator Frames()
    {
        goPoint = false;
        yield return new WaitForSeconds(2);
        goPoint = true;
    }



}

