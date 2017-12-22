using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31;


public class StoreKitGUIManager : MonoBehaviour
{
#if UNITY_IPHONE
	private List<StoreKitProduct> _products;
	public 		bool		canMakePayments;
	public		bool		isFree;
	public		GameObject[]		Moneys;
	public			GameObject		NoInternetConnection;
	
	void Awake(){
		if(PlayerPrefs.GetString("Version", "free") == "free"){
			isFree = true;
		}
		else{
			isFree = false;
			PlayerPrefs.SetInt("Level2_unlocked", 1);
			PlayerPrefs.SetInt("Level3_unlocked", 1);
			PlayerPrefs.SetInt("Level4_unlocked", 1);
			PlayerPrefs.SetInt("Level5_unlocked", 1);
			if(PlayerPrefs.GetInt("Ball2", 0) == 0) PlayerPrefs.SetInt("Ball2", 1);
			if(PlayerPrefs.GetInt("Ball3", 0) == 0) PlayerPrefs.SetInt("Ball3", 1);
			if(PlayerPrefs.GetInt("Ball4", 0) == 0) PlayerPrefs.SetInt("Ball4", 1);
			if(PlayerPrefs.GetInt("Ball5", 0) == 0) PlayerPrefs.SetInt("Ball5", 1);
			PlayerPrefs.SetInt("RemoveAds", 1);
			
			PlayerPrefs.SetInt("AllUnlocked", 1);
		}
	}
	
	void Start()
	{
		// you cannot make any purchases until you have retrieved the products from the server with the requestProductData method
		// we will store the products locally so that we will know what is purchaseable and when we can purchase the products
		StoreKitManager.productListReceivedEvent += allProducts =>
		{
			Debug.Log( "received total products: " + allProducts.Count );
			_products = allProducts;
		};
		
		canMakePayments = StoreKitBinding.canMakePayments();
		Debug.Log( "StoreKit canMakePayments: " + canMakePayments );
		if(isFree){
			var productIdentifiers = new string[] {
				"com.DMDEnterprise.kicktheballfree.100coins",
				"com.DMDEnterprise.kicktheballfree.250coins",
				"com.DMDEnterprise.kicktheballfree.500coins",
				"com.DMDEnterprise.kicktheballfree.1500coins",
				"com.DMDEnterprise.kicktheballfree.3000coins",
				"com.DMDEnterprise.kicktheballfree.5000coins"
			};
			StoreKitBinding.requestProductData( productIdentifiers );
		}
		else{
			var productIdentifiers = new string[] {
				"com.immanitas.KickTheBall.100coins",
				"com.immanitas.KickTheBall.250coins",
				"com.immanitas.KickTheBall.500coins",
				"com.immanitas.KickTheBall.1500coins",
				"com.immanitas.KickTheBall.3000coins",
				"com.immanitas.KickTheBall.5000coins"
			};
			StoreKitBinding.requestProductData( productIdentifiers );
		}
		StoreKitManager.purchaseSuccessfulEvent += purchaseSuccessful;
	}


	void OnGUI()
	{
		return;		
		if( GUILayout.Button( "Get Can Make Payments" ) )
		{
			canMakePayments = StoreKitBinding.canMakePayments();
			Debug.Log( "StoreKit canMakePayments: " + canMakePayments );
		}
		
		
		if( GUILayout.Button( "Get Product Data" ) )
		{
			// array of product ID's from iTunesConnect.  MUST match exactly what you have there!
			var productIdentifiers = new string[] { "com.DMDEnterprise.kicktheballfree.100coins", "com.DMDEnterprise.kicktheballfree.200coins" };
			StoreKitBinding.requestProductData( productIdentifiers );
		}
		
		
		if( GUILayout.Button( "Restore Completed Transactions" ) )
		{
			StoreKitBinding.restoreCompletedTransactions();
		}

			
		
		// enforce the fact that we can't purchase products until we retrieve the product data
		if( _products != null && _products.Count > 0 )
		{
			if( GUILayout.Button( "Purchase Random Product" ) )
			{
				var productIndex = Random.Range( 0, _products.Count );
				var product = _products[productIndex];
				
				Debug.Log( "preparing to purchase product: " + product.productIdentifier );
				StoreKitBinding.purchaseProduct( product.productIdentifier, 1 );
			}
		}

		
		if( GUILayout.Button( "Get Saved Transactions" ) )
		{
			List<StoreKitTransaction> transactionList = StoreKitBinding.getAllSavedTransactions();
			
			// Print all the transactions to the console
			Debug.Log( "\ntotal transaction received: " + transactionList.Count );
			
			foreach( StoreKitTransaction transaction in transactionList )
				Debug.Log( transaction.ToString() + "\n" );
		}

		
		if( GUILayout.Button( "Turn Off Auto Confirmation of Transactions" ) )
		{
			// this is used when you want to validate receipts on your own server or when dealing with iTunes hosted content
			// you must manually call StoreKitBinding.finishPendingTransactions when the download/validation is complete
			StoreKitManager.autoConfirmTransactions = false;
		}


		if( GUILayout.Button( "Display App Store" ) )
		{
			StoreKitBinding.displayStoreWithProductId( "305967442" );
		}
	}
	
	public void InitialiseStoreKit(){
		canMakePayments = StoreKitBinding.canMakePayments();
		Debug.Log( "StoreKit canMakePayments: " + canMakePayments );
		if(isFree){
			var productIdentifiers = new string[] {
				"com.DMDEnterprise.kicktheballfree.100coins",
				"com.DMDEnterprise.kicktheballfree.250coins",
				"com.DMDEnterprise.kicktheballfree.500coins",
				"com.DMDEnterprise.kicktheballfree.1500coins",
				"com.DMDEnterprise.kicktheballfree.3000coins",
				"com.DMDEnterprise.kicktheballfree.5000coins"
			};
			StoreKitBinding.requestProductData( productIdentifiers );
		}
		else{
			var productIdentifiers = new string[] {
				"com.immanitas.KickTheBall.100coins",
				"com.immanitas.KickTheBall.250coins",
				"com.immanitas.KickTheBall.500coins",
				"com.immanitas.KickTheBall.1500coins",
				"com.immanitas.KickTheBall.3000coins",
				"com.immanitas.KickTheBall.5000coins"
			};
			StoreKitBinding.requestProductData( productIdentifiers );
		}
	}
	
	public void buyProductWithId(int productID, int number){
		Debug.Log("Can makePurshe?");
		if(!canMakePayments){
			Debug.Log("No");
			InitialiseStoreKit();
			Debug.Log("Return");
			return;
		}
		Debug.Log("Yes");
		
		var productIndex = productID;
		if(_products != null){
		if(_products.Count > productIndex){
			Debug.Log(_products.Count + "");
		}	
		else{
			Debug.Log("No products");
			NoInternetConnection.SetActive(true);
			return;
		}
		}
		else{
			Debug.Log("No products - null");
			NoInternetConnection.SetActive(true);
			return;
		}
			var product = _products[productIndex];
		Debug.Log( "preparing to purchase product: " + product.productIdentifier );
		StoreKitBinding.purchaseProduct( product.productIdentifier, 1 );
	
	}
	
	public void RestoreAllPurshesh(){
		StoreKitBinding.restoreCompletedTransactions();
	}
	
	public void OpenOtherApp(){
		StoreKitBinding.displayStoreWithProductId( "305967442" );
	}
	
	void purchaseSuccessful( StoreKitTransaction transaction )
	{
		Debug.Log( "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA :" + transaction );
		if(isFree){
		 	if(transaction.productIdentifier == "com.DMDEnterprise.kicktheballfree.100coins") 
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 100);
			else if(transaction.productIdentifier == "com.DMDEnterprise.kicktheballfree.250coins") 
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 250);
			else if(transaction.productIdentifier == "com.DMDEnterprise.kicktheballfree.500coins") 
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 500);
			else if(transaction.productIdentifier == "com.DMDEnterprise.kicktheballfree.1500coins") 
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 1500);
			else if(transaction.productIdentifier == "com.DMDEnterprise.kicktheballfree.3000coins") 
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 3000);
			else if(transaction.productIdentifier == "com.DMDEnterprise.kicktheballfree.5000coins") 
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 5000);
		}
		else{
		 	if(transaction.productIdentifier == "com.immanitas.KickTheBall.100coins") 
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 100);
			else if(transaction.productIdentifier == "com.immanitas.KickTheBall.250coins") 
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 250);
			else if(transaction.productIdentifier == "com.immanitas.KickTheBall.500coins") 
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 500);
			else if(transaction.productIdentifier == "com.immanitas.KickTheBall.1500coins") 
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 1500);
			else if(transaction.productIdentifier == "com.immanitas.KickTheBall.3000coins") 
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 3000);
			else if(transaction.productIdentifier == "com.immanitas.KickTheBall.5000coins") 
				PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 5000);
		}
	}
	
	
	void OnApplicationPause(bool _bool)
    {
	   	if(_bool)
	    {
			
	    }
	    else
	    {
			InitialiseStoreKit();
	    }
    }
	
#endif
}
/*
com.immanitas.KickTheBall.100coins


Buy 100 additional coins
*/