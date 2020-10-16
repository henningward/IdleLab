using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CanvasType
{
    MainMenu,
    GameUI,
    SomethingElse
}

public class CanvasManager : Singleton<CanvasManager>
{
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;

 
    private GameObject canvasParent;

    protected override void Awake()
    {
        base.Awake();
        canvasParent = GameObject.Find("MainCanvas");
        canvasControllerList = canvasParent.GetComponentsInChildren<CanvasController>().ToList();

        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));

        //SwitchCanvas(CanvasType.MainMenu);
        SwitchCanvas(CanvasType.GameUI);
    
    }

    public void SwitchCanvas(CanvasType _type)
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else { Debug.LogWarning("The desired canvas was not found!"); }
    }
 }














