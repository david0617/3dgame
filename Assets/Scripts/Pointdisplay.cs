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
        goPoint = true;
        StartCoroutine(time());
    }
    // Update is called once per frame
    void Update()
    {

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
        print(point.ToString());
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

