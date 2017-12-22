using UnityEngine;
using System.Collections;

public class soundControler : MonoBehaviour {
	
	public			bool			music;
	public			AudioSource		source;
	private			float			gotoVolume;
	public			float			OnVolume		=		1;
	
	// Use this for initialization
	void Awake () {
		if(!source) source = gameObject.audio;
		
		if(!music){
				if(PlayerPrefs.GetInt("Sound", 0) == 0){
					gotoVolume = OnVolume;
				}
				else{
					gotoVolume = 0;
				}
		}
		else{
				if(PlayerPrefs.GetInt("Music", 0) == 0){
					gotoVolume = OnVolume;
				}
				else{
					gotoVolume = 0;
				}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!music){
				if(PlayerPrefs.GetInt("Sound", 0) == 0){
					gotoVolume = OnVolume;
				}
				else{
					gotoVolume = 0;
				}
		}
		else{
				if(PlayerPrefs.GetInt("Music", 0) == 0){
					gotoVolume = OnVolume;
				}
				else{
					gotoVolume = 0;
				}
		}
		
		source.volume = Mathf.Lerp(source.volume, gotoVolume, Time.fixedTime * 0.02f);
	}
}
