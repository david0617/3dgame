using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public int ReloadGameScene;
	public void GameOver() {
		StartCoroutine(ReloadScene());
	}

	private IEnumerator ReloadScene (){
		yield return new WaitForSeconds(ReloadGameScene);
		Scene Scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(Scene.name);
	}
}
