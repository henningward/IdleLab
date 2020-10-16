using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;


public class GameUIText : Singleton<GameUIText>
{
    public Text MoneyText;
    public Text ResearchPointsText;
    public Text RecruitmentPointsText;


    /// <summary>
    /// override to prevent use of DontDestroyOnLoad, as the gameobject associated with GameUIText already contains DontDestroyOnLoad
    /// </summary>
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
    }
    

}

