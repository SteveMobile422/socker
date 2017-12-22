using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RevMobControler : MonoBehaviour {
    private static readonly Dictionary<String, String> REVMOB_APP_IDS = new Dictionary<String, String>() {
        { "Android", "5106bea78e5bd71500000098"},
        { "IOS", "51ff5d3c11a83d2ee5000013" }
    };
    public RevMob revmob;

    void Start() {
        revmob = RevMob.Start(REVMOB_APP_IDS, "RevMobObject");
    }
}
