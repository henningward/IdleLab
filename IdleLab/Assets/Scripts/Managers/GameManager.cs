using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

// =================================================================================
// INITIALIZATION
// =================================================================================
	
    // Initialization of GameManager Instance
    private static GameManager instance;
    public static GameManager Instance {
        get { 
            if (instance == null) {
                instance = FindObjectOfType<GameManager>();
            }
            return instance; } }

// =================================================================================
// EXECUTION OF EVENT FUNCTIONS
// =================================================================================
	void Awake() {
		// Create an dont-destroy instance of this gameObject, if one doesn't exist
		if (instance == null) {
            instance = this; 
            GameObject.DontDestroyOnLoad(gameObject);
        }

		// reduser frame rate for å spare minne
		Application.targetFrameRate = 60;
		
		//Save Game Coroutine
		//StartCoroutine(SaveGame()); 
	}


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
		// Handle click on back button on Android
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKey (KeyCode.Escape))
			{
				Application.Quit ();
			}
		}
    }

}
