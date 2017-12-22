using UnityEngine;
using System.Collections;

public class StopWhenCall : MonoBehaviour {
	
		public		AudioSource		Music;
	
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
