using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateDropShadow : MonoBehaviour {





	// Use this for initialization
	void Start () {
        GameObject dropShadow = Instantiate(this.gameObject, new Vector3(this.transform.position.x + 0.1f, this.transform.position.y - 0.1f,7f), this.transform.rotation);Destroy(dropShadow.GetComponent<CreateDropShadow>());
        Destroy(dropShadow.GetComponent<PolygonCollider2D>());


        foreach (Transform child in dropShadow.transform)
        {
            Destroy(child.gameObject);
        }

        dropShadow.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0,150);
        dropShadow.tag = "Untagged";
        dropShadow.transform.SetParent(this.transform);
        Destroy(this.GetComponent<CreateDropShadow>());

        
	}
	
	
}
