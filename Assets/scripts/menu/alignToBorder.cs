using UnityEngine;
using System.Collections;

public class alignToBorder : MonoBehaviour {
	
	public		bool		left;
	public		bool		right;
	public		bool		up;
	public		bool		down;

	public		Camera		kamera;
	
	void Start () {
	
		if(left) transform.position = new Vector3(kamera.ScreenToWorldPoint(Vector3.zero).x, transform.position.y, transform.position.z);
		if(right) transform.position = new Vector3(kamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x, transform.position.y, transform.position.z);
		if(down) transform.position = new Vector3(transform.position.x, kamera.ScreenToWorldPoint(Vector3.zero).y, transform.position.z);
		if(up) transform.position = new Vector3(transform.position.x, kamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y, transform.position.z);
	}

}
