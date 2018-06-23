using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIController : MonoBehaviour {

    

    public GameController gc;
    public TextMeshProUGUI scoreText, gameOverScoreText, gameOverCoinsText;

    public GameObject gameOverPanel;

    public Vector2 gameOverTextPosition;

    public float UISpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gc.isGameOver)
        {
            gameOverPanel.transform.position = Vector2.Lerp(gameOverPanel.transform.position,gameOverTextPosition, UISpeed * Time.deltaTime);

            gameOverScoreText.text = "You Scored " + gc.score.ToString() + " Points!";
            gameOverCoinsText.text = "You Earned " + gc.CalculateCoins().ToString() + " Coins!";



        }
        else
        {
            scoreText.text = gc.score.ToString();
        }
	}
}
