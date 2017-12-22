using UnityEngine;
using System.Collections;

public class moneys : MonoBehaviour {
	
	public		BitmapMeshText		font;

	// Use this for initialization
	void Start () {
		font.Text = PlayerPrefs.GetInt("coins", 0)+ "";
	}
	
		// Use this for initialization
	void Awake () {
		font.Text = PlayerPrefs.GetInt("coins", 0)+ "";
	}
	
	void LateUpdate(){
		if(font.Text != (PlayerPrefs.GetInt("coins", 0)+ ""))
			font.Text = PlayerPrefs.GetInt("coins", 0)+ "";
	}
	
	// Update is called once per frame
	public void UpdateCoins () {
		font.Text = PlayerPrefs.GetInt("coins", 0)+ "";
	}
}
