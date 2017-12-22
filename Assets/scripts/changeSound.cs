using UnityEngine;
using System.Collections;

public class changeSound : MonoBehaviour {
	
		public			Material		soundon;
		public			Material		soundoff;
	
	void OnEnable(){
		if(PlayerPrefs.GetInt("Sound", 0) == 0){
			renderer.material = soundon;
		}
		else{
			renderer.material = soundoff;
		}
	}
	
	public void changeSoundFX(){
		
		Debug.Log("change sound");
		
		if(PlayerPrefs.GetInt("Sound", 0) == 0){
			PlayerPrefs.SetInt("Sound", 1);
			renderer.material = soundoff;
		}
		else{
			PlayerPrefs.SetInt("Sound", 0);
			renderer.material = soundon;
		}
	}
}
