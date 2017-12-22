using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class soundManager : MonoBehaviour {

	public		AudioSource		kickBall1;
	
	public		AudioSource		hit_grass_1;
	
	public		AudioSource		hit_wood_1;
	
	public		AudioSource		hit_plastic_1;
	
	public		AudioSource		hit_metal_1;
	
	public		AudioSource		aplauz;
	
	public		AudioSource		kamera;
	
	public		AudioSource		menu;
	public		AudioSource		menuError;
	public		AudioSource		menuBuy;
	
	public		AudioSource		colected;
	public		GameObject		ColectedFX;
	
	// Fan
	public		GameObject		FanTurnFX;
	public		AudioSource		fanOn;
	public		AudioSource		fanOff;
	public		AudioSource		fanLoop;
	private		int				fanCount;
	
	public		AudioSource		Music;
	
	public void PlayKick(){
		if( !kickBall1.isPlaying) kickBall1.Play();
	}
	
	public void PlayHitGrass(){
		if(hit_grass_1.isPlaying) return;
		hit_grass_1.Play();
	}
	
	public void PlayHitWood(){
		if(hit_wood_1.isPlaying) return;
		hit_wood_1.Play();
	}
	
	public void PlayHitPlastic(){
		if(hit_plastic_1.isPlaying) return;
		hit_plastic_1.Play();
	}
	
	public void PlayHitMetal(){
		if(hit_metal_1.isPlaying) return;
		hit_metal_1.Play();
	}
	
	public void PlayAplauz(){
		aplauz.Play();
	}
	
	public void PlayCameraChange(){
		kamera.Play();
	}
	
	public void PlayMenuClick(){
		menu.Play();
	}
	public void PlayMenuBuy(){
		menuBuy.Play();
	}
	public void PlayMenuError(){
		menuError.Play();
	}
	
	public void PlayColected(float pitch){
		colected.pitch = pitch;
		colected.Play();
	}
	
//********** FAN
	public void PlayFanOn(){
		fanOn.Play();
	}
	public void PlayFanOff(){
		fanOff.Play();
	}
	public void AddFanMember(){
		fanCount++;
		if(fanCount > 0 && !fanLoop.isPlaying) fanLoop.Play();
	}
	public void RemoveFanMenber(){
		fanCount--;
		if(fanCount <= 0 && fanLoop.isPlaying) fanLoop.Stop();
	}
	public void RemoveFanCounter(){
		fanCount = 0;
		fanLoop.Stop();
	}
	
	
//*********** MusicControl
	
	void OnApplicationPause(bool _bool)
    {
	   	if(_bool)
	    {
			if(Music) Music.Stop();
	    }
	    else
	    {
	   		if(Music.isPlaying) return;
			if(Music) Music.Play();
	    }
    }
	
	
}
