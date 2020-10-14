using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class GameManager : MonoBehaviour
{

// =================================================================================
// INITIALIZATION
// =================================================================================
	
    // Initialization of GameManager Instance
    private static GameManager _instance;
    public static GameManager Instance {
        get { 
            if (_instance == null) {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance; } }


    

// =================================================================================
// DECLARATIONS
// =================================================================================

    // Notation class. Used for number format
    public Notation Notation;

    // Saved game gata
    public GameData Data;

    // Player object
    public Player Player;

// =================================================================================
// EXECUTION OF EVENT FUNCTIONS
// =================================================================================
	void Awake() {
		// Create an dont-destroy instance of this gameObject, if one doesn't exist
		if (_instance == null) {
            _instance = this; 
            GameObject.DontDestroyOnLoad(gameObject);
        }

        // Create objects
        Notation = new Notation();
        Data = new GameData();
        Player = new Player();

		// reduser frame rate for å spare minne
		Application.targetFrameRate = 60;
		
		//Save Game Coroutine
		//StartCoroutine(SaveGame()); 
	}


    // Start is called before the first frame update
    void Start() {
        
		// DETTE ER LOAD!
		//SaveSystem.LoadGame(ref Data);
		
		// kommenter ut denne for å starte "på scratch" ved hver load
		//ResetProgress();

        

		/*
		SoundManager.Instance.SetSoundAndMusic();
		StationManager.Instance.InitializeWorkers<Scientist>(Constants.MAX_NUMBER_OF_SCIENTISTS);
		StationManager.Instance.InitializeWorkers<Investor>(Constants.MAX_NUMBER_OF_SCIENTISTS);
        StationManager.Instance.InitializeStations();

		// Update notation text in settings menu.
		if (PlayerManager.Instance.data.savedNotation != 1){
			PlayerManager.Instance.notation.CurrentNotation = PlayerManager.Instance.data.savedNotation - 1;
			MenuManager.Instance.ToggleNotationType();
		} else{
			PlayerManager.Instance.notation.CurrentNotation = PlayerManager.Instance.notation.GetTotalNotationTypes();
			MenuManager.Instance.ToggleNotationType();
		}
        */
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


#region saveLoadFunctions

    IEnumerator SaveGame() {
        while (true) {
            yield return new WaitForSeconds(5);
            SaveProgress();
            Debug.Log("Game saved!");
        }
    }

    private void SaveProgress() {
        SaveSystem.SaveGame(Data);
    }

    private void ResetProgress() {
        GameManager.Instance.Data.FullReset();
    }

#endregion 


}
