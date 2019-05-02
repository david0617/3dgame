using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMeunManager : MonoBehaviour
{
    public GameObject startEndLesslGameB, startSurvivalGameB, exitGameB, loading, survive;
    private string EndlessGameS, SurvivalGameS;
    public int time;
    void Start()
    {
        loading.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void StartSurvivalGame()
    {
        SurvivalGameS = "Survival";
        StartCoroutine(StartGameTimer(SurvivalGameS));
    }

    public void StartEndLesslGame()
    {
        EndlessGameS = "Endless";
        StartCoroutine(StartGameTimer(EndlessGameS));
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGameload()
    {
        startSurvivalGameB.SetActive(false);
        startEndLesslGameB.SetActive(false);
        exitGameB.SetActive(false);
        survive.SetActive(false);
        loading.SetActive(true);
    }

    public IEnumerator StartGameTimer(string mode)
    {
        StartGameload();
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(mode);
    }
}
