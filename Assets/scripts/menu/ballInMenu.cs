using UnityEngine;
using System.Collections;

public class ballInMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		rigidbody.AddForce(new Vector3(-Input.acceleration.y * Time.deltaTime * 30, Input.acceleration.x* Time.deltaTime * 30, 0) * Time.deltaTime * 1200000);
		
	}
}
