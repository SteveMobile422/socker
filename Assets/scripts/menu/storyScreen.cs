using UnityEngine;
using System.Collections;

public class storyScreen : MonoBehaviour {
	
	public		Animation		animacja;
	public		Camera			guiCamera;
	public		GameObject		next;
	private		int				GuiID;
	private		int				GameplayTouchOne = -1;

	// Update is called once per frame
	void Update () {
		if(!animacja.isPlaying) {
			PlayerPrefs.SetInt("Story", 0);
			Application.LoadLevel(1);
		}
		if(GuiID == 0 ){
			next.transform.localScale = Vector3.Slerp(next.transform.localScale, new Vector3(-2, 2, 1), Time.fixedTime * 16.0f); // STORY MENU
			
		}
		
		
		if(Input.touchCount>0 && GameplayTouchOne < 0 && GuiID == 0){
			
			foreach(Touch dotyk in Input.touches){
				if(dotyk.phase == TouchPhase.Began){
				Debug.Log("TouchStart");
					Ray ray = guiCamera.ScreenPointToRay(dotyk.position);
					RaycastHit hit;
					if(Physics.Raycast(ray, out hit, 100)){
						if(hit.collider.gameObject == next){
							Debug.Log("1");
							GameplayTouchOne = dotyk.fingerId;
							GuiID = 1;
						}
					
					}
				}
			}
		}
		
		if(GameplayTouchOne > -1){
			foreach(Touch dotyk in Input.touches){
				if(dotyk.fingerId == GameplayTouchOne){
					if(dotyk.phase == TouchPhase.Canceled || dotyk.phase == TouchPhase.Ended){
						Ray ray = guiCamera.ScreenPointToRay(dotyk.position);
						RaycastHit hit;
						if(Physics.Raycast(ray, out hit, 100)){
							if(hit.collider.gameObject == next && GuiID == 1){
								PlayerPrefs.SetInt("Story", 0);
								Application.LoadLevel(1);
								
								
							}
						
						}
						GameplayTouchOne = -1;
						GuiID = 0;
					}
					else if(dotyk.phase == TouchPhase.Moved || dotyk.phase == TouchPhase.Stationary){
						
						if(GuiID == 1) next.transform.localScale = Vector3.Slerp(next.transform.localScale, new Vector3(-2.4f, 2.4f, 1), Time.fixedTime*25.0f); // STORY MENU
						
						
						
					}
				}
			}
			
		}
	}
}
