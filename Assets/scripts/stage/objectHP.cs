using UnityEngine;
using System.Collections;

public class objectHP : MonoBehaviour {
	
	public		string		objectType;
	
	public		GameObject	destructFX;
	
	public		float		HP;
	private		int		startHP;
	private		StageGameplay	gameplay;
	
	public		GameObject		lod0;
	public		GameObject		lod1;
	public		GameObject		lod2;

	// Use this for initialization
	void Start () {
		if(!gameplay) gameplay = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StageGameplay>();
	}
	
	void Awake () {
		if(!gameplay) gameplay = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StageGameplay>();
	}
	
	void OnEnable(){
		lod0.SetActive(true);
		lod1.SetActive(false);
		lod2.SetActive(false);
		if(!gameplay) gameplay = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StageGameplay>();
		
		// Get Data From Oryginal Object
		/*rigidbody.mass = prefab.rigidbody.mass;
		rigidbody.drag = prefab.rigidbody.drag;
		rigidbody.angularDrag = prefab.rigidbody.angularDrag;
		rigidbody.useGravity = prefab.rigidbody.useGravity;
		rigidbody.isKinematic = prefab.rigidbody.isKinematic;*/
		
		if(objectType.Length > 0 ) HP = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<globalVariables>().getHP(objectType);
		startHP = (int)HP;
	}
	
	// Update is called once per frame
	void Update () {
		if(lod0.activeInHierarchy && HP < (startHP/3)*2){
			lod0.SetActive(false);
			lod1.SetActive(true);
			if(destructFX) Instantiate(destructFX, transform.position, Quaternion.identity);
			gameplay.AddPoints(transform.position, 2);
		}
		else if(lod1.activeInHierarchy && HP < startHP/3){
			lod1.SetActive(false);
			lod2.SetActive(true);
			if(destructFX) Instantiate(destructFX, transform.position, Quaternion.identity);
			gameplay.AddPoints(transform.position, 2);
		}
		else if(HP <= 0){
			gameplay.AddPoints(transform.position, 4);
			if(destructFX) Instantiate(destructFX, transform.position, Quaternion.identity);
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
