using UnityEngine;
using System.Collections;

public class PopoutWindow : MonoBehaviour {
	
	public		bool				active;
	public		GUITexture			Blackness;
	public		float				timer;
	
	public		bool				NoCoinsEnabled;
	public		GameObject			NoCoins;
	public		bool				DailyRewardEnabled;
	public		GameObject			DailyReward;
	
	public		GameObject[]		Buttons;
	public		GameObject			storeButton;
	public		int					GuiID;
	
	public		BitmapMeshText[]	DailyRewardTexts;
	public		moneys[]			Moneys;
	public		menuClick			boughtSFX;
	
	
	public		GameObject			menuStart;
	public		GameObject			menuLevelselect;
	public		GameObject			menuStageselect;
	public		GameObject			menuCredits;
	public		GameObject			menuStore;
	public		Texts		teksty;
	
	public		GameObject[]		chiniseMeshesh;
	private		GameObject[]		chiniseMemory = new GameObject[5];
	
	void Awake () {
		if(teksty == null) teksty = GameObject.FindWithTag("texts").GetComponent<Texts>();
		chiniseMemory = new GameObject[5];
	}
	
	// Update is called once per frame
	void Update () {
		
		if(NoCoinsEnabled && !NoCoins.activeInHierarchy){
			if(Input.touchCount <= 0){
				active = true;
				NoCoins.SetActive(true);
			}
		}
		
		if(DailyRewardEnabled && !DailyReward.activeInHierarchy){
			
			if(Input.touchCount <= 0){
				active = true;
				DailyReward.SetActive(true);
				for(int i = 0; i < DailyRewardTexts.Length; i++){
					if(i == 0){
						if(PlayerPrefs.GetInt("DayOfDailyReward", 0) == 1){
							DailyRewardTexts[i].Text = DayOfWeekTranslated("Today!", i);	
						}
						else if(PlayerPrefs.GetInt("DayOfDailyReward", 0) > 1){
							DailyRewardTexts[i].Text = DayOfWeekTranslated("Collected", i);	
						}
					}
					else if(i == 1){
						if(PlayerPrefs.GetInt("DayOfDailyReward", 0) == 1){
							DailyRewardTexts[i].Text = DayOfWeekTranslated("Tomorrow", i);	
						}
						else if(PlayerPrefs.GetInt("DayOfDailyReward", 0) == 2){
							DailyRewardTexts[i].Text = DayOfWeekTranslated("Today!", i);
						}	
						else if(PlayerPrefs.GetInt("DayOfDailyReward", 0) > 2){
							DailyRewardTexts[i].Text = DayOfWeekTranslated("Collected", i);
						}	
					}
					else if(i == 2){
						if(PlayerPrefs.GetInt("DayOfDailyReward", 0) < 3){
							DailyRewardTexts[i].Text = DayOfWeekTranslated(System.DateTime.Now.AddDays(3 - PlayerPrefs.GetInt("DayOfDailyReward", 0)).DayOfWeek.ToString(), i);
						}
						else if(PlayerPrefs.GetInt("DayOfDailyReward", 0) == 3){
							DailyRewardTexts[i].Text = DayOfWeekTranslated("Today!", i);
						}	
						else if(PlayerPrefs.GetInt("DayOfDailyReward", 0) > 3){
							DailyRewardTexts[i].Text = DayOfWeekTranslated("Collected", i);
						}	
					}
					else if(i == 3){
						if(PlayerPrefs.GetInt("DayOfDailyReward", 0) < 4){
							DailyRewardTexts[i].Text = DayOfWeekTranslated(System.DateTime.Now.AddDays(4 - PlayerPrefs.GetInt("DayOfDailyReward", 0)).DayOfWeek.ToString(), i);
						}
						else if(PlayerPrefs.GetInt("DayOfDailyReward", 0) == 4){
							DailyRewardTexts[i].Text = DayOfWeekTranslated("Today!", i);
						}	
						else if(PlayerPrefs.GetInt("DayOfDailyReward", 0) > 4){
							DailyRewardTexts[i].Text = DayOfWeekTranslated("Collected", i);
						}	
					}
					else if(i == 4){
						if(PlayerPrefs.GetInt("DayOfDailyReward", 0) < 5){
							DailyRewardTexts[i].Text = DayOfWeekTranslated(System.DateTime.Now.AddDays(5 - PlayerPrefs.GetInt("DayOfDailyReward", 0)).DayOfWeek.ToString(), i);
						}
						else if(PlayerPrefs.GetInt("DayOfDailyReward", 0) == 5){
							DailyRewardTexts[i].Text = DayOfWeekTranslated("Today!", i);
						}	
						else if(PlayerPrefs.GetInt("DayOfDailyReward", 0) > 5){
							DailyRewardTexts[i].Text = DayOfWeekTranslated("Collected", i);
						}	
					}
					
				}
			}
		}
		
		if(active && Input.touchCount <= 0 && (!DailyRewardEnabled && !NoCoinsEnabled)){
			Debug.Log( Input.touchCount );
			active = false;
			NoCoins.SetActive(false);
			DailyReward.SetActive(false);
		}
		
		if(active){
			if(timer < 1) timer += Time.deltaTime * 2;
			Blackness.color = Color.Lerp(new Color(0, 0, 0, 0.0f), new Color(0, 0, 0, 0.8f), timer);
			
			
			if(Input.touchCount > 0){
				if(Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended){
					if(GuiID == 1){
						if(DailyRewardEnabled){
							//SendCoins
							boughtSFX.playClick();
							if(PlayerPrefs.GetInt("DayOfDailyReward", 0) == 1) 
								PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 1);
							else if(PlayerPrefs.GetInt("DayOfDailyReward", 0) == 2) 
								PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 2);
							else if(PlayerPrefs.GetInt("DayOfDailyReward", 0) == 3) 
								PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 3);
							else if(PlayerPrefs.GetInt("DayOfDailyReward", 0) == 3) 
								PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 5);
							else
								PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 10);
							PlayerPrefs.SetFloat("TimeSinceLastAwake", 0);
							foreach(moneys moneyCounter in Moneys){
								moneyCounter.UpdateCoins();
							}
							PlayerPrefs.SetInt("DayOfDailyRewardCollected", 0);
						}
						active = false;
						NoCoinsEnabled = false;
						DailyRewardEnabled = false;
						DailyReward.SetActive(false);
						NoCoins.SetActive(false);
					}
					else if(GuiID == 2){
						// Open Store
						PlayerPrefs.SetInt("loadStore", 1);
						PlayerPrefs.SetInt("loadStoreFrom", 1);
						menuStart.SetActive(false);
						menuLevelselect.SetActive(false);
						menuStageselect.SetActive(false);
						if(menuStore.activeInHierarchy){
							menuStore.GetComponent<store>().GetCoins();
						}
						
						menuStore.SetActive(true);
						
						active = false;
						NoCoinsEnabled = false;
						DailyRewardEnabled = false;
						DailyReward.SetActive(false);
						NoCoins.SetActive(false);
						foreach(GameObject cos in chiniseMemory){
							if(cos) Destroy(cos);	
						}
						chiniseMemory = new GameObject[5];
					}
				}
				if(Input.GetTouch(0).phase == TouchPhase.Began){	
					Ray ray = camera.ScreenPointToRay(Input.GetTouch(0).position);
					RaycastHit hit;
					GuiID = -1;	
				
					if (Physics.Raycast(ray, out hit, 1000)){
						if(hit.collider.gameObject == storeButton){
							GuiID = 2;
						}
						else 
						foreach(GameObject obiekt in Buttons){
							if(hit.collider.gameObject == obiekt){
								GuiID = 1;
							}
						}
					}
				}
				else if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary){
					if(GuiID == 2)
						storeButton.transform.localScale = Vector3.Slerp(storeButton.transform.localScale, Vector3.one * 1.2f, Time.deltaTime*25.0f);
					else if(GuiID == 1)
					foreach(GameObject obiekt in Buttons){
						obiekt.transform.localScale = Vector3.Slerp(obiekt.transform.localScale, Vector3.one * 1.2f, Time.deltaTime*25.0f);
					}
					else					
					foreach(GameObject obiekt in Buttons){
						obiekt.transform.localScale = Vector3.Slerp(obiekt.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
					}
				}
			}
			else{
				foreach(GameObject obiekt in Buttons){
					obiekt.transform.localScale = Vector3.Slerp(obiekt.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
				}
				storeButton.transform.localScale = Vector3.Slerp(storeButton.transform.localScale, Vector3.one, Time.deltaTime*25.0f);
			}
		}
		else{
			if(timer > 0) timer -= Time.deltaTime * 2;
			Blackness.color = Color.Lerp(new Color(0, 0, 0, 0.0f), new Color(0, 0, 0, 0.8f), timer);
		}
	}
	
	public void EnableNoCoins(){
		NoCoinsEnabled = true;
	}
	
	public void EnableDailyReward(bool nextDay){
		if(!nextDay) PlayerPrefs.SetInt("DayOfDailyReward", 1);
		if(nextDay &&  PlayerPrefs.GetInt("DayOfDailyRewardCollected", 0) == 0){

			if(PlayerPrefs.GetInt("DayOfDailyReward", 0) < 1) PlayerPrefs.SetInt("DayOfDailyReward", 1);
			else if(PlayerPrefs.GetInt("DayOfDailyReward", 0) >= 5) PlayerPrefs.SetInt("DayOfDailyReward", 1);
			else PlayerPrefs.SetInt("DayOfDailyReward", PlayerPrefs.GetInt("DayOfDailyReward", 0) + 1);
			PlayerPrefs.SetInt("DayOfDailyRewardCollected", 1);
		}
		DailyRewardEnabled = true;
		Debug.Log( PlayerPrefs.GetInt("DayOfDailyReward", 0));
	}
	
	private string DayOfWeekTranslated(string day, int texts){
		string ToReturn = "";
		Debug.Log("getText " + day + "   " + texts);
		if((Application.systemLanguage.ToString()) == "Chinese" || (Application.systemLanguage.ToString()) == "Russian" || (Application.systemLanguage.ToString()) == "Japanese" || (Application.systemLanguage.ToString()) == "Thai"){
			GenerateChiniseText(day, texts);
		}
		else{
			if(day == "Monday"){
				ToReturn = teksty.GetText(4);	
			}
			else if(day == "Tuesday"){
				ToReturn = teksty.GetText(5);	
			}
			else if(day == "Wednesday"){
				ToReturn = teksty.GetText(6);	
			}
			else if(day == "Thursday"){
				ToReturn = teksty.GetText(7);	
			}
			else if(day == "Friday"){
				ToReturn = teksty.GetText(8);	
			}
			else if(day == "Saturday"){
				ToReturn = teksty.GetText(9);	
			}
			else if(day == "Sunday"){
				ToReturn = teksty.GetText(10);	
			}
			else if(day == "Today!"){
				ToReturn = teksty.GetText(2);	
			}
			else if(day == "Tomorrow"){
				ToReturn = teksty.GetText(3);	
			}
			else if(day == "Collected"){
				ToReturn = teksty.GetText(28);	
			}
		}
		return ToReturn;
	}	
	
	private void GenerateChiniseText(string day, int texts){
		if(chiniseMemory[texts]) return;
		Debug.Log("Generate chinise day: " + day + "   " + texts );
		if(day == "Monday"){
			chiniseMemory[texts] = Instantiate(chiniseMeshesh[0], DailyRewardTexts[texts].transform.position, Quaternion.identity) as GameObject;
			chiniseMemory[texts].transform.parent = DailyRewardTexts[texts].transform;
		}
		else if(day == "Tuesday"){
			chiniseMemory[texts] = Instantiate(chiniseMeshesh[1], DailyRewardTexts[texts].transform.position, Quaternion.identity) as GameObject;
			chiniseMemory[texts].transform.parent = DailyRewardTexts[texts].transform;	
		}
		else if(day == "Wednesday"){
			chiniseMemory[texts] = Instantiate(chiniseMeshesh[2], DailyRewardTexts[texts].transform.position, Quaternion.identity) as GameObject;
			chiniseMemory[texts].transform.parent = DailyRewardTexts[texts].transform;	
		}
		else if(day == "Thursday"){
			chiniseMemory[texts] = Instantiate(chiniseMeshesh[3], DailyRewardTexts[texts].transform.position, Quaternion.identity) as GameObject;
			chiniseMemory[texts].transform.parent = DailyRewardTexts[texts].transform;
		}
		else if(day == "Friday"){
			chiniseMemory[texts] = Instantiate(chiniseMeshesh[4], DailyRewardTexts[texts].transform.position, Quaternion.identity) as GameObject;
			chiniseMemory[texts].transform.parent = DailyRewardTexts[texts].transform;
		}
		else if(day == "Saturday"){
			chiniseMemory[texts] = Instantiate(chiniseMeshesh[5], DailyRewardTexts[texts].transform.position, Quaternion.identity) as GameObject;
			chiniseMemory[texts].transform.parent = DailyRewardTexts[texts].transform;	
		}
		else if(day == "Sunday"){
			chiniseMemory[texts] = Instantiate(chiniseMeshesh[6], DailyRewardTexts[texts].transform.position, Quaternion.identity) as GameObject;
			chiniseMemory[texts].transform.parent = DailyRewardTexts[texts].transform;
		}
		else if(day == "Today!"){
			chiniseMemory[texts] = Instantiate(chiniseMeshesh[7], DailyRewardTexts[texts].transform.position, Quaternion.identity) as GameObject;
			chiniseMemory[texts].transform.parent = DailyRewardTexts[texts].transform;	
		}
		else if(day == "Tomorrow"){
			chiniseMemory[texts] = Instantiate(chiniseMeshesh[8], DailyRewardTexts[texts].transform.position, Quaternion.identity) as GameObject;
			chiniseMemory[texts].transform.parent = DailyRewardTexts[texts].transform;	
		}
		else if(day == "Collected"){
			chiniseMemory[texts] = Instantiate(chiniseMeshesh[9], DailyRewardTexts[texts].transform.position, Quaternion.identity) as GameObject;
			chiniseMemory[texts].transform.parent = DailyRewardTexts[texts].transform;
		}
	}
}
