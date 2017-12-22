using UnityEngine;
using System.Collections;

public class LevelsSelect : MonoBehaviour {
		public			Camera			guiCamera;
	
	
	public			Transform		levels;
	private			Vector3			levelsStartPos;
	private			Vector3			levelsFinalPos;
	
	public			GameObject		cofaj;
	public			GameObject		store;
	public			GameObject		coins;
	public			GameObject		ball;
	
	public			GameObject		level1;
	public			GameObject		level2;
	public			GameObject		level3;
	public			GameObject		level4;
	public			GameObject		level5;
	
	public			GameObject		level2Unlock;
	public			GameObject		level3Unlock;
	public			GameObject		level4Unlock;
	public			GameObject		level5Unlock;
	
	public			menuClick		clickSFX;
	public			menuClick		errorSFX;
	public			menuClick		boughtSFX;
	
	private			Vector2			touchStartPos;
	private			int				GuiID;
	private			bool			moved;
	
	public			GameObject		StartMenu;
	public			GameObject		StageSelect;
	public			GameObject		storeView;
	public			moneys			Moneys;
	
	public			Renderer[]		pagination;
	private			float			touchtimer;
	
	public			Renderer		bg;
	public			Material[]		levelBGs;
	
	public			GameObject		reklama1;
	public			PopoutWindow	popoutwindow;
	public	 		RevMobControler	RevMobObject;

	// Use this for initialization
	void OnEnable () {
		bg.material = levelBGs[ PlayerPrefs.GetInt("loadLevel", 1) -1 ];
		
		clickSFX.playClick();
		if(GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().isFree)
		if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnLevelSelect){
			#if UNITY_ANDROID
				//AdBuddiz.ShowAnAd();
				reklama1.SendMessage("RequestPlayHavenContent");   // ToRemove;
			#endif
			#if UNITY_IPHONE
				//reklama1.SendMessage("RequestPlayHavenContent");
			RevMobObject.revmob.ShowFullscreen();
			#endif	
		}
		
		if(PlayerPrefs.GetInt("Level2_unlocked", 0) == 1){
			level2Unlock.SetActive(false);
		}
		if(PlayerPrefs.GetInt("Level3_unlocked", 0) == 1){
			level3Unlock.SetActive(false);
		}
		if(PlayerPrefs.GetInt("Level4_unlocked", 0) == 1){
			level4Unlock.SetActive(false);
		}
		if(PlayerPrefs.GetInt("Level5_unlocked", 0) == 1){
			level5Unlock.SetActive(false);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyUp(KeyCode.Escape)){
			StartMenu.SetActive(true);
			gameObject.SetActive(false);
			clickSFX.playClick();
		}
		
		// PAGINATION
		if(levelsFinalPos.x > -375 && levelsFinalPos.x <= 3000){
			pagination[0].enabled = true;	
			pagination[1].enabled = false;	
			pagination[2].enabled = false;	
			pagination[3].enabled = false;	
			pagination[4].enabled = false;	
		}
		else if(levelsFinalPos.x > -1125 && levelsFinalPos.x <= -375){
			pagination[0].enabled = false;	
			pagination[1].enabled = true;	
			pagination[2].enabled = false;	
			pagination[3].enabled = false;	
			pagination[4].enabled = false;	
		}
		else if(levelsFinalPos.x > -1875 && levelsFinalPos.x <= -1125){
			pagination[0].enabled = false;	
			pagination[1].enabled = false;	
			pagination[2].enabled = true;	
			pagination[3].enabled = false;
			pagination[4].enabled = false;	
		}
		else if(levelsFinalPos.x > -2625 && levelsFinalPos.x <= -1875){
			pagination[0].enabled = false;	
			pagination[1].enabled = false;	
			pagination[2].enabled = false;	
			pagination[3].enabled = true;
			pagination[4].enabled = false;
		}
		else if(levelsFinalPos.x > -6000 && levelsFinalPos.x <= -2625){
			pagination[0].enabled = false;	
			pagination[1].enabled = false;	
			pagination[2].enabled = false;	
			pagination[3].enabled = false;
			pagination[4].enabled = true;
		}
		
		else if(levelsFinalPos.x > -375){
			pagination[0].enabled = true;	
			pagination[1].enabled = false;	
			pagination[2].enabled = false;	
			pagination[3].enabled = false;	
			pagination[4].enabled = false;		
		}
		else if(levelsFinalPos.x <= -2625){
			pagination[0].enabled = false;	
			pagination[1].enabled = false;	
			pagination[2].enabled = false;	
			pagination[3].enabled = false;
			pagination[4].enabled = true;
		}
		
		
		
		if(Input.touchCount>0){
			if(Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended){
				if(moved){
					if(levelsFinalPos.x > -375 && levelsFinalPos.x <= 3000) levelsFinalPos.x = 0;
					else if(levelsFinalPos.x > -1125 && levelsFinalPos.x <= -375) levelsFinalPos.x = -750;
					else if(levelsFinalPos.x > -1875 && levelsFinalPos.x <= -1125) levelsFinalPos.x = -1500;
					else if(levelsFinalPos.x > -2625 && levelsFinalPos.x <= -1875) levelsFinalPos.x = -2250;
					else if(levelsFinalPos.x > -6000 && levelsFinalPos.x <= -2625) levelsFinalPos.x = -3000;
					
					
					else if(levelsFinalPos.x > -375) levelsFinalPos.x = 0;
					else if(levelsFinalPos.x <= -6000) levelsFinalPos.x = -3000;
					Debug.Log(levelsFinalPos.x);
					moved = false;
				}
				else{
					//*************** END
					cofaj.transform.localScale = new Vector3(2.2f, 2.2f, 1.0f);
					level1.transform.localScale = new Vector3(5.0f, 7.0f, 1);
					level2.transform.localScale = new Vector3(5.0f, 7.0f, 1);
					level3.transform.localScale = new Vector3(5.0f, 7.0f, 1);
					level4.transform.localScale = new Vector3(5.0f, 7.0f, 1);
					level5.transform.localScale = new Vector3(5.0f, 7.0f, 1);
					store.transform.localScale = new Vector3(1.6f, 1.6f, 1);
					coins.transform.localScale = new Vector3(1.23f, 1.23f, 1);
					ball.transform.localScale = new Vector3(1.45f, 1.35f, 1);
					level2Unlock.transform.localScale = new Vector3(1.84f, 2.02f, 1.8f);
					level3Unlock.transform.localScale = new Vector3(1.84f, 2.02f, 1.8f);
					level4Unlock.transform.localScale = new Vector3(1.84f, 2.02f, 1.8f);
					level5Unlock.transform.localScale = new Vector3(1.84f, 2.02f, 1.8f);
					
					if(GuiID == 0){
						StartMenu.SetActive(true);
						gameObject.SetActive(false);
						clickSFX.playClick();
					}
					else if(GuiID == 1){
						StageSelect.GetComponent<StageSelect>().corrLevel = 1;
						clickSFX.playClick();
						if(GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().isFree)
						if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnLevelsClick){
							#if UNITY_ANDROID
								//AdBuddiz.ShowAnAd();
								reklama1.SendMessage("RequestPlayHavenContent");   // ToRemove;
							#endif
							#if UNITY_IPHONE
								//reklama1.SendMessage("RequestPlayHavenContent");
								if(RevMobObject) if(RevMobObject.revmob != null) RevMobObject.revmob.ShowFullscreen();
							#endif	
						}
						StageSelect.SetActive(true);
						gameObject.SetActive(false);
					}
					else if(GuiID == 2){
						StageSelect.GetComponent<StageSelect>().corrLevel = 2;
						clickSFX.playClick();
						if(GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().isFree)
						if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnLevelsClick){
							#if UNITY_ANDROID
								//AdBuddiz.ShowAnAd();
								reklama1.SendMessage("RequestPlayHavenContent");   // ToRemove;
							#endif
							#if UNITY_IPHONE
								//reklama1.SendMessage("RequestPlayHavenContent");
							if(RevMobObject) if(RevMobObject.revmob != null) RevMobObject.revmob.ShowFullscreen();
							#endif	
						}
						StageSelect.SetActive(true);
						gameObject.SetActive(false);
					}
					else if(GuiID == 3){
						StageSelect.GetComponent<StageSelect>().corrLevel = 3;
						clickSFX.playClick();
						if(GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().isFree)
						if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnLevelsClick){
							#if UNITY_ANDROID
								//AdBuddiz.ShowAnAd();
								reklama1.SendMessage("RequestPlayHavenContent");   // ToRemove;
							#endif
							#if UNITY_IPHONE
								//reklama1.SendMessage("RequestPlayHavenContent");
							if(RevMobObject) if(RevMobObject.revmob != null) RevMobObject.revmob.ShowFullscreen();
							#endif	
						}
						StageSelect.SetActive(true);
						gameObject.SetActive(false);
						
					}
					else if(GuiID == 4){
						StageSelect.GetComponent<StageSelect>().corrLevel = 4;
						clickSFX.playClick();
						if(GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().isFree)
						if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnLevelsClick){
							#if UNITY_ANDROID
								//AdBuddiz.ShowAnAd();
								reklama1.SendMessage("RequestPlayHavenContent");   // ToRemove;
							#endif
							#if UNITY_IPHONE
								//reklama1.SendMessage("RequestPlayHavenContent");
							if(RevMobObject) if(RevMobObject.revmob != null) RevMobObject.revmob.ShowFullscreen();
							#endif	
						}
						StageSelect.SetActive(true);
						gameObject.SetActive(false);		
					}
					else if(GuiID == 5){
						clickSFX.playClick();
						if(GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().isFree)
						if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnLevelsClick){
							#if UNITY_ANDROID
								//AdBuddiz.ShowAnAd();
								reklama1.SendMessage("RequestPlayHavenContent");   // ToRemove;
							#endif
							#if UNITY_IPHONE
								//reklama1.SendMessage("RequestPlayHavenContent");
							if(RevMobObject) if(RevMobObject.revmob != null) RevMobObject.revmob.ShowFullscreen();
							#endif	
						}
						StageSelect.GetComponent<StageSelect>().corrLevel = 5;
						StageSelect.SetActive(true);
						gameObject.SetActive(false);						
					}
					else if(GuiID == 6){
						PlayerPrefs.SetInt("loadStore", 0);
						PlayerPrefs.SetInt("loadStoreFrom", 1);
						storeView.SetActive(true);
						gameObject.SetActive(false);
						clickSFX.playClick();
					}
					else if(GuiID == 7){
						PlayerPrefs.SetInt("loadStore", 1);
						PlayerPrefs.SetInt("loadStoreFrom", 1);
						storeView.SetActive(true);
						gameObject.SetActive(false);
						clickSFX.playClick();
					}
					else if(GuiID == 8){
							PlayerPrefs.SetInt("loadStore", 2);
						PlayerPrefs.SetInt("loadStoreFrom", 1);
						storeView.SetActive(true);
						gameObject.SetActive(false);
						clickSFX.playClick();
					}
					else if(GuiID == 12){
						if(PlayerPrefs.GetInt("coins", 0) >= 200){
							boughtSFX.playClick();
							PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 200);
							Moneys.UpdateCoins();
							PlayerPrefs.SetInt("Level2_unlocked", 1);
							level2Unlock.SetActive(false);
							GuiID = -1;
						}
						else{
							coins.animation.Play();
							errorSFX.playClick();
							popoutwindow.EnableNoCoins();
							GuiID = -1;
						}
					}
					else if(GuiID == 13){
						if(PlayerPrefs.GetInt("coins", 0) >= 200){
							boughtSFX.playClick();
							PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 200);
							Moneys.UpdateCoins();
							PlayerPrefs.SetInt("Level3_unlocked", 1);
							level3Unlock.SetActive(false);
							GuiID = -1;
						}
						else{
							coins.animation.Play();
							errorSFX.playClick();
							popoutwindow.EnableNoCoins();
							GuiID = -1;
						}
					}
					else if(GuiID == 14){
						if(PlayerPrefs.GetInt("coins", 0) >= 200){
							boughtSFX.playClick();
							PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 200);
							Moneys.UpdateCoins();
							PlayerPrefs.SetInt("Level4_unlocked", 1);
							level4Unlock.SetActive(false);
							GuiID = -1;
						}
						else{
							coins.animation.Play();
							errorSFX.playClick();
							popoutwindow.EnableNoCoins();
							GuiID = -1;
						}
					}
					else if(GuiID == 15){
						if(PlayerPrefs.GetInt("coins", 0) >= 200){
							boughtSFX.playClick();
							PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 200);
							Moneys.UpdateCoins();
							PlayerPrefs.SetInt("Level5_unlocked", 1);
							level5Unlock.SetActive(false);
							GuiID = -1;
						}
						else{
							coins.animation.Play();
							errorSFX.playClick();
							GuiID = -1;
							popoutwindow.EnableNoCoins();
						}
					}
					moved = false;
				}
			}
			if(Input.GetTouch(0).phase == TouchPhase.Began){
					// Is Popout Window
					if(popoutwindow.active) return;
				
					touchStartPos = Input.GetTouch(0).position;
					levelsStartPos = levels.localPosition;
					moved = false;
					Ray ray = guiCamera.ScreenPointToRay(Input.GetTouch(0).position);
					RaycastHit hit;
				touchtimer = 0.3f;
				GuiID = -1;	
					if (Physics.Raycast(ray, out hit, 1000)){
					//******************** BEGIN
						if(hit.collider.gameObject == cofaj){
							GuiID = 0;
							
						}
						else if(hit.collider.gameObject.name == level1.gameObject.name){
							GuiID = 1;
							
						}
						else if(hit.collider.gameObject == level2.gameObject){
							GuiID = 2;
							
						}
						else if(hit.collider.gameObject == level3.gameObject){
							GuiID = 3;
							
						}
						else if(hit.collider.gameObject == level4.gameObject){
							GuiID = 4;
							
						}
						else if(hit.collider.gameObject == level5.gameObject){
							GuiID = 5;
							
						}
						else if(hit.collider.gameObject == store.gameObject){
							GuiID = 6;
							
						}
						else if(hit.collider.gameObject == coins.gameObject){
							GuiID = 7;
							
						}
						else if(hit.collider.gameObject == ball){
							GuiID = 8;
							
						}
						else if(hit.collider.gameObject == level2Unlock.gameObject){
							GuiID = 12;
							
						}
						else if(hit.collider.gameObject == level3Unlock.gameObject){
							GuiID = 13;
							
						}
						else if(hit.collider.gameObject == level4Unlock.gameObject){
							GuiID = 14;
							
						}
						else if(hit.collider.gameObject == level5Unlock.gameObject){
							GuiID = 15;
							
						}
						else {
							GuiID = -1;
						}
					}
				
			}
			else if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary){
				if(popoutwindow.active) return;
				
				if(Vector2.Distance(Input.GetTouch(0).position, touchStartPos) > 15 && !moved && touchtimer > 0){
					moved = true;
					cofaj.transform.localScale = new Vector3(2.2f, 2.2f, 1.0f);
					level1.transform.localScale = new Vector3(5.0f, 7.0f, 4);
					level2.transform.localScale = new Vector3(5.0f, 7.0f, 4);
					level3.transform.localScale = new Vector3(5.0f, 7.0f, 4);
					level4.transform.localScale = new Vector3(5.0f, 7.0f, 4);
					level5.transform.localScale = new Vector3(5.0f, 7.0f, 4);
					store.transform.localScale = new Vector3(1.6f, 1.6f, 1);
					coins.transform.localScale = new Vector3(1.23f, 1.23f, 1);
					ball.transform.localScale = new Vector3(1.45f, 1.35f, 1);
					level2Unlock.transform.localScale = new Vector3(1.84f, 2.02f, 1.8f);
					level3Unlock.transform.localScale = new Vector3(1.84f, 2.02f, 1.8f);
					level4Unlock.transform.localScale = new Vector3(1.84f, 2.02f, 1.8f);
					level5Unlock.transform.localScale = new Vector3(1.84f, 2.02f, 1.8f);
				}
				if(touchtimer > 0) touchtimer -= Time.deltaTime;
				if(!moved){
					if(GuiID == 0) cofaj.transform.localScale = Vector3.Slerp(cofaj.transform.localScale, new Vector3(2.6f, 2.6f, 1.0f), Time.deltaTime*25.0f);
					if(GuiID == 1) level1.transform.localScale = Vector3.Slerp(level1.transform.localScale, new Vector3(5.3f, 7.3f, 4), Time.deltaTime*25.0f);
					if(GuiID == 2) level2.transform.localScale = Vector3.Slerp(level2.transform.localScale, new Vector3(5.3f, 7.3f, 4), Time.deltaTime*25.0f);
					if(GuiID == 3) level3.transform.localScale = Vector3.Slerp(level3.transform.localScale, new Vector3(5.3f, 7.3f, 4), Time.deltaTime*25.0f);
					else if(GuiID == 4) level4.transform.localScale = Vector3.Slerp(level4.transform.localScale, new Vector3(5.3f, 7.3f, 4), Time.deltaTime*25.0f);
					else if(GuiID == 5) level5.transform.localScale = Vector3.Slerp(level5.transform.localScale, new Vector3(5.3f, 7.3f, 4), Time.deltaTime*25.0f);
					else if(GuiID == 6) store.transform.localScale = Vector3.Slerp(store.transform.localScale, new Vector3(1.9f, 1.9f, 1), Time.deltaTime*25.0f);
					else if(GuiID == 7) coins.transform.localScale = Vector3.Slerp(coins.transform.localScale, new Vector3(1.4f, 1.4f, 1), Time.deltaTime*25.0f);
					else if(GuiID == 8) ball.transform.localScale = Vector3.Slerp(ball.transform.localScale, new Vector3(1.8f, 1.7f, 1), Time.deltaTime*25.0f);
					else if(GuiID == 12){
						level2Unlock.transform.localScale = Vector3.Slerp(level2Unlock.transform.localScale, new Vector3(2.0f, 2.2f, 1.8f), Time.deltaTime*25.0f);
						level2.transform.localScale = Vector3.Slerp(level2.transform.localScale, new Vector3(5.3f, 7.3f, 4), Time.deltaTime*25.0f);
					}
					else if(GuiID == 13){
						level3Unlock.transform.localScale = Vector3.Slerp(level3Unlock.transform.localScale, new Vector3(2.0f, 2.2f, 1.8f), Time.deltaTime*25.0f);
						level3.transform.localScale = Vector3.Slerp(level3.transform.localScale, new Vector3(5.3f, 7.3f, 4), Time.deltaTime*25.0f);
					}
					else if(GuiID == 14){
						level4Unlock.transform.localScale = Vector3.Slerp(level4Unlock.transform.localScale, new Vector3(2.0f, 2.2f, 1.8f), Time.deltaTime*25.0f);
						level4.transform.localScale = Vector3.Slerp(level4.transform.localScale, new Vector3(5.3f, 7.3f, 4), Time.deltaTime*25.0f);
					}
					else if(GuiID == 15){
						level5Unlock.transform.localScale = Vector3.Slerp(level5Unlock.transform.localScale, new Vector3(2.0f, 2.2f, 1.8f), Time.deltaTime*25.0f);
						level5.transform.localScale = Vector3.Slerp(level5.transform.localScale, new Vector3(5.3f, 7.3f, 4), Time.deltaTime*25.0f);
					}
				}
				else{
					
					
					levelsFinalPos = levelsStartPos + new Vector3( (Input.GetTouch(0).position.x - touchStartPos.x)*3.5f, 0, 0);

					
					
				}
			}
		}
		levels.localPosition = Vector3.Lerp(levels.localPosition, levelsFinalPos, Time.deltaTime * 8);
	}
}
