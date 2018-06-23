using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDetector : MonoBehaviour {

    int currentRoadCollisions = 0;

    RoadController rC;
    GameController gC;
	// Use this for initialization
	void Start () {
        rC = GameObject.FindGameObjectWithTag("RoadController").GetComponent<RoadController>();
        gC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "NewRoad")
        {
            rC.AddNewRoadSegment();
            col.tag = "Road";
            currentRoadCollisions++;
        }
        else if (col.tag == "Road")
        {
            currentRoadCollisions++;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Road")
        {
            currentRoadCollisions--;
        }
    }

    private void Update()
    {
        if (currentRoadCollisions == 0)
        {
            gC.isGameOver = true;
        }
    }


}
