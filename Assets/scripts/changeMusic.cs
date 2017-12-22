using UnityEngine;
using System.Collections;

public class changeMusic : MonoBehaviour {
	
		public			Material		soundon;
		public			Material		soundoff;
	
	void OnEnable(){
		if(PlayerPrefs.GetInt("Music", 0) == 0){
			renderer.material = soundon;
		}
		else{
			renderer.material = soundoff;
		}
	}
	
	public void changeMusicFX(){
		if(PlayerPrefs.GetInt("Music", 0) == 0){
			PlayerPrefs.SetInt("Music", 1);
			renderer.material = soundoff;
		}
		else{
			PlayerPrefs.SetInt("Music", 0);
			renderer.material = soundon;
		}
	}
}
