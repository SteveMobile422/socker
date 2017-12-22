using UnityEngine;
using System.Collections;

public class unlockKinematicRigidbody : MonoBehaviour {

void OnCollisionEnter(Collision collision) {
		
		if(rigidbody.isKinematic && collision.gameObject.tag =="Player"){
			rigidbody.isKinematic = false;
						rigidbody.AddForce( collision.gameObject.rigidbody.velocity*100);
			//this.enabled= false;	
		}
		
	}
}
