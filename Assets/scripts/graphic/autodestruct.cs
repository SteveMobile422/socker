using UnityEngine;
using System.Collections;

public class autodestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
		animation.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if( !animation.isPlaying ) Destroy(gameObject);
	}
}