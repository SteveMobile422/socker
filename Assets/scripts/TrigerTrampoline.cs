using UnityEngine;
using System.Collections;

public class TrigerTrampoline : MonoBehaviour {
	
	private  float		timer;

    void OnTriggerEnter(Collider other) {
		if(timer > Time.time) return;
		else timer = Time.time + 1;
		if(other.gameObject.tag == "trampoline"){
			if(other.gameObject.GetComponent<trampoline>().reflect){
			rigidbody.velocity = Vector3.Reflect(rigidbody.velocity * other.gameObject.GetComponent<trampoline>().power, Vector3.up);
			}
			else if(other.gameObject.GetComponent<trampoline>().directionObj2){
				Vector3 lerpDirection = Vector3.Lerp(other.gameObject.GetComponent<trampoline>().TargetDirection2, other.gameObject.GetComponent<trampoline>().TargetDirection,
					(Vector3.Angle(other.gameObject.transform.forward, transform.position - other.gameObject.transform.position) - 45 )/90);
				rigidbody.velocity = lerpDirection;
			}
			else{
				rigidbody.velocity = other.gameObject.GetComponent<trampoline>().TargetDirection;
			}
		}
    }
	
}
