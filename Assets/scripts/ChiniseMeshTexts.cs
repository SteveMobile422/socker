using UnityEngine;
using System.Collections;

public class ChiniseMeshTexts : MonoBehaviour {
	
	public		Texts			teksty;
	public		bool			shop;

	void Awake () {
		changeText();	
	}
	void OnEnable () {
		changeText();	
	}
	
	private void changeText(){
	if(teksty == null) teksty = GameObject.FindWithTag("texts").GetComponent<Texts>();
	
	if(shop){
		if((Application.systemLanguage.ToString()) == "Russian"){
				renderer.enabled = true;
			renderer.sharedMaterial = teksty.chinMats2[1];
		}
		else if((Application.systemLanguage.ToString()) == "Chinese"){
				renderer.enabled = true;
			renderer.sharedMaterial = teksty.chinMats2[0];
		}
		else if((Application.systemLanguage.ToString()) == "Japanese"){
				renderer.enabled = true;
			renderer.sharedMaterial = teksty.chinMats2[2];
		}
		else if((Application.systemLanguage.ToString()) == "Thai"){
				renderer.enabled = true;
			renderer.sharedMaterial = teksty.chinMats2[3];
		}
		else{
				renderer.enabled = false;
			}
		}
	else{
		if((Application.systemLanguage.ToString()) == "Russian"){
				renderer.enabled = true;
			renderer.sharedMaterial = teksty.chinMats[1];
		}
		else if((Application.systemLanguage.ToString()) == "Chinese"){
				renderer.enabled = true;
			renderer.sharedMaterial = teksty.chinMats[0];
		}
		else if((Application.systemLanguage.ToString()) == "Japanese"){
				renderer.enabled = true;
			renderer.sharedMaterial = teksty.chinMats[2];
		}
		else if((Application.systemLanguage.ToString()) == "Thai"){
				renderer.enabled = true;
			renderer.sharedMaterial = teksty.chinMats[3];
		}
		else{
				renderer.enabled = false;
			}
		}
		
	}
	
	void OnDisable(){
	}
}