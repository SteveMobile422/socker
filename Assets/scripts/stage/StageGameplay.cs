using UnityEngine;
using System.Collections;
using Chartboost;

public class StageGameplay : MonoBehaviour {
	
	
	// STAGES
	public			GameObject[]	stagesList;
	public			GameObject		playableStage;
	
	// GAMEPLAY INFO
	public			float			time;
	
	public			float			MaxHight;
	public			float			MaxAngle;
	public			float			MaxPower;
	
	
	// PRIVATE DATA
	public			controller		kontroler;
	public			GameObject[]	guiBallsFrames;
	
	// ELEMENTS
	public			GameObject		timer;
	public			Transform		timerBar;
	private			float			currenttimer;
	
		
	public			int				changeStage;
	
	// POINTS
	public			Camera			Kamera;
	public			Camera			guiCamera;
	public			GameObject		point0;
	public			GameObject		point1;
	public			GameObject		point2;
	public			GameObject		point3;
	public			GameObject		point4;
	
	// GAME CONDITIONS
	public			GameObject		GUI_bidons;
	public			BitmapMeshText	bidonsText;
	
	public			GameObject		GUI_flags;
	public			BitmapMeshText	flagsText;
	
	public			GameObject		GUI_medal;
	public			BitmapMeshText	medalText;
	
	public			GameObject		GUI_puchar;
	public			BitmapMeshText	pucharText;
	
	public			GameObject		GUI_icecream;
	public			BitmapMeshText	icecreamText;
	
	private			stageData		corrStageData;
	

	// STORY
	public			Transform		storyMenu;
	public			Transform		storyBackButton;
	private			GameObject		storyScreenMemory;
	
	
	// POWERUPS
	public			bool			powerup1Active;
	public			bool			powerup2Active;
	public			bool			powerup3Active;
	
	private			Vector3			startBallScale;
	public			ballphysics		correntBallPhisic;
	public			BitmapMeshText	powerup1number;
	public			BitmapMeshText	powerup2number;
	public			BitmapMeshText	powerup3number;
	
	public			GameObject		powerup1HUD;
	public			GameObject		powerup2HUD;
	public			GameObject		powerup3HUD;
	
	public			GameObject		powerup1HUDActive;
	public			GameObject		powerup2HUDActive;
	public			GameObject		powerup3HUDActive;
	
	public			int				scoreMultipler;
	public			InteractiveConsoleHiden			facebookPlugin;
		public			int				lastPlayedStage =  -10;


	void Awake(){
		PlayerPrefs.SetInt("addNumer", 0);
		if(!kontroler.ThisGameIsPremium){
			CBBinding.init ( "52489f5517ba47ec0a000011" , "fc9203bf0d4805d9e5e62a0196e421c7f82a3766");
			
		}
	}

	// Use this for initialization   -44.47495    -41.29734
	void Start () {
				facebookPlugin.CallFBInit();
				//PlayerPrefs.SetInt("loadStage", 2);
		//CBBinding.cacheInterstitial( "default" );
		
		timerBar.localPosition = new Vector3(0, 349, 0);
		currenttimer = time;
		
		//PlayerPrefs.SetInt("loadLevel", corrLevel);
		int corrStage = PlayerPrefs.GetInt("loadStage", 1);
		
		Debug.Log(corrStage);
		
		if(corrStage < 1){
			PlayerPrefs.SetInt("loadStage", 1);
			corrStage = PlayerPrefs.GetInt("loadStage", 1);	
		}
		else if(corrStage > 30){
			PlayerPrefs.SetInt("loadStage", 30);
			corrStage = PlayerPrefs.GetInt("loadStage", 30);
		}
		
		
		LoadStage(corrStage - 1 );
		
		if(corrStageData) if(!corrStageData.storyScreen){
			if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnGameAwake && !kontroler.ThisGameIsPremium){
				#if UNITY_ANDROID
					//kontroler.AdBuddiz.ShowAnAd();
					kontroler.reklama1.SendMessage("RequestPlayHavenContent");   // ToRemove;
				#endif
				#if UNITY_IPHONE
					//kontroler.reklama1.SendMessage("RequestPlayHavenContent");
					//CBBinding.cacheInterstitial("default");
				//	CBBinding.showInterstitial( null );
				#endif	
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if(CBBinding.hasCachedInterstitial("default") ){
			CBBinding.showInterstitial( "default" );
		}
		*/
		
		if(time > 0){
			timer.SetActive(true);
			currenttimer -= Time.deltaTime;
			
			timerBar.localPosition = new Vector3(0, 339 * (currenttimer / time) + 10, 0);
			if(currenttimer <=0 ) currenttimer = time;
		}
		else{
			timer.SetActive(false);
			
		}
		
		if(playableStage) kontroler.complitedWin = corrStageData.complited;
		
		// GAME CONDITIONS
		if( corrStageData.bidon ) {
			GUI_bidons.SetActive(true);
			bidonsText.Text = "" + corrStageData.colected + " / " + corrStageData.ObjectToFall.Length;
			GUI_flags.SetActive(false);
			GUI_medal.SetActive(false);
			GUI_puchar.SetActive(false);
			GUI_icecream.SetActive(false);
		}
		else if( corrStageData.flag ) {
			GUI_flags.SetActive(true);
			flagsText.Text = "" + corrStageData.colected + " / " + corrStageData.ObjectToFall.Length;
			GUI_bidons.SetActive(false);
			GUI_medal.SetActive(false);
			GUI_puchar.SetActive(false);
			GUI_icecream.SetActive(false);
		}
		else if( corrStageData.medal ) {
			GUI_medal.SetActive(true);
			medalText.Text = "" + corrStageData.colected + " / " + corrStageData.ObjectToFall.Length;
			GUI_flags.SetActive(false);
			GUI_bidons.SetActive(false);
			GUI_puchar.SetActive(false);
			GUI_icecream.SetActive(false);
		}
		else if( corrStageData.puchar ) {
			GUI_puchar.SetActive(true);
			pucharText.Text = "" + corrStageData.colected + " / " + corrStageData.ObjectToFall.Length;
			GUI_flags.SetActive(false);
			GUI_medal.SetActive(false);
			GUI_bidons.SetActive(false);
			GUI_icecream.SetActive(false);
		}
		else if( corrStageData.icecream ) {
			GUI_icecream.SetActive(true);
			icecreamText.Text = "" + corrStageData.colected + " / " + corrStageData.ObjectToFall.Length;
			GUI_flags.SetActive(false);
			GUI_medal.SetActive(false);
			GUI_puchar.SetActive(false);
			GUI_bidons.SetActive(false);
		}
		else{
			GUI_bidons.SetActive(false);
			GUI_flags.SetActive(false);
			GUI_medal.SetActive(false);
			GUI_puchar.SetActive(false);
			GUI_icecream.SetActive(false);
		}
		
		
	}
	
	public	void LoadStage(int nr){
		PlayerPrefs.SetInt("FastPowerups", PlayerPrefs.GetInt("FastPowerups", 0) - 1);
		Debug.Log("fastPowerupsCounter: " + PlayerPrefs.GetInt("FastPowerups", 0));
		
							GameObject oldBalls = GameObject.FindGameObjectWithTag("spawnedBalls");
		if(oldBalls) Destroy(oldBalls);
				 oldBalls = GameObject.FindGameObjectWithTag("spawnedBalls");
		if(oldBalls) Destroy(oldBalls);
				oldBalls = GameObject.FindGameObjectWithTag("spawnedBalls");
		if(oldBalls) Destroy(oldBalls);
		
		// Powerups;
		RemovePowerups();
		CheckPowerups();
		
		
		GameObject.FindGameObjectWithTag("soundmanager").GetComponent<soundManager>().RemoveFanCounter();
		
		if(changeStage > -1) nr = changeStage;
		
		kontroler.gameOver = false;
		kontroler.gameOverTimer = 0;
		
		if(nr >= 30){
			Debug.LogWarning("More than 30 stages");
			return;
		}
		if(playableStage) Destroy(playableStage);
		playableStage = null;
		if(nr < 0) nr = 0;
		playableStage = (GameObject)Instantiate(stagesList[ nr ], Vector3.zero, Quaternion.identity) as GameObject;
		
		corrStageData = playableStage.GetComponent<stageData>();
		
		kontroler.corrPoint = corrStageData.FirstPosition;
		kontroler.points = corrStageData.positions;
		kontroler.center = corrStageData.center;
		kontroler.ballsAvaible = corrStageData.ballsNumber;
		
		foreach(ballIndicator guiball in kontroler.ballsGUI){
			guiball.changeState(0);
		}
		for(int i = 0; i < corrStageData.ballsNumber; i++){
			kontroler.ballsGUI[i].changeState(1);
			
		}
		
		kontroler.RestartBall();
		kontroler.CheckHorizontalMoveButtons();
		kontroler.complited = false;
		kontroler.finish = false;
		kontroler.score = 0;
		kontroler.RotationLimit = corrStageData.maxHorizontal;
		kontroler.upRotationLimit = new Vector2(2, corrStageData.maxVertical);
		kontroler.power = corrStageData.power;
		
		if(kontroler.finishMenu.activeInHierarchy) kontroler.finishMenu.SetActive(false);
		
		// CREATE STORY SCREEN
		if(corrStageData.storyScreen && lastPlayedStage != nr){
			kontroler.pauza = true;	
			kontroler.powerupShop = false;
			kontroler.hasStoryMenu = true;
			kontroler.AdditionalPowerupsMenu = false;
			
			storyScreenMemory = Instantiate(corrStageData.storyScreen) as GameObject;
			storyScreenMemory.transform.parent = storyMenu;
			storyScreenMemory.transform.localPosition = Vector3.zero;
			storyBackButton.position = storyScreenMemory.GetComponent<tutorialScreenData>().button.position;
			storyScreenMemory.GetComponent<tutorialScreenData>().button.gameObject.SetActive(false);
		}
		//CREATE MorePowerups SCREEN
		else if(!corrStageData.storyScreen && PlayerPrefs.GetInt("FastPowerups", 0) <= 0){
			PlayerPrefs.SetInt("FastPowerups", 3);
			kontroler.pauza = true;	
			kontroler.powerupShop = false;
			kontroler.hasStoryMenu = false;
			kontroler.AdditionalPowerupsMenu = true;
		}
		else if(storyScreenMemory) Destroy(storyScreenMemory);
				lastPlayedStage = nr;
		
		kontroler.RestartBallTapped();
		kontroler.frizeCamera = false;
		
			oldBalls = GameObject.FindGameObjectWithTag("spawnedBalls");
		if(oldBalls) Destroy(oldBalls);
				 oldBalls = GameObject.FindGameObjectWithTag("spawnedBalls");
		if(oldBalls) Destroy(oldBalls);
				oldBalls = GameObject.FindGameObjectWithTag("spawnedBalls");
		if(oldBalls) Destroy(oldBalls);
	}
	
	
	public	void AddPoints (Vector3 pozycja, int punkty){
		Vector3 pozycja_fin = Kamera.WorldToScreenPoint(pozycja);
		pozycja_fin = guiCamera.ScreenToWorldPoint(new Vector3( pozycja_fin.x, pozycja_fin.y, 140));
		int dodajPunkty = 0;
		if(punkty > 40){
			dodajPunkty = 1000;
			Instantiate(point4, pozycja_fin, Quaternion.identity);
		}
		else if(punkty > 20){
			dodajPunkty = 500;
			Instantiate(point3, pozycja_fin, Quaternion.identity);
		}
		else if(punkty > 10){
			dodajPunkty = 250;
			Instantiate(point2, pozycja_fin, Quaternion.identity);
		}
		else if(punkty > 5){
			dodajPunkty = 100;
			Instantiate(point1, pozycja_fin, Quaternion.identity);
		}
		else if(punkty > 0){
			dodajPunkty = 20;
			Instantiate(point0, pozycja_fin, Quaternion.identity);
		}
		
		
		
		Debug.Log("add some points: " + dodajPunkty);
		kontroler.score += dodajPunkty * scoreMultipler;
	}
	
	public	void AddBidon (Vector3 pozycja){
		Vector3 pozycja_fin = Kamera.WorldToScreenPoint(pozycja);
		pozycja_fin = guiCamera.ScreenToWorldPoint(new Vector3( pozycja_fin.x, pozycja_fin.y, 140));

			Instantiate(point4, pozycja_fin, Quaternion.identity);
			int dodajPunkty = 1000;
		
		Debug.Log("Colected Bidon: " + dodajPunkty);
		kontroler.score += dodajPunkty * scoreMultipler;
	}
	
	public	void AddBallPoints (Vector3 pozycja){
		Vector3 pozycja_fin = Kamera.WorldToScreenPoint(pozycja);
		pozycja_fin = guiCamera.ScreenToWorldPoint(new Vector3( pozycja_fin.x, pozycja_fin.y, 140));
		pozycja_fin = new Vector3(pozycja.x, pozycja.y, 20);
			
			Instantiate(point4, pozycja_fin, Quaternion.identity);
			int dodajPunkty = 1000;
		
		Debug.Log("Colected Ball: " + dodajPunkty);
		kontroler.score += dodajPunkty;
	}
	
	public void CheckPowerups(){
		powerup1number.Text = "x" + PlayerPrefs.GetInt("powerup1", 0);
		powerup2number.Text = "x" + PlayerPrefs.GetInt("powerup2", 0);
		powerup3number.Text = "x" + PlayerPrefs.GetInt("powerup3", 0);
		
		int powerupnumbers = 0;
		 if( PlayerPrefs.GetInt("powerup1", 0) > 0 && !powerup1Active){
			powerupnumbers = PlayerPrefs.GetInt("powerup1", 0);
			powerupnumbers--;
			PlayerPrefs.SetInt("powerup1", powerupnumbers);
	
			correntBallPhisic.ball.localScale = Vector3.one * 1.5f;
			correntBallPhisic.gameObject.rigidbody.mass = 60;
			correntBallPhisic.gameObject.GetComponent<SphereCollider>().radius = 0.75f;
			kontroler.powerForceMultipler = 6.5f;
			powerup1number.Text = "x" + PlayerPrefs.GetInt("powerup1", 0);
			powerup1Active = true;
			powerup1HUD.SetActive(true);
			powerup1HUDActive.SetActive(true);
		}
		else if(!powerup1Active){
			correntBallPhisic.ball.localScale = Vector3.one;
			correntBallPhisic.gameObject.rigidbody.mass = 10;
			kontroler.powerForceMultipler = 1;
			powerup1number.Text = "x0";
			powerup1Active = false;
			powerup1HUD.SetActive(false);
			powerup1HUDActive.SetActive(false);
		}
		
		powerupnumbers = 0;
		if( PlayerPrefs.GetInt("powerup2", 0) > 0 && !powerup2Active){
			powerupnumbers = PlayerPrefs.GetInt("powerup2", 0);
			powerupnumbers--;
			PlayerPrefs.SetInt("powerup2", powerupnumbers);
			
			powerup2number.Text = "x" + PlayerPrefs.GetInt("powerup2", 0);
			scoreMultipler = 2;
			powerup2Active = true;
			powerup2HUD.SetActive(true);
			powerup2HUDActive.SetActive(true);
		}
		else if(!powerup2Active){

			powerup2number.Text = "x0";
			powerup2Active = false;
			scoreMultipler = 1;
			powerup2HUD.SetActive(false);
			powerup2HUDActive.SetActive(false);
		}
		
		powerupnumbers = 0;
		if( PlayerPrefs.GetInt("powerup3", 0) > 0 && !powerup3Active){
			powerupnumbers = PlayerPrefs.GetInt("powerup3", 0);
			powerupnumbers--;
			PlayerPrefs.SetInt("powerup3", powerupnumbers);
			
			powerup3number.Text = "x" + PlayerPrefs.GetInt("powerup3", 0);
			powerup3Active = true;
			powerup3HUD.SetActive(true);
			powerup3HUDActive.SetActive(true);
		}
		else if(!powerup3Active){

			powerup3number.Text = "x0";
			powerup3Active = false;
			powerup3HUD.SetActive(false);
			powerup3HUDActive.SetActive(false);
		}
		
		
	}
	
	public void RemovePowerups(){
			correntBallPhisic.ball.localScale = Vector3.one;
			correntBallPhisic.gameObject.rigidbody.mass = 10;
			kontroler.powerForceMultipler = 1;
			powerup1Active = false;
		
			powerup2Active = false;
			scoreMultipler = 1;
		
			powerup3Active = false;
		
			powerup1HUD.SetActive(false);
			powerup2HUD.SetActive(false);
			powerup3HUD.SetActive(false);
		
		powerup1HUDActive.SetActive(false);
		powerup2HUDActive.SetActive(false);
		powerup3HUDActive.SetActive(false);
		
	}
	
}
