using UnityEngine;
using System.Collections;

public class credits : MonoBehaviour {
	public			Camera			guiCamera;
	private		int				GuiID;
	public			menuClick		clickSFX;
	
	public		GameObject		facebook;
	public		GameObject		back;
	
	public		GameObject		previous;
	
	public			Renderer		bg;
	public			Material[]		levelBGs;
	
	public		GameObject[]		tutorials;
	public		int				tutorial;
	
	void OnEnable(){
		//bg.material = levelBGs[ PlayerPrefs.GetInt("loadLevel", 1) -1 ] ;
		tutorial = 0;
		foreach(GameObject tutek in tutorials){
			tutek.SetActive(false);	
		}
		tutorials[tutorial].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0){
			if(Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended){
					facebook.transform.localScale = new Vector3(1.5f, 1.6f, 1);
					back.transform.localScale = new Vector3(2.2f, 2.2f, 1);
				if(GuiID == 0){
					if(PlayerPrefs.GetInt("LikeUsReward", 0) == 0){
						PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 10);	
						PlayerPrefs.SetInt("LikeUsReward", 1);
					}
					Application.OpenURL("https://www.facebook.com/kicktheballgame");
					clickSFX.playClick();
				}
				else if(GuiID == 1){
					previous.SetActive(true);
					gameObject.SetActive(false);
					clickSFX.playClick();
				}
			}
			if(Input.GetTouch(0).phase == TouchPhase.Began){
					Ray ray = guiCamera.ScreenPointToRay(Input.GetTouch(0).position);
					RaycastHit hit;
				GuiID = -1;	
				
					if (Physics.Raycast(ray, out hit, 1000)){
					
						if(hit.collider.gameObject == facebook){
							GuiID = 0;
							
						}
						else if(hit.collider.gameObject == back){
							GuiID = 1;
							
						}
						else {
							foreach(GameObject tutek in tutorials){
								tutek.SetActive(false);	
							}
							tutorial++;
							if(tutorial >= tutorials.Length) tutorial = 0;
							tutorials[tutorial].SetActive(true);
							GuiID = -1;	
						}
				}

			}
			else if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary){
					if(GuiID == 0) facebook.transform.localScale = Vector3.Slerp(facebook.transform.localScale, new Vector3(1.8f, 1.9f, 1), Time.deltaTime*25.0f);
					if(GuiID == 1) back.transform.localScale = Vector3.Slerp(back.transform.localScale, new Vector3(2.6f, 2.6f, 1), Time.deltaTime*25.0f);
			}
		}
		
		
	}
}
