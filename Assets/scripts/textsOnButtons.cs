using UnityEngine;
using System.Collections;

public class textsOnButtons : MonoBehaviour {
	
	public		Material[]		Languages;
	
	void Awake () {
		ChangeText();
	}
	
	void OnEnable () {
		ChangeText();
	}
	
	private void ChangeText(){
		int lang = 0;
		
		if((Application.systemLanguage.ToString()) == "Polish"){
			lang = 1;
		}
		else if((Application.systemLanguage.ToString()) == "German"){
			lang = 2;
		}
		else if((Application.systemLanguage.ToString()) == "French"){
			lang = 3;
		}
		else if((Application.systemLanguage.ToString()) == "Italian"){
			lang = 4;
		}
		else if((Application.systemLanguage.ToString()) == "Spanish"){
			lang = 5;
		}
		else if((Application.systemLanguage.ToString()) == "Russian"){
			lang = 7;
		}
		else if((Application.systemLanguage.ToString()) == "Chinese"){
			lang = 6;
		}
		else if((Application.systemLanguage.ToString()) == "Japanese"){
			lang = 8;
		}
		else if((Application.systemLanguage.ToString()) == "Thai"){
			lang = 9;
		}
		Debug.Log("change button to: " + Application.systemLanguage.ToString());
		renderer.sharedMaterial = Languages[lang];
		
	}
}
	// English
	// Polish
	// German
	// French
	// Italian
	// Spanish
	// Russian
	// Chinese
	// Japanese