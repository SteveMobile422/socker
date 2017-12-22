using UnityEngine;
using System.Collections;

public class MoreCoinsGui : MonoBehaviour {
	
	public 		bool		 	aktywny;
	public		int				GuiID;
	
	public		bool			noCoins;
	public		GameObject		noCoinsObj;
	
	public		bool			moreCoins;
	public		GameObject		moreCoinsObj;
	
	public		GameObject[]	BackButtons;
	public		GameObject		YesButton;
	
	public		GameObject		coins1;
	public		GameObject		coins2;
	public		GameObject		coins3;
	public		GameObject		coins4;
	public		GameObject		coins5;
	public		GameObject		coins6;
	
	public		StoreKitGUIManager		StoreControler;
	
	
	// Update is called once per frame
	void Update () {
		
		if(moreCoins && !moreCoinsObj.activeInHierarchy){
			if(Input.touchCount <= 0){
				aktywny = true;
				moreCoinsObj.SetActive(true);
				camera.enabled = true;
			}
		}
		else if(noCoins && !noCoinsObj.activeInHierarchy){
			if(Input.touchCount <= 0){
				aktywny = true;
				noCoinsObj.SetActive(true);
				camera.enabled = true;
			}
		}
		
		if(aktywny && Input.touchCount <= 0 && (!moreCoins && !noCoins)){
			Debug.Log( Input.touchCount );
			aktywny = false;
			camera.enabled = false;
			noCoinsObj.SetActive(false);
			moreCoinsObj.SetActive(false);
		}
	
		if(aktywny){
			camera.enabled = true;
			
			if(!noCoins && noCoinsObj.activeInHierarchy){
				noCoinsObj.SetActive(false);
				if(!moreCoins){ 
					aktywny = false;
					camera.enabled = true;
					return;
				}
			}
			
			if(Input.touchCount > 0){
				if(Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended){
					if(GuiID == 1){
						aktywny = false;
						noCoins = false;
						moreCoins = false;
						noCoinsObj.SetActive(false);
						moreCoinsObj.SetActive(false);
					}
					if(GuiID >= 5 && GuiID <= 10){
						if(GuiID == 5){
							// Zakup Coins1;
							StoreControler.buyProductWithId(0, 1);
						}
						else if(GuiID == 6){
							// Zakup Coins2;	
							StoreControler.buyProductWithId(2, 1);
						}
						else if(GuiID == 7){
							// Zakup Coins3;	
							StoreControler.buyProductWithId(5, 1);
						}
						else if(GuiID == 8){
							// Zakup Coins4;	
							StoreControler.buyProductWithId(1, 1);
						}
						else if(GuiID == 9){
							// Zakup Coins5;	
							StoreControler.buyProductWithId(3, 1);
						}
						else if(GuiID == 10){
							// Zakup Coins6;	
							StoreControler.buyProductWithId(4, 1);
						}
					}
					else if(GuiID == 2){
						// Open Store
						noCoins = false;
						moreCoins = true;
						noCoinsObj.SetActive(false);
						moreCoinsObj.SetActive(true);
						if(!StoreControler.canMakePayments){
							StoreControler.InitialiseStoreKit();
						}
					}
				}
				if(Input.GetTouch(0).phase == TouchPhase.Began){	
					Ray ray = camera.ScreenPointToRay(Input.GetTouch(0).position);
					RaycastHit hit;
					GuiID = -1;	
				
					if (Physics.Raycast(ray, out hit, 1000)){
						if(hit.collider.gameObject == YesButton){
							GuiID = 2;
						}
						if(hit.collider.gameObject == coins1){
							GuiID = 5;
						}
						if(hit.collider.gameObject == coins2){
							GuiID = 6;
						}
						if(hit.collider.gameObject == coins3){
							GuiID = 7;
						}
						if(hit.collider.gameObject == coins4){
							GuiID = 8;
						}
						if(hit.collider.gameObject == coins5){
							GuiID = 9;
						}
						if(hit.collider.gameObject == coins6){
							GuiID = 10;
						}
						else 
						foreach(GameObject obiekt in BackButtons){
							if(hit.collider.gameObject == obiekt){
								GuiID = 1;
							}
						}
					}
				}
				else if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary){
					if(GuiID == 2)
						YesButton.transform.localScale = Vector3.Slerp(YesButton.transform.localScale, Vector3.one * 1.2f, Time.deltaTime*25.0f);
					else if(GuiID == 1)
					foreach(GameObject obiekt in BackButtons){
						obiekt.transform.localScale = Vector3.Slerp(obiekt.transform.localScale, Vector3.one * 1.2f, Time.deltaTime*25.0f);
					}
					else					
					foreach(GameObject obiekt in BackButtons){
						obiekt.transform.localScale = Vector3.Slerp(obiekt.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
					}
				}
			}
			else{
				foreach(GameObject obiekt in BackButtons){
					obiekt.transform.localScale = Vector3.Slerp(obiekt.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
				}
				YesButton.transform.localScale = Vector3.Slerp(YesButton.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			}
		}
		else{
			camera.enabled = false;
		}
	}
	
	public void EnableNoCoins(){
		noCoins = true;
		if(!StoreControler.canMakePayments){
			StoreControler.InitialiseStoreKit();
		}
	}
	
	public void EnableMoreCoins(){
		moreCoins = true;
		if(!StoreControler.canMakePayments){
			StoreControler.InitialiseStoreKit();
		}
	}
}
