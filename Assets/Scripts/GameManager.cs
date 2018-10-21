using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public int ReloadGameSceneTimer;
	public void GameOver() {
		StartCoroutine(ReloadScene());
	}

	private IEnumerator ReloadScene (){
		yield return new WaitForSeconds(ReloadGameSceneTimer);
		Scene Scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(Scene.name);
	}
}
