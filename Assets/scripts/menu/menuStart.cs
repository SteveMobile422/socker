using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chartboost;
using UnityEngine.SocialPlatforms;

public class menuStart : MonoBehaviour {
		public			Camera			guiCamera;
	
		public			GameObject		start;
		
		public			GameObject		music;	
		public			GameObject		sound;
		public			GameObject		facebook;
		public			GameObject		credits;
		public			GameObject		store;
		public			GameObject		coins;
		public			GameObject		ball;
		public			GameObject		MoreGamesButt;
		public			GameObject		GameCenter;
	
		private			int				GuiID;
		public			BitmapMeshText	DebugText;
	
		public			GameObject		LevelSelect;
		public			GameObject		creditsView;
		public			GameObject		storeView;
	
		public			Material		soundon;
		public			Material		soundoff;
		public			Material		musicon;
		public			Material		musicoff;
	
		public			menuClick		clickSFX;
	
		public			Renderer		bg;
		public			Material[]		levelBGs;
	
		public			InteractiveConsoleHiden			facebookPlugin;
		public			bool			FeedFacebookInfo;
		public			bool			PostAfterLogin;
		public			GameObject		reklama1;
		public			GameObject		reklama2_moregames;
		public			bool			moreGamesOnAndroid;
		public			bool			moreGamesOnIos;
		public			PopoutWindow	popoutwindow;
		public		 	RevMobControler	RevMobObject;
		public			StoreKitGUIManager	StoreControler;
		public			gameControler	gameKontroler;
	
	private			bool			isGCSignedIn;
	private			int				GCShowWindowAfter;
	

	// Use this for initialization
	void Awake () {
		GCShowWindowAfter = 0;
		
		
		//PlayerPrefs.SetInt("RemoveAds", 0);
#if UNITY_IPHONE
		if( (iPhone.generation == iPhoneGeneration.iPad1Gen ||
			iPhone.generation == iPhoneGeneration.iPhone ||
			iPhone.generation == iPhoneGeneration.iPhone3G ||
			iPhone.generation == iPhoneGeneration.iPhone3GS ||
			iPhone.generation == iPhoneGeneration.iPhone4 ||
			iPhone.generation == iPhoneGeneration.iPodTouch1Gen ||
			iPhone.generation == iPhoneGeneration.iPodTouch2Gen ||
			iPhone.generation == iPhoneGeneration.iPodTouch3Gen ||
			iPhone.generation == iPhoneGeneration.iPodTouch4Gen) && QualitySettings.GetQualityLevel() != 0)
		{
			QualitySettings.SetQualityLevel(0);
		}
		else if( iPhone.generation != iPhoneGeneration.iPad1Gen &&
			iPhone.generation != iPhoneGeneration.iPhone &&
			iPhone.generation != iPhoneGeneration.iPhone3G &&
			iPhone.generation != iPhoneGeneration.iPhone3GS &&
			iPhone.generation != iPhoneGeneration.iPhone4 &&
			iPhone.generation != iPhoneGeneration.iPodTouch1Gen &&
			iPhone.generation != iPhoneGeneration.iPodTouch2Gen &&
			iPhone.generation != iPhoneGeneration.iPodTouch3Gen &&
			iPhone.generation != iPhoneGeneration.iPodTouch4Gen && QualitySettings.GetQualityLevel() != 1){
			QualitySettings.SetQualityLevel(1);
		}
		
		if(!moreGamesOnIos) MoreGamesButt.SetActive(false);

		
#endif
#if UNITY_EDITOR		
		PlayerPrefs.DeleteAll();
		//PlayerPrefs.SetInt("coins", 10000);
		PlayerPrefs.SetInt("coins", 1000);
#endif		
			
		//facebookPlugin.CallFBInit();
		// FIRST PLAYED
		if(PlayerPrefs.GetInt("Played", 0) == 0){
			//popoutwindow.EnableDailyReward(true);
			//PlayerPrefs.SetFloat("TimeSinceLastTimeAwake", ActualTime() - 1050);
			//Debug.LogError(PlayerPrefs.GetFloat("TimeSinceLastAwake", 0) + (ActualTime() - PlayerPrefs.GetFloat("TimeSinceLastTimeAwake", 0)));
			//PlayerPrefs.DeleteAll();
			PlayerPrefs.SetInt("Ball1", 2);
			#if UNITY_EDITOR
				//PlayerPrefs.SetInt("coins", 10000);
			#endif		
			
		}
		else if(PlayerPrefs.GetInt("LastLoggedToFacebook", 0) > 0){
				//facebookPlugin.CallFBLogin();
			}
		if(!StoreControler.isFree){
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
		else{

		}
		
		if(PlayerPrefs.GetInt("Sound", 0) == 1){
			sound.renderer.material = soundoff;
		}
		else{
			sound.renderer.material = soundon;	
		}
		
		if(PlayerPrefs.GetInt("Music", 0) == 1){
			music.renderer.material = musicoff;
		}
		else{
			music.renderer.material = musicon;	
		}
		PlayerPrefs.SetInt("Played", PlayerPrefs.GetInt("Played", 0) + 1);
			Debug.LogWarning(PlayerPrefs.GetInt("Played", 0));
			
			
			
		// Last Time Played
		//PlayerPrefs.SetFloat("TimeSinceLastAwake", 1040);
	
		//if(PlayerPrefs.GetFloat("TimeSinceLastTimeAwake", 0) == 0) PlayerPrefs.SetFloat("TimeSinceLastTimeAwake", ActualTime());
		PlayerPrefs.SetFloat("TimeSinceLastAwake", PlayerPrefs.GetFloat("TimeSinceLastAwake", 0) + (ActualTime() - PlayerPrefs.GetFloat("TimeSinceLastTimeAwake", 0)));
		PlayerPrefs.SetFloat("TimeSinceLastTimeAwake", ActualTime());
			if(PlayerPrefs.GetFloat("TimeSinceLastAwake", 0) > 2800)

				popoutwindow.EnableDailyReward(false);
				
			else if(PlayerPrefs.GetFloat("TimeSinceLastAwake", 0) > 1020){
				popoutwindow.EnableDailyReward(true);
			}
			else{
				Debug.Log("za malo czasu");	
			}
		Debug.Log(PlayerPrefs.GetFloat("TimeSinceLastAwake", 0));
		//Debug.Log(ActualTime());
	}
	
	void OnEnable(){
		bg.material = levelBGs[ PlayerPrefs.GetInt("loadLevel", 1) -1 ] ;
		if(GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().isFree)
		if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnStartEnabled){
			#if UNITY_ANDROID
				//AdBuddiz.ShowAnAd();
				reklama1.SendMessage("RequestPlayHavenContent");   // ToRemove;
			#endif
			#if UNITY_IPHONE
				if(RevMobObject) if(RevMobObject.revmob != null) RevMobObject.revmob.ShowFullscreen();
			#endif
		}

	}
		
	void Start(){
		Debug.Log("chartboostInit");
		CBBinding.init ( "52489f5517ba47ec0a000011", "fc9203bf0d4805d9e5e62a0196e421c7f82a3766" );
		Debug.Log("chartboostInitEnd");
		//CBBinding.cacheMoreApps();	
		//facebookPlugin.CallFBInit();
		 Social.localUser.Authenticate (ProcessAuthentication);
		
	Social.localUser.Authenticate (success => {
		if (success) {
			Debug.Log ("Authentication successful");
			string userInfo = "Username: " + Social.localUser.userName + 
				"\nUser ID: " + Social.localUser.id + 
				"\nIsUnderage: " + Social.localUser.underage;
			Debug.Log (userInfo);
		}
		else
			Debug.Log ("Authentication failed");
	});
		if(GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().isFree)
		if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnStart){
			#if UNITY_ANDROID
				//AdBuddiz.ShowAnAd();
				reklama1.SendMessage("RequestPlayHavenContent");   // ToRemove;
			#endif
			#if UNITY_IPHONE
				//reklama1.SendMessage("RequestPlayHavenContent");
				if(RevMobObject) if(RevMobObject.revmob != null) RevMobObject.revmob.ShowFullscreen();
			#endif
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		//DebugText.Text = ("" + facebookPlugin.isInit + ",  " + FB.IsLoggedIn + ",  "+FB.IsLoggedIn);
		/*if(FeedFacebookInfo){
			FeedFacebookInfo = false;
			try
            {
               facebookPlugin.CallFBFeed();
               facebookPlugin.status = "Feed dialog called";
            }
            catch (Exception e)
            {
              facebookPlugin.status = e.Message;
            }
		}*/
			
			if(Input.GetKeyUp(KeyCode.Escape)){ Application.Quit();}
			if(popoutwindow.active) GuiID = -1;
		
		if(Input.touchCount>0){
			if(Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended){
					start.transform.localScale = new Vector3(6.0f, 2.0f, 1);
					sound.transform.localScale = new Vector3(1.5f, 1.6f, 1);
					music.transform.localScale = new Vector3(1.5f, 1.6f, 1);
					facebook.transform.localScale = new Vector3(1.5f, 1.6f, 1);
					credits.transform.localScale = new Vector3(1.5f, 1.6f, 1);
					store.transform.localScale = new Vector3(1.6f, 1.6f, 1);
					coins.transform.localScale = new Vector3(1.23f, 1.23f, 1);
					ball.transform.localScale = new Vector3(1.45f, 1.35f, 1);
					MoreGamesButt.transform.localScale = new Vector3(1.0f, 1.0f, 1);
					GameCenter.transform.localScale = new Vector3(1.5f, 1.6f, 1);
				if(GuiID == 0){
					clickSFX.playClick();
					if(GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().isFree)
					if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnStartClick){
						#if UNITY_ANDROID
							//AdBuddiz.ShowAnAd();
							//reklama1.SendMessage("RequestPlayHavenContent");   // ToRemove;
							ChartBoostAndroid.showInterstitial( null );
						#endif
						#if UNITY_IPHONE
							//reklama1.SendMessage("RequestPlayHavenContent");
							if(RevMobObject) if(RevMobObject.revmob != null) RevMobObject.revmob.ShowFullscreen();
						#endif
					}
					LevelSelect.SetActive(true);
					gameObject.SetActive(false);
				}
				else if(GuiID == 1){
					if(PlayerPrefs.GetInt("Sound", 0) == 0){
						PlayerPrefs.SetInt("Sound", 1);
						sound.renderer.material = soundoff;
						clickSFX.source.volume = 1;
						
					}
					else{
						PlayerPrefs.SetInt("Sound", 0);
						sound.renderer.material = soundon;
						clickSFX.source.volume = 0;
						clickSFX.playClick();
					}
					
				}
				else if(GuiID == 2){
					if(PlayerPrefs.GetInt("Music", 0) == 0){
						PlayerPrefs.SetInt("Music", 1);
						music.renderer.material = musicoff;
					}
					else{
						PlayerPrefs.SetInt("Music", 0);
						music.renderer.material = musicon;
					}
					clickSFX.playClick();
				}
				else if(GuiID == 3){
					/*
					if(!FB.IsLoggedIn){
						FB.Login("email,publish_actions", AuthCallback);
						FeedFacebookInfo = true;
					}
					else if(FB.IsLoggedIn){
						 try
			            {
			               facebookPlugin.CallFBFeed();
			               facebookPlugin.status = "Feed dialog called";
			            }
			            catch (Exception e)
			            {
			              facebookPlugin.status = e.Message;
			            }	
					}		*/
					if(PlayerPrefs.GetInt("LikeUsReward", 0) == 0){
						PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 10);	
						PlayerPrefs.SetInt("LikeUsReward", 1);
					}
					OpenFacebookPage();
					
					
					clickSFX.playClick();
				}
				else if(GuiID == 4){
					creditsView.SetActive(true);
					gameObject.SetActive(false);
					clickSFX.playClick();
				}
				else if(GuiID == 5){
					PlayerPrefs.SetInt("loadStore", 0);
					PlayerPrefs.SetInt("loadStoreFrom", 0);
						storeView.SetActive(true);
						gameObject.SetActive(false);
					clickSFX.playClick();
				}
				else if(GuiID == 6){
					PlayerPrefs.SetInt("loadStore", 1);
					PlayerPrefs.SetInt("loadStoreFrom", 0);
						storeView.SetActive(true);
						gameObject.SetActive(false);
					clickSFX.playClick();
				}
				else if(GuiID == 7){
					PlayerPrefs.SetInt("loadStore", 2);
					PlayerPrefs.SetInt("loadStoreFrom", 0);
						storeView.SetActive(true);
						gameObject.SetActive(false);
					clickSFX.playClick();
				}
				else if(GuiID == 8){
					clickSFX.playClick();
					#if UNITY_ANDROID

					#endif
					#if UNITY_IPHONE
						CBBinding.showMoreApps();
						//reklama2_moregames.SendMessage("RequestPlayHavenContent");
					#endif	
						
				}
				else if(GuiID == 9){
					clickSFX.playClick();
					Social.ShowAchievementsUI();	
				}
			}
			if(Input.GetTouch(0).phase == TouchPhase.Began){
					// Is Popout Window
					if(popoutwindow.active) return;
					
					Ray ray = guiCamera.ScreenPointToRay(Input.GetTouch(0).position);
					RaycastHit hit;
				GuiID = -1;	
				
					if (Physics.Raycast(ray, out hit, 1000)){
					//**************** BEGAN

						if(hit.collider.gameObject == start){
							GuiID = 0;
							
						}
						else if(hit.collider.gameObject == sound){
							GuiID = 1;
							
						}
						else if(hit.collider.gameObject == music){
							GuiID = 2;
						}
						else if(hit.collider.gameObject == facebook){
							GuiID = 3;
						}
						else if(hit.collider.gameObject == credits){
							GuiID = 4;
						}
						else if(hit.collider.gameObject == store){
							GuiID = 5;
						}
						else if(hit.collider.gameObject == coins){
							GuiID = 6;
						}
						else if(hit.collider.gameObject == ball){
							GuiID = 7;
						}
						else if(hit.collider.gameObject == MoreGamesButt){
							GuiID = 8;
						}
						else if(hit.collider.gameObject == GameCenter){
							GuiID = 9;
						}
						else {
							GuiID = -1;	
						}
				}
			}
			else if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary){
					if(GuiID == 0) start.transform.localScale = Vector3.Slerp(start.transform.localScale, new Vector3(6.7f, 2.3f, 1), Time.deltaTime*25.0f);
					if(GuiID == 1) sound.transform.localScale = Vector3.Slerp(sound.transform.localScale, new Vector3(1.8f, 1.9f, 1), Time.deltaTime*25.0f);
					if(GuiID == 2) music.transform.localScale = Vector3.Slerp(music.transform.localScale, new Vector3(1.8f, 1.9f, 1), Time.deltaTime*25.0f);
					if(GuiID == 3) facebook.transform.localScale = Vector3.Slerp(facebook.transform.localScale, new Vector3(1.8f, 1.9f, 1), Time.deltaTime*25.0f);
					if(GuiID == 4) credits.transform.localScale = Vector3.Slerp(credits.transform.localScale, new Vector3(1.8f, 1.9f, 1), Time.deltaTime*25.0f);
					if(GuiID == 5) store.transform.localScale = Vector3.Slerp(store.transform.localScale, new Vector3(1.9f, 1.9f, 1), Time.deltaTime*25.0f);
					if(GuiID == 6) coins.transform.localScale = Vector3.Slerp(coins.transform.localScale, new Vector3(1.4f, 1.4f, 1), Time.deltaTime*25.0f);
					if(GuiID == 7) ball.transform.localScale = Vector3.Slerp(ball.transform.localScale, new Vector3(1.8f, 1.7f, 1), Time.deltaTime*25.0f);
					if(GuiID == 8) MoreGamesButt.transform.localScale = Vector3.Slerp(MoreGamesButt.transform.localScale, new Vector3(1.15f, 1.15f, 1), Time.deltaTime*25.0f);
					if(GuiID == 9) GameCenter.transform.localScale = Vector3.Slerp(GameCenter.transform.localScale, new Vector3(1.8f, 1.9f, 1), Time.deltaTime*25.0f);
			
			}
		}
		
		
	}
		
	public float ActualTime(){
		return (System.DateTime.Now.Minute + System.DateTime.Now.Hour*60 + System.DateTime.Now.Day*24*60 + (System.DateTime.Now.Year - 2012) *365*24*60);	
	}
		
	void AuthCallback(FBResult result) {
    if(FB.IsLoggedIn) {
        Debug.Log(FB.UserId);
    } else {
        Debug.Log("User cancelled login");
    }
}
	

	
	void ProcessAuthentication (bool success) {
        if (success) {
            Debug.Log ("Authenticated, checking achievements");
			isGCSignedIn = true;
            // Request loaded achievements, and register a callback for processing them
            Social.LoadAchievements (ProcessLoadedAchievements);
        }
        else{
            Debug.Log ("Failed to authenticate");
						isGCSignedIn = false;	
		}
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
		if(procentComplited > stagessMaxNumber) procentComplited = stagessMaxNumber;
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
		if(procentComplited > stagessMaxNumber) procentComplited = stagessMaxNumber;
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
		if(procentComplited > stagessMaxNumber) procentComplited = stagessMaxNumber;
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
		if(procentComplited > stagessMaxNumber) procentComplited = stagessMaxNumber;
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
		if(procentComplited > stagessMaxNumber) procentComplited = stagessMaxNumber;
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
		if(procentComplited > stagessMaxNumber) procentComplited = stagessMaxNumber;
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
		if(procentComplited > ballsMaxNumber) procentComplited = 100;
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
		if(procentComplited > ballsMaxNumber) procentComplited = 100;
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
		if(procentComplited > ballsMaxNumber) procentComplited = 100;
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
		if(procentComplited > ballsMaxNumber) procentComplited = 100;
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
		if(procentComplited > ballsMaxNumber) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.kick250balls", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress5");
            else
                Debug.Log ("Failed to report achievement5 " +procentComplited  );
        });
		
		UpdateScores();
		if(GCShowWindowAfter > 0) {
			Social.ShowAchievementsUI();
			GCShowWindowAfter = 0;
		}
    }
	
	public void UpdateScores(){
		Social.ReportScore (
					gameKontroler.LeaderboardScoreForLevel(1),
					"grp.immanitas.KickTheBall", 
					success => {
			Debug.Log(success ? "Reported score successfully" : "Failed to report score");
		});
		Social.ReportScore (
					gameKontroler.LeaderboardScoreForLevel(2),
					"grp.immanitas.KickTheBall.level2", 
					success => {
			Debug.Log(success ? "Reported score successfully" : "Failed to report score");
		});
		Social.ReportScore (
					gameKontroler.LeaderboardScoreForLevel(3),
					"grp.immanitas.KickTheBall.level3", 
					success => {
			Debug.Log(success ? "Reported score successfully" : "Failed to report score");
		});
		Social.ReportScore (
					gameKontroler.LeaderboardScoreForLevel(4),
					"grp.immanitas.KickTheBall.level4", 
					success => {
			Debug.Log(success ? "Reported score successfully" : "Failed to report score");
		});

		Social.ReportScore (
					gameKontroler.LeaderboardScoreForLevel(5),
					"grp.immanitas.KickTheBall.level5", 
					success => {
			Debug.Log(success ? "Reported score successfully" : "Failed to report score");
		});
	}
	
    void OpenFacebookPage ()
    {
        float startTime;
        startTime = Time.timeSinceLevelLoad;
       
        //open the facebook app
        Application.OpenURL("fb://profile/411110898990364");
       
        if (Time.timeSinceLevelLoad - startTime <= 1f)
        {
            //fail. Open safari.
			Application.OpenURL("https://www.facebook.com/kicktheballgame");
        }
    }
}




