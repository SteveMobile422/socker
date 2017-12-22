using UnityEngine;
using System.Collections;

public class stageData : MonoBehaviour {
	
	public		int				levelID;
	public		int				stageID;
	public		Vector3			scoresBariers;
	
	// Orientation
	public		Transform[]		positions;
	public		int				FirstPosition;
	public		Transform		center;
	
	// Ball
	public		int				ballsNumber;
	public		float			power;
	public		float			maxVertical;
	public		float			maxHorizontal;
	
	// GAME ENDER
	public		GameObject[]	ObjectToFall;
	public		GameObject[]	ObjectToDestroy;
	
	public		bool			complited;
	
	
	public		bool			bidon;
	public		bool			flag;
	public		bool			medal;
	public		bool			puchar;
	public		bool			icecream;
	
	public		int				colected;
	public		int				destroyed;
	
	public		GameObject		storyScreen;	

	// Use this for initialization
	void Start () {
		complited = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!complited && ObjectToFall.Length > 0 || ObjectToDestroy.Length > 0){
			int i = 0;
			
			foreach(GameObject tofall in ObjectToFall){
				if( tofall.activeInHierarchy && tofall.transform.position.y < 0.5f){
					i++;
					tofall.SetActive(false);
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StageGameplay>().AddBidon(tofall.transform.position);
					GameObject.FindGameObjectWithTag("soundmanager").GetComponent<soundManager>().PlayColected(1);
					Instantiate(GameObject.FindGameObjectWithTag("soundmanager").GetComponent<soundManager>().ColectedFX, tofall.transform.position, Quaternion.identity);
				}
				else if( !tofall.activeInHierarchy ){
					i++;	
				}
			}
			foreach(GameObject todestroy in ObjectToDestroy){
				if( todestroy.transform.position.y < 0.5f) i++;	  // if HP == 0
			}
			colected = i;
			if( i == ObjectToFall.Length + ObjectToDestroy.Length) complited = true;
			
		}
	
	}
}
