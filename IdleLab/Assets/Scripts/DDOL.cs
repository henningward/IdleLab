using UnityEngine;

public class DDOL:MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // Debug.Log("DDOL " + gameObject.name);
        //  https://stackoverflow.com/questions/35890932/unity-game-manager-script-works-only-one-time/35891919#35891919
    }
}