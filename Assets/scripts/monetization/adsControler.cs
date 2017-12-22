using UnityEngine;
using System.Collections;

public class adsControler : MonoBehaviour {
	
	public		bool		Init;
	public		bool		isFree;
	
	public		bool		AdOnStart;
	public		bool		AdOnStartEnabled;
	public		bool		AdOnStartClick;
	public		bool		AdOnLevelSelect;
	public		bool		AdOnLevelsClick;
	public		bool		AdOnStagesSelect;
	public		bool		AdOnGameAwake;
	public		bool		AdOnTutorialClose;
	public		bool		AdOnGameSummaryStart;
	public		bool		AdOnGameSummaryEnd;
	public		int			interstitialThisTime;
	
	public void Awake(){
		if(!Init) return;
		if(isFree){
			PlayerPrefs.SetString("Version", "free"); 	
		}
		else{
			PlayerPrefs.SetString("Version", "premium"); 
			PlayerPrefs.SetInt("Level2_unlocked", 1);
			PlayerPrefs.SetInt("Level3_unlocked", 1);
			PlayerPrefs.SetInt("Level4_unlocked", 1);
			PlayerPrefs.SetInt("Level5_unlocked", 1);
			if(PlayerPrefs.GetInt("Ball2", 0) == 0) PlayerPrefs.SetInt("Ball2", 1);
			if(PlayerPrefs.GetInt("Ball3", 0) == 0) PlayerPrefs.SetInt("Ball3", 1);
			if(PlayerPrefs.GetInt("Ball4", 0) == 0) PlayerPrefs.SetInt("Ball4", 1);
			if(PlayerPrefs.GetInt("Ball5", 0) == 0) PlayerPrefs.SetInt("Ball5", 1);
			PlayerPrefs.SetInt("RemoveAds", 1);
			
			PlayerPrefs.SetInt("AllUnlocked", 1);
		}
	}
	
}
