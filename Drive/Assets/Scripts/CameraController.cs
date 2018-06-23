using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform car;

    public Vector3 cameraOffset;
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = car.transform.position + cameraOffset;


	}
}
