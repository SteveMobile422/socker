using UnityEngine;
using System.Collections;

public class ballphysics : MonoBehaviour {
	public			Transform			pivot;
	public			Transform			ball;
	
	private			float			finskala = 0;
	
	public			float			podTimeStart;
	public			Vector3			podkrecenie;
	public			bool			podFizyk;
	public			float				pedmultiply = 1;
	
	public		soundManager SFX;
	public		controller		kontroler;
	public			bool			ballSpawned;
	
	void Awake (){
		if(SFX == null) GameObject.FindGameObjectWithTag("soundmanager").GetComponent<soundManager>();
	}

	// Update is called once per frame
	void Update () {
		
		if(rigidbody.velocity.magnitude > 0.01f) pivot.rotation = Quaternion.LookRotation(rigidbody.velocity.normalized);
		float skala = rigidbody.velocity.magnitude/(150*pedmultiply);
		finskala = Mathf.Lerp(finskala,skala,100*Time.deltaTime);
		pivot.localScale = new Vector3(1-finskala, 1-finskala, 1+finskala*2);
		ball.rotation = transform.rotation;
		
		if(podFizyk){
			rigidbody.AddForce(podkrecenie*(Time.time - podTimeStart) * 40, ForceMode.Force);
			rigidbody.angularVelocity = new Vector3(0, podkrecenie.x * 8, 0);
			
		}
		
		if(ballSpawned && rigidbody.velocity.magnitude < 0.5f) Destroy(gameObject);
	
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag =="grass"){
			if(SFX)	SFX.PlayHitGrass();
		}
		if(collision.gameObject.GetComponent<objectHP>() && collision.gameObject.name != "trampoline"){
			if(!ballSpawned){
				if(!kontroler.frizeCamera) kontroler.movetimer = 1;
				 kontroler.frizeCamera = true;
			}
		}
		podFizyk = false;
		//finskala = -0.0f;
	}
}
