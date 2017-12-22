using UnityEngine;
using System.Collections;

public class nextDay : MonoBehaviour {
	
	public		int			DayOffeset;
	public		BitmapMeshText	Mesz;

	// Use this for initialization
	void OnEnable () {
		NextDay();
	}
	
	private void NextDay(){
		Mesz.Text = System.DateTime.Now.AddDays(DayOffeset).DayOfWeek.ToString();
	}
	
}
