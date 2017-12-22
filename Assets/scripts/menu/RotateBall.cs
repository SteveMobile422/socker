using UnityEngine;
using System.Collections;

public class RotateBall : MonoBehaviour {
	
	public		float		updateTimer;
	public		float		speed;
	private		float		timer;
	
	private		Vector3		rotate;
	private		Vector3		rotateLerp;
	
	// Update is called once per frame
	void Update () {
		if(timer < Time.time){
			rotate = new Vector3(Random.Range(1.0f, -1.0f), Random.Range(1.0f, -1.0f), Random.Range(1, -1.0f));
			timer = Time.time + updateTimer;
		}
		
		rotateLerp = Vector3.Lerp(rotateLerp, rotate.normalized, Time.deltaTime * 0.5f);
		
		transform.RotateAround(rotateLerp, Mathf.Sin((timer - Time.time)/updateTimer * Mathf.PI) * 0.8f * Time.deltaTime * speed + 1.8f * Time.deltaTime * speed);
		
	}
}
