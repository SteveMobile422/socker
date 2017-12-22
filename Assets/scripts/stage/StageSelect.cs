using UnityEngine;
using System.Collections;

public class StageSelect : MonoBehaviour {
		public			Camera			guiCamera;
	
	public			int				corrLevel;
	
	public			Transform		levels;
	private			Vector3			levelsStartPos;
	private			Vector3			levelsFinalPos;
	
	public			GameObject		level1;
	public			GameObject		level2;
	public			GameObject		level3;
	public			GameObject		level4;
	public			GameObject		level5;
	public			GameObject		level1_free;
	public			GameObject		level2_free;
	
	public			GameObject		cofaj;
	public			GameObject		store;
	public			GameObject		money;
	public			GameObject		ball;
	public			GameObject[]	usedStages;
	public			GameObject[]	stages;
	public			GameObject[]	stages2;
	public			GameObject[]	stages3;
	public			GameObject[]	stages4;
	public			GameObject[]	stages5;
	public			GameObject[]	stages_free;
	public			GameObject[]	stages2_free;
	
	public			menuClick		clickSFX;
	
	private			Vector2			touchStartPos;
	private			int				GuiID;
	private			bool			moved;
	
	public			GameObject		StartMenu;
	public			GameObject		LevelSelect;
	public			GameObject		storeView;
	
	public			Renderer[]		pagination;
	public			Renderer[]		paginationFrame;
	
	public			Renderer		bg;
	public			Material[]		levelBGs;
	
	public			GameObject			reklama1;
	public			PopoutWindow	popoutwindow;
	public	 RevMobControler	RevMobObject;
	
	public			GameObject		LockStagePrefab;
	public			gameControler	controler;
	private bool ADS;
	
	// Use this for initialization
	void OnEnable () {
		//PlayerPrefs.SetInt("loadLevel", 1)
		
		ADS = GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().isFree;
		
		bg.material = levelBGs[ corrLevel - 1 ] ;
		 levelsFinalPos.x = 0;
		
		level1.SetActive(false);
		level2.SetActive(false);
		level3.SetActive(false);
		level4.SetActive(false);
		level5.SetActive(false);
		level1_free.SetActive(false);
		level2_free.SetActive(false);
		
		Debug.Log(corrLevel + "       ");
		
		if((corrLevel == 1 || corrLevel == 2) && !ADS) level1.SetActive(true);
		else if(corrLevel == 2 && !ADS) level2.SetActive(true);
		else if(corrLevel == 3) level3.SetActive(true);
		else if(corrLevel == 4) level4.SetActive(true);
		else if(corrLevel == 5) level5.SetActive(true);
		else if(corrLevel == 1 && ADS) level1_free.SetActive(true);
		else if(corrLevel == 2 && ADS) level2_free.SetActive(true);
		
		if((corrLevel == 1 || corrLevel == 2) && !ADS) usedStages = stages;
		else if(corrLevel == 2  && !ADS) usedStages = stages2;
		else if(corrLevel == 3) usedStages = stages3;
		else if(corrLevel == 4) usedStages = stages4;
		else if(corrLevel == 5) usedStages = stages5;
		else if(corrLevel == 1 && ADS) usedStages = stages_free;
		else if(corrLevel == 2 && ADS) usedStages = stages2_free;
		
		if((corrLevel == 1 || corrLevel == 2) && !ADS){
			paginationFrame[0].enabled = true;
			paginationFrame[4].enabled = true;
		}
		else{
			pagination[0].enabled = false;
			pagination[4].enabled = false;
			paginationFrame[0].enabled = false;
			paginationFrame[4].enabled = false;
		}
		
		
		// Lock Stages
		for(int i = usedStages.Length-1; i >0; i--){
			Debug.Log("checked StageFinish: " + i + "   previous stage is: " + controler.getStageStars(corrLevel, i));
			if( controler.getStageStars(corrLevel, i) <= 0){
				usedStages[i].SetActive(false);
				GameObject lockedStageIcon = Instantiate(LockStagePrefab, usedStages[i].transform.position, usedStages[i].transform.rotation) as GameObject;
				lockedStageIcon.transform.parent = usedStages[i].transform.parent;
				usedStages[i].SetActive(false);
			}
			else break;
		}
		
		
		if(!ADS)
		if(PlayerPrefs.GetInt("RemoveAds", 0) == 0 && GameObject.FindGameObjectWithTag("ADsControler").GetComponent<adsControler>().AdOnStagesSelect){
			#if UNITY_ANDROID
				//AdBuddiz.ShowAnAd();
				reklama1.SendMessage("RequestPlayHavenContent");   // ToRemove;
			#endif
			#if UNITY_IPHONE
				//reklama1.SendMessage("RequestPlayHavenContent");
				RevMobObject.revmob.ShowFullscreen();
			#endif	
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyUp(KeyCode.Escape)){
			LevelSelect.SetActive(true);
			gameObject.SetActive(false);
			clickSFX.playClick();
		}
		
		if((corrLevel == 1 || corrLevel == 2) && !ADS ){
			// PAGINATION
			if(levelsFinalPos.x > -825 && levelsFinalPos.x <= 3000){
				pagination[0].enabled = true;	
				pagination[1].enabled = false;	
				pagination[2].enabled = false;	
				pagination[3].enabled = false;	
				pagination[4].enabled = false;	
			}
			else if(levelsFinalPos.x > -2475 && levelsFinalPos.x <= -825){
				pagination[0].enabled = false;	
				pagination[1].enabled = true;	
				pagination[2].enabled = false;	
				pagination[3].enabled = false;	
				pagination[4].enabled = false;	
			}
			else if(levelsFinalPos.x > -4125 && levelsFinalPos.x <= -2475){
				pagination[0].enabled = false;	
				pagination[1].enabled = false;	
				pagination[2].enabled = true;	
				pagination[3].enabled = false;
				pagination[4].enabled = false;	
			}
			else if(levelsFinalPos.x > -5775 && levelsFinalPos.x <= -4125){
				pagination[0].enabled = false;	
				pagination[1].enabled = false;	
				pagination[2].enabled = false;	
				pagination[3].enabled = true;
				pagination[4].enabled = false;
			}
			else if(levelsFinalPos.x > -9000 && levelsFinalPos.x <= -5775){
				pagination[0].enabled = false;	
				pagination[1].enabled = false;	
				pagination[2].enabled = false;	
				pagination[3].enabled = false;
				pagination[4].enabled = true;
			}
			
			else if(levelsFinalPos.x > 275){
				pagination[0].enabled = true;	
				pagination[1].enabled = false;	
				pagination[2].enabled = false;	
				pagination[3].enabled = false;	
				pagination[4].enabled = false;		
			}
			else if(levelsFinalPos.x <= -5775){
				pagination[0].enabled = false;	
				pagination[1].enabled = false;	
				pagination[2].enabled = false;	
				pagination[3].enabled = false;
				pagination[4].enabled = true;
			}
		}
		else{
			// PAGINATION
			if(levelsFinalPos.x > -825 && levelsFinalPos.x <= 3000){
				pagination[1].enabled = true;	
				pagination[2].enabled = false;	
				pagination[3].enabled = false;	

			}
			else if(levelsFinalPos.x > -2475 && levelsFinalPos.x <= -825){
				pagination[1].enabled = false;	
				pagination[2].enabled = true;	
				pagination[3].enabled = false;	
			}
			else if(levelsFinalPos.x > -4125 && levelsFinalPos.x <= -2475){
				pagination[1].enabled = false;	
				pagination[2].enabled = false;	
				pagination[3].enabled = true;	
			}
			
			else if(levelsFinalPos.x > 275){
				pagination[1].enabled = true;	
				pagination[2].enabled = false;	
				pagination[3].enabled = false;		
			}
			else if(levelsFinalPos.x <= -2475){
				pagination[1].enabled = false;	
				pagination[2].enabled = false;	
				pagination[3].enabled = true;	
			}
		}
		
		
		if(Input.touchCount>0){
			if(Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended){
				foreach( GameObject stage in usedStages){
					stage.transform.localScale = Vector3.one * 1.5f;
				}
				
				if(moved){
					if((corrLevel == 1 || corrLevel == 2) && !ADS){
						if(levelsFinalPos.x > -825 && levelsFinalPos.x <= 3000) levelsFinalPos.x = 0;
						else if(levelsFinalPos.x > -2475 && levelsFinalPos.x <= -825) levelsFinalPos.x = -1650;
						else if(levelsFinalPos.x > -4125 && levelsFinalPos.x <= -2475) levelsFinalPos.x = -3300;
						else if(levelsFinalPos.x > -5775 && levelsFinalPos.x <= -4125) levelsFinalPos.x = -4950;
						else if(levelsFinalPos.x > -9000 && levelsFinalPos.x <= -5775) levelsFinalPos.x = -6600;
						
						
						else if(levelsFinalPos.x > -825) levelsFinalPos.x = 0;
						else if(levelsFinalPos.x <= -5775) levelsFinalPos.x = -6600;
					}
					else{
						if(levelsFinalPos.x > -825 && levelsFinalPos.x <= 3000) levelsFinalPos.x = 0;
						else if(levelsFinalPos.x > -2475 && levelsFinalPos.x <= -825) levelsFinalPos.x = -1650;
						else if(levelsFinalPos.x > -4125 && levelsFinalPos.x <= -2475) levelsFinalPos.x = -3300;
						
						
						else if(levelsFinalPos.x > 310) levelsFinalPos.x = 0;
						else if(levelsFinalPos.x <= -2475) levelsFinalPos.x = -3300;
					}
					
					Debug.Log(levelsFinalPos.x);
					moved = false;
				}
				else{
					cofaj.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
					foreach(GameObject stejdz in usedStages){
						stejdz.transform.localScale = Vector3.one * 1.5f;
						
					}

					
					if(GuiID == 31){
						LevelSelect.SetActive(true);
						gameObject.SetActive(false);
						clickSFX.playClick();
					}
					else if(GuiID == 32){
						PlayerPrefs.SetInt("loadStore", 0);
						PlayerPrefs.SetInt("loadStoreFrom", 2);
							storeView.SetActive(true);
							gameObject.SetActive(false);
						clickSFX.playClick();
						store.transform.localScale = new Vector3(1.6f, 1.6f, 1);
					}
					else if(GuiID == 33){
						PlayerPrefs.SetInt("loadStore", 1);
						PlayerPrefs.SetInt("loadStoreFrom", 2);
							storeView.SetActive(true);
							gameObject.SetActive(false);
						clickSFX.playClick();
					}
					else if(GuiID == 34){

						PlayerPrefs.SetInt("loadStore", 2);
						PlayerPrefs.SetInt("loadStoreFrom", 2);
							storeView.SetActive(true);
							gameObject.SetActive(false);
						clickSFX.playClick();
						money.transform.localScale = new Vector3(1.23f, 1.23f, 1);
					}
					else if(GuiID > -1 && GuiID < 30){
						PlayerPrefs.SetInt("loadLevel", corrLevel);
						PlayerPrefs.SetInt("loadStage", GuiID + 1);
						if(GuiID == 0) PlayerPrefs.SetInt("Story", 1);
						else PlayerPrefs.SetInt("Story", 0);
						Application.LoadLevel(1);	
						clickSFX.playClick();
						ball.transform.localScale = new Vector3(1.45f, 1.35f, 1);
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
									GuiID = -1;
					if (Physics.Raycast(ray, out hit, 1000)){
					Debug.Log(hit.collider.gameObject.name);
						if(hit.collider.gameObject == cofaj){
							GuiID = 31;
							
						}
						else if(hit.collider.gameObject == store){
							GuiID = 32;
							
						}
						else if(hit.collider.gameObject == money){
							GuiID = 33;
							
						}
						else if(hit.collider.gameObject == ball){
							GuiID = 34;
							
						}
						else {
							for(int i = 0; i < usedStages.Length; i++){ 
								if(hit.collider.gameObject.name == ("ball_" + (i+1))){
									GuiID = i;
									break;
								}
							}
						}
					}
				
			}
			else if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary){
				if(Vector2.Distance(Input.GetTouch(0).position, touchStartPos) > 15 && !moved){
					moved = true;
					cofaj.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
					foreach( GameObject stage in usedStages){
						stage.transform.localScale = Vector3.one * 1.5f;
					}
				}
				
				if(!moved){
					if(GuiID == 31) cofaj.transform.localScale = Vector3.Slerp(cofaj.transform.localScale, new Vector3(2.6f, 2.6f, 1.2f), Time.deltaTime*25.0f);	
					else if(GuiID == 32) store.transform.localScale = Vector3.Slerp(store.transform.localScale, new Vector3(1.9f, 1.9f, 1), Time.deltaTime*25.0f);
					else if(GuiID == 33) money.transform.localScale = Vector3.Slerp(money.transform.localScale, new Vector3(1.4f, 1.4f, 1), Time.deltaTime*25.0f);
					else if(GuiID == 34) ball.transform.localScale = Vector3.Slerp(ball.transform.localScale, new Vector3(1.8f, 1.7f, 1), Time.deltaTime*25.0f);
					else if(GuiID > -1 && GuiID < 30){
						usedStages[GuiID].transform.localScale = Vector3.Slerp(cofaj.transform.localScale, new Vector3(1.6f, 1.6f, 1.6f), Time.deltaTime*25.0f);
					}
				}
				else{
					
					levelsFinalPos = levelsStartPos + new Vector3( (Input.GetTouch(0).position.x - touchStartPos.x)*6.2f, 0, 0);

					
					
				}
			}
		}
		levels.localPosition = Vector3.Lerp(levels.localPosition, levelsFinalPos, Time.deltaTime * 8 );
	}
}
