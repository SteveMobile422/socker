using UnityEngine;
using System.Collections;

public class blob : MonoBehaviour {
	
	public			Transform			obiekt;
	
	public			Vector3				sundir;
	public			bool				debuguj;
	public			bool				xaxis;
	public			bool				rotateShadow;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(obiekt.position.x, -0.52f, obiekt.position.z);
		transform.position += sundir * ( obiekt.position.y + 0.52f ) * 0.5f;
		
		if(rotateShadow && obiekt.rigidbody.velocity.magnitude>0.07f){
			if(!xaxis){
				if(Vector3.Angle(Vector3.up, obiekt.forward)>60) transform.rotation = Quaternion.LookRotation(new Vector3(obiekt.forward.x, 0, obiekt.forward.z).normalized);
				else if(Vector3.Angle(Vector3.up, obiekt.right)>60) transform.rotation = Quaternion.LookRotation(new Vector3(obiekt.right.x, 0, obiekt.right.z).normalized) 
																						* Quaternion.Euler(new Vector3(0, 90, 0));
				else transform.rotation = Quaternion.LookRotation(new Vector3(obiekt.up.x, 0, obiekt.up.z).normalized);
			}
			else{
				if(Vector3.Angle(Vector3.up, obiekt.right)>30) transform.rotation = Quaternion.LookRotation(new Vector3(obiekt.right.x, 0, obiekt.right.z).normalized)
																					* Quaternion.Euler(new Vector3(0, 0, 0));
				else if(Vector3.Angle(Vector3.up, obiekt.forward)>60) transform.rotation = Quaternion.LookRotation(new Vector3(obiekt.forward.x, 0, obiekt.forward.z).normalized) 
																						* Quaternion.Euler(new Vector3(0, -90, 0));
				else transform.rotation = Quaternion.LookRotation(new Vector3(obiekt.up.x, 0, obiekt.up.z).normalized);
			}
		}
	}
}
