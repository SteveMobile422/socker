using UnityEngine;
using System.Collections;

public class levelStarsColected : MonoBehaviour {
	
	public		int				level;
	
	public		GameObject[]	stages;
	private		Vector3			metters;
	public		gameControler	controler;
	
	public		BitmapMeshText	font;

	// Use this for initialization
	void OnEnable () {
		int starsColected = 0;
		bool ADS = GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().isFree;
		
		if(level == 1) starsColected += controler.AllStarsForLevel(1);
		else if(level == 2) starsColected += controler.AllStarsForLevel(2);
		else if(level == 3) starsColected += controler.AllStarsForLevel(3);
		else if(level == 4) starsColected += controler.AllStarsForLevel(4);
		else if(level == 5) starsColected += controler.AllStarsForLevel(5);
		
		if((level == 1 || level == 2) && ADS) font.Text = starsColected + " / 45";
		else if((level == 1 || level == 2) && !ADS) font.Text = starsColected + " / 90";
		else font.Text = starsColected + " / 45";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
