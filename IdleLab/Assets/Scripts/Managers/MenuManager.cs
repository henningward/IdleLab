using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using BreakInfinity;
using static BreakInfinity.BigDouble;
public class MenuManager : MonoBehaviour
{

    #region Declarations

    // SINGLETON ACCESSABILITY
    private static MenuManager _instance;
    public static MenuManager Instance {
        get {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MenuManager> ();
            }
            return _instance;
        }
    }

    // REFERENCES ==>
    private Notation Notation;
    private GameData Data;


    // MAIN UI ==>
    public GameObject Main_topNavigation;
    public GameObject Main_bottomNavigation;
    public GameObject Main_upgradeNavigation;
    public Text MoneyText;
    public Text ResearchPointsText;
    public Text RecruitmentPointsText;

    #endregion


    // Awake is called before Start
    void Awake() {
        if (_instance == null) {
            // Create an dont-destroy-instance of this gameObject, if one doesn't already exist
            _instance = this;
            GameObject.DontDestroyOnLoad (gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        Notation = GameManager.Instance.Notation;
        Data = GameManager.Instance.Data;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Main:
                Debug.Log ("main menu");
                break;
            case MenuName.Sound:
                Debug.Log("sound menu");
                break;
        }
    }
}
