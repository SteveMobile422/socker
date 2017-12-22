using UnityEngine;
using System.Collections;

public class gameControler : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		//setStageScore(1, 1, 1000);
		//setStageStars(1, 4, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public int getStageStars(int level, int stage){
		int score = 0;
		if(level == 1){
			if(	stage == 1) score = PlayerPrefs.GetInt("Level1Stage1stars", 0);
			if(	stage == 2) score = PlayerPrefs.GetInt("Level1Stage2stars", 0);
			if(	stage == 3) score = PlayerPrefs.GetInt("Level1Stage3stars", 0);
			if(	stage == 4) score = PlayerPrefs.GetInt("Level1Stage4stars", 0);
			if(	stage == 5) score = PlayerPrefs.GetInt("Level1Stage5stars", 0);
			
			if(	stage == 6) score = PlayerPrefs.GetInt("Level1Stage6stars", 0);
			if(	stage == 7) score = PlayerPrefs.GetInt("Level1Stage7stars", 0);
			if(	stage == 8) score = PlayerPrefs.GetInt("Level1Stage8stars", 0);
			if(	stage == 9) score = PlayerPrefs.GetInt("Level1Stage9stars", 0);
			if(	stage == 10) score = PlayerPrefs.GetInt("Level1Stage10stars", 0);
			
			if(	stage == 11) score = PlayerPrefs.GetInt("Level1Stage11stars", 0);
			if(	stage == 12) score = PlayerPrefs.GetInt("Level1Stage12stars", 0);
			if(	stage == 13) score = PlayerPrefs.GetInt("Level1Stage13stars", 0);
			if(	stage == 14) score = PlayerPrefs.GetInt("Level1Stage14stars", 0);
			if(	stage == 15) score = PlayerPrefs.GetInt("Level1Stage15stars", 0);
			
			if(	stage == 16) score = PlayerPrefs.GetInt("Level1Stage16stars", 0);
			if(	stage == 17) score = PlayerPrefs.GetInt("Level1Stage17stars", 0);
			if(	stage == 18) score = PlayerPrefs.GetInt("Level1Stage18stars", 0);
			if(	stage == 19) score = PlayerPrefs.GetInt("Level1Stage19stars", 0);
			if(	stage == 20) score = PlayerPrefs.GetInt("Level1Stage20stars", 0);
			
			if(	stage == 21) score = PlayerPrefs.GetInt("Level1Stage21stars", 0);
			if(	stage == 22) score = PlayerPrefs.GetInt("Level1Stage22stars", 0);
			if(	stage == 23) score = PlayerPrefs.GetInt("Level1Stage23stars", 0);
			if(	stage == 24) score = PlayerPrefs.GetInt("Level1Stage24stars", 0);
			if(	stage == 25) score = PlayerPrefs.GetInt("Level1Stage25stars", 0);
			
			if(	stage == 26) score = PlayerPrefs.GetInt("Level1Stage26stars", 0);
			if(	stage == 27) score = PlayerPrefs.GetInt("Level1Stage27stars", 0);
			if(	stage == 28) score = PlayerPrefs.GetInt("Level1Stage28stars", 0);
			if(	stage == 29) score = PlayerPrefs.GetInt("Level1Stage29stars", 0);
			if(	stage == 30) score = PlayerPrefs.GetInt("Level1Stage30stars", 0);
		}
		else if(level == 2){
			if(	stage == 1) score = PlayerPrefs.GetInt("Level2Stage1stars", 0);
			if(	stage == 2) score = PlayerPrefs.GetInt("Level2Stage2stars", 0);
			if(	stage == 3) score = PlayerPrefs.GetInt("Level2Stage3stars", 0);
			if(	stage == 4) score = PlayerPrefs.GetInt("Level2Stage4stars", 0);
			if(	stage == 5) score = PlayerPrefs.GetInt("Level2Stage5stars", 0);
			
			if(	stage == 6) score = PlayerPrefs.GetInt("Level2Stage6stars", 0);
			if(	stage == 7) score = PlayerPrefs.GetInt("Level2Stage7stars", 0);
			if(	stage == 8) score = PlayerPrefs.GetInt("Level2Stage8stars", 0);
			if(	stage == 9) score = PlayerPrefs.GetInt("Level2Stage9stars", 0);
			if(	stage == 10) score = PlayerPrefs.GetInt("Level2Stage10stars", 0);
			
			if(	stage == 11) score = PlayerPrefs.GetInt("Level2Stage11stars", 0);
			if(	stage == 12) score = PlayerPrefs.GetInt("Level2Stage12stars", 0);
			if(	stage == 13) score = PlayerPrefs.GetInt("Level2Stage13stars", 0);
			if(	stage == 14) score = PlayerPrefs.GetInt("Level2Stage14stars", 0);
			if(	stage == 15) score = PlayerPrefs.GetInt("Level2Stage15stars", 0);
			
			if(	stage == 16) score = PlayerPrefs.GetInt("Level2Stage16stars", 0);
			if(	stage == 17) score = PlayerPrefs.GetInt("Level2Stage17stars", 0);
			if(	stage == 18) score = PlayerPrefs.GetInt("Level2Stage18stars", 0);
			if(	stage == 19) score = PlayerPrefs.GetInt("Level2Stage19stars", 0);
			if(	stage == 20) score = PlayerPrefs.GetInt("Level2Stage20stars", 0);
	
			if(	stage == 21) score = PlayerPrefs.GetInt("Level2Stage21stars", 0);
			if(	stage == 22) score = PlayerPrefs.GetInt("Level2Stage22stars", 0);
			if(	stage == 23) score = PlayerPrefs.GetInt("Level2Stage23stars", 0);
			if(	stage == 24) score = PlayerPrefs.GetInt("Level2Stage24stars", 0);
			if(	stage == 25) score = PlayerPrefs.GetInt("Level2Stage25stars", 0);
			
			if(	stage == 26) score = PlayerPrefs.GetInt("Level2Stage26stars", 0);
			if(	stage == 27) score = PlayerPrefs.GetInt("Level2Stage27stars", 0);
			if(	stage == 28) score = PlayerPrefs.GetInt("Level2Stage28stars", 0);
			if(	stage == 29) score = PlayerPrefs.GetInt("Level2Stage29stars", 0);
			if(	stage == 30) score = PlayerPrefs.GetInt("Level2Stage30stars", 0);
		}
		else if(level == 3){
			if(	stage == 1) score = PlayerPrefs.GetInt("Level3Stage1stars", 0);
			if(	stage == 2) score = PlayerPrefs.GetInt("Level3Stage2stars", 0);
			if(	stage == 3) score = PlayerPrefs.GetInt("Level3Stage3stars", 0);
			if(	stage == 4) score = PlayerPrefs.GetInt("Level3Stage4stars", 0);
			if(	stage == 5) score = PlayerPrefs.GetInt("Level3Stage5stars", 0);
			
			if(	stage == 6) score = PlayerPrefs.GetInt("Level3Stage6stars", 0);
			if(	stage == 7) score = PlayerPrefs.GetInt("Level3Stage7stars", 0);
			if(	stage == 8) score = PlayerPrefs.GetInt("Level3Stage8stars", 0);
			if(	stage == 9) score = PlayerPrefs.GetInt("Level3Stage9stars", 0);
			if(	stage == 10) score = PlayerPrefs.GetInt("Level3Stage10stars", 0);
			
			if(	stage == 11) score = PlayerPrefs.GetInt("Level3Stage11stars", 0);
			if(	stage == 12) score = PlayerPrefs.GetInt("Level3Stage12stars", 0);
			if(	stage == 13) score = PlayerPrefs.GetInt("Level3Stage13stars", 0);
			if(	stage == 14) score = PlayerPrefs.GetInt("Level3Stage14stars", 0);
			if(	stage == 15) score = PlayerPrefs.GetInt("Level3Stage15stars", 0);
			
			if(	stage == 16) score = PlayerPrefs.GetInt("Level3Stage16stars", 0);
			if(	stage == 17) score = PlayerPrefs.GetInt("Level3Stage17stars", 0);
			if(	stage == 18) score = PlayerPrefs.GetInt("Level3Stage18stars", 0);
			if(	stage == 19) score = PlayerPrefs.GetInt("Level3Stage19stars", 0);
			if(	stage == 20) score = PlayerPrefs.GetInt("Level3Stage20stars", 0);
	
			if(	stage == 21) score = PlayerPrefs.GetInt("Level3Stage21stars", 0);
			if(	stage == 22) score = PlayerPrefs.GetInt("Level3Stage22stars", 0);
			if(	stage == 23) score = PlayerPrefs.GetInt("Level3Stage23stars", 0);
			if(	stage == 24) score = PlayerPrefs.GetInt("Level3Stage24stars", 0);
			if(	stage == 25) score = PlayerPrefs.GetInt("Level3Stage25stars", 0);
			
			if(	stage == 26) score = PlayerPrefs.GetInt("Level3Stage26stars", 0);
			if(	stage == 27) score = PlayerPrefs.GetInt("Level3Stage27stars", 0);
			if(	stage == 28) score = PlayerPrefs.GetInt("Level3Stage28stars", 0);
			if(	stage == 29) score = PlayerPrefs.GetInt("Level3Stage29stars", 0);
			if(	stage == 30) score = PlayerPrefs.GetInt("Level3Stage30stars", 0);
		}
		else if(level == 4){
			if(	stage == 1) score = PlayerPrefs.GetInt("Level4Stage1stars", 0);
			if(	stage == 2) score = PlayerPrefs.GetInt("Level4Stage2stars", 0);
			if(	stage == 3) score = PlayerPrefs.GetInt("Level4Stage3stars", 0);
			if(	stage == 4) score = PlayerPrefs.GetInt("Level4Stage4stars", 0);
			if(	stage == 5) score = PlayerPrefs.GetInt("Level4Stage5stars", 0);
			
			if(	stage == 6) score = PlayerPrefs.GetInt("Level4Stage6stars", 0);
			if(	stage == 7) score = PlayerPrefs.GetInt("Level4Stage7stars", 0);
			if(	stage == 8) score = PlayerPrefs.GetInt("Level4Stage8stars", 0);
			if(	stage == 9) score = PlayerPrefs.GetInt("Level4Stage9stars", 0);
			if(	stage == 10) score = PlayerPrefs.GetInt("Level4Stage10stars", 0);
			
			if(	stage == 11) score = PlayerPrefs.GetInt("Level4Stage11stars", 0);
			if(	stage == 12) score = PlayerPrefs.GetInt("Level4Stage12stars", 0);
			if(	stage == 13) score = PlayerPrefs.GetInt("Level4Stage13stars", 0);
			if(	stage == 14) score = PlayerPrefs.GetInt("Level4Stage14stars", 0);
			if(	stage == 15) score = PlayerPrefs.GetInt("Level4Stage15stars", 0);
			
			if(	stage == 16) score = PlayerPrefs.GetInt("Level4Stage16stars", 0);
			if(	stage == 17) score = PlayerPrefs.GetInt("Level4Stage17stars", 0);
			if(	stage == 18) score = PlayerPrefs.GetInt("Level4Stage18stars", 0);
			if(	stage == 19) score = PlayerPrefs.GetInt("Level4Stage19stars", 0);
			if(	stage == 20) score = PlayerPrefs.GetInt("Level4Stage20stars", 0);
	
			if(	stage == 21) score = PlayerPrefs.GetInt("Level4Stage21stars", 0);
			if(	stage == 22) score = PlayerPrefs.GetInt("Level4Stage22stars", 0);
			if(	stage == 23) score = PlayerPrefs.GetInt("Level4Stage23stars", 0);
			if(	stage == 24) score = PlayerPrefs.GetInt("Level4Stage24stars", 0);
			if(	stage == 25) score = PlayerPrefs.GetInt("Level4Stage25stars", 0);
			
			if(	stage == 26) score = PlayerPrefs.GetInt("Level4Stage26stars", 0);
			if(	stage == 27) score = PlayerPrefs.GetInt("Level4Stage27stars", 0);
			if(	stage == 28) score = PlayerPrefs.GetInt("Level4Stage28stars", 0);
			if(	stage == 29) score = PlayerPrefs.GetInt("Level4Stage29stars", 0);
			if(	stage == 30) score = PlayerPrefs.GetInt("Level4Stage30stars", 0);
		}
		else if(level == 5){
			if(	stage == 1) score = PlayerPrefs.GetInt("Level5Stage1stars", 0);
			if(	stage == 2) score = PlayerPrefs.GetInt("Level5Stage2stars", 0);
			if(	stage == 3) score = PlayerPrefs.GetInt("Level5Stage3stars", 0);
			if(	stage == 4) score = PlayerPrefs.GetInt("Level5Stage4stars", 0);
			if(	stage == 5) score = PlayerPrefs.GetInt("Level5Stage5stars", 0);
			
			if(	stage == 6) score = PlayerPrefs.GetInt("Level5Stage6stars", 0);
			if(	stage == 7) score = PlayerPrefs.GetInt("Level5Stage7stars", 0);
			if(	stage == 8) score = PlayerPrefs.GetInt("Level5Stage8stars", 0);
			if(	stage == 9) score = PlayerPrefs.GetInt("Level5Stage9stars", 0);
			if(	stage == 10) score = PlayerPrefs.GetInt("Level5Stage10stars", 0);
			
			if(	stage == 11) score = PlayerPrefs.GetInt("Level5Stage11stars", 0);
			if(	stage == 12) score = PlayerPrefs.GetInt("Level5Stage12stars", 0);
			if(	stage == 13) score = PlayerPrefs.GetInt("Level5Stage13stars", 0);
			if(	stage == 14) score = PlayerPrefs.GetInt("Level5Stage14stars", 0);
			if(	stage == 15) score = PlayerPrefs.GetInt("Level5Stage15stars", 0);
			
			if(	stage == 16) score = PlayerPrefs.GetInt("Level5Stage16stars", 0);
			if(	stage == 17) score = PlayerPrefs.GetInt("Level5Stage17stars", 0);
			if(	stage == 18) score = PlayerPrefs.GetInt("Level5Stage18stars", 0);
			if(	stage == 19) score = PlayerPrefs.GetInt("Level5Stage19stars", 0);
			if(	stage == 20) score = PlayerPrefs.GetInt("Level5Stage20stars", 0);
	
			if(	stage == 21) score = PlayerPrefs.GetInt("Level5Stage21stars", 0);
			if(	stage == 22) score = PlayerPrefs.GetInt("Level5Stage22stars", 0);
			if(	stage == 23) score = PlayerPrefs.GetInt("Level5Stage23stars", 0);
			if(	stage == 24) score = PlayerPrefs.GetInt("Level5Stage24stars", 0);
			if(	stage == 25) score = PlayerPrefs.GetInt("Level5Stage25stars", 0);
			
			if(	stage == 26) score = PlayerPrefs.GetInt("Level5Stage26stars", 0);
			if(	stage == 27) score = PlayerPrefs.GetInt("Level5Stage27stars", 0);
			if(	stage == 28) score = PlayerPrefs.GetInt("Level5Stage28stars", 0);
			if(	stage == 29) score = PlayerPrefs.GetInt("Level5Stage29stars", 0);
			if(	stage == 30) score = PlayerPrefs.GetInt("Level5Stage30stars", 0);
		}	
		return score;
	}
	
	public void setStageStars(int level, int stage, int score){
		//  LEVEL 1
		if(level == 1){
			if(	stage == 1) PlayerPrefs.SetInt("Level1Stage1stars", score);
			else if(	stage == 2) PlayerPrefs.SetInt("Level1Stage2stars", score);
			else if(	stage == 3) PlayerPrefs.SetInt("Level1Stage3stars", score);
			else if(	stage == 4) PlayerPrefs.SetInt("Level1Stage4stars", score);
			else if(	stage == 5) PlayerPrefs.SetInt("Level1Stage5stars", score);
			
			else if(	stage == 6) PlayerPrefs.SetInt("Level1Stage6stars", score);
			else if(	stage == 7) PlayerPrefs.SetInt("Level1Stage7stars", score);
			else if(	stage == 8) PlayerPrefs.SetInt("Level1Stage8stars", score);
			else if(	stage == 9) PlayerPrefs.SetInt("Level1Stage9stars", score);
			else if(	stage == 10) PlayerPrefs.SetInt("Level1Stage10stars", score);
			
			else if(	stage == 11) PlayerPrefs.SetInt("Level1Stage11stars", score);
			else if(	stage == 12) PlayerPrefs.SetInt("Level1Stage12stars", score);
			else if(	stage == 13) PlayerPrefs.SetInt("Level1Stage13stars", score);
			else if(	stage == 14) PlayerPrefs.SetInt("Level1Stage14stars", score);
			else if(	stage == 15) PlayerPrefs.SetInt("Level1Stage15stars", score);
			
			else if(	stage == 16) PlayerPrefs.SetInt("Level1Stage16stars", score);
			else if(	stage == 17) PlayerPrefs.SetInt("Level1Stage17stars", score);
			else if(	stage == 18) PlayerPrefs.SetInt("Level1Stage18stars", score);
			else if(	stage == 19) PlayerPrefs.SetInt("Level1Stage19stars", score);
			else if(	stage == 20) PlayerPrefs.SetInt("Level1Stage20stars", score);
			
			else if(	stage == 21) PlayerPrefs.SetInt("Level1Stage21stars", score);
			else if(	stage == 22) PlayerPrefs.SetInt("Level1Stage22stars", score);
			else if(	stage == 23) PlayerPrefs.SetInt("Level1Stage23stars", score);
			else if(	stage == 24) PlayerPrefs.SetInt("Level1Stage24stars", score);
			else if(	stage == 25) PlayerPrefs.SetInt("Level1Stage25stars", score);
			
			else if(	stage == 26) PlayerPrefs.SetInt("Level1Stage26stars", score);
			else if(	stage == 27) PlayerPrefs.SetInt("Level1Stage27stars", score);
			else if(	stage == 28) PlayerPrefs.SetInt("Level1Stage28stars", score);
			else if(	stage == 29) PlayerPrefs.SetInt("Level1Stage29stars", score);
			else if(	stage == 30) PlayerPrefs.SetInt("Level1Stage30stars", score);
		}
		//  LEVEL 2
		else if(level == 2){
			if(	stage == 1) PlayerPrefs.SetInt("Level2Stage1stars", score);
			else if(	stage == 2) PlayerPrefs.SetInt("Level2Stage2stars", score);
			else if(	stage == 3) PlayerPrefs.SetInt("Level2Stage3stars", score);
			else if(	stage == 4) PlayerPrefs.SetInt("Level2Stage4stars", score);
			else if(	stage == 5) PlayerPrefs.SetInt("Level2Stage5stars", score);
			
			else if(	stage == 6) PlayerPrefs.SetInt("Level2Stage6stars", score);
			else if(	stage == 7) PlayerPrefs.SetInt("Level2Stage7stars", score);
			else if(	stage == 8) PlayerPrefs.SetInt("Level2Stage8stars", score);
			else if(	stage == 9) PlayerPrefs.SetInt("Level2Stage9stars", score);
			else if(	stage == 10) PlayerPrefs.SetInt("Level2Stage10stars", score);
			
			else if(	stage == 11) PlayerPrefs.SetInt("Level2Stage11stars", score);
			else if(	stage == 12) PlayerPrefs.SetInt("Level2Stage12stars", score);
			else if(	stage == 13) PlayerPrefs.SetInt("Level2Stage13stars", score);
			else if(	stage == 14) PlayerPrefs.SetInt("Level2Stage14stars", score);
			else if(	stage == 15) PlayerPrefs.SetInt("Level2Stage15stars", score);
			
			else if(	stage == 16) PlayerPrefs.SetInt("Level2Stage16stars", score);
			else if(	stage == 17) PlayerPrefs.SetInt("Level2Stage17stars", score);
			else if(	stage == 18) PlayerPrefs.SetInt("Level2Stage18stars", score);
			else if(	stage == 19) PlayerPrefs.SetInt("Level2Stage19stars", score);
			else if(	stage == 20) PlayerPrefs.SetInt("Level2Stage20stars", score);
			
			else if(	stage == 21) PlayerPrefs.SetInt("Level2Stage21stars", score);
			else if(	stage == 22) PlayerPrefs.SetInt("Level2Stage22stars", score);
			else if(	stage == 23) PlayerPrefs.SetInt("Level2Stage23stars", score);
			else if(	stage == 24) PlayerPrefs.SetInt("Level2Stage24stars", score);
			else if(	stage == 25) PlayerPrefs.SetInt("Level2Stage25stars", score);
			
			else if(	stage == 26) PlayerPrefs.SetInt("Level2Stage26stars", score);
			else if(	stage == 27) PlayerPrefs.SetInt("Level2Stage27stars", score);
			else if(	stage == 28) PlayerPrefs.SetInt("Level2Stage28stars", score);
			else if(	stage == 29) PlayerPrefs.SetInt("Level2Stage29stars", score);
			else if(	stage == 30) PlayerPrefs.SetInt("Level2Stage30stars", score);
		}
		else if(level == 3){
			if(			stage == 1) PlayerPrefs.SetInt("Level3Stage1stars", score);
			else if(	stage == 2) PlayerPrefs.SetInt("Level3Stage2stars", score);
			else if(	stage == 3) PlayerPrefs.SetInt("Level3Stage3stars", score);
			else if(	stage == 4) PlayerPrefs.SetInt("Level3Stage4stars", score);
			else if(	stage == 5) PlayerPrefs.SetInt("Level3Stage5stars", score);
			
			else if(	stage == 6) PlayerPrefs.SetInt("Level3Stage6stars", score);
			else if(	stage == 7) PlayerPrefs.SetInt("Level3Stage7stars", score);
			else if(	stage == 8) PlayerPrefs.SetInt("Level3Stage8stars", score);
			else if(	stage == 9) PlayerPrefs.SetInt("Level3Stage9stars", score);
			else if(	stage == 10) PlayerPrefs.SetInt("Level3Stage10stars", score);
			
			else if(	stage == 11) PlayerPrefs.SetInt("Level3Stage11stars", score);
			else if(	stage == 12) PlayerPrefs.SetInt("Level3Stage12stars", score);
			else if(	stage == 13) PlayerPrefs.SetInt("Level3Stage13stars", score);
			else if(	stage == 14) PlayerPrefs.SetInt("Level3Stage14stars", score);
			else if(	stage == 15) PlayerPrefs.SetInt("Level3Stage15stars", score);
			
			else if(	stage == 16) PlayerPrefs.SetInt("Level3Stage16stars", score);
			else if(	stage == 17) PlayerPrefs.SetInt("Level3Stage17stars", score);
			else if(	stage == 18) PlayerPrefs.SetInt("Level3Stage18stars", score);
			else if(	stage == 19) PlayerPrefs.SetInt("Level3Stage19stars", score);
			else if(	stage == 20) PlayerPrefs.SetInt("Level3Stage20stars", score);
			
			else if(	stage == 21) PlayerPrefs.SetInt("Level3Stage21stars", score);
			else if(	stage == 22) PlayerPrefs.SetInt("Level3Stage22stars", score);
			else if(	stage == 23) PlayerPrefs.SetInt("Level3Stage23stars", score);
			else if(	stage == 24) PlayerPrefs.SetInt("Level3Stage24stars", score);
			else if(	stage == 25) PlayerPrefs.SetInt("Level3Stage25stars", score);
			
			else if(	stage == 26) PlayerPrefs.SetInt("Level3Stage26stars", score);
			else if(	stage == 27) PlayerPrefs.SetInt("Level3Stage27stars", score);
			else if(	stage == 28) PlayerPrefs.SetInt("Level3Stage28stars", score);
			else if(	stage == 29) PlayerPrefs.SetInt("Level3Stage29stars", score);
			else if(	stage == 30) PlayerPrefs.SetInt("Level3Stage30stars", score);
		}
		else if(level == 4){
			if(			stage == 1) PlayerPrefs.SetInt("Level4Stage1stars", score);
			else if(	stage == 2) PlayerPrefs.SetInt("Level4Stage2stars", score);
			else if(	stage == 3) PlayerPrefs.SetInt("Level4Stage3stars", score);
			else if(	stage == 4) PlayerPrefs.SetInt("Level4Stage4stars", score);
			else if(	stage == 5) PlayerPrefs.SetInt("Level4Stage5stars", score);
			
			else if(	stage == 6) PlayerPrefs.SetInt("Level4Stage6stars", score);
			else if(	stage == 7) PlayerPrefs.SetInt("Level4Stage7stars", score);
			else if(	stage == 8) PlayerPrefs.SetInt("Level4Stage8stars", score);
			else if(	stage == 9) PlayerPrefs.SetInt("Level4Stage9stars", score);
			else if(	stage == 10) PlayerPrefs.SetInt("Level4Stage10stars", score);
			
			else if(	stage == 11) PlayerPrefs.SetInt("Level4Stage11stars", score);
			else if(	stage == 12) PlayerPrefs.SetInt("Level4Stage12stars", score);
			else if(	stage == 13) PlayerPrefs.SetInt("Level4Stage13stars", score);
			else if(	stage == 14) PlayerPrefs.SetInt("Level4Stage14stars", score);
			else if(	stage == 15) PlayerPrefs.SetInt("Level4Stage15stars", score);
			
			else if(	stage == 16) PlayerPrefs.SetInt("Level4Stage16stars", score);
			else if(	stage == 17) PlayerPrefs.SetInt("Level4Stage17stars", score);
			else if(	stage == 18) PlayerPrefs.SetInt("Level4Stage18stars", score);
			else if(	stage == 19) PlayerPrefs.SetInt("Level4Stage19stars", score);
			else if(	stage == 20) PlayerPrefs.SetInt("Level4Stage20stars", score);
			
			else if(	stage == 21) PlayerPrefs.SetInt("Level4Stage21stars", score);
			else if(	stage == 22) PlayerPrefs.SetInt("Level4Stage22stars", score);
			else if(	stage == 23) PlayerPrefs.SetInt("Level4Stage23stars", score);
			else if(	stage == 24) PlayerPrefs.SetInt("Level4Stage24stars", score);
			else if(	stage == 25) PlayerPrefs.SetInt("Level4Stage25stars", score);
			
			else if(	stage == 26) PlayerPrefs.SetInt("Level4Stage26stars", score);
			else if(	stage == 27) PlayerPrefs.SetInt("Level4Stage27stars", score);
			else if(	stage == 28) PlayerPrefs.SetInt("Level4Stage28stars", score);
			else if(	stage == 29) PlayerPrefs.SetInt("Level4Stage29stars", score);
			else if(	stage == 30) PlayerPrefs.SetInt("Level4Stage30stars", score);
		}
		else if(level == 5){
			if(			stage == 1) PlayerPrefs.SetInt("Level5Stage1stars", score);
			else if(	stage == 2) PlayerPrefs.SetInt("Level5Stage2stars", score);
			else if(	stage == 3) PlayerPrefs.SetInt("Level5Stage3stars", score);
			else if(	stage == 4) PlayerPrefs.SetInt("Level5Stage4stars", score);
			else if(	stage == 5) PlayerPrefs.SetInt("Level5Stage5stars", score);
			
			else if(	stage == 6) PlayerPrefs.SetInt("Level5Stage6stars", score);
			else if(	stage == 7) PlayerPrefs.SetInt("Level5Stage7stars", score);
			else if(	stage == 8) PlayerPrefs.SetInt("Level5Stage8stars", score);
			else if(	stage == 9) PlayerPrefs.SetInt("Level5Stage9stars", score);
			else if(	stage == 10) PlayerPrefs.SetInt("Level5Stage10stars", score);
			
			else if(	stage == 11) PlayerPrefs.SetInt("Level5Stage11stars", score);
			else if(	stage == 12) PlayerPrefs.SetInt("Level5Stage12stars", score);
			else if(	stage == 13) PlayerPrefs.SetInt("Level5Stage13stars", score);
			else if(	stage == 14) PlayerPrefs.SetInt("Level5Stage14stars", score);
			else if(	stage == 15) PlayerPrefs.SetInt("Level5Stage15stars", score);
			
			else if(	stage == 16) PlayerPrefs.SetInt("Level5Stage16stars", score);
			else if(	stage == 17) PlayerPrefs.SetInt("Level5Stage17stars", score);
			else if(	stage == 18) PlayerPrefs.SetInt("Level5Stage18stars", score);
			else if(	stage == 19) PlayerPrefs.SetInt("Level5Stage19stars", score);
			else if(	stage == 20) PlayerPrefs.SetInt("Level5Stage20stars", score);
			
			else if(	stage == 21) PlayerPrefs.SetInt("Level5Stage21stars", score);
			else if(	stage == 22) PlayerPrefs.SetInt("Level5Stage22stars", score);
			else if(	stage == 23) PlayerPrefs.SetInt("Level5Stage23stars", score);
			else if(	stage == 24) PlayerPrefs.SetInt("Level5Stage24stars", score);
			else if(	stage == 25) PlayerPrefs.SetInt("Level5Stage25stars", score);
			
			else if(	stage == 26) PlayerPrefs.SetInt("Level5Stage26stars", score);
			else if(	stage == 27) PlayerPrefs.SetInt("Level5Stage27stars", score);
			else if(	stage == 28) PlayerPrefs.SetInt("Level5Stage28stars", score);
			else if(	stage == 29) PlayerPrefs.SetInt("Level5Stage29stars", score);
			else if(	stage == 30) PlayerPrefs.SetInt("Level5Stage30stars", score);
		}
		
	}
	
	
	public int getStageScore(int level, int stage){
		int score = 0;
		if(level == 1){
			if(	stage == 1) score = PlayerPrefs.GetInt("Level1Stage1", 0);
			if(	stage == 2) score = PlayerPrefs.GetInt("Level1Stage2", 0);
			if(	stage == 3) score = PlayerPrefs.GetInt("Level1Stage3", 0);
			if(	stage == 4) score = PlayerPrefs.GetInt("Level1Stage4", 0);
			if(	stage == 5) score = PlayerPrefs.GetInt("Level1Stage5", 0);
			
			if(	stage == 6) score = PlayerPrefs.GetInt("Level1Stage6", 0);
			if(	stage == 7) score = PlayerPrefs.GetInt("Level1Stage7", 0);
			if(	stage == 8) score = PlayerPrefs.GetInt("Level1Stage8", 0);
			if(	stage == 9) score = PlayerPrefs.GetInt("Level1Stage9", 0);
			if(	stage == 10) score = PlayerPrefs.GetInt("Level1Stage10", 0);
			
			if(	stage == 11) score = PlayerPrefs.GetInt("Level1Stage11", 0);
			if(	stage == 12) score = PlayerPrefs.GetInt("Level1Stage12", 0);
			if(	stage == 13) score = PlayerPrefs.GetInt("Level1Stage13", 0);
			if(	stage == 14) score = PlayerPrefs.GetInt("Level1Stage14", 0);
			if(	stage == 15) score = PlayerPrefs.GetInt("Level1Stage15", 0);
			
			if(	stage == 16) score = PlayerPrefs.GetInt("Level1Stage16", 0);
			if(	stage == 17) score = PlayerPrefs.GetInt("Level1Stage17", 0);
			if(	stage == 18) score = PlayerPrefs.GetInt("Level1Stage18", 0);
			if(	stage == 19) score = PlayerPrefs.GetInt("Level1Stage19", 0);
			if(	stage == 20) score = PlayerPrefs.GetInt("Level1Stage20", 0);
			
			if(	stage == 21) score = PlayerPrefs.GetInt("Level1Stage21", 0);
			if(	stage == 22) score = PlayerPrefs.GetInt("Level1Stage22", 0);
			if(	stage == 23) score = PlayerPrefs.GetInt("Level1Stage23", 0);
			if(	stage == 24) score = PlayerPrefs.GetInt("Level1Stage24", 0);
			if(	stage == 25) score = PlayerPrefs.GetInt("Level1Stage25", 0);
			
			if(	stage == 26) score = PlayerPrefs.GetInt("Level1Stage26", 0);
			if(	stage == 27) score = PlayerPrefs.GetInt("Level1Stage27", 0);
			if(	stage == 28) score = PlayerPrefs.GetInt("Level1Stage28", 0);
			if(	stage == 29) score = PlayerPrefs.GetInt("Level1Stage29", 0);
			if(	stage == 30) score = PlayerPrefs.GetInt("Level1Stage30", 0);
		}
		else if(level == 2){
			if(	stage == 1) score = PlayerPrefs.GetInt("Level2Stage1", 0);
			if(	stage == 2) score = PlayerPrefs.GetInt("Level2Stage2", 0);
			if(	stage == 3) score = PlayerPrefs.GetInt("Level2Stage3", 0);
			if(	stage == 4) score = PlayerPrefs.GetInt("Level2Stage4", 0);
			if(	stage == 5) score = PlayerPrefs.GetInt("Level2Stage5", 0);
			
			if(	stage == 6) score = PlayerPrefs.GetInt("Level2Stage6", 0);
			if(	stage == 7) score = PlayerPrefs.GetInt("Level2Stage7", 0);
			if(	stage == 8) score = PlayerPrefs.GetInt("Level2Stage8", 0);
			if(	stage == 9) score = PlayerPrefs.GetInt("Level2Stage9", 0);
			if(	stage == 10) score = PlayerPrefs.GetInt("Level2Stage10", 0);
			
			if(	stage == 11) score = PlayerPrefs.GetInt("Level2Stage11", 0);
			if(	stage == 12) score = PlayerPrefs.GetInt("Level2Stage12", 0);
			if(	stage == 13) score = PlayerPrefs.GetInt("Level2Stage13", 0);
			if(	stage == 14) score = PlayerPrefs.GetInt("Level2Stage14", 0);
			if(	stage == 15) score = PlayerPrefs.GetInt("Level2Stage15", 0);
			
			if(	stage == 16) score = PlayerPrefs.GetInt("Level2Stage16", 0);
			if(	stage == 17) score = PlayerPrefs.GetInt("Level2Stage17", 0);
			if(	stage == 18) score = PlayerPrefs.GetInt("Level2Stage18", 0);
			if(	stage == 19) score = PlayerPrefs.GetInt("Level2Stage19", 0);
			if(	stage == 20) score = PlayerPrefs.GetInt("Level2Stage20", 0);
	
			if(	stage == 21) score = PlayerPrefs.GetInt("Level2Stage21", 0);
			if(	stage == 22) score = PlayerPrefs.GetInt("Level2Stage22", 0);
			if(	stage == 23) score = PlayerPrefs.GetInt("Level2Stage23", 0);
			if(	stage == 24) score = PlayerPrefs.GetInt("Level2Stage24", 0);
			if(	stage == 25) score = PlayerPrefs.GetInt("Level2Stage25", 0);
			
			if(	stage == 26) score = PlayerPrefs.GetInt("Level2Stage26", 0);
			if(	stage == 27) score = PlayerPrefs.GetInt("Level2Stage27", 0);
			if(	stage == 28) score = PlayerPrefs.GetInt("Level2Stage28", 0);
			if(	stage == 29) score = PlayerPrefs.GetInt("Level2Stage29", 0);
			if(	stage == 30) score = PlayerPrefs.GetInt("Level2Stage30", 0);
		}
		else if(level == 3){
			if(	stage == 1) score = PlayerPrefs.GetInt("Level3Stage1", 0);
			if(	stage == 2) score = PlayerPrefs.GetInt("Level3Stage2", 0);
			if(	stage == 3) score = PlayerPrefs.GetInt("Level3Stage3", 0);
			if(	stage == 4) score = PlayerPrefs.GetInt("Level3Stage4", 0);
			if(	stage == 5) score = PlayerPrefs.GetInt("Level3Stage5", 0);
			
			if(	stage == 6) score = PlayerPrefs.GetInt("Level3Stage6", 0);
			if(	stage == 7) score = PlayerPrefs.GetInt("Level3Stage7", 0);
			if(	stage == 8) score = PlayerPrefs.GetInt("Level3Stage8", 0);
			if(	stage == 9) score = PlayerPrefs.GetInt("Level3Stage9", 0);
			if(	stage == 10) score = PlayerPrefs.GetInt("Level3Stage10", 0);
			
			if(	stage == 11) score = PlayerPrefs.GetInt("Level3Stage11", 0);
			if(	stage == 12) score = PlayerPrefs.GetInt("Level3Stage12", 0);
			if(	stage == 13) score = PlayerPrefs.GetInt("Level3Stage13", 0);
			if(	stage == 14) score = PlayerPrefs.GetInt("Level3Stage14", 0);
			if(	stage == 15) score = PlayerPrefs.GetInt("Level3Stage15", 0);
			
			if(	stage == 16) score = PlayerPrefs.GetInt("Level3Stage16", 0);
			if(	stage == 17) score = PlayerPrefs.GetInt("Level3Stage17", 0);
			if(	stage == 18) score = PlayerPrefs.GetInt("Level3Stage18", 0);
			if(	stage == 19) score = PlayerPrefs.GetInt("Level3Stage19", 0);
			if(	stage == 20) score = PlayerPrefs.GetInt("Level3Stage20", 0);
	
			if(	stage == 21) score = PlayerPrefs.GetInt("Level3Stage21", 0);
			if(	stage == 22) score = PlayerPrefs.GetInt("Level3Stage22", 0);
			if(	stage == 23) score = PlayerPrefs.GetInt("Level3Stage23", 0);
			if(	stage == 24) score = PlayerPrefs.GetInt("Level3Stage24", 0);
			if(	stage == 25) score = PlayerPrefs.GetInt("Level3Stage25", 0);
			
			if(	stage == 26) score = PlayerPrefs.GetInt("Level3Stage26", 0);
			if(	stage == 27) score = PlayerPrefs.GetInt("Level3Stage27", 0);
			if(	stage == 28) score = PlayerPrefs.GetInt("Level3Stage28", 0);
			if(	stage == 29) score = PlayerPrefs.GetInt("Level3Stage29", 0);
			if(	stage == 30) score = PlayerPrefs.GetInt("Level3Stage30", 0);
		}
		else if(level == 4){
			if(	stage == 1) score = PlayerPrefs.GetInt("Level4Stage1", 0);
			if(	stage == 2) score = PlayerPrefs.GetInt("Level4Stage2", 0);
			if(	stage == 3) score = PlayerPrefs.GetInt("Level4Stage3", 0);
			if(	stage == 4) score = PlayerPrefs.GetInt("Level4Stage4", 0);
			if(	stage == 5) score = PlayerPrefs.GetInt("Level4Stage5", 0);
			
			if(	stage == 6) score = PlayerPrefs.GetInt("Level4Stage6", 0);
			if(	stage == 7) score = PlayerPrefs.GetInt("Level4Stage7", 0);
			if(	stage == 8) score = PlayerPrefs.GetInt("Level4Stage8", 0);
			if(	stage == 9) score = PlayerPrefs.GetInt("Level4Stage9", 0);
			if(	stage == 10) score = PlayerPrefs.GetInt("Level4Stage10", 0);
			
			if(	stage == 11) score = PlayerPrefs.GetInt("Level4Stage11", 0);
			if(	stage == 12) score = PlayerPrefs.GetInt("Level4Stage12", 0);
			if(	stage == 13) score = PlayerPrefs.GetInt("Level4Stage13", 0);
			if(	stage == 14) score = PlayerPrefs.GetInt("Level4Stage14", 0);
			if(	stage == 15) score = PlayerPrefs.GetInt("Level4Stage15", 0);
			
			if(	stage == 16) score = PlayerPrefs.GetInt("Level4Stage16", 0);
			if(	stage == 17) score = PlayerPrefs.GetInt("Level4Stage17", 0);
			if(	stage == 18) score = PlayerPrefs.GetInt("Level4Stage18", 0);
			if(	stage == 19) score = PlayerPrefs.GetInt("Level4Stage19", 0);
			if(	stage == 20) score = PlayerPrefs.GetInt("Level4Stage20", 0);
	
			if(	stage == 21) score = PlayerPrefs.GetInt("Level4Stage21", 0);
			if(	stage == 22) score = PlayerPrefs.GetInt("Level4Stage22", 0);
			if(	stage == 23) score = PlayerPrefs.GetInt("Level4Stage23", 0);
			if(	stage == 24) score = PlayerPrefs.GetInt("Level4Stage24", 0);
			if(	stage == 25) score = PlayerPrefs.GetInt("Level4Stage25", 0);
			
			if(	stage == 26) score = PlayerPrefs.GetInt("Level4Stage26", 0);
			if(	stage == 27) score = PlayerPrefs.GetInt("Level4Stage27", 0);
			if(	stage == 28) score = PlayerPrefs.GetInt("Level4Stage28", 0);
			if(	stage == 29) score = PlayerPrefs.GetInt("Level4Stage29", 0);
			if(	stage == 30) score = PlayerPrefs.GetInt("Level4Stage30", 0);
		}
		else if(level == 5){
			if(	stage == 1) score = PlayerPrefs.GetInt("Level5Stage1", 0);
			if(	stage == 2) score = PlayerPrefs.GetInt("Level5Stage2", 0);
			if(	stage == 3) score = PlayerPrefs.GetInt("Level5Stage3", 0);
			if(	stage == 4) score = PlayerPrefs.GetInt("Level5Stage4", 0);
			if(	stage == 5) score = PlayerPrefs.GetInt("Level5Stage5", 0);
			
			if(	stage == 6) score = PlayerPrefs.GetInt("Level5Stage6", 0);
			if(	stage == 7) score = PlayerPrefs.GetInt("Level5Stage7", 0);
			if(	stage == 8) score = PlayerPrefs.GetInt("Level5Stage8", 0);
			if(	stage == 9) score = PlayerPrefs.GetInt("Level5Stage9", 0);
			if(	stage == 10) score = PlayerPrefs.GetInt("Level5Stage10", 0);
			
			if(	stage == 11) score = PlayerPrefs.GetInt("Level5Stage11", 0);
			if(	stage == 12) score = PlayerPrefs.GetInt("Level5Stage12", 0);
			if(	stage == 13) score = PlayerPrefs.GetInt("Level5Stage13", 0);
			if(	stage == 14) score = PlayerPrefs.GetInt("Level5Stage14", 0);
			if(	stage == 15) score = PlayerPrefs.GetInt("Level5Stage15", 0);
			
			if(	stage == 16) score = PlayerPrefs.GetInt("Level5Stage16", 0);
			if(	stage == 17) score = PlayerPrefs.GetInt("Level5Stage17", 0);
			if(	stage == 18) score = PlayerPrefs.GetInt("Level5Stage18", 0);
			if(	stage == 19) score = PlayerPrefs.GetInt("Level5Stage19", 0);
			if(	stage == 20) score = PlayerPrefs.GetInt("Level5Stage20", 0);
	
			if(	stage == 21) score = PlayerPrefs.GetInt("Level5Stage21", 0);
			if(	stage == 22) score = PlayerPrefs.GetInt("Level5Stage22", 0);
			if(	stage == 23) score = PlayerPrefs.GetInt("Level5Stage23", 0);
			if(	stage == 24) score = PlayerPrefs.GetInt("Level5Stage24", 0);
			if(	stage == 25) score = PlayerPrefs.GetInt("Level5Stage25", 0);
			
			if(	stage == 26) score = PlayerPrefs.GetInt("Level5Stage26", 0);
			if(	stage == 27) score = PlayerPrefs.GetInt("Level5Stage27", 0);
			if(	stage == 28) score = PlayerPrefs.GetInt("Level5Stage28", 0);
			if(	stage == 29) score = PlayerPrefs.GetInt("Level5Stage29", 0);
			if(	stage == 30) score = PlayerPrefs.GetInt("Level5Stage30", 0);
		}	
		return score;
		
	}
	
	public void setStageScore(int level, int stage, int score){
		//  LEVEL 1
		if(level == 1){
			if(	stage == 1) PlayerPrefs.SetInt("Level1Stage1", score);
			else if(	stage == 2) PlayerPrefs.SetInt("Level1Stage2", score);
			else if(	stage == 3) PlayerPrefs.SetInt("Level1Stage3", score);
			else if(	stage == 4) PlayerPrefs.SetInt("Level1Stage4", score);
			else if(	stage == 5) PlayerPrefs.SetInt("Level1Stage5", score);
			
			else if(	stage == 6) PlayerPrefs.SetInt("Level1Stage6", score);
			else if(	stage == 7) PlayerPrefs.SetInt("Level1Stage7", score);
			else if(	stage == 8) PlayerPrefs.SetInt("Level1Stage8", score);
			else if(	stage == 9) PlayerPrefs.SetInt("Level1Stage9", score);
			else if(	stage == 10) PlayerPrefs.SetInt("Level1Stage10", score);
			
			else if(	stage == 11) PlayerPrefs.SetInt("Level1Stage11", score);
			else if(	stage == 12) PlayerPrefs.SetInt("Level1Stage12", score);
			else if(	stage == 13) PlayerPrefs.SetInt("Level1Stage13", score);
			else if(	stage == 14) PlayerPrefs.SetInt("Level1Stage14", score);
			else if(	stage == 15) PlayerPrefs.SetInt("Level1Stage15", score);
			
			else if(	stage == 16) PlayerPrefs.SetInt("Level1Stage16", score);
			else if(	stage == 17) PlayerPrefs.SetInt("Level1Stage17", score);
			else if(	stage == 18) PlayerPrefs.SetInt("Level1Stage18", score);
			else if(	stage == 19) PlayerPrefs.SetInt("Level1Stage19", score);
			else if(	stage == 20) PlayerPrefs.SetInt("Level1Stage20", score);
			
			else if(	stage == 21) PlayerPrefs.SetInt("Level1Stage21", score);
			else if(	stage == 22) PlayerPrefs.SetInt("Level1Stage22", score);
			else if(	stage == 23) PlayerPrefs.SetInt("Level1Stage23", score);
			else if(	stage == 24) PlayerPrefs.SetInt("Level1Stage24", score);
			else if(	stage == 25) PlayerPrefs.SetInt("Level1Stage25", score);
			
			else if(	stage == 26) PlayerPrefs.SetInt("Level1Stage26", score);
			else if(	stage == 27) PlayerPrefs.SetInt("Level1Stage27", score);
			else if(	stage == 28) PlayerPrefs.SetInt("Level1Stage28", score);
			else if(	stage == 29) PlayerPrefs.SetInt("Level1Stage29", score);
			else if(	stage == 30) PlayerPrefs.SetInt("Level1Stage30", score);
		}
		//  LEVEL 2
		else if(level == 2){
			if(	stage == 1) PlayerPrefs.SetInt("Level2Stage1", score);
			else if(	stage == 2) PlayerPrefs.SetInt("Level2Stage2", score);
			else if(	stage == 3) PlayerPrefs.SetInt("Level2Stage3", score);
			else if(	stage == 4) PlayerPrefs.SetInt("Level2Stage4", score);
			else if(	stage == 5) PlayerPrefs.SetInt("Level2Stage5", score);
			
			else if(	stage == 6) PlayerPrefs.SetInt("Level2Stage6", score);
			else if(	stage == 7) PlayerPrefs.SetInt("Level2Stage7", score);
			else if(	stage == 8) PlayerPrefs.SetInt("Level2Stage8", score);
			else if(	stage == 9) PlayerPrefs.SetInt("Level2Stage9", score);
			else if(	stage == 10) PlayerPrefs.SetInt("Level2Stage10", score);
			
			else if(	stage == 11) PlayerPrefs.SetInt("Level2Stage11", score);
			else if(	stage == 12) PlayerPrefs.SetInt("Level2Stage12", score);
			else if(	stage == 13) PlayerPrefs.SetInt("Level2Stage13", score);
			else if(	stage == 14) PlayerPrefs.SetInt("Level2Stage14", score);
			else if(	stage == 15) PlayerPrefs.SetInt("Level2Stage15", score);
			
			else if(	stage == 16) PlayerPrefs.SetInt("Level2Stage16", score);
			else if(	stage == 17) PlayerPrefs.SetInt("Level2Stage17", score);
			else if(	stage == 18) PlayerPrefs.SetInt("Level2Stage18", score);
			else if(	stage == 19) PlayerPrefs.SetInt("Level2Stage19", score);
			else if(	stage == 20) PlayerPrefs.SetInt("Level2Stage20", score);
			
			else if(	stage == 21) PlayerPrefs.SetInt("Level2Stage21", score);
			else if(	stage == 22) PlayerPrefs.SetInt("Level2Stage22", score);
			else if(	stage == 23) PlayerPrefs.SetInt("Level2Stage23", score);
			else if(	stage == 24) PlayerPrefs.SetInt("Level2Stage24", score);
			else if(	stage == 25) PlayerPrefs.SetInt("Level2Stage25", score);
			
			else if(	stage == 26) PlayerPrefs.SetInt("Level2Stage26", score);
			else if(	stage == 27) PlayerPrefs.SetInt("Level2Stage27", score);
			else if(	stage == 28) PlayerPrefs.SetInt("Level2Stage28", score);
			else if(	stage == 29) PlayerPrefs.SetInt("Level2Stage29", score);
			else if(	stage == 30) PlayerPrefs.SetInt("Level2Stage30", score);
		}
		else if(level == 3){
			if(			stage == 1) PlayerPrefs.SetInt("Level3Stage1", score);
			else if(	stage == 2) PlayerPrefs.SetInt("Level3Stage2", score);
			else if(	stage == 3) PlayerPrefs.SetInt("Level3Stage3", score);
			else if(	stage == 4) PlayerPrefs.SetInt("Level3Stage4", score);
			else if(	stage == 5) PlayerPrefs.SetInt("Level3Stage5", score);
			
			else if(	stage == 6) PlayerPrefs.SetInt("Level3Stage6", score);
			else if(	stage == 7) PlayerPrefs.SetInt("Level3Stage7", score);
			else if(	stage == 8) PlayerPrefs.SetInt("Level3Stage8", score);
			else if(	stage == 9) PlayerPrefs.SetInt("Level3Stage9", score);
			else if(	stage == 10) PlayerPrefs.SetInt("Level3Stage10", score);
			
			else if(	stage == 11) PlayerPrefs.SetInt("Level3Stage11", score);
			else if(	stage == 12) PlayerPrefs.SetInt("Level3Stage12", score);
			else if(	stage == 13) PlayerPrefs.SetInt("Level3Stage13", score);
			else if(	stage == 14) PlayerPrefs.SetInt("Level3Stage14", score);
			else if(	stage == 15) PlayerPrefs.SetInt("Level3Stage15", score);
			
			else if(	stage == 16) PlayerPrefs.SetInt("Level3Stage16", score);
			else if(	stage == 17) PlayerPrefs.SetInt("Level3Stage17", score);
			else if(	stage == 18) PlayerPrefs.SetInt("Level3Stage18", score);
			else if(	stage == 19) PlayerPrefs.SetInt("Level3Stage19", score);
			else if(	stage == 20) PlayerPrefs.SetInt("Level3Stage20", score);
			
			else if(	stage == 21) PlayerPrefs.SetInt("Level3Stage21", score);
			else if(	stage == 22) PlayerPrefs.SetInt("Level3Stage22", score);
			else if(	stage == 23) PlayerPrefs.SetInt("Level3Stage23", score);
			else if(	stage == 24) PlayerPrefs.SetInt("Level3Stage24", score);
			else if(	stage == 25) PlayerPrefs.SetInt("Level3Stage25", score);
			
			else if(	stage == 26) PlayerPrefs.SetInt("Level3Stage26", score);
			else if(	stage == 27) PlayerPrefs.SetInt("Level3Stage27", score);
			else if(	stage == 28) PlayerPrefs.SetInt("Level3Stage28", score);
			else if(	stage == 29) PlayerPrefs.SetInt("Level3Stage29", score);
			else if(	stage == 30) PlayerPrefs.SetInt("Level3Stage30", score);
		}
		else if(level == 4){
			if(			stage == 1) PlayerPrefs.SetInt("Level4Stage1", score);
			else if(	stage == 2) PlayerPrefs.SetInt("Level4Stage2", score);
			else if(	stage == 3) PlayerPrefs.SetInt("Level4Stage3", score);
			else if(	stage == 4) PlayerPrefs.SetInt("Level4Stage4", score);
			else if(	stage == 5) PlayerPrefs.SetInt("Level4Stage5", score);
			
			else if(	stage == 6) PlayerPrefs.SetInt("Level4Stage6", score);
			else if(	stage == 7) PlayerPrefs.SetInt("Level4Stage7", score);
			else if(	stage == 8) PlayerPrefs.SetInt("Level4Stage8", score);
			else if(	stage == 9) PlayerPrefs.SetInt("Level4Stage9", score);
			else if(	stage == 10) PlayerPrefs.SetInt("Level4Stage10", score);
			
			else if(	stage == 11) PlayerPrefs.SetInt("Level4Stage11", score);
			else if(	stage == 12) PlayerPrefs.SetInt("Level4Stage12", score);
			else if(	stage == 13) PlayerPrefs.SetInt("Level4Stage13", score);
			else if(	stage == 14) PlayerPrefs.SetInt("Level4Stage14", score);
			else if(	stage == 15) PlayerPrefs.SetInt("Level4Stage15", score);
			
			else if(	stage == 16) PlayerPrefs.SetInt("Level4Stage16", score);
			else if(	stage == 17) PlayerPrefs.SetInt("Level4Stage17", score);
			else if(	stage == 18) PlayerPrefs.SetInt("Level4Stage18", score);
			else if(	stage == 19) PlayerPrefs.SetInt("Level4Stage19", score);
			else if(	stage == 20) PlayerPrefs.SetInt("Level4Stage20", score);
			
			else if(	stage == 21) PlayerPrefs.SetInt("Level4Stage21", score);
			else if(	stage == 22) PlayerPrefs.SetInt("Level4Stage22", score);
			else if(	stage == 23) PlayerPrefs.SetInt("Level4Stage23", score);
			else if(	stage == 24) PlayerPrefs.SetInt("Level4Stage24", score);
			else if(	stage == 25) PlayerPrefs.SetInt("Level4Stage25", score);
			
			else if(	stage == 26) PlayerPrefs.SetInt("Level4Stage26", score);
			else if(	stage == 27) PlayerPrefs.SetInt("Level4Stage27", score);
			else if(	stage == 28) PlayerPrefs.SetInt("Level4Stage28", score);
			else if(	stage == 29) PlayerPrefs.SetInt("Level4Stage29", score);
			else if(	stage == 30) PlayerPrefs.SetInt("Level4Stage30", score);
		}
		else if(level == 5){
			if(			stage == 1) PlayerPrefs.SetInt("Level5Stage1", score);
			else if(	stage == 2) PlayerPrefs.SetInt("Level5Stage2", score);
			else if(	stage == 3) PlayerPrefs.SetInt("Level5Stage3", score);
			else if(	stage == 4) PlayerPrefs.SetInt("Level5Stage4", score);
			else if(	stage == 5) PlayerPrefs.SetInt("Level5Stage5", score);
			
			else if(	stage == 6) PlayerPrefs.SetInt("Level5Stage6", score);
			else if(	stage == 7) PlayerPrefs.SetInt("Level5Stage7", score);
			else if(	stage == 8) PlayerPrefs.SetInt("Level5Stage8", score);
			else if(	stage == 9) PlayerPrefs.SetInt("Level5Stage9", score);
			else if(	stage == 10) PlayerPrefs.SetInt("Level5Stage10", score);
			
			else if(	stage == 11) PlayerPrefs.SetInt("Level5Stage11", score);
			else if(	stage == 12) PlayerPrefs.SetInt("Level5Stage12", score);
			else if(	stage == 13) PlayerPrefs.SetInt("Level5Stage13", score);
			else if(	stage == 14) PlayerPrefs.SetInt("Level5Stage14", score);
			else if(	stage == 15) PlayerPrefs.SetInt("Level5Stage15", score);
			
			else if(	stage == 16) PlayerPrefs.SetInt("Level5Stage16", score);
			else if(	stage == 17) PlayerPrefs.SetInt("Level5Stage17", score);
			else if(	stage == 18) PlayerPrefs.SetInt("Level5Stage18", score);
			else if(	stage == 19) PlayerPrefs.SetInt("Level5Stage19", score);
			else if(	stage == 20) PlayerPrefs.SetInt("Level5Stage20", score);
			
			else if(	stage == 21) PlayerPrefs.SetInt("Level5Stage21", score);
			else if(	stage == 22) PlayerPrefs.SetInt("Level5Stage22", score);
			else if(	stage == 23) PlayerPrefs.SetInt("Level5Stage23", score);
			else if(	stage == 24) PlayerPrefs.SetInt("Level5Stage24", score);
			else if(	stage == 25) PlayerPrefs.SetInt("Level5Stage25", score);
			
			else if(	stage == 26) PlayerPrefs.SetInt("Level5Stage26", score);
			else if(	stage == 27) PlayerPrefs.SetInt("Level5Stage27", score);
			else if(	stage == 28) PlayerPrefs.SetInt("Level5Stage28", score);
			else if(	stage == 29) PlayerPrefs.SetInt("Level5Stage29", score);
			else if(	stage == 30) PlayerPrefs.SetInt("Level5Stage30", score);
		}
		
	}
	
	public int LeaderboardScoreForLevel(int level){
		int score = 0;
		if(level == 1){
			score += PlayerPrefs.GetInt("Level1Stage1", 0);
			score += PlayerPrefs.GetInt("Level1Stage2", 0);
			score += PlayerPrefs.GetInt("Level1Stage3", 0);
			score += PlayerPrefs.GetInt("Level1Stage4", 0);
			score += PlayerPrefs.GetInt("Level1Stage5", 0);
			
			score += PlayerPrefs.GetInt("Level1Stage6", 0);
			score += PlayerPrefs.GetInt("Level1Stage7", 0);
			score += PlayerPrefs.GetInt("Level1Stage8", 0);
			score += PlayerPrefs.GetInt("Level1Stage9", 0);
			score += PlayerPrefs.GetInt("Level1Stage10", 0);
			
			score += PlayerPrefs.GetInt("Level1Stage11", 0);
			score += PlayerPrefs.GetInt("Level1Stage12", 0);
			score += PlayerPrefs.GetInt("Level1Stage13", 0);
			score += PlayerPrefs.GetInt("Level1Stage14", 0);
			score += PlayerPrefs.GetInt("Level1Stage15", 0);
			
			score += PlayerPrefs.GetInt("Level1Stage16", 0);
			score += PlayerPrefs.GetInt("Level1Stage17", 0);
			score += PlayerPrefs.GetInt("Level1Stage18", 0);
			score += PlayerPrefs.GetInt("Level1Stage19", 0);
			score += PlayerPrefs.GetInt("Level1Stage20", 0);
			
			score += PlayerPrefs.GetInt("Level1Stage21", 0);
			score += PlayerPrefs.GetInt("Level1Stage22", 0);
			score += PlayerPrefs.GetInt("Level1Stage23", 0);
			score += PlayerPrefs.GetInt("Level1Stage24", 0);
			score += PlayerPrefs.GetInt("Level1Stage25", 0);
			
			score += PlayerPrefs.GetInt("Level1Stage26", 0);
			score += PlayerPrefs.GetInt("Level1Stage27", 0);
			score += PlayerPrefs.GetInt("Level1Stage28", 0);
			score += PlayerPrefs.GetInt("Level1Stage29", 0);
			score += PlayerPrefs.GetInt("Level1Stage30", 0);
		}
		else if(level == 2){
			score += PlayerPrefs.GetInt("Level2Stage1", 0);
			score += PlayerPrefs.GetInt("Level2Stage2", 0);
			score += PlayerPrefs.GetInt("Level2Stage3", 0);
			score += PlayerPrefs.GetInt("Level2Stage4", 0);
			score += PlayerPrefs.GetInt("Level2Stage5", 0);
			
			score += PlayerPrefs.GetInt("Level2Stage6", 0);
			score += PlayerPrefs.GetInt("Level2Stage7", 0);
			score += PlayerPrefs.GetInt("Level2Stage8", 0);
			score += PlayerPrefs.GetInt("Level2Stage9", 0);
			score += PlayerPrefs.GetInt("Level2Stage10", 0);
			
			score += PlayerPrefs.GetInt("Level2Stage11", 0);
			score += PlayerPrefs.GetInt("Level2Stage12", 0);
			score += PlayerPrefs.GetInt("Level2Stage13", 0);
			score += PlayerPrefs.GetInt("Level2Stage14", 0);
			score += PlayerPrefs.GetInt("Level2Stage15", 0);
			
			score += PlayerPrefs.GetInt("Level2Stage16", 0);
			score += PlayerPrefs.GetInt("Level2Stage17", 0);
			score += PlayerPrefs.GetInt("Level2Stage18", 0);
			score += PlayerPrefs.GetInt("Level2Stage19", 0);
			score += PlayerPrefs.GetInt("Level2Stage20", 0);
	
			score += PlayerPrefs.GetInt("Level2Stage21", 0);
			score += PlayerPrefs.GetInt("Level2Stage22", 0);
			score += PlayerPrefs.GetInt("Level2Stage23", 0);
			score += PlayerPrefs.GetInt("Level2Stage24", 0);
			score += PlayerPrefs.GetInt("Level2Stage25", 0);
			
			score += PlayerPrefs.GetInt("Level2Stage26", 0);
			score += PlayerPrefs.GetInt("Level2Stage27", 0);
			score += PlayerPrefs.GetInt("Level2Stage28", 0);
			score += PlayerPrefs.GetInt("Level2Stage29", 0);
			score += PlayerPrefs.GetInt("Level2Stage30", 0);
		}
		else if(level == 3){
			score += PlayerPrefs.GetInt("Level3Stage1", 0);
			score += PlayerPrefs.GetInt("Level3Stage2", 0);
			score += PlayerPrefs.GetInt("Level3Stage3", 0);
			score += PlayerPrefs.GetInt("Level3Stage4", 0);
			score += PlayerPrefs.GetInt("Level3Stage5", 0);
			
			score += PlayerPrefs.GetInt("Level3Stage6", 0);
			score += PlayerPrefs.GetInt("Level3Stage7", 0);
			score += PlayerPrefs.GetInt("Level3Stage8", 0);
			score += PlayerPrefs.GetInt("Level3Stage9", 0);
			score += PlayerPrefs.GetInt("Level3Stage10", 0);
			
			score += PlayerPrefs.GetInt("Level3Stage11", 0);
			score += PlayerPrefs.GetInt("Level3Stage12", 0);
			score += PlayerPrefs.GetInt("Level3Stage13", 0);
			score += PlayerPrefs.GetInt("Level3Stage14", 0);
			score += PlayerPrefs.GetInt("Level3Stage15", 0);
		}
		else if(level == 4){
			score += PlayerPrefs.GetInt("Level4Stage1", 0);
			score += PlayerPrefs.GetInt("Level4Stage2", 0);
			score += PlayerPrefs.GetInt("Level4Stage3", 0);
			score += PlayerPrefs.GetInt("Level4Stage4", 0);
			score += PlayerPrefs.GetInt("Level4Stage5", 0);
			
			score += PlayerPrefs.GetInt("Level4Stage6", 0);
			score += PlayerPrefs.GetInt("Level4Stage7", 0);
			score += PlayerPrefs.GetInt("Level4Stage8", 0);
			score += PlayerPrefs.GetInt("Level4Stage9", 0);
			score += PlayerPrefs.GetInt("Level4Stage10", 0);
			
			score += PlayerPrefs.GetInt("Level4Stage11", 0);
			score += PlayerPrefs.GetInt("Level4Stage12", 0);
			score += PlayerPrefs.GetInt("Level4Stage13", 0);
			score += PlayerPrefs.GetInt("Level4Stage14", 0);
			score += PlayerPrefs.GetInt("Level4Stage15", 0);
		}
		else if(level == 5){
			score += PlayerPrefs.GetInt("Level5Stage1", 0);
			score += PlayerPrefs.GetInt("Level5Stage2", 0);
			score += PlayerPrefs.GetInt("Level5Stage3", 0);
			score += PlayerPrefs.GetInt("Level5Stage4", 0);
			score += PlayerPrefs.GetInt("Level5Stage5", 0);
			
			score += PlayerPrefs.GetInt("Level5Stage6", 0);
			score += PlayerPrefs.GetInt("Level5Stage7", 0);
			score += PlayerPrefs.GetInt("Level5Stage8", 0);
			score += PlayerPrefs.GetInt("Level5Stage9", 0);
			score += PlayerPrefs.GetInt("Level5Stage10", 0);
			
			score += PlayerPrefs.GetInt("Level5Stage11", 0);
			score += PlayerPrefs.GetInt("Level5Stage12", 0);
			score += PlayerPrefs.GetInt("Level5Stage13", 0);
			score += PlayerPrefs.GetInt("Level5Stage14", 0);
			score += PlayerPrefs.GetInt("Level5Stage15", 0);
		}
		return score;
	}
	
	public int AllStarsForLevel(int level){
		int score = 0;
		if(level == 1){
			score += PlayerPrefs.GetInt("Level1Stage1stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage2stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage3stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage4stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage5stars", 0);
			
			score += PlayerPrefs.GetInt("Level1Stage6stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage7stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage8stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage9stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage10stars", 0);
			
			score += PlayerPrefs.GetInt("Level1Stage11stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage12stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage13stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage14stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage15stars", 0);
			
			score += PlayerPrefs.GetInt("Level1Stage16stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage17stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage18stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage19stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage20stars", 0);
			
			score += PlayerPrefs.GetInt("Level1Stage21stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage22stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage23stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage24stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage25stars", 0);
			
			score += PlayerPrefs.GetInt("Level1Stage26stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage27stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage28stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage29stars", 0);
			score += PlayerPrefs.GetInt("Level1Stage30stars", 0);
		}
		else if(level == 2){
			score += PlayerPrefs.GetInt("Level2Stage1stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage2stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage3stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage4stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage5stars", 0);
			
			score += PlayerPrefs.GetInt("Level2Stage6stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage7stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage8stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage9stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage10stars", 0);
			
			score += PlayerPrefs.GetInt("Level2Stage11stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage12stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage13stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage14stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage15stars", 0);
			
			score += PlayerPrefs.GetInt("Level2Stage16stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage17stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage18stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage19stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage20stars", 0);
	
			score += PlayerPrefs.GetInt("Level2Stage21stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage22stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage23stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage24stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage25stars", 0);
			
			score += PlayerPrefs.GetInt("Level2Stage26stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage27stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage28stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage29stars", 0);
			score += PlayerPrefs.GetInt("Level2Stage30stars", 0);
		}
		else if(level == 3){
			score += PlayerPrefs.GetInt("Level3Stage1stars", 0);
			score += PlayerPrefs.GetInt("Level3Stage2stars", 0);
			score += PlayerPrefs.GetInt("Level3Stage3stars", 0);
			score += PlayerPrefs.GetInt("Level3Stage4stars", 0);
			score += PlayerPrefs.GetInt("Level3Stage5stars", 0);
			
			score += PlayerPrefs.GetInt("Level3Stage6stars", 0);
			score += PlayerPrefs.GetInt("Level3Stage7stars", 0);
			score += PlayerPrefs.GetInt("Level3Stage8stars", 0);
			score += PlayerPrefs.GetInt("Level3Stage9stars", 0);
			score += PlayerPrefs.GetInt("Level3Stage10stars", 0);
			
			score += PlayerPrefs.GetInt("Level3Stage11stars", 0);
			score += PlayerPrefs.GetInt("Level3Stage12stars", 0);
			score += PlayerPrefs.GetInt("Level3Stage13stars", 0);
			score += PlayerPrefs.GetInt("Level3Stage14stars", 0);
			score += PlayerPrefs.GetInt("Level3Stage15stars", 0);
		}
		else if(level == 4){
			score += PlayerPrefs.GetInt("Level4Stage1stars", 0);
			score += PlayerPrefs.GetInt("Level4Stage2stars", 0);
			score += PlayerPrefs.GetInt("Level4Stage3stars", 0);
			score += PlayerPrefs.GetInt("Level4Stage4stars", 0);
			score += PlayerPrefs.GetInt("Level4Stage5stars", 0);
			
			score += PlayerPrefs.GetInt("Level4Stage6stars", 0);
			score += PlayerPrefs.GetInt("Level4Stage7stars", 0);
			score += PlayerPrefs.GetInt("Level4Stage8stars", 0);
			score += PlayerPrefs.GetInt("Level4Stage9stars", 0);
			score += PlayerPrefs.GetInt("Level4Stage10stars", 0);
			
			score += PlayerPrefs.GetInt("Level4Stage11stars", 0);
			score += PlayerPrefs.GetInt("Level4Stage12stars", 0);
			score += PlayerPrefs.GetInt("Level4Stage13stars", 0);
			score += PlayerPrefs.GetInt("Level4Stage14stars", 0);
			score += PlayerPrefs.GetInt("Level4Stage15stars", 0);
		}
		else if(level == 5){
			score += PlayerPrefs.GetInt("Level5Stage1stars", 0);
			score += PlayerPrefs.GetInt("Level5Stage2stars", 0);
			score += PlayerPrefs.GetInt("Level5Stage3stars", 0);
			score += PlayerPrefs.GetInt("Level5Stage4stars", 0);
			score += PlayerPrefs.GetInt("Level5Stage5stars", 0);
			
			score += PlayerPrefs.GetInt("Level5Stage6stars", 0);
			score += PlayerPrefs.GetInt("Level5Stage7stars", 0);
			score += PlayerPrefs.GetInt("Level5Stage8stars", 0);
			score += PlayerPrefs.GetInt("Level5Stage9stars", 0);
			score += PlayerPrefs.GetInt("Level5Stage10stars", 0);
			
			score += PlayerPrefs.GetInt("Level5Stage11stars", 0);
			score += PlayerPrefs.GetInt("Level5Stage12stars", 0);
			score += PlayerPrefs.GetInt("Level5Stage13stars", 0);
			score += PlayerPrefs.GetInt("Level5Stage14stars", 0);
			score += PlayerPrefs.GetInt("Level5Stage15stars", 0);
		}
		return score;
	}
}
