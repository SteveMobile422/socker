using UnityEngine;
using System.Collections;

public class store : MonoBehaviour {
	
	public			GameObject		powerups;
	public			GameObject		coins;
	public			GameObject		balls;
	public			GameObject		back;
	
	// POWERUPS
	public			GameObject		powerup1;
	public			GameObject		powerup2;
	public			GameObject		powerup3;
	public			GameObject		powerup4;
	public			GameObject		powerup5;
	
	public			BitmapMeshText	powerup1number;
	public			BitmapMeshText	powerup2number;
	public			BitmapMeshText	powerup3number;

	public			GameObject		powerupAllActive;
	
	// COINS
	public			GameObject		coins1;
	public			GameObject		coins2;
	public			GameObject		coins3;
	public			GameObject		coins4;
	public			GameObject		coins5;
	public			GameObject		coins6;
	public			moneys			Moneys;
	
	// BALLS
	public			GameObject		balls1;
	public			GameObject		balls2;
	public			GameObject		balls3;
	public			GameObject		balls4;
	public			GameObject		balls5;
	public			GameObject		ballsBuy;
	
	public			GameObject		BallSelected;
	public			GameObject		BallHave;
	public			GameObject		BallLocked;
	public			BitmapMeshText	BallCost;
	public			GameObject[]	BallsMesh;
	public			GameObject[]	BallsDescription;
	public			float[]			BallsCosts;
	public			int				BallsCurrent;
	
	public			GameObject		removeadsPrice;
	public			GameObject		removeadsHave;
	
	public			GameObject		allPrice;
	public			GameObject		allHave;
	
	
	public			Camera			guiCamera;
	private			int				GuiID;
	public			menuClick		clickSFX;
	public			menuClick		errorSFX;
	public			menuClick		boughtSFX;
	
	public			GameObject		CatPowerups;
	public			GameObject		CatCoins;
	public			GameObject		CatBalls;
	
	public			GameObject		startMenu;
	public			GameObject		LevelSelect;
	public			GameObject		StageSelect;
	
	public			Renderer		bg;
	public			Renderer		bg2;
	public			Material[]		levelBGs;
	public			PopoutWindow	popoutwindow;
	public			StoreKitGUIManager	StoreControler;
	
	private			bool			moveTouch;
	private			Vector2			moveTouchStart;
	private			Vector3			swipeStart;
	public			Transform		swipe;
	public			GameObject		arrow;
	public			GameObject		arrow_pointer;

	

	
	
	void OnEnable(){
		
		if(!StoreControler.canMakePayments){
			StoreControler.InitialiseStoreKit();
		}
		
		if(!StoreControler.isFree){
			powerup4.SetActive(false);
			powerup5.SetActive(false);
			arrow.SetActive(false);
			powerup1.transform.localPosition = new Vector3(0, 150, 950);
			powerup2.transform.localPosition = new Vector3(0, -170, 950);
			powerup3.transform.localPosition = new Vector3(0, -490, 950);
			arrow_pointer.SetActive(false);
		}
		else{
			swipe.position = new Vector3(swipe.position.x, 135, swipe.position.z);
			arrow_pointer.SetActive(true);
			float PointerPosition = 200 - 550 * (swipe.position.y/700);
			arrow_pointer.transform.localPosition = new Vector3(794,PointerPosition,500);
		}
		
		if(StoreControler.isFree) {
			if(PlayerPrefs.GetInt("AllUnlocked", 0) == 1){
				allHave.SetActive(true);
				allPrice.SetActive(false);
			}
			else{
				allHave.SetActive(false);
				allPrice.SetActive(true);
			}
			if(PlayerPrefs.GetInt("RemoveAds", 0) == 0){
				removeadsPrice.SetActive(true);
				removeadsHave.SetActive(false);
			}
			else{
				removeadsPrice.SetActive(false);
				removeadsHave.SetActive(true);
			}
			
		}
		
		if(PlayerPrefs.GetInt("loadStore", 0) == 0){
			// POWERUPS ACTIVE
			CatPowerups.SetActive(true);
			CatCoins.SetActive(false);
			CatBalls.SetActive(false);
			
			powerup1number.Text = "x" + PlayerPrefs.GetInt("powerup1", 0);
			powerup2number.Text = "x" + PlayerPrefs.GetInt("powerup2", 0);
			powerup3number.Text = "x" + PlayerPrefs.GetInt("powerup3", 0);
		}
		else if(PlayerPrefs.GetInt("loadStore", 0) == 1){
			// COINS ACTIVE
			CatPowerups.SetActive(false);
			CatCoins.SetActive(true);
			CatBalls.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("loadStore", 0) == 2){
			// BALL ACTIVE
			CatPowerups.SetActive(false);
			CatCoins.SetActive(false);
			CatBalls.SetActive(true);
		}
		ChangeBall(PlayerPrefs.GetInt("SelectedBall", 0));
		powerup1number.Text = "x" + PlayerPrefs.GetInt("powerup1", 0);
		powerup2number.Text = "x" + PlayerPrefs.GetInt("powerup2", 0);
		powerup3number.Text = "x" + PlayerPrefs.GetInt("powerup3", 0);
		bg.material = levelBGs[ PlayerPrefs.GetInt("loadLevel", 1) -1 ] ;
		bg2.material = levelBGs[ PlayerPrefs.GetInt("loadLevel", 1) -1 ] ;
	}
	
	// Update is called once per frame
	void Update () {
		
					float PointerPosition = 200 - 550 * (swipe.position.y/700);
			arrow_pointer.transform.localPosition = new Vector3(794,PointerPosition,500);
		
		if(GuiID < 0){
			//*************    END SCALE
			back.transform.localScale = Vector3.Slerp(back.transform.localScale, new Vector3(2.2f, 2.2f, 1), Time.deltaTime*25.0f);
			powerups.transform.localScale = Vector3.Slerp(powerups.transform.localScale,  new Vector3(1.6f, 1.6f, 1), Time.deltaTime*25.0f);
			coins.transform.localScale = Vector3.Slerp(coins.transform.localScale,  new Vector3(1.23f, 1.23f, 1), Time.deltaTime*25.0f);
			balls.transform.localScale = Vector3.Slerp(balls.transform.localScale, new Vector3(1.45f, 1.35f, 1), Time.deltaTime*25.0f);
			
			powerup1.transform.localScale = Vector3.Slerp(powerup1.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			powerup2.transform.localScale = Vector3.Slerp(powerup2.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			powerup3.transform.localScale = Vector3.Slerp(powerup3.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			powerup4.transform.localScale = Vector3.Slerp(powerup4.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			powerup5.transform.localScale = Vector3.Slerp(powerup5.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			
			coins1.transform.localScale = Vector3.Slerp(coins1.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			coins2.transform.localScale = Vector3.Slerp(coins2.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			coins3.transform.localScale = Vector3.Slerp(coins3.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			coins4.transform.localScale = Vector3.Slerp(coins4.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			coins5.transform.localScale = Vector3.Slerp(coins5.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			coins6.transform.localScale = Vector3.Slerp(coins6.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			
			ballsBuy.transform.localScale = Vector3.Slerp(ballsBuy.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			balls1.transform.localScale = Vector3.Slerp(balls1.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			balls2.transform.localScale = Vector3.Slerp(balls2.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			balls3.transform.localScale = Vector3.Slerp(balls3.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			balls4.transform.localScale = Vector3.Slerp(balls4.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			balls5.transform.localScale = Vector3.Slerp(balls5.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
		}
		if(Input.touchCount>0){
			if(Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended){				
				//*************    END ACTIONS
				moveTouch = false;
				if(GuiID == 0){
					
					if( PlayerPrefs.GetInt("loadStoreFrom", 0) == 0) startMenu.SetActive(true);
					else if( PlayerPrefs.GetInt("loadStoreFrom", 0) == 1) LevelSelect.SetActive(true);
					else if( PlayerPrefs.GetInt("loadStoreFrom", 0) == 2) StageSelect.SetActive(true);
					PlayerPrefs.SetInt("loadStoreFrom", 0);
					clickSFX.playClick();
					gameObject.SetActive(false);
				}
				else if(GuiID == 1){
					if(CatBalls.transform.localPosition.x > -10) CatBalls.animation.Play("storeWindowExit");
					if(CatCoins.transform.localPosition.x > -10) CatCoins.animation.Play("storeWindowExit");
					CatPowerups.SetActive(true);
					if(CatPowerups.transform.localPosition.x <= -10) CatPowerups.animation.Play("storeWindowStart");
				}
				else if(GuiID == 2){
					if(CatPowerups.transform.localPosition.x > -10) CatPowerups.animation.Play("storeWindowExit");
					if(CatBalls.transform.localPosition.x > -10) CatBalls.animation.Play("storeWindowExit");
					CatCoins.SetActive(true);
					if(CatCoins.transform.localPosition.x <= -10)  CatCoins.animation.Play("storeWindowStart");
				}
				else if(GuiID == 3){
					if(CatPowerups.transform.localPosition.x > -10) CatPowerups.animation.Play("storeWindowExit");
					if(CatCoins.transform.localPosition.x > -10) CatCoins.animation.Play("storeWindowExit");
					CatBalls.SetActive(true);
					if(CatBalls.transform.localPosition.x <= -10) CatBalls.animation.Play("storeWindowStart");
				}
				// ********* POWERUPS
				else if(GuiID == 10){ // POWERUP 1
					if(PlayerPrefs.GetInt("coins", 0) >= 20){
						boughtSFX.playClick();
						PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 20);
						int powerupNumbers = PlayerPrefs.GetInt("powerup1", 0);
						powerupNumbers++;
						PlayerPrefs.SetInt("powerup1", powerupNumbers);
						powerup1number.Text = "x" + PlayerPrefs.GetInt("powerup1", 0);
						powerup2number.Text = "x" + PlayerPrefs.GetInt("powerup2", 0);
						powerup3number.Text = "x" + PlayerPrefs.GetInt("powerup3", 0);
						Moneys.UpdateCoins();
					}
					else{
						coins.animation.Play();
						errorSFX.playClick();
						popoutwindow.EnableNoCoins();
					}
				}
				else if(GuiID == 11){ // POWERUP 2
					if(PlayerPrefs.GetInt("coins", 0) >= 20){
						boughtSFX.playClick();
						PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 20);
						int powerupNumbers = PlayerPrefs.GetInt("powerup2", 0);
						powerupNumbers++;
						PlayerPrefs.SetInt("powerup2", powerupNumbers);
						powerup1number.Text = "x" + PlayerPrefs.GetInt("powerup1", 0);
						powerup2number.Text = "x" + PlayerPrefs.GetInt("powerup2", 0);
						powerup3number.Text = "x" + PlayerPrefs.GetInt("powerup3", 0);
						Moneys.UpdateCoins();
					}
					else{
						coins.animation.Play();
						errorSFX.playClick();
						popoutwindow.EnableNoCoins();
					}
				}
				else if(GuiID == 12){ // POWERUP 3
					if(PlayerPrefs.GetInt("coins", 0) >= 20){
						boughtSFX.playClick();
						PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 20);
						int powerupNumbers = PlayerPrefs.GetInt("powerup3", 0);
						powerupNumbers++;
						PlayerPrefs.SetInt("powerup3", powerupNumbers);
						powerup1number.Text = "x" + PlayerPrefs.GetInt("powerup1", 0);
						powerup2number.Text = "x" + PlayerPrefs.GetInt("powerup2", 0);
						powerup3number.Text = "x" + PlayerPrefs.GetInt("powerup3", 0);
						Moneys.UpdateCoins();
					}
					else{
						coins.animation.Play();
						errorSFX.playClick();
						popoutwindow.EnableNoCoins();
					}
				}
				else if(GuiID == 13){ // POWERUP 4  -- REMOVE ADS
					if(PlayerPrefs.GetInt("coins", 0) >= 1500){
						
						if(PlayerPrefs.GetInt("RemoveAds", 0) == 0){
							PlayerPrefs.SetInt("RemoveAds", 1);
							PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 1500);
							boughtSFX.playClick();
						}
						else{
							errorSFX.playClick();	
						}
						
							if(PlayerPrefs.GetInt("AllUnlocked", 0) == 1){
								allHave.SetActive(true);
								allPrice.SetActive(false);
							}
							else{
								allHave.SetActive(false);
								allPrice.SetActive(true);
							}
							if(PlayerPrefs.GetInt("RemoveAds", 0) == 0){
								removeadsPrice.SetActive(true);
								removeadsHave.SetActive(false);
							}
							else{
								removeadsPrice.SetActive(false);
								removeadsHave.SetActive(true);
							}
						
						Moneys.UpdateCoins();
					}
					else if(PlayerPrefs.GetInt("RemoveAds", 0) == 0){
						coins.animation.Play();
						errorSFX.playClick();
						popoutwindow.EnableNoCoins();
					}
					else{
						errorSFX.playClick();
					}
				}
				else if(GuiID == 14){ // POWERUP 5 - Unlock All
					if(PlayerPrefs.GetInt("AllUnlocked", 0) == 1){
						errorSFX.playClick();
						//clickSFX.playClick();
					}
					else if(
						PlayerPrefs.GetInt("Level2_unlocked", 0) > 0 &&
						PlayerPrefs.GetInt("Level3_unlocked", 0) > 0 &&
						PlayerPrefs.GetInt("Level4_unlocked", 0) > 0 &&
						PlayerPrefs.GetInt("Level5_unlocked", 0) > 0 &&
						PlayerPrefs.GetInt("Ball2", 0) > 0 &&
						PlayerPrefs.GetInt("Ball3", 0) > 0 &&
						PlayerPrefs.GetInt("Ball4", 0) > 0 &&
						PlayerPrefs.GetInt("Ball5", 0) > 0 &&
						PlayerPrefs.GetInt("RemoveAds", 0) > 0 &&
						PlayerPrefs.GetInt("AllUnlocked", 0) == 0 
						){
						PlayerPrefs.SetInt("AllUnlocked", 1);
							if(PlayerPrefs.GetInt("AllUnlocked", 0) == 1){
								allHave.SetActive(true);
								allPrice.SetActive(false);
							}
							else{
								allHave.SetActive(false);
								allPrice.SetActive(true);
							}
							if(PlayerPrefs.GetInt("RemoveAds", 0) == 0){
								removeadsPrice.SetActive(true);
								removeadsHave.SetActive(false);
							}
							else{
								removeadsPrice.SetActive(false);
								removeadsHave.SetActive(true);
							}
						boughtSFX.playClick();
					}
					else if(PlayerPrefs.GetInt("coins", 0) >= 3000){
						boughtSFX.playClick();
						PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - 3000);
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
						Moneys.UpdateCoins();
						
							if(PlayerPrefs.GetInt("AllUnlocked", 0) == 1){
								allHave.SetActive(true);
								allPrice.SetActive(false);
							}
							else{
								allHave.SetActive(false);
								allPrice.SetActive(true);
							}
							if(PlayerPrefs.GetInt("RemoveAds", 0) == 0){
								removeadsPrice.SetActive(true);
								removeadsHave.SetActive(false);
							}
							else{
								removeadsPrice.SetActive(false);
								removeadsHave.SetActive(true);
							}
					}
					else{
						coins.animation.Play();
						errorSFX.playClick();
						popoutwindow.EnableNoCoins();
					}
				}
				// ********* COINS
				else if(GuiID == 20){
					// SEND INAPP REQUEST
					StoreControler.buyProductWithId(0, 1);
					clickSFX.playClick();
					//PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 100);
					Moneys.UpdateCoins();
				}
				else if(GuiID == 21){
					// SEND INAPP REQUEST
					StoreControler.buyProductWithId(2, 1);
					clickSFX.playClick();
					//PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 250);
					Moneys.UpdateCoins();
				}
				else if(GuiID == 22){
					// SEND INAPP REQUEST
					StoreControler.buyProductWithId(5, 1);
					clickSFX.playClick();
					//PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 500);
					Moneys.UpdateCoins();
				}
				else if(GuiID == 23){
					// SEND INAPP REQUEST
					StoreControler.buyProductWithId(1, 1);
					clickSFX.playClick();
					//PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 1500);
					Moneys.UpdateCoins();
				}
				else if(GuiID == 24){
					// SEND INAPP REQUEST
					StoreControler.buyProductWithId(3, 1);
					clickSFX.playClick();
					//PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 3000);
					Moneys.UpdateCoins();
				}
				else if(GuiID == 25){
					// SEND INAPP REQUEST
					StoreControler.buyProductWithId(4, 1);
					//boughtSFX.playClick();
					clickSFX.playClick();
					//PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 5000);
					Moneys.UpdateCoins();
				}
				// ********* BALLS
				else if(GuiID == 30){
					// BUY
					string ballMemory = "Ball" + (BallsCurrent+1);
					if(PlayerPrefs.GetInt(ballMemory, 0) == 0){
						if(PlayerPrefs.GetInt("coins", 0) >= BallsCosts[BallsCurrent]){
							boughtSFX.playClick();
							PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) - (int)BallsCosts[BallsCurrent]));
							PlayerPrefs.SetInt(ballMemory, 1);
						}
						else{
							coins.animation.Play();	
							errorSFX.playClick();
							popoutwindow.EnableNoCoins();
						}
					}
					else if(PlayerPrefs.GetInt(ballMemory, 0) == 1){
						PlayerPrefs.GetInt("SelectedBall", 0);
						
						clickSFX.playClick();
						PlayerPrefs.SetInt(ballMemory, 2);
						ballMemory = "Ball" + (PlayerPrefs.GetInt("SelectedBall", 0)+1);
						PlayerPrefs.SetInt(ballMemory, 1);
						PlayerPrefs.SetInt("SelectedBall", BallsCurrent);
					}
					else {clickSFX.playClick();}
					ChangeBall(BallsCurrent);
					Moneys.UpdateCoins();
				}
				else if(GuiID == 31){
					// BUY
					BallsCurrent = GuiID - 31;
					ChangeBall(BallsCurrent);
					clickSFX.playClick();
				}
				else if(GuiID == 32){
					// BUY
					BallsCurrent = GuiID - 31;
					ChangeBall(BallsCurrent);
					clickSFX.playClick();;
				}
				else if(GuiID == 33){
					// BUY
					BallsCurrent = GuiID - 31;
					ChangeBall(BallsCurrent);
					clickSFX.playClick();
				}
				else if(GuiID == 34){
					// BUY
					BallsCurrent = GuiID - 31;
					ChangeBall(BallsCurrent);
					clickSFX.playClick();
				}
				else if(GuiID == 35){
					// BUY
					BallsCurrent = GuiID - 31;
					ChangeBall(BallsCurrent);
					clickSFX.playClick();
				}
				GuiID = -1;
			}
			if(Input.GetTouch(0).phase == TouchPhase.Began){
									// Is Popout Window
				moveTouchStart = Input.GetTouch(0).position;
					if(popoutwindow.active) return;
				Ray ray = guiCamera.ScreenPointToRay(Input.GetTouch(0).position);
				RaycastHit hit;
				GuiID = -1;	
					if (Physics.Raycast(ray, out hit, 1000)){
						//*********************** BEGAN
						if(hit.collider.gameObject == back){
							GuiID = 0;
						}
						else if(hit.collider.gameObject == powerups){
							GuiID = 1;
						}
						else if(hit.collider.gameObject == coins){
							GuiID = 2;
						}
						else if(hit.collider.gameObject == balls){
							GuiID = 3;
						}
					//***** POWERUPS
						else if(hit.collider.gameObject == powerup1){
							GuiID = 10;
						}
						else if(hit.collider.gameObject == powerup2){
							GuiID = 11;
						}
						else if(hit.collider.gameObject == powerup3){
							GuiID = 12;
						}
						else if(hit.collider.gameObject == powerup4){
							GuiID = 13;
						}
						else if(hit.collider.gameObject == powerup5){
							GuiID = 14;
						}
					//***** COINS
						else if(hit.collider.gameObject == coins1){
							GuiID = 20;
						}
						else if(hit.collider.gameObject == coins2){
							GuiID = 21;
						}
						else if(hit.collider.gameObject == coins3){
							GuiID = 22;
						}
						else if(hit.collider.gameObject == coins4){
							GuiID = 23;
						}
						else if(hit.collider.gameObject == coins5){
							GuiID = 24;
						}
						else if(hit.collider.gameObject == coins6){
							GuiID = 25;
						}
					//***** BALLS
						else if(hit.collider.gameObject == ballsBuy){
							GuiID = 30;
						}
						else if(hit.collider.gameObject == balls1){
							GuiID = 31;
						}
						else if(hit.collider.gameObject == balls2){
							GuiID = 32;
						}
						else if(hit.collider.gameObject == balls3){
							GuiID = 33;
						}
						else if(hit.collider.gameObject == balls4){
							GuiID = 34;
						}
						else if(hit.collider.gameObject == balls5){
							GuiID = 35;
						}
						else {
							GuiID = -1;	
						}
				}
			}
			else if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary){
				if(Vector2.Distance(moveTouchStart, Input.GetTouch(0).position) > 10 && !moveTouch){
					moveTouch = true;
					swipeStart = swipe.position;
					GuiID = -1;
				}
				else if(moveTouch){
					Vector3 newPos = swipeStart + new Vector3(0, (Input.GetTouch(0).position.y - moveTouchStart.y), 0) * 2;
					if(newPos.y < 0) newPos = new Vector3(newPos.x, 0, newPos.z);
					if(newPos.y > 700 && powerup5.activeInHierarchy) newPos = new Vector3(newPos.x, 700, newPos.z);
					else if(newPos.y > 0 && !powerup5.activeInHierarchy) newPos = new Vector3(newPos.x, 0, newPos.z);
					swipe.position = newPos;
					
				}
				else{
				//*****************  MOVE
					if(GuiID == 0) back.transform.localScale = Vector3.Slerp(back.transform.localScale, new Vector3(2.6f, 2.6f, 1), Time.deltaTime*25.0f);
					if(GuiID == 1) powerups.transform.localScale = Vector3.Slerp(powerups.transform.localScale, new Vector3(1.9f, 1.9f, 1), Time.deltaTime*25.0f);
					if(GuiID == 2) coins.transform.localScale = Vector3.Slerp(coins.transform.localScale, new Vector3(1.4f, 1.4f, 1), Time.deltaTime*25.0f);
					if(GuiID == 3) balls.transform.localScale = Vector3.Slerp(balls.transform.localScale, new Vector3(1.8f, 1.7f, 1), Time.deltaTime*25.0f);
				
					if(GuiID == 10) powerup1.transform.localScale = Vector3.Slerp(powerup1.transform.localScale, Vector3.one * 1.1f, Time.deltaTime*25.0f);
					if(GuiID == 11) powerup2.transform.localScale = Vector3.Slerp(powerup2.transform.localScale, Vector3.one * 1.1f, Time.deltaTime*25.0f);
					if(GuiID == 12) powerup3.transform.localScale = Vector3.Slerp(powerup3.transform.localScale, Vector3.one * 1.1f, Time.deltaTime*25.0f);
					if(GuiID == 13) powerup4.transform.localScale = Vector3.Slerp(powerup4.transform.localScale, Vector3.one * 1.1f, Time.deltaTime*25.0f);
					if(GuiID == 14) powerup5.transform.localScale = Vector3.Slerp(powerup5.transform.localScale, Vector3.one * 1.1f, Time.deltaTime*25.0f);
				
					if(GuiID == 20) coins1.transform.localScale = Vector3.Slerp(coins1.transform.localScale, Vector3.one * 1.1f, Time.deltaTime*25.0f);
					if(GuiID == 21) coins2.transform.localScale = Vector3.Slerp(coins2.transform.localScale, Vector3.one * 1.1f, Time.deltaTime*25.0f);
					if(GuiID == 22) coins3.transform.localScale = Vector3.Slerp(coins3.transform.localScale, Vector3.one * 1.1f, Time.deltaTime*25.0f);
					if(GuiID == 23) coins4.transform.localScale = Vector3.Slerp(coins4.transform.localScale, Vector3.one * 1.1f, Time.deltaTime*25.0f);
					if(GuiID == 24) coins5.transform.localScale = Vector3.Slerp(coins5.transform.localScale, Vector3.one * 1.1f, Time.deltaTime*25.0f);
					if(GuiID == 25) coins6.transform.localScale = Vector3.Slerp(coins6.transform.localScale, Vector3.one * 1.1f, Time.deltaTime*25.0f);
				
					if(GuiID == 30) ballsBuy.transform.localScale = Vector3.Slerp(ballsBuy.transform.localScale, Vector3.one * 1.1f, Time.deltaTime*25.0f);
					if(GuiID == 31) balls1.transform.localScale = Vector3.Slerp(balls1.transform.localScale, Vector3.one * 1.2f, Time.deltaTime*25.0f);
					if(GuiID == 32) balls2.transform.localScale = Vector3.Slerp(balls2.transform.localScale, Vector3.one * 1.2f, Time.deltaTime*25.0f);
					if(GuiID == 33) balls3.transform.localScale = Vector3.Slerp(balls3.transform.localScale, Vector3.one * 1.2f, Time.deltaTime*25.0f);
					if(GuiID == 34) balls4.transform.localScale = Vector3.Slerp(balls4.transform.localScale, Vector3.one * 1.2f, Time.deltaTime*25.0f);
					if(GuiID == 35) balls5.transform.localScale = Vector3.Slerp(balls5.transform.localScale, Vector3.one * 1.2f, Time.deltaTime*25.0f);
				}
			
			}
		}
	
	}
	
	private void ChangeBall(int ballID){
		foreach(GameObject ABall in BallsMesh){
			ABall.SetActive(false);
			
		}
		foreach(GameObject DBall in BallsDescription){
			DBall.SetActive(false);
			
		}
			
		BallsDescription[ballID].SetActive(true);
		BallsMesh[ballID].SetActive(true);
		BallCost.Text = "" + BallsCosts[ballID];
		string ballMemory = "Ball" + (ballID+1);
		Debug.Log(PlayerPrefs.GetInt(ballMemory, 0));
		
		if(PlayerPrefs.GetInt(ballMemory, 0) == 0){
			BallLocked.SetActive(true);
			BallHave.SetActive(false);
			BallSelected.SetActive(false);
		}
		else if(PlayerPrefs.GetInt(ballMemory, 0) == 1){
			BallLocked.SetActive(false);
			BallHave.SetActive(true);
			BallSelected.SetActive(false);
		}
		else{
			BallLocked.SetActive(false);
			BallHave.SetActive(false);
			BallSelected.SetActive(true);
		}
		
	}
	
	public void GetCoins(){
		if(CatPowerups.transform.localPosition.x > -10) CatPowerups.animation.Play("storeWindowExit");
		if(CatBalls.transform.localPosition.x > -10) CatBalls.animation.Play("storeWindowExit");
		CatCoins.SetActive(true);
		if(CatCoins.transform.localPosition.x <= -10)  CatCoins.animation.Play("storeWindowStart");
	}
	
	
}
