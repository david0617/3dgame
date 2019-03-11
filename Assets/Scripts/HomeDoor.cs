using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeDoor : MonoBehaviour
{
    public Text textDisplay;
    public GameObject textDisplayOBJ;

    private void Start()
    {
        textDisplayOBJ.SetActive(false);
    }
    public void OnTriggerEnter(Collider go)
    {
        Timer KO = go.gameObject.GetComponent<Timer>();

        PlayerHealth ph = go.gameObject.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            if (KO.key == true)
            {
                textDisplayOBJ.SetActive(true);
                textDisplay.text = "Hit F";
                if (Input.GetKeyDown("f"))
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
            else
            {
                textDisplayOBJ.SetActive(true);
                textDisplay.text = "You can not open the door";
            }
        }

    }
    public void OnTriggerExit(Collider go)
    {
        textDisplayOBJ.SetActive(false);
    }
}
