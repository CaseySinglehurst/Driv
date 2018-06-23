using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [HideInInspector]
    public bool isGameOver = false;

    float timeAlive;
    public int score;

    bool addedCoins = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!isGameOver)
        {
            timeAlive += Time.deltaTime;
            score = (int)(timeAlive);
        }
        else if (!addedCoins)
        {
            addedCoins = true;
            ServerController.instance.coins += CalculateCoins();

        }
	}

    public int CalculateCoins()
    {
        return (int)( 1 + (score / 10));
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }


}
