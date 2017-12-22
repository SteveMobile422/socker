using UnityEngine;
using System.Collections;

public class lvl5kamera : MonoBehaviour {
	
	public		Transform		player;
	
	public		Transform		montaz;

	
	void OnEnable(){
		
		player = GameObject.FindGameObjectWithTag("MainCamera").transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		montaz.transform.rotation = Quaternion.LookRotation(-Vector3.forward);
		
		transform.rotation =  Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position, Vector3.up), Time.deltaTime * 1);
	
	}
}
