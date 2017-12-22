using UnityEngine;
using System.Collections;

public class glow : MonoBehaviour {
	
	public		Transform		 	mainCamera;
	public		ParticleSystem		particle;
	
	void OnEnable (){
		
		if(!mainCamera) mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation(mainCamera.position - transform.position);
		
	}
}
