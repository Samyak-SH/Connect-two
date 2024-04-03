using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryController : MonoBehaviour
{
    public Text ScoreDisplay;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player1");
    }

    // Update is called once per frame
    void Update()
    {
        ScoreDisplay.text = "Your Score is " + Player.GetComponent<Player_1_Movement>().score.ToString();
        Player.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Player.GetComponent<Player_1_Movement>().kill();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
