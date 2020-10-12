using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class PlayerManager : MonoBehaviour {

    // Initialization of Instance
    private static PlayerManager instance;
    public static PlayerManager Instance {
        get { 
            if (instance == null) {
                instance = FindObjectOfType<PlayerManager>();
            }
            return instance; } 
    }



    // All data for saving
	//public PlayerData data;

    // Employees 
    //public PlayerWorker playerWorker;
    
    void Awake()
    {
		if (instance == null) {
            // Create an dont-destroy instance of this gameObject, if one doesn't exist
            instance = this; 
            GameObject.DontDestroyOnLoad(gameObject);
        }
        //data = new PlayerData();
        
        //playerWorker = new PlayerWorker();
    }
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }


}


