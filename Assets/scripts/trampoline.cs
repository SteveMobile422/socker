using UnityEngine;
using System.Collections;

public class trampoline : MonoBehaviour {
	
	public      bool        onlyY;
	
	public		float		power;
	public		float		PowerOnObjects;
	
	public		bool		direction;
	public		Transform	directionObj;
	public		Transform	directionObj2;
	
	public		bool		newTrampoline;
	public		bool		reflect;
	public		Vector3		TargetDirection;
	public		Vector3		TargetDirection2;
	
	void Awake(){
		float multiplypower = 1;
		if(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StageGameplay>().powerup1Active) multiplypower = 6.5f;
		if(newTrampoline && !reflect){
			TargetDirection = (directionObj.position -  transform.position).normalized * power * 2 * multiplypower;
			if(directionObj2) TargetDirection2 = (directionObj2.position -  transform.position).normalized * power * 2 * multiplypower;
		}
	}
	
	void Update(){
				float multiplypower = 1;
		if(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StageGameplay>().powerup1Active) multiplypower = 6.5f;
		if(newTrampoline && !reflect){
			TargetDirection = (directionObj.position -  transform.position).normalized * power * 2 * multiplypower;
			if(directionObj2) TargetDirection2 = (directionObj2.position -  transform.position).normalized * power * 2 * multiplypower;
		}
	}
	
	void OnCollisionEnter(Collision collision) {		
		if(newTrampoline) return;
		float multiplypower = 1;
		if(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StageGameplay>().powerup1Active) multiplypower = 6.5f;
		
		
		if(collision.rigidbody){ if(collision.rigidbody.isKinematic) return;}
		else return;
		
		if(animation) animation.Play();
		
				
		if(direction){
			if(collision.gameObject.tag == "Player") collision.rigidbody.AddForce((directionObj.position -  transform.position).normalized * power * 2 * multiplypower,   
	                       ForceMode.Impulse);
			else collision.rigidbody.AddForce((directionObj.position -  transform.position).normalized * PowerOnObjects,   
	                       ForceMode.Impulse);
		}
		
		else if(onlyY){
			if(collision.gameObject.tag == "Player") collision.rigidbody.AddForce(Vector3.up * power,   
	                       ForceMode.Impulse);
			else collision.rigidbody.AddForce(Vector3.up * PowerOnObjects,   
	                       ForceMode.Impulse);
		}
		else{
			if(collision.gameObject.tag == "Player") collision.rigidbody.AddForce(Vector3.Reflect(collision.impactForceSum, 
	                                      collision.contacts[0].normal) * power * multiplypower,   
	                       ForceMode.Impulse);
			else if(collision.gameObject.rigidbody) collision.rigidbody.AddForce(Vector3.Reflect(collision.impactForceSum, 
	                                      collision.contacts[0].normal) * PowerOnObjects,   
	                       ForceMode.Impulse);
		}
	}
}
