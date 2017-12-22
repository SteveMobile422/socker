using UnityEngine;
using System.Collections;

public class loadscene : MonoBehaviour {
	
	public		int		loadID;
	public		int[]	storyLevelsID;
	public		GameObject[]	tuts;
	void Awake(){
		if(PlayerPrefs.GetInt("Story", 0) == 1){}
		else{
			if(PlayerPrefs.GetInt("Level3Stage1stars", 0) > 0){
				tuts[Random.Range(0, tuts.Length)].SetActive(true);
			}
			else if(PlayerPrefs.GetInt("Level2Stage1stars", 0) > 0){
				tuts[Random.Range(0, 4)].SetActive(true);
			}
			else if(PlayerPrefs.GetInt("Level1Stage16stars", 0) > 0){
				tuts[Random.Range(0, 3)].SetActive(true);
			}
			else if(PlayerPrefs.GetInt("Level1Stage5stars", 0) > 0){
				tuts[Random.Range(0, 2)].SetActive(true);
			}
			else{
				tuts[0].SetActive(true);
			}
			
			
		}
	}
	
	// Use this for initialization
	void Start () {
		Debug.Log("*=*=*=*=*=*=**= NOW LOAD: " + PlayerPrefs.GetInt("loadLevel", 2) +"   with story " + PlayerPrefs.GetInt("Story", 0));
		if(PlayerPrefs.GetInt("Story", 0) == 1){
			PlayerPrefs.SetInt("Story", 0);
			Application.LoadLevelAsync(storyLevelsID[PlayerPrefs.GetInt("loadLevel", 2) - 1]);
		}
		else Application.LoadLevel(PlayerPrefs.GetInt("loadLevel", 2)+1);
	}
}
