using UnityEngine;
using System.Collections;

public class planerotation : MonoBehaviour {
	
	public			float		speed;
	

	// Update is called once per frame
	void Update () {
	
		transform.RotateAround(Vector3.up, Time.deltaTime * speed);
		
	}
}
