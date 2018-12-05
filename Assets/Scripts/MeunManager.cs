using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeunManager : MonoBehaviour {

	public void StartSurvivalGame(){
		SceneManager.LoadScene("Survival");
	}

	public void StartEndLesslGame(){
		SceneManager.LoadScene("EndLess");
	}
	public void ExitGame(){
		Application.Quit();
	}
}
