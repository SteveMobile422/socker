using UnityEngine;
using System.Collections;

public class menuClick : MonoBehaviour {
	
	public	AudioSource   source;

	public void playClick(){
		//if(source.isPlaying) return;
		source.Play();
	}
}
