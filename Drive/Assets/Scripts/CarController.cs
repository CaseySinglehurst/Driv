using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour {
    [Header("Handling Variables")]
    float currentRotationSpeed;

    public float maxRotationSpeed, rotationMagnitude, rotationDamping;

    public float carSpeed;

    [Range(0,1)]
    public float driftScale;

    Rigidbody2D carRigid;

    [Header("Tyre Trail Variables")]

    public GameObject tyreTrail;
    public GameObject leftTyre, rightTyre;
    GameObject leftTrail, rightTrail;
    bool isTrail = false;

    
	// Use this for initialization
	void Start () {
        carRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x >= Screen.width / 2)
            {
                currentRotationSpeed -= rotationMagnitude * Time.deltaTime;
            }
            else if (Input.GetTouch(0).position.x < Screen.width / 2)
            {
                currentRotationSpeed += rotationMagnitude * Time.deltaTime;
            }
            if (currentRotationSpeed > maxRotationSpeed)
            {
                currentRotationSpeed = maxRotationSpeed;
            }
            else if (currentRotationSpeed < -maxRotationSpeed)
            {
                currentRotationSpeed = -maxRotationSpeed;
            }
        }
        else
        {
                currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, 0, rotationDamping * Time.deltaTime);
        }
        carRigid.rotation += currentRotationSpeed;
        carRigid.velocity = ((new Vector2(transform.up.x, transform.up.y) * driftScale) + (carRigid.velocity * (1 - driftScale))).normalized;
        carRigid.velocity = carRigid.velocity * carSpeed;

        HandleTyreTrails();
	}

    void HandleTyreTrails()
    {
        if (Vector2.Angle(new Vector2(transform.up.x, transform.up.y),new Vector2( carRigid.velocity.x, carRigid.velocity.y)) > 30)
        {
            if (!isTrail)
            {
                leftTrail = Instantiate(tyreTrail, leftTyre.transform.position, Quaternion.identity);
                rightTrail = Instantiate(tyreTrail, rightTyre.transform.position, Quaternion.identity);
                isTrail = true;
            }
            else
            {
                leftTrail.transform.position = leftTyre.transform.position;
                rightTrail.transform.position = rightTyre.transform.position;
            }
        }
        else
        {
            if (isTrail)
            {
                leftTrail = null;
                rightTrail = null;
                isTrail = false;
            }
        }
    }


}
