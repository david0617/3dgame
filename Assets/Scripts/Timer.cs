using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public int timeS,timeM;
	public bool endLess,key;
	public Text timerDisplay;
	// Use this for initialization
	void Start () {
		if(endLess){
			timeS = 0;
			timeM = 0;
			StartCoroutine(Times());
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeM.ToString();
		timeS.ToString();
		timerDisplay.text = timeM + ":" + timeS;
	}
	private IEnumerator Timers(){
		yield return new WaitForSeconds(1);
		timeS -- ;
		print(timeS);
		if(timeS == 0 || timeS < 0){
			timeM--;
			timeS = 59;
		}
		StartCoroutine(Timers());
	}

	 public void OnTriggerEnter(Collider go)
    {
        PlayerHealth ph = go.gameObject.GetComponent<PlayerHealth>();
        if (ph != null && key)
        {
			StartCoroutine(Timers());
        }
    }

	private IEnumerator Times(){
		yield return new WaitForSeconds(1);
		timeS ++;
		if(timeS == 59){
			timeM ++;
			timeS = 0;
		}
		StartCoroutine(Times());
	}
}
