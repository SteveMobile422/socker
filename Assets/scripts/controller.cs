using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chartboost;
using UnityEngine.SocialPlatforms;

public class controller : MonoBehaviour {
	public			bool			ThisGameIsPremium;
	public 			Camera 			Kamera;
	public			Camera			guiCamera;
	public			Camera			OverallCamera;
	
	private			int				GameplayTouchOne 		= -1;
	private			bool			GuiTouch;
	
	public 			GameObject		guiZoom;
	
	public			Rigidbody		ball;
	
	// Celownik
	public			Transform		cel_base;
	public			Transform		cel_tower;
	public			Transform		cel_dir;
	public			Vector2			upRotationLimit = new Vector2(2, 30);			// Vertical
	public			float			RotationLimit = 37;								// Horizontal
	public			float			power			= 1;
	public			float			katWidzenia;
	
	public			Transform[]		points;
	public			int				corrPoint;
	public			Transform		center;
	
	private			float			 cameraParentRotateAngle;
	private			bool			onRight;
	
	// Additional Skip Physic
	public			GameObject[]		AdditionalBalls;
	private			float			afterThrowTimer;
	public			GameObject		ballPivot;
	public			GameObject		ballBlob;
		public			LineRenderer	ballLine;
	// POWERUPS
	public			float			powerForceMultipler = 1;
	
	// GUI
	public			changeball		ballchangerscript;
	private			int				GuiID;
	public			Transform		changeball;
	public			Transform		pause;
	public			Transform		back;
	public			Transform		money;
	public			Transform		menu;
	public			Transform		share;
	public			Transform		left;
	public			Transform		right;
	public			Transform		left_bw;
	public			Transform		right_bw;
	public			Transform		restartPause;
	
	public			Transform		facebookPause;
	public			Transform		facebookFinish;
	public			Transform		GameCenter;
	public			Transform		GameCenter2;
	
	// SUMMARY
	public			Transform		repeat2;
	public			Transform		menu2;
	public			Transform		next2;
	
	// PAUSE SOUND
	public			Transform		changeSound;
	public			Transform		changeMusic;
	
	// POWERUPS
	public			Transform		moreCoins;
	public			Transform		powerupSelect1;
	public			Transform		powerupSelect2;
	public			Transform		powerupSelect3;
	public			Transform		powerupCancel;
	
	public			Transform		powerupSelect1Fast;
	public			Transform		powerupSelect2Fast;
	public			Transform		powerupSelect3Fast;
	public			Transform		powerupCloseFast;
	
	public			ballIndicator[]		ballsGUI;
	public			int				ballsAvaible;
	
	
	// BALL THROWED
	public			bool			throwed;
	public			float			throwedStopTimer;
	private			Vector3			startCamPos;
	private			Quaternion		startCamRot;
	private			float			camRotation;
	
	
	// PAUSE MENU
	public			GameObject		pauzaMenu;
	public			bool			pauza;
	public			GameObject		finishMenu;
	public			bool			finish;
	public			GUITexture		blacknes;
	private			float			blacknesFade;
	
	// GAME OVER
	public			bool			gameOver;
	public			float			gameOverTimer;
	public			bool			complited;
	public			bool			complitedWin;
	
	public			GameObject		win;
	public			GameObject		lose;
	
	// GAMEPLAY
	public			int				score;
	public			BitmapMeshText	scoretron;
	public			StageGameplay	gameplay;
	public			soundManager	soundMGR;
	
	// POWERUPS MENU
	public			GameObject		powerupsMenu;
	public			bool			powerupShop;
	public			BitmapMeshText[]	powerupsFastHave;	
	public			GameObject[]	powerupsFastActive;
	
	// STORY MENU
	public			bool			hasStoryMenu;
	public			bool			AdditionalPowerupsMenu;
	public			GameObject		storyMenu;
	public			Transform		storyBackBtn;
	public			GameObject		AddPowerMenu;
	
	public			bool			frizeCamera;
	public			float			movetimer;
	public			Vector3			camVelocity;
	public			Vector3			lastCamPos;
	

	public			GameObject			reklama1;
	public			InteractiveConsoleHiden			facebookPlugin;
	public			bool			FeedFacebookInfo;
	public			bool			PostAfterLogin;
	public			MoreCoinsGui	MoreCoinsGUIControler;
	public			GameObject		coins;
	public			StoreKitGUIManager	StoreControler;
	
	public			GameObject		loadingMenu;
	
	private			bool			ImLoadingSomething = false;


	// Use this for initialization
	void Start () {
		// INITIALISATION
		
		startCamPos = Kamera.transform.position + points[corrPoint].position;
		startCamRot = Kamera.transform.rotation;
		RestartBall();
		blacknes.enabled = false;
		blacknes.color = new Color(0.2f, 0.2f, 0.2f, blacknesFade);
		pauzaMenu.SetActive(false);
	}
	
	void Awake(){
		Social.localUser.Authenticate (ProcessAuthentication);
		//if(startCamPos != Vector3.zero) Kamera.transform.position = startCamPos;
		//if(startCamRot != Quaternion.identity) Kamera.transform.rotation = startCamRot;
		if(points[0])	 RestartBall();
		CheckHorizontalMoveButtons();
		if(!StoreControler.canMakePayments){
			StoreControler.InitialiseStoreKit();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Application.isLoadingLevel) return;
		
		if(Vector3.Distance(center.position, ball.position) > 27) ball.rigidbody.drag = 2;
		else ball.rigidbody.drag = 0.5f;
		if(Input.GetKeyDown(KeyCode.Space)) frizeCamera = true;
		
		scoretron.Text = "Score: " + score;
				//  Angle Between Points
		float OrientCameraBy = 0;
		if(Vector3.Angle(Vector3.forward, center.position - points[corrPoint].position) <90){
			OrientCameraBy = Vector3.Angle(Vector3.right, center.position - points[corrPoint].position)-90;
			if(OrientCameraBy < 0) onRight = true;
			else onRight = false;
		}
		else if(!onRight)
			OrientCameraBy = 180 + (180 - Vector3.Angle(Vector3.right, center.position - points[corrPoint].position)-90);
		else if(onRight)
			OrientCameraBy = -1 * Vector3.Angle(Vector3.right, center.position - points[corrPoint].position)-90;
		
		cameraParentRotateAngle = Mathf.Lerp(cameraParentRotateAngle, OrientCameraBy, Time.deltaTime * 12);
		
		// PAUZE MENU
		if(pauza){
			if(powerupShop) powerupsMenu.SetActive(true);
			else if(hasStoryMenu) storyMenu.SetActive(true);
			else if(AdditionalPowerupsMenu) AddPowerMenu.SetActive(true);
			else pauzaMenu.SetActive(true);
		
			UpdateHavePowerupsFast();
			
			Time.timeScale = 0;
			if(!blacknes.enabled) blacknes.enabled = true;
			blacknesFade = Mathf.Lerp( blacknesFade, 0.7f, Time.fixedDeltaTime * 4.0f);
			blacknes.color = new Color(0.1f, 0.1f, 0.1f, blacknesFade);
			
		}
		else if(!pauza && !finish && blacknes.enabled){
			powerupsMenu.SetActive(false);
			pauzaMenu.SetActive(false);
			storyMenu.SetActive(false);
			AddPowerMenu.SetActive(false);
			blacknesFade = Mathf.Lerp( blacknesFade, 0.0f, Time.fixedDeltaTime * 4.0f);
			blacknes.color = new Color(0.1f, 0.1f, 0.1f, blacknesFade);
			Time.timeScale = 1 - blacknesFade * 1.2f;
			if(blacknesFade <= 0) blacknes.enabled = false;
		}
		
		// FINISH MENU
		if(complitedWin && !gameOver && !throwed){
			gameOverTimer = 0;
			gameOver = true;	
		}
		else if(complited && !gameOver && !throwed){
			if(IsAllObjectsStatic()){
				gameOverTimer = 0;
				gameOver = true;
			}
		}
		
		
		
		if(finish){
			if(hasStoryMenu) Debug.Log("omg");
			finishMenu.SetActive(true);
			ImLoadingSomething = false;
			repeat2.localScale = Vector3.one;
			//Time.timeScale = 0;
			if(!blacknes.enabled) blacknes.enabled = true;
			blacknesFade = Mathf.Lerp( blacknesFade, 0.7f, Time.fixedDeltaTime * 4.0f);
			blacknes.color = new Color(0.2f, 0.2f, 0.2f, blacknesFade);
			
		}
		else if(!pauza && blacknes.enabled){
			finishMenu.SetActive(false);
			blacknesFade = Mathf.Lerp( blacknesFade, 0.0f, Time.fixedDeltaTime * 4.0f);
			blacknes.color = new Color(0.2f, 0.2f, 0.2f, blacknesFade);
			//Time.timeScale = 1 - blacknesFade * 1.428f;
			if(blacknesFade <= 0) blacknes.enabled = false;
		}
		
		if(gameOver){
			gameOverTimer += Time.deltaTime;
			if(gameOverTimer > 0.5f){
				foreach( ballIndicator pozostale in ballsGUI){
					if( pozostale.state == 1){
						pozostale.changeState(2);
						gameplay.AddBallPoints( pozostale.transform.position);
				
					}
				}
			}
			
			if(gameOverTimer > 2){
				// LOAD GAME OVER
				//LoadGameOver();
				
				if(!finish && complitedWin){
					Debug.Log("ShowGameOverWin");
					win.SetActive(true);
					lose.SetActive(false);
					next2.gameObject.SetActive(true);
					soundMGR.PlayAplauz();
				}
				else if(!finish && !complitedWin){
					Debug.Log("ShowGameOver");
					score = 0;
					win.SetActive(false);
					lose.SetActive(true);
					next2.gameObject.SetActive(false);
					/* play lose game */
				}
				
				finish = true;
			}
		}
		
		if(!throwed && Vector3.Distance( ball.position, points[corrPoint].position ) >= 0.25f) {
			Debug.Log("ballToFar");
			ball.velocity = Vector3.zero;
			RestartBall();
		}
		
		if(MoreCoinsGUIControler.aktywny){
			GuiID = -1;	
			return;
		}
		
		if(Input.touchCount>0){
			
			foreach(Touch dotyk in Input.touches){
				if(dotyk.phase == TouchPhase.Began){
					BeginGuiTouchFunction(dotyk);
				}
			}
		}
		else{
		}
		TouchOneVoid();
		#if UNITY_EDITOR
			//PCControls();
		#endif
	}
	
	
	void TouchOneVoid(){
		
		if(GuiTouch && GameplayTouchOne > -1){
			foreach(Touch dotyk in Input.touches){
				if(dotyk.fingerId == GameplayTouchOne){
					if(dotyk.phase == TouchPhase.Canceled || dotyk.phase == TouchPhase.Ended){
						if(GuiID == 0){
							pause.localScale = Vector3.one;
							if(!pauza) pauza = true;
							else return;
							soundMGR.PlayMenuClick();
						}
						else if(GuiID == 1){
							back.localScale = Vector3.one;
							pauza = false;
							soundMGR.PlayMenuClick();
						}
						else if(GuiID == 2){
							money.localScale = Vector3.one;
							if(!pauza) pauza = true;
							else return;
							powerupShop = true;
							soundMGR.PlayMenuClick();
						}
						else if(GuiID == 3){
							menu.localScale = Vector3.one;
							Time.timeScale = 1;
							loadingMenu.SetActive(true);
							Application.LoadLevel(0);
							soundMGR.PlayMenuClick();
						}
						else if(GuiID == 4){
							share.localScale = Vector3.one;
							ShowFacebook();
							soundMGR.PlayMenuClick();
						}
						else if(GuiID == 5){
							left.localScale = Vector3.one;
							soundMGR.PlayCameraChange();
							corrPoint --;
							right.gameObject.SetActive(true);
							right_bw.gameObject.SetActive(false);
							if(corrPoint <= 0){
								corrPoint = 0;
								left.gameObject.SetActive(false);
								left_bw.gameObject.SetActive(true);
							}
							RestartBall();
						}
						else if(GuiID == 6){
							left.localScale = Vector3.one;
							soundMGR.PlayCameraChange();
							corrPoint ++;
							left.gameObject.SetActive(true);
							left_bw.gameObject.SetActive(false);
							if(corrPoint >= points.Length -1){
								corrPoint = points.Length - 1;
								right.gameObject.SetActive(false);
								right_bw.gameObject.SetActive(true);
							}
							RestartBall();
						}
						else if(GuiID == 7){
							GuiID = 0;
							soundMGR.PlayMenuClick();
							gameOver = false;
							finish = false;
							menu2.localScale = Vector3.one;
									int corrStage = PlayerPrefs.GetInt("loadStage", 0);
							gameplay.LoadStage(corrStage - 1);
							Time.timeScale = 1;
						}
						else if(GuiID == 8){
							finishMenu.SetActive(false);
							hasStoryMenu = false;
							AdditionalPowerupsMenu = false;
							pauza = false;
							finish = false;
							soundMGR.PlayMenuClick();
							gameOver = false;
							finish = false;
							repeat2.localScale = Vector3.one;
							next2.localScale = new Vector3(-1, 1, 1);
							Time.timeScale = 1;
							loadingMenu.SetActive(true);
							Application.LoadLevel(0);
						}
						else if(GuiID == 9){
							Debug.Log("load Next Stage");
							finishMenu.SetActive(false);
							hasStoryMenu = false;
							AdditionalPowerupsMenu = false;
							finish = false;
							pauza = false;
							soundMGR.PlayMenuClick();
							gameOver = false;
							finish = false;
							next2.localScale = new Vector3(-1, 1, 1);
							repeat2.localScale = Vector3.one;
							LoadGameOver();
							Time.timeScale = 1;
							Debug.Log("end Load Next Stage");
						}
						
						else if(GuiID == 10){
							soundMGR.PlayMenuClick();
							changeSound.localScale = new Vector3( 0.86f, 1.0f, 1);
							changeSound.GetComponent<changeSound>().changeSoundFX();
						}
						else if(GuiID == 11){
							soundMGR.PlayMenuClick();
							changeMusic.localScale = new Vector3( 0.86f, 1.0f, 1);
							changeMusic.GetComponent<changeMusic>().changeMusicFX();
						}
						else if(GuiID == 12){ // POWERUP MENU
							powerupSelect1.localScale = new Vector3( 1.0f, 1.0f, 1);
							if(PlayerPrefs.GetInt("coins", 0) >= 20){
								PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 20);
								soundMGR.PlayMenuBuy();
								int powerupNumbers = PlayerPrefs.GetInt("powerup1", 0);
								powerupNumbers++;
								PlayerPrefs.SetInt("powerup1", powerupNumbers);
								gameplay.CheckPowerups();
								Debug.Log(PlayerPrefs.GetInt("powerup1", 0));
							}
							else{
								MoreCoinsGUIControler.EnableNoCoins();
								soundMGR.PlayMenuError();
								//coins.animation.Play();								
							}
							
							
						}
						else if(GuiID == 13){ // POWERUP MENU
							powerupSelect2.localScale = new Vector3( 1.0f, 1.0f, 1);
							if(PlayerPrefs.GetInt("coins", 0) >= 20){
								PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 20);
								soundMGR.PlayMenuBuy();
								int powerupNumbers = PlayerPrefs.GetInt("powerup2", 0);
								powerupNumbers++;
								PlayerPrefs.SetInt("powerup2", powerupNumbers);
								gameplay.CheckPowerups();
								Debug.Log(PlayerPrefs.GetInt("powerup2", 0));
							}
							else{
								MoreCoinsGUIControler.EnableNoCoins();
								soundMGR.PlayMenuError();
								//coins.animation.Play();								
							}
							
							
						}
						else if(GuiID == 14){ // POWERUP MENU
							powerupSelect3.localScale = new Vector3( 1.0f, 1.0f, 1);
							if(PlayerPrefs.GetInt("coins", 0) >= 20){
								PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 20);
								soundMGR.PlayMenuBuy();
								int powerupNumbers = PlayerPrefs.GetInt("powerup3", 0);
								powerupNumbers++;
								PlayerPrefs.SetInt("powerup3", powerupNumbers);
								gameplay.CheckPowerups();
								Debug.Log(PlayerPrefs.GetInt("powerup3", 0));
							}
							else{
								MoreCoinsGUIControler.EnableNoCoins();
								soundMGR.PlayMenuError();
								//coins.animation.Play();								
							}
						}
						else if(GuiID == 15){ // POWERUP MENU
							soundMGR.PlayMenuClick();
							powerupCancel.localScale = new Vector3( 1.0f, 1.0f, 1);
							pauza = false;
							powerupShop = false;
							
						}
						else if(GuiID == 16){ // POWERUP MENU COINS
							soundMGR.PlayMenuClick();
							MoreCoinsGUIControler.EnableMoreCoins();
							moreCoins.localScale = new Vector3( 1.0f, 1.0f, 1);
							coins.transform.localScale = new Vector3( 1.0f, 1.0f, 1);
							
						}
						else if(GuiID == 22){ // POWERUP MENU COINS
							soundMGR.PlayMenuClick();
							MoreCoinsGUIControler.EnableMoreCoins();
							moreCoins.localScale = new Vector3( 1.0f, 1.0f, 1);
							coins.transform.localScale = new Vector3( 1.0f, 1.0f, 1);
						}
						else if(GuiID == 17){ // FACEBOOK PAUSE
							soundMGR.PlayMenuClick();
							ShowFacebook();
							facebookPause.localScale = new Vector3( 0.86f, 1.0f, 1);
							
						}
						else if(GuiID == 18){ // FACEBOOK FINISH
							soundMGR.PlayMenuClick();
							ShowFacebook();
							facebookFinish.localScale = new Vector3( 0.86f, 1.0f, 1);
							
						}
						else if(GuiID == 23){ // GAMECENTER FINISH
							soundMGR.PlayMenuClick();
							Social.ShowAchievementsUI();
							GameCenter.localScale = new Vector3( 1.0f, 1.0f, 1);
							GameCenter2.localScale = new Vector3(1.0f, 1.0f, 1);
						}
						else if(GuiID == 19){ // Restart PAUSE
							soundMGR.PlayMenuClick();
								powerupsMenu.SetActive(false);
								pauzaMenu.SetActive(false);
								storyMenu.SetActive(false);
								AddPowerMenu.SetActive(false);
								blacknesFade = Mathf.Lerp( blacknesFade, 0.0f, Time.fixedDeltaTime * 4.0f);
								blacknes.color = new Color(0.1f, 0.1f, 0.1f, blacknesFade);
								Time.timeScale = 1 - blacknesFade * 1.2f;
								if(blacknesFade <= 0) blacknes.enabled = false;
							
							restartPause.localScale = new Vector3( 1.0f, 1.0f, 1);
							GuiID = 0;
							soundMGR.PlayMenuClick();
							gameOver = false;
							finish = false;
							pauza = false;
							menu2.localScale = Vector3.one;
							int corrStage = PlayerPrefs.GetInt("loadStage", 0);
							gameplay.LoadStage(corrStage - 1);
							Time.timeScale = 1;
							
						}
						else if(GuiID == 20){
							soundMGR.PlayMenuClick();
							changeball.localScale = Vector3.one;
							//ballchangerscript.ChangeThisBall();
						}
						else if(GuiID == 21){
							pauza = false;
							storyMenu.SetActive(false);
							AddPowerMenu.SetActive(false);
							hasStoryMenu = false;
							AdditionalPowerupsMenu = false;
							if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnTutorialClose && !ThisGameIsPremium){
								#if UNITY_ANDROID
								#endif
								#if UNITY_IPHONE
									//CBBinding.cacheInterstitial("default");
									//CBBinding.showInterstitial( null );
								#endif
							}
							soundMGR.PlayMenuClick();
							next2.localScale = new Vector3(-1, 1, 1);
						}
						else if(GuiID == 25){ // POWERUP MENU
							powerupSelect1Fast.localScale = Vector3.one;
							if(PlayerPrefs.GetInt("coins", 0) >= 20){
								PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 20);
								soundMGR.PlayMenuBuy();
								int powerupNumbers = PlayerPrefs.GetInt("powerup1", 0);
								powerupNumbers++;
								PlayerPrefs.SetInt("powerup1", powerupNumbers);
								gameplay.CheckPowerups();
								UpdateHavePowerupsFast();
								Debug.Log(PlayerPrefs.GetInt("powerup1", 0));
							}
							else{
								MoreCoinsGUIControler.EnableNoCoins();
								soundMGR.PlayMenuError();
								//coins.animation.Play();								
							}
							
							
						}
						else if(GuiID == 26){ // POWERUP MENU
							powerupSelect2Fast.localScale = Vector3.one;
							if(PlayerPrefs.GetInt("coins", 0) >= 20){
								PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 20);
								soundMGR.PlayMenuBuy();
								int powerupNumbers = PlayerPrefs.GetInt("powerup2", 0);
								powerupNumbers++;
								PlayerPrefs.SetInt("powerup2", powerupNumbers);
								gameplay.CheckPowerups();
								UpdateHavePowerupsFast();
								Debug.Log(PlayerPrefs.GetInt("powerup2", 0));
							}
							else{
								MoreCoinsGUIControler.EnableNoCoins();
								soundMGR.PlayMenuError();
								//coins.animation.Play();								
							}
							
							
						}
						else if(GuiID == 27){ // POWERUP MENU
							powerupSelect3Fast.localScale = Vector3.one;
							if(PlayerPrefs.GetInt("coins", 0) >= 20){
								PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 20);
								soundMGR.PlayMenuBuy();
								int powerupNumbers = PlayerPrefs.GetInt("powerup3", 0);
								powerupNumbers++;
								PlayerPrefs.SetInt("powerup3", powerupNumbers);
								gameplay.CheckPowerups();
								UpdateHavePowerupsFast();
								Debug.Log(PlayerPrefs.GetInt("powerup3", 0));
							}
							else{
								MoreCoinsGUIControler.EnableNoCoins();
								soundMGR.PlayMenuError();
								//coins.animation.Play();								
							}
						}
						else if(GuiID == 28){
							Debug.Log("Close Additional Powerups");
							pauza = false;
							storyMenu.SetActive(false);
							AddPowerMenu.SetActive(false);
							hasStoryMenu = false;
							AdditionalPowerupsMenu = false;
							ImLoadingSomething = false;
							/*if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnTutorialClose && !ThisGameIsPremium){
								#if UNITY_ANDROID
								#endif
								#if UNITY_IPHONE
									//CBBinding.cacheInterstitial("default");
									CBBinding.showInterstitial( null );
								#endif
							}*/
							soundMGR.PlayMenuClick();
							powerupCloseFast.localScale = Vector3.one;
						}
						
						GameplayTouchOne=-1;
						GuiTouch = false;
					}
					else if(dotyk.phase == TouchPhase.Moved || dotyk.phase == TouchPhase.Stationary){
						if(GuiID == 0) pause.localScale = Vector3.Slerp(pause.localScale, new Vector3(1.1f, 1.1f, 1), Time.deltaTime*25.0f);
						if(GuiID == 1) back.localScale = Vector3.Slerp(back.localScale, new Vector3(1.1f, 1.1f, 1), Time.fixedTime*25.0f);
						if(GuiID == 2) money.localScale = Vector3.Slerp(money.localScale, new Vector3(1.1f, 1.1f, 1), Time.deltaTime*25.0f);
						if(GuiID == 3) menu.localScale = Vector3.Slerp(menu.localScale, new Vector3(1.1f, 1.1f, 1), Time.fixedTime*25.0f);
						if(GuiID == 4) share.localScale = Vector3.Slerp(share.localScale, new Vector3(1.1f, 1.1f, 1), Time.deltaTime*25.0f);
						if(GuiID == 5) left.localScale = Vector3.Slerp(left.localScale, new Vector3(1.1f, 1.1f, 1), Time.deltaTime*25.0f);
						if(GuiID == 6) right.localScale = Vector3.Slerp(right.localScale, new Vector3(1.1f, 1.1f, 1), Time.deltaTime*25.0f);
						if(GuiID == 7) repeat2.localScale = Vector3.Slerp(repeat2.localScale, new Vector3(1.1f, 1.1f, 1), Time.fixedTime*25.0f); // FINISH MENU
						if(GuiID == 8) menu2.localScale = Vector3.Slerp(menu2.localScale, new Vector3(1.1f, 1.1f, 1), Time.fixedTime*25.0f); // FINISH MENU
						if(GuiID == 9) next2.localScale = Vector3.Slerp(next2.localScale, new Vector3(-1.1f, 1.1f, 1), Time.fixedTime*25.0f); // FINISH MENU
						if(GuiID == 10) changeSound.localScale = Vector3.Slerp(changeSound.localScale, new Vector3(1.0f, 1.2f, 1), Time.fixedTime*25.0f); // PAUSE MENU
						if(GuiID == 11) changeMusic.localScale = Vector3.Slerp(changeMusic.localScale, new Vector3(1.0f, 1.2f, 1), Time.fixedTime*25.0f); // PAUSE MENU
						
						if(GuiID == 12) powerupSelect1.localScale = Vector3.Slerp(powerupSelect1.localScale, new Vector3(1.1f, 1.1f, 1), Time.fixedTime*25.0f); // POWERUP MENU
						if(GuiID == 13) powerupSelect2.localScale = Vector3.Slerp(powerupSelect2.localScale, new Vector3(1.1f, 1.1f, 1), Time.fixedTime*25.0f); // POWERUP MENU
						if(GuiID == 14) powerupSelect3.localScale = Vector3.Slerp(powerupSelect3.localScale, new Vector3(1.1f, 1.1f, 1), Time.fixedTime*25.0f); // POWERUP MENU
						if(GuiID == 15) powerupCancel.localScale = Vector3.Slerp(powerupCancel.localScale, new Vector3(1.1f, 1.1f, 1), Time.fixedTime*25.0f); // POWERUP MENU
						if(GuiID == 16) moreCoins.localScale = Vector3.Slerp(moreCoins.localScale, new Vector3(1.1f, 1.1f, 1), Time.fixedTime*25.0f); // POWERUP MENU COINS
						if(GuiID == 22) coins.transform.localScale = Vector3.Slerp(coins.transform.localScale, new Vector3( 1.3f, 1.3f, 1), Time.deltaTime*25.0f);
						if(GuiID == 23) GameCenter.transform.localScale = Vector3.Slerp(GameCenter.transform.localScale, new Vector3( 1.3f, 1.3f, 1), Time.deltaTime*25.0f);
						if(GuiID == 23) GameCenter2.transform.localScale = Vector3.Slerp(GameCenter2.transform.localScale, new Vector3( 1.3f, 1.3f, 1), Time.deltaTime*25.0f);
						
						if(GuiID == 20) changeball.localScale = Vector3.Slerp(changeball.localScale, new Vector3(1.1f, 1.1f, 1), Time.deltaTime*25.0f);
						
						if(GuiID == 17) facebookPause.localScale = Vector3.Slerp(facebookPause.localScale, new Vector3(1.0f, 1.2f, 1), Time.fixedTime*25.0f);
						if(GuiID == 18) facebookFinish.localScale = Vector3.Slerp(facebookFinish.localScale, new Vector3(1.0f, 1.2f, 1), Time.fixedTime*25.0f);
						if(GuiID == 19) restartPause.localScale = Vector3.Slerp(restartPause.localScale, new Vector3(1.1f, 1.1f, 1), Time.fixedTime*25.0f);
						
						if(GuiID == 21) storyBackBtn.localScale = Vector3.Slerp(storyBackBtn.localScale, new Vector3(-1.1f, 1.1f, 1), Time.fixedTime*25.0f); // STORY MENU
						
						if(GuiID == 25) powerupSelect1Fast.localScale = Vector3.Slerp(powerupSelect1Fast.localScale, Vector3.one * 1.1f, Time.fixedTime*25.0f); // POWERUP MENU
						if(GuiID == 26) powerupSelect2Fast.localScale = Vector3.Slerp(powerupSelect2Fast.localScale, Vector3.one * 1.1f, Time.fixedTime*25.0f); // POWERUP MENU
						if(GuiID == 27) powerupSelect3Fast.localScale = Vector3.Slerp(powerupSelect3Fast.localScale, Vector3.one * 1.1f, Time.fixedTime*25.0f); // POWERUP MENU
						if(GuiID == 28) powerupCloseFast.localScale = Vector3.Slerp(powerupCloseFast.localScale, Vector3.one * 1.1f, Time.fixedTime*25.0f); // POWERUP MENU
					}
				}
			}
		}
		
		else if(GameplayTouchOne > -1){
			foreach(Touch dotyk in Input.touches){
				if(dotyk.fingerId == GameplayTouchOne){
					if(dotyk.phase == TouchPhase.Canceled || dotyk.phase == TouchPhase.Ended){
						GameplayTouchOne=-1;
						Debug.Log("touchUp");
						if(!throwed && Vector3.Distance( ball.position, points[corrPoint].position ) < 0.25f) FireBall();
						else if(throwed){
							RestartBall();
						}
					}
					else if(dotyk.phase == TouchPhase.Moved || dotyk.phase == TouchPhase.Stationary){
						
						Vector2 procentage = new Vector2(
														(dotyk.position.x/Screen.width),
														(dotyk.position.y/Screen.height)
														);
						
						procentage = new Vector2(1-procentage.x, (1 - 1 * procentage.y * 2.5f));
						
						if(procentage.x < 0) procentage = new Vector2(0, procentage.y);
						else if(procentage.x >1) procentage = new Vector2(1, procentage.y);
						
						if(procentage.y < 0) procentage = new Vector2(procentage.x, 0);
						else if(procentage.y >1) procentage = new Vector2(procentage.x, 1);
						
						if(!throwed){
														
							cel_base.rotation = Quaternion.identity;
							cel_tower.localRotation = Quaternion.Euler(new Vector3(-upRotationLimit.x - upRotationLimit.y*procentage.y ,0, 0));
							Parabola(cel_dir.forward);
							//cel_base.rotation = Quaternion.Euler(new Vector3(0, (-RotationLimit + RotationLimit*procentage.x*2)-Input.acceleration.x*12 - cameraParentRotateAngle, 0));
							cel_base.rotation = Quaternion.Euler(new Vector3(0, (-RotationLimit + RotationLimit*procentage.x*2) - cameraParentRotateAngle, 0));
							
							//cel_base.RotateAroundLocal(cel_dir.forward, Input.acceleration.x*1.8f);
						
							//Kamera.transform.rotation = Quaternion.Lerp(Kamera.transform.rotation ,  startCamRot * Quaternion.Euler(new Vector3(0, (procentage.x-0.5f)*5, 0)), Time.deltaTime * 4);
						
							camRotation = Mathf.Lerp(camRotation, (procentage.x-0.5f)*0.3f, Time.deltaTime * 16);
							Kamera.transform.rotation = startCamRot;
							Kamera.transform.RotateAround(Vector3.up, camRotation - cameraParentRotateAngle/55);
						}
					}
				}
			}
		}
		
		// BALL THROWED
		
		if(throwed){
			afterThrowTimer += Time.deltaTime;
			
			if(ball.velocity.magnitude < 4.5f){
				throwedStopTimer += Time.deltaTime;
			}
			if( throwedStopTimer > 3 ){
				RestartBall();
			}
		
		}
		
		if(!frizeCamera){
			camVelocity = (Kamera.transform.position - lastCamPos).normalized;
			lastCamPos = Kamera.transform.position;
		Kamera.transform.position = Vector3.Lerp(Kamera.transform.position, (ball.transform.position + points[corrPoint].position)/2 
																		+ new Vector3(0, startCamPos.y, 0) 
																		+ (points[corrPoint].position - center.position).normalized * 5 ,
												Time.deltaTime * 4); 
		}
		
		if(GameplayTouchOne == -1){
			/*if(ball.position.x < 2.0f) camRotation = Mathf.Lerp(camRotation, (ball.position.x - center.position.x) * 0.02f, Time.deltaTime * 4);
			else camRotation = Mathf.Lerp(camRotation, 0.04f, Time.deltaTime * 4);*/
			
			// TO DO    KAMERA MUSI OBRACAC SIE NA PILKE GDY NIE JEST NA SRODKU MAPY
			if(!frizeCamera){
				
				
				Vector3 vect = new Vector3(ball.position.x, 0, ball.position.z) - new Vector3(Kamera.transform.position.x, 0, Kamera.transform.position.z);
				vect = Quaternion.AngleAxis(90, Vector3.up) * vect;
				
				camRotation = Mathf.Lerp(camRotation, 
										(Vector3.Angle(points[corrPoint].position - center.position, vect) - 90) * -0.01f,
										 Time.deltaTime * 4);
				
				Kamera.transform.rotation = startCamRot;
				Kamera.transform.RotateAround(Vector3.up, camRotation + katWidzenia / 55 - cameraParentRotateAngle / 55);
			//Kamera.transform.parent.rotation = Quaternion.Euler(new Vector3( 0, katWidzenia, 0));
			}
			else{
			
				Kamera.transform.Translate( camVelocity * Time.deltaTime * 	movetimer * 7, Space.World);
				Debug.Log(camVelocity * movetimer * 10);
				if(movetimer > 0) movetimer -= Time.deltaTime * 1.2f;
				else movetimer = 0;
				
			}
		}
				
	}
	
	void Parabola ( Vector3 startdir) {
	Vector3 nextposition = points[corrPoint].position - cel_base.position;
	cel_base.GetComponent<LineRenderer>().SetVertexCount(60);
	
		for(int i =0; i<60; i++){
			cel_base.GetComponent<LineRenderer>().SetPosition(i, nextposition);
			nextposition += startdir*0.7f * power;
			nextposition -= Vector3.up*i*0.0125f;
			nextposition -= startdir*0.003f*i;
			
		}
		
		
	}
	
	void PCControls(){
		if(Input.GetKeyDown(KeyCode.LeftArrow)) GoToLeft();
		if(Input.GetKeyDown(KeyCode.RightArrow)) GoToRight();
		
		
		if(Input.GetMouseButtonUp(0)){
					if(!throwed && Vector3.Distance( ball.position, points[corrPoint].position ) < 1) FireBall();
						else if(throwed){
							RestartBall();	
						}
					}
			
		Vector2 procentage = new Vector2(
										(Input.mousePosition.x/Screen.width),
										(Input.mousePosition.y/Screen.height)
										);
		//Debug.Log(Screen.height - Screen.height * procentage.y * 3 + "     " + procentage.y);
		
		procentage = new Vector2(1-procentage.x, (1 - 1 * procentage.y * 2.5f));
		
		if(procentage.x < 0) procentage = new Vector2(0, procentage.y);
		else if(procentage.x >1) procentage = new Vector2(1, procentage.y);
		
		if(procentage.y < 0) procentage = new Vector2(procentage.x, 0);
		else if(procentage.y >1) procentage = new Vector2(procentage.x, 1);
		
		if(!throwed){
										
			cel_base.rotation = Quaternion.identity;
			cel_tower.localRotation = Quaternion.Euler(new Vector3(-upRotationLimit.x - upRotationLimit.y*procentage.y ,0, 0));
			Parabola(cel_dir.forward);
			cel_base.rotation = Quaternion.Euler(new Vector3(0, (-RotationLimit + RotationLimit*procentage.x*2)-0 - cameraParentRotateAngle, 0));
			
			cel_base.RotateAroundLocal(cel_dir.forward, 0);
		
		//Kamera.transform.rotation = Quaternion.Lerp(Kamera.transform.rotation ,  startCamRot * Quaternion.Euler(new Vector3(0, (procentage.x-0.5f)*5, 0)), Time.deltaTime * 4);
		
			camRotation = Mathf.Lerp(camRotation, (procentage.x-0.5f)*0.3f, Time.deltaTime * 16);
			Kamera.transform.rotation = startCamRot;
			Kamera.transform.RotateAround(Vector3.up, camRotation - cameraParentRotateAngle/55);
		}
		
		if(Input.GetKeyDown(KeyCode.KeypadPlus)){
			int corrStage = PlayerPrefs.GetInt("loadStage", 0);
						corrStage++;
			if(corrStage > 30){
				corrStage = 30;
			}
			PlayerPrefs.SetInt("loadStage", corrStage);
			Debug.Log(corrStage);
			gameplay.LoadStage(corrStage - 1);
			
		}
		else if(Input.GetKeyDown(KeyCode.KeypadMinus)){
			int corrStage = PlayerPrefs.GetInt("loadStage", 0);
					corrStage --;
			if(corrStage < 1){
				corrStage = 1;				
			}
			PlayerPrefs.SetInt("loadStage", corrStage);
			Debug.Log(corrStage);
			gameplay.LoadStage(corrStage - 1);
			
		}


	}
	
	//Fire
	void FireBall () {
		if(ballsAvaible <= 0) return;
		PlayerPrefs.SetInt("BallKicked", (PlayerPrefs.GetInt("BallKicked", 0) + 1 ));
		Debug.Log("-----------------" + PlayerPrefs.GetInt("BallKicked", 0));
		//AddAcheavementBall();
		afterThrowTimer = 0;
	frizeCamera = false;
		RemoveBall();
	throwed = true;
	throwedStopTimer = 0;
		soundMGR.PlayKick();
		ball.transform.position = points[corrPoint].position;
		ball.velocity = Vector3.zero;
		ball.AddForce(cel_dir.forward * powerForceMultipler * 300 * power, ForceMode.Impulse);
		ball.GetComponent<ballphysics>().podFizyk = true;
		ball.GetComponent<ballphysics>().podTimeStart = Time.time-1.0f;
		ball.GetComponent<ballphysics>().podkrecenie = new Vector3(0, 0, 0);
		
		
	}
	
	public void RestartBall(){
		//if(!IsAllObjectsStatic()) return;
		
		if(ball.rigidbody.velocity.magnitude > 0.5f) return;
		if(ballsAvaible == 0){
			ballPivot.SetActive(false);
			ballBlob.SetActive(false);
			ballLine.enabled = false;
		}
		else{
			ballPivot.SetActive(true);
			ballBlob.SetActive(true);
			ballLine.enabled = true;
		}
		afterThrowTimer = 0;
		throwed = false;
		frizeCamera = false;
		ball.transform.position = points[corrPoint].position;
		ball.transform.position += Vector3.up * ( gameplay.correntBallPhisic.gameObject.GetComponent<SphereCollider>().radius - 0.5f);
		cel_base.position = points[corrPoint].position;
		ball.velocity = Vector3.zero;
		ball.angularVelocity = Vector3.zero;
		
			cel_base.rotation = Quaternion.LookRotation(center.position -  points[corrPoint].position, Vector3.up);
			cel_tower.localRotation = Quaternion.Euler(new Vector3(-upRotationLimit.x - upRotationLimit.y * 0.5f ,0, 0));
			Parabola(cel_dir.forward);
			cel_base.rotation = Quaternion.Euler(new Vector3(0, (-RotationLimit + RotationLimit * 0.5f * 2), 0));
	}
	
	public void RestartBallTapped(){
		Vector3 orgBallPos = ball.transform.position;
		Quaternion orgBallRot = ball.transform.rotation;
		Vector3 orgBalVel = ball.velocity;
		Vector3 orgBalAngVel = ball.angularVelocity;
		afterThrowTimer = 0;
		if(ballsAvaible == 0){
			ballPivot.SetActive(false);
			ballBlob.SetActive(false);
			ballLine.enabled =  false;
		}
		else{
			ballPivot.SetActive(true);
			ballBlob.SetActive(true);
			ballLine.enabled = true;
		}
		
		throwed = false;
		frizeCamera = false;
		ball.transform.position = points[corrPoint].position;
		ball.transform.position += Vector3.up * ( gameplay.correntBallPhisic.gameObject.GetComponent<SphereCollider>().radius - 0.5f);
		cel_base.position = points[corrPoint].position;
		ball.velocity = Vector3.zero;
		ball.angularVelocity = Vector3.zero;
		
			cel_base.rotation = Quaternion.LookRotation(center.position -  points[corrPoint].position, Vector3.up);
			cel_tower.localRotation = Quaternion.Euler(new Vector3(-upRotationLimit.x - upRotationLimit.y * 0.5f ,0, 0));
			Parabola(cel_dir.forward);
			cel_base.rotation = Quaternion.Euler(new Vector3(0, (-RotationLimit + RotationLimit * 0.5f * 2), 0));
		
		
		GameObject AdBal = Instantiate( AdditionalBalls[PlayerPrefs.GetInt("SelectedBall", 0)], orgBallPos, orgBallRot) as GameObject;
		AdBal.rigidbody.velocity = orgBalVel;
		AdBal.rigidbody.angularVelocity = orgBalAngVel;
	}
	
	public void CheckHorizontalMoveButtons(){
		if(corrPoint > 0){
			left.gameObject.SetActive(true);
			left_bw.gameObject.SetActive(false);
		}
		else{
			left.gameObject.SetActive(false);
			left_bw.gameObject.SetActive(true);
		}
		
		if(corrPoint < points.Length-1 ){
			right.gameObject.SetActive(true);
			right_bw.gameObject.SetActive(false);
		}
		else{
			right.gameObject.SetActive(false);
			right_bw.gameObject.SetActive(true);
		}
		
	}
	
	
	private void RemoveBall(){
	
		ballsAvaible --;
		if(ballsAvaible <= 0){
			//gameOverTimer = 0;
			//gameOver = true;
			complited = true;
		}
		
		ballsGUI[ ballsAvaible ].changeState(2);
		
		
	}
	
	private	void LoadGameOver (){
		if(ImLoadingSomething){
			Debug.Log("Cancel Load Game Over");
			return;
		}
		Debug.Log("Load Game Over");
		ImLoadingSomething = true;
		pauza = false;
		finishMenu.SetActive(false);
		int corrStage = PlayerPrefs.GetInt("loadStage", 0);
		int corrLevel = PlayerPrefs.GetInt("loadLevel", 0);
		corrStage++;
		Debug.LogWarning(corrStage + "     " + PlayerPrefs.GetInt("loadLevel", 0));
		if(corrStage < 30 && (corrLevel == 1|| corrLevel == 2 || corrLevel == 0) && ThisGameIsPremium){
			Debug.LogWarning("load1");
			PlayerPrefs.SetInt("loadStage", corrStage);
		}
		else if(corrStage < 16 && (corrLevel == 1|| corrLevel == 2 || corrLevel == 0) && !ThisGameIsPremium){
			Debug.LogWarning("load1");
			PlayerPrefs.SetInt("loadStage", corrStage);
		}
		else if(corrStage < 16 && (PlayerPrefs.GetInt("loadLevel", 0) >= 3)){
			Debug.LogWarning("load2");
			PlayerPrefs.SetInt("loadStage", corrStage);
		}
		else{
			bool nextIsLocked = false;
			Debug.Log("Level loaded" + PlayerPrefs.GetInt("loadLevel", 0));
			Debug.Log(PlayerPrefs.GetInt("Level2_unlocked", 0));
			Debug.Log(PlayerPrefs.GetInt("Level3_unlocked", 0));
			Debug.Log(PlayerPrefs.GetInt("Level4_unlocked", 0));
			Debug.Log(PlayerPrefs.GetInt("Level5_unlocked", 0));
			
			if((PlayerPrefs.GetInt("loadLevel", 0) == 0 || PlayerPrefs.GetInt("loadLevel", 0) == 1) && PlayerPrefs.GetInt("Level2_unlocked", 0) == 0) nextIsLocked = true;
			if(PlayerPrefs.GetInt("loadLevel", 0) == 2 && PlayerPrefs.GetInt("Level3_unlocked", 0) == 0) nextIsLocked = true;
			if(PlayerPrefs.GetInt("loadLevel", 0) == 3 && PlayerPrefs.GetInt("Level4_unlocked", 0) == 0) nextIsLocked = true;
			if(PlayerPrefs.GetInt("loadLevel", 0) == 4 && PlayerPrefs.GetInt("Level5_unlocked", 0) == 0) nextIsLocked = true;
			
			if(PlayerPrefs.GetInt("loadLevel", 0) >= 5){
				Debug.LogWarning("load3");
				loadingMenu.SetActive(true);
				Application.LoadLevel(0);
				
			}
			else if(PlayerPrefs.GetInt("loadLevel", 0) == 0){
				Debug.LogWarning("load4");
				PlayerPrefs.SetInt("loadLevel", 2 );
				PlayerPrefs.SetInt("loadStage", 1);
				PlayerPrefs.SetInt("Story", 1);
				Application.LoadLevel(1);	
			}
			else if(!nextIsLocked){
				Debug.LogWarning("load5");
				PlayerPrefs.SetInt("loadLevel", (PlayerPrefs.GetInt("loadLevel", 0)+1) );
				PlayerPrefs.SetInt("loadStage", 1);
				PlayerPrefs.SetInt("Story", 1);
				Application.LoadLevel(1);	
				Debug.Log("ABCD:  " + PlayerPrefs.GetInt("loadLevel", 0));
			}
			else{
				loadingMenu.SetActive(true);
				Application.LoadLevel(0);
			}
		}
		
		gameplay.LoadStage(corrStage - 1);
	}
	
	private void GoToLeft(){
		if(corrPoint <=0 )return;
		left.localScale = Vector3.one;
		corrPoint --;
		right.gameObject.SetActive(true);
		right_bw.gameObject.SetActive(false);
		if(corrPoint <= 0){
			corrPoint = 0;
			left.gameObject.SetActive(false);
			left_bw.gameObject.SetActive(true);
		}
		RestartBall();
		
	}
	
	private void GoToRight(){
		if(corrPoint >= points.Length -1)return;
			left.localScale = Vector3.one;
			corrPoint ++;
			left.gameObject.SetActive(true);
			left_bw.gameObject.SetActive(false);
			if(corrPoint >= points.Length -1){
				corrPoint = points.Length - 1;
				right.gameObject.SetActive(false);
				right_bw.gameObject.SetActive(true);
			}
			RestartBall();	
		
	}
	
	private void BeginGuiTouchFunction (Touch dotyk){
		if(GameplayTouchOne > -1) return;
		
		Ray ray = guiCamera.ScreenPointToRay(dotyk.position);
		RaycastHit hit;
		
		Ray ray2 = OverallCamera.ScreenPointToRay(dotyk.position);
		RaycastHit hit2;
		// OverallMenu
		if(Physics.Raycast(ray2, out hit2, 100) && (finishMenu.activeInHierarchy || pauzaMenu.activeInHierarchy || powerupsMenu.activeInHierarchy || storyMenu.activeInHierarchy || AddPowerMenu.activeInHierarchy)){
			if(hit2.collider.gameObject == back.gameObject){
				GuiTouch = true;
				GuiID = 1;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == menu.gameObject){
				GuiTouch = true;
				GuiID = 3;
				GameplayTouchOne = dotyk.fingerId;
				
			}
			else if(hit2.collider.gameObject == changeSound.gameObject ){  // PAUSE MENU
				GuiTouch = true;
				GuiID = 10;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == changeMusic.gameObject ){ // PAUSE MENU
				GuiTouch = true;
				GuiID = 11;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == facebookPause.gameObject ){ // PAUSE MENU
				GuiTouch = true;
				GuiID = 17;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == restartPause.gameObject ){ // PAUSE MENU
				GuiTouch = true;
				GuiID = 19;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == repeat2.gameObject ){ // FINISH MENU
				GuiTouch = true;
				GuiID = 7;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == menu2.gameObject ){  // FINISH MENU
				GuiTouch = true;
				GuiID = 8;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == next2.gameObject){ // FINISH MENU
				GuiTouch = true;
				GuiID = 9;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == facebookFinish.gameObject){ // FINISH MENU
				GuiTouch = true;
				GuiID = 18;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject ==  GameCenter.gameObject){ // FINISH MENU
				GuiTouch = true;
				GuiID = 23;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject ==  GameCenter2.gameObject){ // FINISH MENU
				GuiTouch = true;
				GuiID = 23;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == storyBackBtn.gameObject){ // STORY MENU
				GuiTouch = true;
				GuiID = 21;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == powerupSelect1.gameObject && GameplayTouchOne<0 ){  // POWERUP MENU  1
				GuiTouch = true;
				GuiID = 12;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == powerupSelect2.gameObject && GameplayTouchOne<0 ){ // POWERUP MENU  2
				GuiTouch = true;
				GuiID = 13;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == powerupSelect3.gameObject && GameplayTouchOne<0 ){  // POWERUP MENU  3
				GuiTouch = true;
				GuiID = 14;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == powerupCancel.gameObject && GameplayTouchOne<0 ){ // POWERUP MENU  back
				GuiTouch = true;
				GuiID = 15;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == moreCoins.gameObject && GameplayTouchOne<0 ){ // POWERUP MENU  coins
				GuiTouch = true;
				GuiID = 16;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == coins && GameplayTouchOne<0 ){ // POWERUP MENU  coins
				GuiTouch = true;
				GuiID = 22;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == powerupSelect1Fast.gameObject && GameplayTouchOne<0 ){  // POWERUP MENU2  1
				GuiTouch = true;
				GuiID = 25;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == powerupSelect2Fast.gameObject && GameplayTouchOne<0 ){ // POWERUP MENU2  2
				GuiTouch = true;
				GuiID = 26;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == powerupSelect3Fast.gameObject && GameplayTouchOne<0 ){  // POWERUP MENU2  3
				GuiTouch = true;
				GuiID = 27;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit2.collider.gameObject == powerupCloseFast.gameObject && GameplayTouchOne<0 ){  // POWERUP MENU2  Close
				GuiTouch = true;
				GuiID = 28;
				GameplayTouchOne = dotyk.fingerId;
			}
			
		}
		else if (Physics.Raycast(ray, out hit, 100) && !finishMenu.activeInHierarchy && !pauzaMenu.activeInHierarchy && !powerupsMenu.activeInHierarchy && !storyMenu.activeInHierarchy && !AddPowerMenu.activeInHierarchy){
			if(hit.collider.gameObject == pause.gameObject&& !pauza && !gameOver){
				GuiTouch = true;
				GuiID = 0;
				GameplayTouchOne = dotyk.fingerId;
			}

			else if(hit.collider.gameObject == money.gameObject  && !pauza && !gameOver){
				GuiTouch = true;
				GuiID = 2;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit.collider.gameObject == share.gameObject  && !pauza && !gameOver){
				GuiTouch = true;
				GuiID = 4;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit.collider.gameObject == left.gameObject  && !pauza && !gameOver && !throwed){
				GuiTouch = true;
				GuiID = 5;
				GameplayTouchOne = dotyk.fingerId;
			}
			else if(hit.collider.gameObject == right.gameObject  && !pauza && !gameOver && !throwed){
				GuiTouch = true;
				GuiID = 6;
				GameplayTouchOne = dotyk.fingerId;
			}

			else if(hit.collider.gameObject == changeball.gameObject && GameplayTouchOne<0){
				GuiTouch = true;
				GuiID = 20;
				GameplayTouchOne = dotyk.fingerId;
			}						
		}
		else{
			if(GameplayTouchOne < 0  && !pauza && !gameOver){
				if(frizeCamera || afterThrowTimer > 0.8f){
					RestartBallTapped();
					Debug.Log("freze camera cancel  " + afterThrowTimer);	
					afterThrowTimer = 0;
				}
				else{
					GuiTouch = false;
					GameplayTouchOne = dotyk.fingerId;
				}
			}
		}
					
	}
	
	public bool IsAllObjectsStatic(){
		Rigidbody[] ilosc =  GameObject.FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
		
		bool  isAllStatic = true;
		
		
		foreach(Rigidbody body in ilosc){
			if(body){
				//if( body.IsSleeping() == false && body.isKinematic == false) 	isAllStatic = false;
				if(body.gameObject.tag == "Player" && body.velocity.magnitude > 10.0f){
					isAllStatic = false;
					Debug.Log("Ball is static");	
				}
				else if(body.velocity.magnitude > 0.6f && body.transform.position.y > -0.7f && body.transform.position.y < 20  && body.isKinematic == false && body.gameObject.tag != "moving") isAllStatic = false;
			}
		}
		Debug.Log(isAllStatic);
		return isAllStatic ;
	}
	
	private void ShowFacebook(){
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
		}				
	}
	void AuthCallback(FBResult result) {
	    if(FB.IsLoggedIn) {
	        Debug.Log(FB.UserId);
	    } else {
	        Debug.Log("User cancelled login");
	    }
	}
	
	public void AddAcheavementBall(){
		int procentComplited = 0;
		int ballsMaxNumber = 0;	
	
		ballsMaxNumber = 10;
		procentComplited = (int)((PlayerPrefs.GetInt("BallKicked", 0) / ballsMaxNumber)*100);
		if(procentComplited > ballsMaxNumber) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.kick10balls", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement1 " + procentComplited);
        });
		
		
		ballsMaxNumber = 60;
		procentComplited = (int)((PlayerPrefs.GetInt("BallKicked", 0) / ballsMaxNumber)*100);
		if(procentComplited > ballsMaxNumber) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.kick60balls", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement2 " + procentComplited);
        });
		
		ballsMaxNumber = 90;
		procentComplited = (int)((PlayerPrefs.GetInt("BallKicked", 0) / ballsMaxNumber)*100);
		if(procentComplited > ballsMaxNumber) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.kick90balls", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement3 " + procentComplited);
        });
		
		ballsMaxNumber = 120;
		procentComplited = (int)((PlayerPrefs.GetInt("BallKicked", 0) / ballsMaxNumber)*100);
		if(procentComplited > ballsMaxNumber) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.kick120balls", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement4 " + procentComplited );
        });
		
		ballsMaxNumber = 250;
		procentComplited = (int)((PlayerPrefs.GetInt("BallKicked", 0) / ballsMaxNumber)*100);
		if(procentComplited > ballsMaxNumber) procentComplited = 100;
		Social.ReportProgress ("grp.immanitas.KickTheBall.kick250balls", procentComplited, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement5 " +procentComplited  );
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

        /*// You can also call into the functions like this
        Social.ReportProgress ("grp.immanitas.KickTheBall.win3stages", 1, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement");
        });*/
    }
	
	public	void UpdateHavePowerupsFast(){
		if(gameplay.powerup1Active) powerupsFastActive[0].SetActive(true);
		else powerupsFastActive[0].SetActive(false);
		
		if(gameplay.powerup2Active) powerupsFastActive[1].SetActive(true);
		else powerupsFastActive[1].SetActive(false);
		
		if(gameplay.powerup3Active) powerupsFastActive[2].SetActive(true);
		else powerupsFastActive[2].SetActive(false);
		
		powerupsFastHave[0].Text = "x" + PlayerPrefs.GetInt("powerup1", 0);	
		powerupsFastHave[1].Text = "x" + PlayerPrefs.GetInt("powerup2", 0);	
		powerupsFastHave[2].Text = "x" + PlayerPrefs.GetInt("powerup3", 0);	
		gameplay.CheckPowerups();
	}
	
	void OnApplicationPause(bool _bool)
    {
	   	if(_bool)
	    {
			if(!pauza && !finishMenu.activeInHierarchy && !pauzaMenu.activeInHierarchy && !powerupsMenu.activeInHierarchy && !storyMenu.activeInHierarchy && !AddPowerMenu.activeInHierarchy){
				pauza = true;
				pauzaMenu.SetActive(true);
	    		print("paused");
				Time.timeScale = 0;
				if(!blacknes.enabled) blacknes.enabled = true;
				blacknesFade = 0.7f;
				blacknes.color = new Color(0.1f, 0.1f, 0.1f, blacknesFade);
			}
	    }
	    else
	    {
	   		print("resumed");
	    }
    }
}
