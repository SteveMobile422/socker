using UnityEngine;
using System.Collections;

public class getText : MonoBehaviour {
	
	public		Texts			teksty;
	public		int				textID;
	private		GameObject		SpawnedMeshTekst;
	public		bool			Meshesh;
	
	void Awake () {
		changeText();	
	}
	void OnEnable () {
		changeText();	
	}
	
	private void changeText(){
	if(teksty == null) teksty = GameObject.FindWithTag("texts").GetComponent<Texts>();
		if(textID == 1 && Application.systemLanguage.ToString() == "German"){
			transform.localScale = Vector3.one * 0.77f;
		}
		else if(textID == 1){
			transform.localScale = Vector3.one * 0.95f;
		}
		if(textID == 12 && Application.systemLanguage.ToString() == "Spanish"){
			transform.localScale = Vector3.one * 1.5f;
		}
		else if(textID == 12){
			transform.localScale = Vector3.one * 1.615f;
		}
		
		if((Application.systemLanguage.ToString()) == "Russian" && Meshesh){
			gameObject.renderer.enabled = false;
			SpawnedMeshTekst = Instantiate(teksty.GetGraphicText(textID), transform.position, Quaternion.identity) as GameObject;
			SpawnedMeshTekst.transform.parent = transform;
		}
		else if((Application.systemLanguage.ToString()) == "Chinese" && Meshesh){
			gameObject.renderer.enabled = false;
			SpawnedMeshTekst = Instantiate(teksty.GetGraphicText(textID), transform.position, Quaternion.identity) as GameObject;
			SpawnedMeshTekst.transform.parent = transform;
		}
		else if((Application.systemLanguage.ToString()) == "Japanese" && Meshesh){
			gameObject.renderer.enabled = false;
			SpawnedMeshTekst = Instantiate(teksty.GetGraphicText(textID), transform.position, Quaternion.identity) as GameObject;
			SpawnedMeshTekst.transform.parent = transform;
		}
		else if((Application.systemLanguage.ToString()) == "Thai" && Meshesh){
			gameObject.renderer.enabled = false;
			SpawnedMeshTekst = Instantiate(teksty.GetGraphicText(textID), transform.position, Quaternion.identity) as GameObject;
			SpawnedMeshTekst.transform.parent = transform;
		}
		else gameObject.GetComponent<BitmapMeshText>().Text = teksty.GetText(textID);
	}
	
	void OnDisable(){
		gameObject.renderer.enabled = true;
		if(SpawnedMeshTekst) Destroy( SpawnedMeshTekst);
	}
}
