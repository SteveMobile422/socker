using UnityEngine;
using System.Collections;

public class changeball : MonoBehaviour {
	
	private 		int				correntBall = 0;
	public			GameObject[]	balls;
	public			float[]			ballsHardnes;

	
	void Start(){
		Debug.Log(PlayerPrefs.GetInt("SelectedBall", 0));
		foreach(GameObject ABall in balls){
			ABall.SetActive(false);
		}
		balls[PlayerPrefs.GetInt("SelectedBall", 0)].SetActive(true);
		correntBall = PlayerPrefs.GetInt("SelectedBall", 0);
		gameObject.GetComponent<ballphysics>().ball = balls[correntBall].transform;
		gameObject.GetComponent<ballphysics>().pedmultiply = ballsHardnes[correntBall];
		
	}

/*	public void ChangeThisBall () {
		correntBall ++;
		if(correntBall>= balls.Length) correntBall=0;
		GameObject oldBall = gameObject.GetComponent<ballphysics>().ball.gameObject;
		oldBall.SetActive(false);
		balls[correntBall].gameObject.SetActive(true);	
		gameObject.GetComponent<ballphysics>().ball = balls[correntBall];
		gameObject.GetComponent<ballphysics>().pedmultiply = ballsHardnes[correntBall];
		
	}*/

}
