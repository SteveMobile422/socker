using UnityEngine;
using System.Collections;

public class wiatrak : MonoBehaviour {
	
	private		Rigidbody[]		acriveObjects;
	public		bool			connected;
	
	public		bool			IsSwitch;
	private		float			SwitchTimer;
	
	public		bool			working;
	public		int				power;
	public		int				powerOnObjects;
	private		float			actualpower;
	private		float			actualObjectsPower;
	
	public		ParticleSystem	particle;
	
	public		Transform		direction;
	public		Animation		animacja;
	
	public		GameObject		turnFX;
	
	void OnEnable(){
		soundManager manager = GameObject.FindGameObjectWithTag("soundmanager").GetComponent<soundManager>();
		turnFX = manager.FanTurnFX;
		manager.AddFanMember();
	}

	void Awake () {
		int i = 0;
		if(connected){
			foreach(Transform child in transform.parent.parent){
				if(child.rigidbody)i ++;
			}
			acriveObjects = new Rigidbody[i + 1];
			
			i = 0;
			foreach(Transform child in transform.parent.parent){
				if(child.rigidbody){
					acriveObjects[i] = child.rigidbody;
					i ++;
				}
			}
		}
		else{
			foreach(Transform child in transform.parent){
				if(child.rigidbody)i ++;
			}
			acriveObjects = new Rigidbody[i + 1];
			
			i = 0;
			foreach(Transform child in transform.parent){
				if(child.rigidbody){
					acriveObjects[i] = child.rigidbody;
					i ++;
				}
			}
		}
		
		if(working) particle.Play();
		
		acriveObjects[i] = GameObject.FindGameObjectWithTag("Player").rigidbody;
		
	}
	
	void Update () {
		animacja["wiatrak"].speed = actualpower/power * 2;
		
		if(working){
			animacja["wiatrak"].speed = actualpower/power * 2;
			
			actualpower = Mathf.Lerp(actualpower, power, Time.deltaTime*2);
			actualObjectsPower = Mathf.Lerp(actualObjectsPower, powerOnObjects, Time.deltaTime*2);
		}
		else{
			actualpower = Mathf.Lerp(actualpower, 0, Time.deltaTime*2);
			actualObjectsPower = Mathf.Lerp(actualObjectsPower, 0, Time.deltaTime*2);
		}
		
		foreach(Rigidbody child in acriveObjects){
			if(child){
				float angle = Vector3.Angle(direction.up, (child.transform.position - direction.position));
				float dystans = Vector3.Distance(child.transform.position, direction.position);
				if(angle < 20 && dystans < 12){
					if(child.tag == "Player") child.AddForce(
						
						direction.up * Time.deltaTime * actualpower * (25 - angle) 
						* (12 - dystans)
						
						);
						
					else child.AddForce(
						
						direction.up * Time.deltaTime * actualObjectsPower * (25 - angle) 
						* (12 - dystans)
						
						);
					
					
				}
			}
		}
		
	}
	
	void OnCollisionEnter(Collision collision) {
		if(!IsSwitch) return;
		if(!working) return;
		if(collision.gameObject.tag == "Player") {
			if( SwitchTimer > Time.time) return;
			if(working){
				working = false;
				particle.Stop();
				Instantiate(turnFX, transform.position, transform.rotation);
				GameObject.FindGameObjectWithTag("soundmanager").GetComponent<soundManager>().RemoveFanMenber();
				GameObject.FindGameObjectWithTag("soundmanager").GetComponent<soundManager>().PlayFanOff();
			}
			else{
				working = true;
				particle.Play();
			}
			
			SwitchTimer = Time.time + 1;
		}
		
	}
}
