using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDropShadowController : MonoBehaviour {

    public Transform car;

	
	// Update is called once per frame
	void LateUpdate () {
        transform.rotation = car.transform.rotation;
        transform.position = new Vector3(car.transform.position.x + 0.1f, car.transform.position.y - 0.1f, transform.position.z);
	}
}
