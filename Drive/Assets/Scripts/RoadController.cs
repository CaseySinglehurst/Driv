using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour {

    public GameObject[] roadSegments;

    public GameObject[] turnSegments;



    List<GameObject> road = new List<GameObject>();

    int currentSpawnedSegment, currentRoadSegment;

    public int segmentBuffer = 5;


	// Use this for initialization
	void Start () {
        GameObject firstRoad = Instantiate(roadSegments[0], new Vector3(0, -5f, 5f), Quaternion.identity) as GameObject;
        road.Add(firstRoad);
        firstRoad.GetComponent<CreateDropShadow>().enabled = true;

        for (int i = 1; i<segmentBuffer; i++)
        {
            AddNewRoadSegment();
        }
	}
	
	public void AddNewRoadSegment()
    {
        
        GameObject newRoad;
        if ((currentSpawnedSegment % 4) == 0)
        {
            newRoad = Instantiate(turnSegments[Random.Range(0, turnSegments.Length)], new Vector3(0, 0, 0), road[currentSpawnedSegment].transform.GetChild(1).rotation);
        }
        else
        {
            newRoad = Instantiate(roadSegments[Random.Range(0, roadSegments.Length)], new Vector3(0, 0, 0), road[currentSpawnedSegment].transform.GetChild(1).rotation);
        }

        //test if works
        {
            newRoad.transform.GetChild(Random.Range(0, 2)).SetAsFirstSibling();
            newRoad.transform.GetChild(0).Rotate(0, 0, 180);
            newRoad.transform.Rotate(-newRoad.transform.GetChild(0).localRotation.eulerAngles);

        }


        //newRoad.transform.rotation = Quaternion.Euler(0, 180 * (1 + (-2 * Random.Range(0,2))), 0);

        //newRoad.transform.localScale = newRoad.transform.lossyScale * (1 + (-2 * Random.Range(0, 2)));
        
        Vector3 segmentOffset = newRoad.transform.GetChild(0).position - newRoad.transform.position;
        newRoad.transform.position = road[currentSpawnedSegment].transform.GetChild(1).position -  segmentOffset;
        road.Add(newRoad);
        newRoad.GetComponent<CreateDropShadow>().enabled = true;
        currentSpawnedSegment++;

        if (currentSpawnedSegment > (segmentBuffer * 2))
        {
            Destroy(road[(currentSpawnedSegment - (segmentBuffer * 2)) - 1]);
        }

    }
}
