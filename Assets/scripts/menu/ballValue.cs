using UnityEngine;
using System.Collections;

public class ballValue : MonoBehaviour {
	public			int				score;

	public			gameControler	controler;
	public			StageSelect		selector;
	public			int				stageNR;
	
	public			Vector3			metters;
	public			int				stars;
	
	public			Renderer		starone_on;
	public			Renderer		starone_off;
	public			Renderer		starsec_on;
	public			Renderer		starsec_off;
	public			Renderer		startri_on;
	public			Renderer		startri_off;

	// Use this for initialization
	void OnEnable () {

		score = controler.getStageScore(selector.corrLevel, stageNR);
		stars = controler.getStageStars(selector.corrLevel, stageNR);
		
		if(stars > 0) {
			starone_on.enabled = true;
			starone_off.enabled = false;
		}
		else{
			starone_on.enabled = false;
			starone_off.enabled = true;
		}
		
		if(stars > 1) {
			starsec_on.enabled = true;
			starsec_off.enabled = false;
		}
		else{
			starsec_on.enabled = false;
			starsec_off.enabled = true;
		}
		
		if(stars > 2) {
			startri_on.enabled = true;
			startri_off.enabled = false;
		}
		else{
			startri_on.enabled = false;
			startri_off.enabled = true;
		}
		
		
	}
	
}
