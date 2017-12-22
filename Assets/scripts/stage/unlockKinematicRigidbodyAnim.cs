using UnityEngine;
using System.Collections;

public class unlockKinematicRigidbodyAnim : MonoBehaviour {
	
	public		bool		rotateLeft;
	public		bool		rotateRight;
	public		bool		rotateLocalup;
	public		bool		rotateLocalfor;
	
	public		bool		desroyable;
	
	public		float		speed;
	
	public		bool		wachacz;
	private		float		wachaczStartTime;
	public		float		angle;
	private		Quaternion	startrotation;
	
	void Start(){
		startrotation = transform.rotation;
	}
	
	void OnEnable(){
		if(wachacz) wachaczStartTime = Time.time;
	}
	
	void Update(){
		
		if(!rigidbody.isKinematic) return;
		
		if(rotateLeft){
			
			transform.RotateAround(Vector3.up, -0.5f * speed* Time.fixedDeltaTime);	
			
		}
		else if(rotateRight){
			
			transform.RotateAround(Vector3.up, 0.5f * speed* Time.fixedDeltaTime);	
			
		}
		else if(rotateLocalup){
			
			transform.RotateAround(transform.up, 0.5f * speed* Time.fixedDeltaTime);	
			
		}
		else if(rotateLocalfor){
			
			transform.RotateAround(transform.forward, 0.5f * speed* Time.fixedDeltaTime);	
			
		}
		
		if(wachacz){
			transform.rotation = startrotation;
			transform.RotateAround(Vector3.up, (Mathf.Sin((Time.time - wachaczStartTime) * speed) * angle) / 90);
		}
	}
		

void OnCollisionEnter(Collision collision) {
		
		if(rigidbody.isKinematic && collision.gameObject.tag =="Player"){
			if(desroyable) rigidbody.isKinematic = false;
						rigidbody.AddForce( collision.gameObject.rigidbody.velocity * 100);
			//this.enabled= false;	
		}
		else{
			if (collision.impactForceSum.magnitude > 1.0f){
						if(desroyable) rigidbody.isKinematic = false;
						if(collision.gameObject.rigidbody) rigidbody.AddForce( collision.gameObject.rigidbody.velocity* 100);
			}
		}
		
	}
	
	
	public void Usun(){
		if(desroyable) return;
		if(wachacz) return;
		rigidbody.isKinematic = false;
		
		
	}
}
