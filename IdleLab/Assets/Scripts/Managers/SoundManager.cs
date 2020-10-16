using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager> {
    
// =================================================================================
// INITIALIZATION
// =================================================================================
    
    // Initalization of AudioSources here
    private AudioSource musicSource;
    private AudioSource soundSource;

    // Initalization of soundclips (ALL soundclips must be in folder named 'Resources')
    // Example: 
    // private static AudioClip someSound; 
    GameData data;

    // Initialization of other objects below here
    public GameObject soundToggleButton;
    public GameObject musicToggleButton;
    public Sprite  soundON, soundOFF;
    public Sprite musicON, musicOFF;
    

// =================================================================================
// EXECUTION OF EVENT FUNCTIONS
// =================================================================================

    // Awake is the first Event Function to trigger 
    // Important to Initialize Manager Objects immediately on scene load
    protected override void Awake()
    {

        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        
        soundSource = transform.GetChild (0).gameObject.GetComponent<AudioSource>();
        musicSource = transform.GetChild (1).gameObject.GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start() {
        // Example: 
        // someSound = Resources.Load<AudioClip>("/Sounds/somesound");
    }

// =================================================================================
// OTHER METHODS
// =================================================================================

    // Method: PlayOneShot of given sound
    public void PlayThisSound(string identifier) {
        switch (identifier) {
            case "someSound":
                // Example: 
                // soundSource.PlayOneShot(someSound);
                break;
        }
    }

    // Method: Toggle sound on/off from UI button
    public void ToggleSoundButton() {
        
        data = GameManager.GetInstance().Data;
        // soundToggleButton.GetComponent<Animator>().SetTrigger("Click");
        if (soundSource.mute) {
            soundSource.mute = false;
            //soundToggleButton.GetComponent<Image>().sprite = soundON;
            data.soundOn = true;
        } else {
            soundSource.mute = true;
            //soundToggleButton.GetComponent<Image>().sprite = soundOFF;
            data.soundOn = false;
        }
    }

    public void ToggleMusicButton() {
        data = GameManager.GetInstance().Data;
        if (musicSource.mute) {
            musicSource.mute = false;
			//musicToggleButton.GetComponent<Image> ().sprite = musicON;
            data.musicOn = false;
        } else {
            musicSource.mute = true;
			//musicToggleButton.GetComponent<Image> ().sprite = musicOFF;
            data.musicOn = true;
        }
    }

    public void SetSoundAndMusic() {
        data = GameManager.GetInstance().Data;
		if (data.musicOn) {
			musicSource.mute = false;
			// musicToggleButton.GetComponent<Image> ().sprite = musicON;
			// musicButton.transform.GetChild (1).GetComponent<Text> ().text = "Music: ON";
		} else { 
			musicSource.mute = true;
			// musicToggleButton.GetComponent<Image> ().sprite = musicOFF;
			// musicButton.transform.GetChild (1).GetComponent<Text> ().text = "Music: OFF";
		}

		if (data.soundOn) {
			soundSource.mute = false;
			// musicToggleButton.GetComponent<Image> ().sprite = musicON;
			// soundButton.transform.GetChild (1).GetComponent<Text> ().text = "SFX: ON";
		} else {
			soundSource.mute = true;
			// musicToggleButton.GetComponent<Image> ().sprite = musicOFF;
			// soundButton.transform.GetChild (1).GetComponent<Text> ().text = "SFX: OFF";
		}
    }
}
