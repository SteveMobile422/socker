using UnityEngine;
using System.Collections;
using Chartboost;
using UnityEngine.SocialPlatforms;

public class StageFinish : MonoBehaviour {
	
	public			GameObject			starleft;
	public			GameObject			starmid;
	public			GameObject			starright;
	
	public			GameObject			starleftPart;
	public			GameObject			starmidPart;
	public			GameObject			starrightPart;
	
	public			controller			kontroler;
	public			StageGameplay		gameplay;
	public			gameControler		gameKontroler;
	
	public			float				timer;
	
	private			float				scoretron;
	private			float				scoreSpeed;
	public			BitmapMeshText		scoreText;
	
	public			bool				isAnimating;
	public			int					starsColected;
	
	public			GameObject			powerup3Menu;
	public			int					powerup3Cash;
	public			BitmapMeshText		powerup3CashText;
	
	private			bool				finished;
	
	public			BitmapMeshText		finishCashmesh;
	private			int					finishCash;
	
	public			GameObject			reklama1;
	private			bool				adEndShowed;
	
	private			int				AlreadyCollected;
	
	// Update is called once per frame
	void Update () {
		
		
		
		if(AlreadyCollected >= 1 && !starleft.activeInHierarchy){
			starleft.SetActive(true);
			starleft.animation.Play("starColectLeft");
			starleft.animation["starColectLeft"].normalizedTime = 1;
			timer --;
		}
		if(AlreadyCollected >= 2 && !starmid.activeInHierarchy){
			starmid.SetActive(true);
			starmid.animation.Play("starColectedMid");
			starmid.animation["starColectedMid"].normalizedTime = 1;
			timer -= 0.5f;
		}
		 if(AlreadyCollected >= 3 && !starright.activeInHierarchy){
			starright.SetActive(true);
			starright.animation.Play("starColectedRight");
			starright.animation["starColectedRight"].normalizedTime = 1;
			timer -= 0.5f;
		}
		
		if(scoretron < kontroler.score) scoretron += Time.deltaTime * scoreSpeed;
		else if(!finished){
			scoretron = kontroler.score;

			finished = true;
		}
				
		scoreText.Text = ""+ (int)scoretron;
		finishCashmesh.Text = "+" + finishCash;
		if(gameplay.powerup3Active){
			if(!powerup3Menu.activeInHierarchy) powerup3Menu.SetActive(true);
			powerup3Cash = (int)(scoretron / 200);
			powerup3CashText.Text = "+" + powerup3Cash;
		}
		else{
			if(powerup3Menu.activeInHierarchy) powerup3Menu.SetActive(false);
		}
		
		
		/*if(!isAnimating && starsColected == 0 && gameplay.playableStage.GetComponent<stageData>().scoresBariers.x <= kontroler.score){
			isAnimating = true;	
		}
		else if(isAnimating && timer + 1  < Time.time && gameplay.playableStage.GetComponent<stageData>().scoresBariers.x > kontroler.score ){
			isAnimating = false;
			Debug.Log("send stars:  " + starsColected);
			
				gameKontroler.setStageStars(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID, starsColected);
		}
		else if(isAnimating && timer + 1.5f  < Time.time && gameplay.playableStage.GetComponent<stageData>().scoresBariers.y > kontroler.score){
			isAnimating = false;
			Debug.Log("send stars:  " + starsColected);
			
				gameKontroler.setStageStars(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID, starsColected);
		}
		else if(isAnimating && timer + 2 < Time.time && gameplay.playableStage.GetComponent<stageData>().scoresBariers.z > kontroler.score  ){
			isAnimating = false;
			Debug.Log("send stars:  " + starsColected);
			
				gameKontroler.setStageStars(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID, starsColected);
		}*/
		
		if(timer + 3 < Time.time && !adEndShowed){
			adEndShowed = true;
			if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnGameSummaryEnd && !kontroler.ThisGameIsPremium){
				#if UNITY_IPHONE
					//CBBinding.cacheInterstitial("default");
				#endif
			}
		}
		
		if(timer + 1  < Time.time && !starleft.activeInHierarchy && gameplay.playableStage.GetComponent<stageData>().scoresBariers.x <= kontroler.score && AlreadyCollected < 1){
			starleft.SetActive(true);
			starleft.animation["starColectLeft"].normalizedTime = 0;
			starleft.animation.Play("starColectLeft");
			starleft.animation["starColectLeft"].normalizedTime = 0;
			starleft.animation.Rewind("starColectLeft");
			gameKontroler.setStageStars(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID, starsColected);
		}
		else if(timer + 1.5f  < Time.time && !starmid.activeInHierarchy && gameplay.playableStage.GetComponent<stageData>().scoresBariers.y <= kontroler.score && AlreadyCollected < 2){
			starmid.SetActive(true);
			starmid.animation["starColectedMid"].normalizedTime = 0;
			starmid.animation.Play("starColectedMid");
			starmid.animation["starColectedMid"].normalizedTime = 0;
			 starmid.animation.Rewind("starColectedMid");
			gameKontroler.setStageStars(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID, starsColected);
		}
		else if(timer + 2 < Time.time && !starright.activeInHierarchy && gameplay.playableStage.GetComponent<stageData>().scoresBariers.z <= kontroler.score  && AlreadyCollected < 3){
			starright.SetActive(true);
			starright.animation["starColectedRight"].normalizedTime = 0;
			starright.animation.Play("starColectedRight");
			starright.animation["starColectedRight"].normalizedTime = 0;
			starright.animation.Rewind("starColectedRight");
			Debug.Log("send stars:  " + starsColected);
			
				gameKontroler.setStageStars(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID, starsColected);
		}
		
		
		//***************************** POMIN START
		if(Input.touchCount > 0)
		if(Input.GetTouch(0).phase == TouchPhase.Began && timer + 2 > Time.time && timer + 0.5f < Time.time){
			Debug.LogWarning("POMINIETE");
			if(gameplay.playableStage.GetComponent<stageData>().scoresBariers.x <= kontroler.score){
				starleft.animation.Play("starColectLeft");
				starleft.animation["starColectLeft"].normalizedTime = 2;
				if (AlreadyCollected < 1) finishCash = 2;
			}
			if(gameplay.playableStage.GetComponent<stageData>().scoresBariers.y <= kontroler.score){
				starmid.animation.Play("starColectedMid");
				starmid.animation["starColectedMid"].normalizedTime = 2;
				if (AlreadyCollected < 2) finishCash += 3;
			}
			if(gameplay.playableStage.GetComponent<stageData>().scoresBariers.z <= kontroler.score){
				starright.animation.Play("starColectedRight");
				starright.animation["starColectedRight"].normalizedTime = 2;
				if (AlreadyCollected < 3) finishCash += 5;
			}
			starleft.animation.Play("starColectLeft");
			starleft.animation["starColectLeft"].normalizedTime = 2;
			starmid.animation.Play("starColectedMid");
			starmid.animation["starColectedMid"].normalizedTime = 2;
			starright.animation.Play("starColectedRight");
			starright.animation["starColectedRight"].normalizedTime = 2;
			
			timer -= 3;
			scoretron = kontroler.score;
			if(gameplay.powerup3Active){
				powerup3Cash = (int)(scoretron/200);
				//PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + powerup3Cash);
			}
			if(gameplay.powerup3Active){
				if(!powerup3Menu.activeInHierarchy) powerup3Menu.SetActive(true);
				powerup3Cash = (int)(scoretron/200);
				powerup3CashText.Text = "+" + powerup3Cash;

			}
			
			finished = true;
		}
		//***************************** POMIN END
		
		
		if(starleft.activeInHierarchy && !starleftPart.activeInHierarchy && !starleft.animation.isPlaying && AlreadyCollected < 1 ){
			starleftPart.SetActive(true);
			GameObject.FindGameObjectWithTag("soundmanager").GetComponent<soundManager>().PlayColected(1);
			if(finishCash < 2) finishCash += 2;

		}
		if(starmid.activeInHierarchy && !starmidPart.activeInHierarchy && !starmid.animation.isPlaying && AlreadyCollected < 2 ){
			starmidPart.SetActive(true);
			GameObject.FindGameObjectWithTag("soundmanager").GetComponent<soundManager>().PlayColected(0.8f);
			if(finishCash < 5) finishCash += 3;
		}
		if(starright.activeInHierarchy && !starrightPart.activeInHierarchy && !starright.animation.isPlaying && AlreadyCollected < 3 ){
			starrightPart.SetActive(true);
			GameObject.FindGameObjectWithTag("soundmanager").GetComponent<soundManager>().PlayColected(0.6f);
			if(finishCash < 10) finishCash += 5;
		}
	
	
	
	}
	
	void OnEnable(){
		Debug.Log(gameplay.playableStage.GetComponent<stageData>().stageID);
		//gameKontroler.setStageStars(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID, 1);
		
		AlreadyCollected = gameKontroler.getStageStars(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID);
		
		Social.localUser.Authenticate (ProcessAuthentication);
		adEndShowed = false;
			starleft.animation.Stop();
			starmid.animation.Stop();
			starright.animation.Stop();
		
		if(PlayerPrefs.GetInt("addNumer", 0) <= 3){	
			PlayerPrefs.SetInt("addNumer", 3);
			if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnGameSummaryStart && !kontroler.ThisGameIsPremium){
				#if UNITY_ANDROID
					//AdBuddiz.ShowAnAd();
					reklama1.SendMessage("RequestPlayHavenContent");   // ToRemove;
				#endif
				#if UNITY_IPHONE
					//reklama1.SendMessage("RequestPlayHavenContent");
					CBBinding.showInterstitial( "null" );
				#endif	
			}
		}
		PlayerPrefs.SetInt("addNumer", PlayerPrefs.GetInt("addNumer", 0) - 1);
		
		// Scoretron
		if(gameplay.powerup3Active){
			float scoretron2 = kontroler.score;
			int powerup3Cash = (int)(scoretron2/200);
			PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + powerup3Cash);
		}
		
		finishCash = 0;
		finished = false;
		isAnimating = true;
		starsColected = 0;
		timer = Time.time;
		starleft.SetActive(false);
		starmid.SetActive(false);
		starright.SetActive(false);
		scoretron = 0;
		scoreSpeed = kontroler.score / 1;
		
		if(kontroler.score > 0 && gameKontroler.getStageScore(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID) <= 0){
			PlayerPrefs.SetInt("StageComplited", (PlayerPrefs.GetInt("StageComplited", 0) + 1 ));
			Debug.Log(PlayerPrefs.GetInt("StageComplited", 0));	
			AddAcheavementStage();
			
		}
		if(kontroler.score > gameKontroler.getStageScore(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID)) {
					gameKontroler.setStageScore(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID, kontroler.score);
			Debug.Log("set score: " + kontroler.score);	
		}
		
		if(gameplay.playableStage.GetComponent<stageData>().scoresBariers.x <= kontroler.score && AlreadyCollected < 1){
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 2);
		}
		if(gameplay.playableStage.GetComponent<stageData>().scoresBariers.y <= kontroler.score && AlreadyCollected < 2){
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 3);
		}
		if(gameplay.playableStage.GetComponent<stageData>().scoresBariers.z <= kontroler.score && AlreadyCollected < 3){
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 5);
		}
		
		if(gameplay.playableStage.GetComponent<stageData>().scoresBariers.z <= kontroler.score){
			starsColected = 3;
		}
		else if(gameplay.playableStage.GetComponent<stageData>().scoresBariers.y <= kontroler.score){
			starsColected = 2;
		}
		else if(gameplay.playableStage.GetComponent<stageData>().scoresBariers.x <= kontroler.score){
			starsColected = 1;
		}
		if(starsColected > gameKontroler.getStageStars(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID)) 
		gameKontroler.setStageStars(gameplay.playableStage.GetComponent<stageData>().levelID, gameplay.playableStage.GetComponent<stageData>().stageID, starsColected);
		
				UpdateScores();
	}
	
	void OnDisable(){
		finishCash = 0;
		starleft.SetActive(false);
		starmid.SetActive(false);
		starright.SetActive(false);
		
		starleftPart.SetActive(false);
		starmidPart.SetActive(false);
		starrightPart.SetActive(false);
		powerup3Menu.SetActive(false);
	}
	
	public void AddAcheavementStage(){
		int procentComplited = 0;
		int stagessMaxNumber = 0;	
	
		stagessMaxNumber = 3;
		procentComplited = (int)((PlayerPrefs.GetInt("StageComplited", 0) / stagessMaxNumber)*100);
		if(procentComplited > stagessMaxNumber) procentComplited = stagessMaxNumber;
		Social.ReportProgress ("grp.immanitas.KickTheBall.win3stages", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement");
        });
		
		
		stagessMaxNumber = 10;
		procentComplited = (int)((PlayerPrefs.GetInt("StageComplited", 0) / stagessMaxNumber)*100);
		if(procentComplited > stagessMaxNumber) procentComplited = stagessMaxNumber;
		Social.ReportProgress ("grp.immanitas.KickTheBall.win10stages", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement");
        });
		
		
		stagessMaxNumber = 20;
		procentComplited = (int)((PlayerPrefs.GetInt("StageComplited", 0) / stagessMaxNumber)*100);
		if(procentComplited > stagessMaxNumber) procentComplited = stagessMaxNumber;
		Social.ReportProgress ("grp.immanitas.KickTheBall.win20stages", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement");
        });
		
		stagessMaxNumber = 30;
		procentComplited = (int)((PlayerPrefs.GetInt("StageComplited", 0) / stagessMaxNumber)*100);
		if(procentComplited > stagessMaxNumber) procentComplited = stagessMaxNumber;
		Social.ReportProgress ("grp.immanitas.KickTheBall.win30stages", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement");
        });
		
		stagessMaxNumber = 60;
		procentComplited = (int)((PlayerPrefs.GetInt("StageComplited", 0) / stagessMaxNumber)*100);
		if(procentComplited > stagessMaxNumber) procentComplited = stagessMaxNumber;
		Social.ReportProgress ("grp.immanitas.KickTheBall.win60stages", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement");
        });
		
		stagessMaxNumber = 90;
		procentComplited = (int)((PlayerPrefs.GetInt("StageComplited", 0) / stagessMaxNumber)*100);
		if(procentComplited > stagessMaxNumber) procentComplited = stagessMaxNumber;
		Social.ReportProgress ("grp.immanitas.KickTheBall.win90stages", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement");
        });

	}
	
	void ProcessAuthentication (bool success) {
        if (success) {
            Debug.Log ("Authenticated, checking achievements");

            // Request loaded achievements, and register a callback for processing them
            Social.LoadAchievements (ProcessLoadedAchievements);
        }
        else
            Debug.Log ("Failed to authenticate");
    }

    // This function gets called when the LoadAchievement call completes
    void ProcessLoadedAchievements (IAchievement[] achievements) {
        if (achievements.Length == 0)
            Debug.Log ("Error: no achievements found");
        else
            Debug.Log ("Got " + achievements.Length + " achievements");
		
// STAGES
		int procentComplited = 0;
		int stagessMaxNumber = 0;	
		int ballsMaxNumber = 0;
		float calculation;
		
	Debug.Log("******************" + PlayerPrefs.GetInt("StageComplited", 0));
		stagessMaxNumber = 3;
		calculation = PlayerPrefs.GetInt("StageComplited", 0);
		calculation /= stagessMaxNumber;
		calculation *= 100;
		procentComplited = (int)calculation;
		if(procentComplited > 100) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.win3stages", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress 0");
            else
                Debug.Log ("Failed to report achievement");
        });
		
		
		stagessMaxNumber = 10;
		calculation = PlayerPrefs.GetInt("StageComplited", 0);
		calculation /= stagessMaxNumber;
		calculation *= 100;
		procentComplited = (int)calculation;
		if(procentComplited > 100) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.win10stages", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress 1");
            else
                Debug.Log ("Failed to report achievement");
        });
		
		
		stagessMaxNumber = 20;
		calculation = PlayerPrefs.GetInt("StageComplited", 0);
		calculation /= stagessMaxNumber;
		calculation *= 100;
		procentComplited = (int)calculation;
		if(procentComplited > 100) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.win20stages", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress 2");
            else
                Debug.Log ("Failed to report achievement");
        });
		
		stagessMaxNumber = 30;
		calculation = PlayerPrefs.GetInt("StageComplited", 0);
		calculation /= stagessMaxNumber;
		calculation *= 100;
		procentComplited = (int)calculation;
		if(procentComplited > 100) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.win30stages", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress 3");
            else
                Debug.Log ("Failed to report achievement");
        });
		
		stagessMaxNumber = 60;
		calculation = PlayerPrefs.GetInt("StageComplited", 0);
		calculation /= stagessMaxNumber;
		calculation *= 100;
		procentComplited = (int)calculation;
		if(procentComplited > 100) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.win60stages", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress 4");
            else
                Debug.Log ("Failed to report achievement");
        });
		
		stagessMaxNumber = 90;
		calculation = PlayerPrefs.GetInt("StageComplited", 0);
		calculation /= stagessMaxNumber;
		calculation *= 100;
		procentComplited = (int)calculation;
		if(procentComplited > 100) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.win90stages", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress 5");
            else
                Debug.Log ("Failed to report achievement");
        });
		
// BALLS
		Debug.Log("******************" + PlayerPrefs.GetInt("BallKicked", 0));
		ballsMaxNumber = 10;
		calculation = PlayerPrefs.GetInt("BallKicked", 0);
		calculation /= ballsMaxNumber;
		calculation *= 100;
		procentComplited = (int)calculation;
		if(procentComplited > 100) procentComplited = 100;
		Debug.Log(procentComplited);
		Social.ReportProgress ("grp.immanitas.KickTheBall.kick10balls", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress1");
            else
                Debug.Log ("Failed to report achievement1 " + procentComplited);
        });
		
		
		ballsMaxNumber = 60;
		calculation = PlayerPrefs.GetInt("BallKicked", 0);
		calculation /= ballsMaxNumber;
		calculation *= 100;
		procentComplited = (int)calculation;
		if(procentComplited > 100) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.kick60balls", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress2");
            else
                Debug.Log ("Failed to report achievement2 " + procentComplited);
        });
		
		ballsMaxNumber = 90;
		calculation = PlayerPrefs.GetInt("BallKicked", 0);
		calculation /= ballsMaxNumber;
		calculation *= 100;
		procentComplited = (int)calculation;
		if(procentComplited > 100) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.kick90balls", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress3");
            else
                Debug.Log ("Failed to report achievement3 " + procentComplited);
        });
		
		ballsMaxNumber = 120;
		calculation = PlayerPrefs.GetInt("BallKicked", 0);
		calculation /= ballsMaxNumber;
		calculation *= 100;
		procentComplited = (int)calculation;
		if(procentComplited > 100) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.kick120balls", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress4");
            else
                Debug.Log ("Failed to report achievement4 " + procentComplited );
        });
		
		ballsMaxNumber = 250;
		calculation = PlayerPrefs.GetInt("BallKicked", 0);
		calculation /= ballsMaxNumber;
		calculation *= 100;
		procentComplited = (int)calculation;
		if(procentComplited > 100) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.kick250balls", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress5");
            else
                Debug.Log ("Failed to report achievement5 " +procentComplited  );
        });
		
		Debug.Log("scores: " + PlayerPrefs.GetInt("StageComplited", 0) + "   " + PlayerPrefs.GetInt("BallKicked", 0));
    }
	
	public void UpdateScores(){
		string leaderboardID = "";
		
		if(gameplay.playableStage.GetComponent<stageData>().levelID == 1){
			leaderboardID = "grp.immanitas.KickTheBall";
		}
		else if(gameplay.playableStage.GetComponent<stageData>().levelID == 2){
			leaderboardID = "grp.immanitas.KickTheBall.level2";
		}
		else if(gameplay.playableStage.GetComponent<stageData>().levelID == 3){
			leaderboardID = "grp.immanitas.KickTheBall.level3";
		}
		else if(gameplay.playableStage.GetComponent<stageData>().levelID == 4){
			leaderboardID = "grp.immanitas.KickTheBall.level4";
		}
		else if(gameplay.playableStage.GetComponent<stageData>().levelID == 5){
			leaderboardID = "grp.immanitas.KickTheBall.level5";
		}
		
		Social.ReportScore (
					gameKontroler.LeaderboardScoreForLevel(gameplay.playableStage.GetComponent<stageData>().levelID),
					leaderboardID, 
					success => {
			Debug.Log(success ? "Reported score successfully" : "Failed to report score");
		});
	}
}
