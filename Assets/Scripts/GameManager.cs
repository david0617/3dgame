using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public void GameOver() {
		NextScenes NS = GameObject.Find("NextScene").GetComponent<NextScenes>();
		NS.next();
		SceneManager.LoadScene("GameOver");
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene("Start");
		}
	}
}
