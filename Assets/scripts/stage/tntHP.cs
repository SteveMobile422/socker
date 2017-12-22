using UnityEngine;
using System.Collections;

public class tntHP : MonoBehaviour {
	
	public		string			objectType;
	
	public		GameObject		destructFX;
	
	public		float			HP;
	private		StageGameplay	gameplay;
	
	public		GameObject		lod0;
	
	public		float			power   = 1;
	public		bool			connected;

	// Use this for initialization
	void Start () {
		if(!gameplay) gameplay = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StageGameplay>();
	}
	
	void Awake () {
		if(!gameplay) gameplay = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StageGameplay>();
	}
	
	void OnEnable(){
		lod0.SetActive(true);
		if(!gameplay) gameplay = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StageGameplay>();
		
		// Get Data From Oryginal Object
		/*rigidbody.mass = prefab.rigidbody.mass;
		rigidbody.drag = prefab.rigidbody.drag;
		rigidbody.angularDrag = prefab.rigidbody.angularDrag;
		rigidbody.useGravity = prefab.rigidbody.useGravity;
		rigidbody.isKinematic = prefab.rigidbody.isKinematic;*/
		
	}
	
	// Update is called once per frame
	void Update () {
		if(lod0.activeInHierarchy && HP <= 0){
			lod0.SetActive(false);
			if(connected){
				foreach(Transform child in transform.parent.parent){

					
					Debug.Log("connected");
					
					float dystans = Vector3.Distance(child.position, transform.position);
					if(dystans < 14 * power){
						if(child.GetComponent<unlockKinematicRigidbodyAnim>()){
							if(dystans < 8 * power) child.GetComponent<unlockKinematicRigidbodyAnim>().Usun();
								
						}
						else if(child.rigidbody){
							if(child.rigidbody.isKinematic)	child.rigidbody.isKinematic = false;
							 Debug.Log(child.gameObject.name);
						}
						else { }
						
						if(child.rigidbody) child.rigidbody.AddExplosionForce(4000 * power, transform.position, 14 * power);
						if(child.GetComponent<objectHP>())child.GetComponent<objectHP>().HP -= (14 - dystans) * 5 * power;

					}
				}
			}
			else{
				foreach(Transform child in transform.parent){
					float dystans = Vector3.Distance(child.position, transform.position);
					if(child.GetComponent<unlockKinematicRigidbodyAnim>()){
						if(dystans < 8 * power) child.GetComponent<unlockKinematicRigidbodyAnim>().Usun();
							
					}
					else if(child.rigidbody){
						if(child.rigidbody.isKinematic)	child.rigidbody.isKinematic = false;
						
					}
					else { Debug.Log(child.gameObject.name); }
					
					
					Debug.Log("not");
					
					if(dystans < 14){
						
						if(child.GetComponent<unlockKinematicRigidbodyAnim>()){
							child.GetComponent<unlockKinematicRigidbodyAnim>().Usun();
								
						}
						else if(child.rigidbody){
							if(child.rigidbody.isKinematic)	child.rigidbody.isKinematic = false;
							 Debug.Log(child.gameObject.name);
						}
						else { }
						
						if(child.rigidbody) child.rigidbody.AddExplosionForce(4000 * power, transform.position, 14 * power);
						if(child.GetComponent<objectHP>())child.GetComponent<objectHP>().HP -= (14 - dystans) * 5 * power;
						
					}
					
				}
			}
			if(destructFX) Instantiate(destructFX, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
			Destroy(gameObject);
		}
		
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "trampoline") return;
		int		minushp = 0;
			minushp -= (int)collision.impactForceSum.magnitude;
			if(collision.gameObject.tag =="Player"){
				minushp -= (int)collision.impactForceSum.magnitude;
				collision.gameObject.rigidbody.AddForce(collision.impactForceSum);
				GameObject.FindGameObjectWithTag("MainCamera").GetComponent<globalVariables>().playHit(objectType);
			}
		HP += minushp;
		if(collision.impactForceSum.magnitude > 1)
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<globalVariables>().playSmallHit(objectType);
		//gameplay.AddPoints(transform.position, -minushp*2);
	}
}
