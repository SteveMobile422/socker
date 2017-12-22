using UnityEngine;
using System.Collections;

public class planeDetail : MonoBehaviour {

		public			float		speed;
	
	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.Euler(
			
			new Vector3(0, 0, 
			Mathf.Sin(Time.time * speed) * 20)
			
			
			);
	}
}
