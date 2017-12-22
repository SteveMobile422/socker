using UnityEngine;
using System.Collections;

public class globalVariables : MonoBehaviour {
	
	public		int			karton_HP;
	public		int			kartonSmall_HP;
	public		int			kartonLong_HP;
	
	public		int			wood_HP;
	public		int			woodSmall_HP;
	public		int			woodLong_HP;
	
	public		int			rock_HP;
	public		int			rockSmall_HP;
	public		int			rockLong_HP;
	
	public		int			metal_HP;
	public		int			metalSmall_HP;
	public		int			metalLong_HP;
	
	public		soundManager SFX;
	
	
	public int getHP(string typ){
		if(typ == "woodLong") return woodLong_HP;
		else if(typ == "woodBig") return wood_HP;
		else if(typ == "woodSmall") return woodSmall_HP;
		
		else if(typ == "kartonLong") return kartonLong_HP;
		else if(typ == "kartonBig") return karton_HP;
		else if(typ == "kartonSmall") return kartonSmall_HP;
		
		else if(typ == "rockLong") return rockLong_HP;
		else if(typ == "rockBig") return rock_HP;
		else if(typ == "rockSmall") return rockSmall_HP;
		
		else if(typ == "metalLong") return metalLong_HP;
		else if(typ == "metalBig") return metal_HP;
		else if(typ == "metalSmall") return metalSmall_HP;
		
		else{
			Debug.LogError(" Wrong object HP type");
			return 0;
		}
	}
	
	public void playHit(string typ){
		if(typ == "woodLong") SFX.PlayHitWood();
		else if(typ == "woodBig") SFX.PlayHitWood();
		else if(typ == "woodSmall") SFX.PlayHitWood();
		
		else if(typ == "kartonLong") SFX.PlayHitPlastic();
		else if(typ == "kartonBig") SFX.PlayHitPlastic();
		else if(typ == "kartonSmall") SFX.PlayHitPlastic();
		
		else if(typ == "rockLong") SFX.PlayHitWood();
		else if(typ == "rockBig") SFX.PlayHitWood();
		else if(typ == "rockSmall") SFX.PlayHitWood();
		
		else if(typ == "metalLong") SFX.PlayHitMetal();
		else if(typ == "metalBig") SFX.PlayHitMetal();
		else if(typ == "metalSmall") SFX.PlayHitMetal();
		
		else if(typ == "tnt") SFX.PlayHitMetal();
		
		else{
			Debug.LogError(" Wrong object HP type");
		}
	}
	
	public void playSmallHit(string typ){
		if(typ == "woodLong") SFX.PlayHitPlastic();
		else if(typ == "woodBig") SFX.PlayHitPlastic();
		else if(typ == "woodSmall") SFX.PlayHitPlastic();
		
		else if(typ == "kartonLong") SFX.PlayHitPlastic();
		else if(typ == "kartonBig") SFX.PlayHitPlastic();
		else if(typ == "kartonSmall") SFX.PlayHitPlastic();
		
		else if(typ == "rockLong") SFX.PlayHitWood();
		else if(typ == "rockBig") SFX.PlayHitWood();
		else if(typ == "rockSmall") SFX.PlayHitWood();
		
		else if(typ == "metalLong") SFX.PlayHitMetal();
		else if(typ == "metalBig") SFX.PlayHitMetal();
		else if(typ == "metalSmall") SFX.PlayHitMetal();
		
		else if(typ == "tnt") SFX.PlayHitMetal();
		
		else{
		Debug.LogError(" Wrong object HP type");
		}
	}
	
}
