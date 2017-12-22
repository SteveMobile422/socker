using UnityEngine;
using System.Collections;

public class NoInternetConnection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.touchCount > 0){
	
			if(Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended){
				gameObject.SetActive(false);	
			}
			
		}
	}
}
