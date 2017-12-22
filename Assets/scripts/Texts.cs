using UnityEngine;
using System;
using System.Globalization;

public class Texts : MonoBehaviour {
	
	[System.Serializable]
	public class Region
	{
		public 		string 				code;
		public 		string[]			texts;
	}
	
	public		Material[]			chinMats;
	public		Material[]			chinMats2;
	public 		GameObject[]		Russian;
	public 		GameObject[] 		Chainese;
	public		GameObject[]		Japanese;
	
	public		Region[]		SupportedLanguages;
	// English
	// Polish
	// German
	// French
	// Italian
	// Spanish
	// Russian
	// Chinese
	// Japanese
	
	void Start (){

	}

	public string GetText(int textID){
	//	Debug.Log("this is my country 3	: " + 	Application.systemLanguage);
		string toReturn = "";
		int languageID = 0;
		for(int i = 0; i < SupportedLanguages.Length; i++){
			if(SupportedLanguages[i].code == (Application.systemLanguage.ToString())){
				languageID = i;
				break;
			}
		}
		toReturn = SupportedLanguages[languageID].texts[textID];
		return toReturn;
		
	}
	
	public GameObject GetGraphicText(int textID){
		GameObject toReturn = null;
		if((Application.systemLanguage.ToString()) == "Russian"){
			toReturn = Russian[textID];
		}
		else if((Application.systemLanguage.ToString()) == "Chinese"){
			toReturn = Chainese[textID];
		}
		else if((Application.systemLanguage.ToString()) == "Japanese"){
			toReturn = Japanese[textID];
		}
		return toReturn;
	}
	
	
	
}
