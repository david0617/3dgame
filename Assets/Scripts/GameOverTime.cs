using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverTime : MonoBehaviour {
	public int GameOverTimer;
	private int Time;
	public Text TimeDisplay;
	private string GameOverTimerDisplay;
	// Use this for initialization
	void Start () {
		Time = GameOverTimer;
		StartCoroutine(GameOver());
	}
	
	// Update is called once per frame
	void Update () {
		GameOverTimerDisplay = Time.ToString();
		TimeDisplay.text = GameOverTimerDisplay;
	}
	private IEnumerator GameOver(){
		yield return new WaitForSeconds(1);
		Time --;
		if (Time >0){
			StartCoroutine(GameOver());
		}else{SceneManager.LoadScene("play");}
	}
}
