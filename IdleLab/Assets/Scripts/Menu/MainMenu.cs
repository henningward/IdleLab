using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Button>().onClick.AddListener(StartGame);
    }
    private void StartGame(){
        CanvasManager.GetInstance().SwitchCanvas(CanvasType.GameUI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
