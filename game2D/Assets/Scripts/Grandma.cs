using UnityEngine;
using System.Collections;

public class Grandma : MonoBehaviour {

    [HideInInspector, SerializeField] private int health;
    [HideInInspector, SerializeField] private int power;
    [HideInInspector, SerializeField] private int special;

    [ExposeProperty] public int Health { get { return health; } set { if (value < 0) health = 0; else health = value; } }
    [ExposeProperty] public int Power { get { return power; } set { if (value < 0) power = 0; else power = value; } }
    [ExposeProperty] public int Special { get { return special; } set { if (value < 0) special = 0; else special = value; } }


    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
