using UnityEngine;
using System.Collections;

public class ballIndicator : MonoBehaviour {
	
	public		GameObject			on;
	public		GameObject			off;
	public		int					state;

	// Use this for initialization
	void OnEnable () {
		on.SetActive(true);
		off.SetActive(false);
	}

	
	public void changeState(int status){
		if(status == 0){
			on.SetActive(false);
			off.SetActive(false);
		}
		else if(status == 1){
			on.SetActive(true);
			off.SetActive(false);
		}
		else{
			on.SetActive(false);
			off.SetActive(true);
		}
		
		state = status;
		
		if(!gameObject.activeInHierarchy){
		
			
		}
	}
}
