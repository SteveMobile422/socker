using UnityEngine;
using System.Collections;

public class pauseMenuData : MonoBehaviour {
	
	public		Renderer		star1;
	public		Renderer		star2;
	public		Renderer		star3;
	private		int				stars;
	
	public		BitmapMeshText	bestScore;
	public			StageGameplay		gameplay;
	public			gameControler		gameKontroler;

	// Update is called once per frame
	void OnEnable () {
		bestScore.Text = "" + gameKontroler.getStageScore(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID);
		stars = gameKontroler.getStageStars(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID);
		star1.enabled = false;
		star2.enabled = false;
		star3.enabled = false;
		
		if( stars >= 1) star1.enabled = true;
		if( stars >= 2) star2.enabled = true;
		if( stars >= 3) star3.enabled = true;
	}
}
