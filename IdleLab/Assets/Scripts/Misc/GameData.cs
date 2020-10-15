using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using static BreakInfinity.BigDouble;
using System;

[Serializable]
public class GameData {

    // GENERAL    
    private BigDouble _researchPoints;
    public BigDouble ResearchPoints {
        get { return _researchPoints; }
        set {   
            _researchPoints = value;
            GameUIText.GetInstance().ResearchPointsText.text = (value <= 10000) ? value.ToString("F0") : GameManager.GetInstance().Notation.Prettify(value, 2);
        }
    }
    
    private BigDouble _money;
    public BigDouble Money {
        get { return _money; }
        set { 
            _money = value; 
            GameUIText.GetInstance().MoneyText.text = (value <= 10000) ? value.ToString("F0") :  GameManager.GetInstance().Notation.Prettify(value, 2);
        }
    }

    private BigDouble _recruitmentPoints;
    public BigDouble RecruitmentPoints {
        get { return _recruitmentPoints; }
        set {
            _recruitmentPoints = value;
            GameUIText.GetInstance().RecruitmentPointsText.text = (value <= 10000) ? value.ToString("F0") :  GameManager.GetInstance().Notation.Prettify(value, 2);
        }
    }

    public int savedNotation;

/*
    public BigDouble currentBuyMultiplier;
    
    public int savedNotation;
    

    public int unlockedExtraStations;

    // STATION
    public bool[] Station_UnlockStatus = new bool[Constants.MAX_NUMBER_OF_STATIONS];
    public BigDouble[] Station_UnlockCost = new BigDouble[Constants.MAX_NUMBER_OF_STATIONS];
    public string[] Station_Type = new String[Constants.MAX_NUMBER_OF_STATIONS];

    public int[] Research_Station_Level = new int[Constants.MAX_NUMBER_OF_STATIONS];
    public int[] Finance_Station_Level = new int[Constants.MAX_NUMBER_OF_STATIONS];
    
    public BigDouble[] Station_LevelUpgradeCost = new BigDouble[Constants.MAX_NUMBER_OF_STATIONS];

    // RESEARCH
    public BigDouble[] Research_Level = new BigDouble[Constants.MAX_NUMBER_OF_STATIONS];
   	// public int[] Research_ScientistsHired = new int[Constants.MAX_NUMBER_OF_STATIONS];
    public BigDouble ResearchDuration_Cap;
    public BigDouble Research_globalRPMultiplier;

    // FINANCE
    public BigDouble[] Finance_Level = new BigDouble[Constants.MAX_NUMBER_OF_STATIONS];
   	public int[] Finance_InvestorsHired = new int[Constants.MAX_NUMBER_OF_STATIONS];
    public BigDouble FinanceDuration_Cap;
    public BigDouble Finance_globalRPMultiplier;


    // PLAYER WORKER (BASE TING SKAL BORT)
    public int PlayerWorker_currentStation;
    public BigDouble PlayerWorker_DurationBaseBonus;
    public BigDouble PlayerWorker_RevenueBaseBonus;


    // SCIENTISTS
    public int[] Scientist_CurrentStation           = new int[Constants.MAX_NUMBER_OF_SCIENTISTS];
    public bool[] Scientist_UnlockStatus            = new bool[Constants.MAX_NUMBER_OF_SCIENTISTS];
    public int[] Scientist_ScientistType            = new int[Constants.MAX_NUMBER_OF_SCIENTISTS];
    public BigDouble[] Scientist_Level              = new BigDouble[Constants.MAX_NUMBER_OF_SCIENTISTS];
    public BigDouble[] Scientist_SalaryIncrease     = new BigDouble[Constants.MAX_NUMBER_OF_SCIENTISTS];

    // INVESTORS
    public int[]  Investor_CurrentStation           = new int[Constants.MAX_NUMBER_OF_INVESTORS];
    public bool[] Investor_UnlockStatus            = new bool[Constants.MAX_NUMBER_OF_INVESTORS];
    public int[]  Investor_InvestorType            = new int[Constants.MAX_NUMBER_OF_INVESTORS];
    public BigDouble[] Investor_Level              = new BigDouble[Constants.MAX_NUMBER_OF_INVESTORS];
    public BigDouble[] Investor_SalaryIncrease     = new BigDouble[Constants.MAX_NUMBER_OF_INVESTORS];

    // SETTINGS
    public bool musicOn;
    public bool soundOn;
    public bool vfxOn;
    */
    
    public GameData(){
        
        //FullReset();

        //coins;
        //coinsClickValue;
        
    }

    public void FullReset(){
        
        ResearchPoints = 100;
        Money = 100;
        RecruitmentPoints = 100;

        savedNotation = 1;
    }
/*
    public void FullReset(){
        researchPoints = 100;
        money = 1e2;
        virusPoints = 0;
        currentBuyMultiplier = 1;
        savedNotation = 1;
        ResearchDuration_Cap = 0.5;
        FinanceDuration_Cap = 0.5;

        Finance_globalRPMultiplier = 1;

        unlockedExtraStations = 1; // 1 extra is currently max
        PlayerWorker_currentStation = -1;
        PlayerWorker_DurationBaseBonus = 1.1;
        PlayerWorker_RevenueBaseBonus = 0.9;

        // Set cost and base-cost to initial values when reset.
        for (int i=0; i<Constants.MAX_NUMBER_OF_STATIONS; i++) {
            if (i == 0) { Station_UnlockStatus[i] = true; }
            else { Station_UnlockStatus[i] = false; }
            
            Station_Type[i]                     = Constants.RESEARCH_STATION_NAME;

            Station_LevelUpgradeCost[i]         = Constants.STATION_LEVEL_UPGRADE_COST_INIT[i];

            Research_Level[i]                   = 0;
            Research_Station_Level[i]           = 0;
            // Research_ScientistsHired[i]         = 0;
		        
            Finance_Level[i]                    = 0;
            Finance_Station_Level[i]            = 0;
            Finance_InvestorsHired[i]           = 0;

        }

        for (int i=0; i<Constants.MAX_NUMBER_OF_SCIENTISTS; i++) {
            Scientist_CurrentStation[i] = -1;
            Scientist_UnlockStatus[i] = false;
            Scientist_ScientistType[i] = 0;
            Scientist_Level[i] = 0;
            Scientist_SalaryIncrease[i] = 0;
		}	

        
        for (int i=0; i<Constants.MAX_NUMBER_OF_INVESTORS; i++) {
            Investor_CurrentStation[i] = -1;
            Investor_UnlockStatus[i] = false;
            Investor_InvestorType[i] = 0;
            Investor_Level[i] = 0;
            Investor_SalaryIncrease[i] = 0;
		}

        // SETTINGS
        musicOn = true;
        soundOn = true;
        vfxOn = true;
    }
    */
}
