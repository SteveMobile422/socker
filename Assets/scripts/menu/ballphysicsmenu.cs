using UnityEngine;
using System.Collections;

public class ballphysicsmenu : MonoBehaviour {
	public			Transform			pivot;
	public			Transform			ball;
	
	private			float			finskala = 0;
	
	public			float			podTimeStart;
	public			Vector3			podkrecenie;
	public			bool			podFizyk;
	public			float				pedmultiply = 1;

	// Update is called once per frame
	void Update () {
		
		if(rigidbody.velocity.magnitude>0) pivot.rotation = Quaternion.LookRotation(rigidbody.velocity.normalized);
		float skala = rigidbody.velocity.magnitude/(7500);
		finskala = Mathf.Lerp(finskala,skala,100*Time.deltaTime);
		pivot.localScale = new Vector3(1-finskala, 1-finskala, 1+finskala*2);
		ball.rotation = transform.rotation;
		
		if(podFizyk){
			rigidbody.AddForce(podkrecenie*(Time.time - podTimeStart)*40, ForceMode.Force);
			rigidbody.angularVelocity = new Vector3(0, podkrecenie.x*8, 0);
			
		}
	
	}
	
	void OnCollisionEnter(){
		podFizyk = false;
		//finskala = -0.0f;
	}
}
