using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using static BreakInfinity.BigDouble;


public class Constants {

    // DEFINITIONS


    // sufficies for notation

    public static readonly string[] suffices =
    {"K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc", "Ud",
    "Dd", "Td", "Qad", "Qid", "Sxd", "Spd", "Od", "Nd", "V", "Uv", "Dv",
    "Tv", "Qav", "Qiv", "Sxv", "Spv", "Ov", "Nv", "Tg", "Utg", "Dtg", "Ttg",
    "Qatg", "Qitg", "Sxtg", "Sptg", "Otg", "Ntg", "Qaa", "Uqa", "Dqa", "Tqa",
    "Qaqa", "Qiqa", "Sxqa", "Spqa", "Oqa", "Nqa", "Qia", "Uqi", "Dqi",
    "Tqi", "Qaqi", "Qiqi", "Sxqi", "Spqi", "Oqi", "Nqi", "Sxa", "Usx",
    "Dsx", "Tsx", "Qasx", "Qisx", "Sxsx", "Spsx", "Osx", "Nsx", "Spa",
    "Usp", "Dsp", "Tsp", "Qasp", "Qisp", "Sxsp", "Spsp", "Osp", "Nsp",
    "Og", "Uog", "Dog", "Tog", "Qaog", "Qiog", "Sxog", "Spog", "Oog",
    "Nog", "Na", "Un", "Dn", "Tn", "Qan", "Qin", "Sxn", "Spn", "On",
    "Nn", "Ct", "Uc"};

    public static readonly string[] sufficies2 = 
    {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
		

        

/*
    // DEFINITIONS
    public const int MAX_NUMBER_OF_STATIONS = 6;
    public const int MAX_WORKERS_PER_STATION = 4;
    public const int MAX_WORKERS = 60;
    public const int MAX_NUMBER_OF_SCIENTISTS = 30;
    public const int MAX_NUMBER_OF_INVESTORS = 30;
    public const int WORKER_POOL_INDEX = -1;
    

    // STATION UNLOCK PRICE ("slot", not station type)
    public static readonly BigDouble[] UNLOCK_STATION_COST = {4, 60, 720, 8640, 103680, 1500000};
    
    #region RESEARCH STATION

    public static readonly BigDouble[] RESEARCH_DURATION_INIT = {1, 3, 6, 12, 24, 48};
    public static readonly BigDouble[] RESEARCH_GROWTH_RATES = {1.07, 1.15, 1.14, 1.13, 1.12, 1.11};

    public static readonly BigDouble[] RESEARCH_REVENUE_INIT = {1, 60, 540, 4320, 51840, 65000};
    public static readonly BigDouble[] STATION_LEVEL_UPGRADE_COST_INIT = {100, 1000, 10000, 100000, 1000000, 10000000};
    
    // SOFT PRESTIGE AKA STATION LEVEL
    // Initial price for station level upgrades
    public static readonly BigDouble[] RESEARCH_STATION_LEVEL_UPGRADE_COST_INIT = 
    {100, 1000, 10000, 100000, 1000000, 10000000};
    // Growth rate per station level upgrade
    public static readonly BigDouble[] RESEARCH_STATION_LEVEL_UPGRADE_GROWTH_RATE = 
    {2e2, 5e4, 12e6, 1e8, 1e12, 1e20};
    // Revenue reward per station level upgrade
    public static readonly BigDouble[] RESEARCH_STATION_LEVEL_REWARD_MULTIPLIER = 
    {6e2, 1e3, 1e3, 1e3, 1e3, 1e3};
    // Price multiplier for research upgrade between each station level upgrade
    public static readonly BigDouble[] RESEARCH_STATION_LEVEL_PRICE_MULTIPLIER = 
    {2e3, 3e3, 12e3, 11e3, 13e3, 1e3};

    #endregion

    public static readonly BigDouble[] RESEARCH_PRODUCTION_UPGRADE_COST_INIT = {4, 60, 720, 8640, 103680, 1500000};
    public const string RESEARCH_STATION_NAME = "ResearchStation";
    public const string RESEARCH_STATION_VISIBLE_NAME = "RESEARCH LAB";
    public const string RESEARCH_STATION_DESCRIPTION = "A workstation for scientists. Buy to increases the production of research points that can be used for upgrades or sold for cash!";
    public const string RESEARCH_STATION_WORKER_TYPE = "SCIENTIST";
    public static readonly Color32 RESEARCH_STATION_THEME_COLOR = new Color32(21,180,255,255);



    #region FINANCE STATION

    public static readonly BigDouble[] FINANCE_DURATION_INIT = {3, 9, 20, 30, 80, 200};
    public static readonly BigDouble[] FINANCE_GROWTH_RATES = {1.08, 1.16, 1.15, 1.14, 1.11, 1.11};
    public static readonly BigDouble[] FINANCE_REVENUE_INIT = {1, 60, 540, 4320, 51840, 65000};
    
    // SOFT PRESTIGE AKA STATION LEVEL
    // Initial price for station level upgrades
    public static readonly BigDouble[] FINANCE_STATION_LEVEL_UPGRADE_COST_INIT = 
    {1000, 10000, 100000, 1000000, 10000000, 100000000};
    // Growth rate per station level upgrade
    public static readonly BigDouble[] FINANCE_STATION_LEVEL_UPGRADE_GROWTH_RATE = 
    {1.5e2, 12e4, 1e6, 1e8, 1e12, 1e20};
    // Revenue reward per station level upgrade
    public static readonly BigDouble[] FINANCE_STATION_LEVEL_REWARD_MULTIPLIER = 
    {15e3, .2e3, 1e3, 1e3, 1e3, 1e3};
    // Price multiplier for finance upgrade between each station level upgrade
    public static readonly BigDouble[] FINANCE_STATION_LEVEL_PRICE_MULTIPLIER = 
    {2e3, 3e3, 4e3, 5e3, 6e3, 7e3};

    #endregion

    public static readonly BigDouble[] FINANCE_PRODUCTION_UPGRADE_COST_INIT = {4, 60, 720, 8640, 103680, 1500000};
    public const string FINANCE_STATION_NAME = "FinanceStation";
    public const string FINANCE_STATION_VISIBLE_NAME = "OFFICE";
    public const string FINANCE_STATION_DESCRIPTION = "Every lab need an office to handle the finances. Hire economists to help automate the conversion of research-selling!";
    public const string FINANCE_STATION_WORKER_TYPE = "INVESTOR";
    public static readonly Color32 FINANCE_STATION_THEME_COLOR = new Color32(241,178,49,255);
    
    // SCIENTISTS
    // insp https://www.quora.com/What-is-the-job-title-hierarchy-amongst-software-engineers
    public static readonly string[] SCIENTIST_TITLES = {"Intern", "Junior Scientist", "Senior Scientist", "Lead Scientist", "Science Director"};
    public static readonly BigDouble[] SCIENTIST_REVENUE_BASE_BONUS = {1, 1e2, 1e5, 1e8, 1e10};
    public static readonly BigDouble[] SCIENTIST_DURATION_BASE_BONUS = {0.1, 5, 26, 100, 360};
    public static readonly BigDouble[] SCIENTIST_SALARY_BASE = {1, 5, 26, 100, 360};
    
    // INVESTORS / FINANCE GUYS
    public static readonly string[] INVESTOR_TITLES = {"Summer Associate", "Junior Associate", "Senior Associate", "Partner", "Managing Partner"};
    public static readonly BigDouble[] INVESTOR_REVENUE_BASE_BONUS = {1, 1e2, 1e5, 1e8, 1e10};
    public static readonly BigDouble[] INVESTOR_DURATION_BASE_BONUS = {0.1, 5, 26, 100, 360};
    public static readonly BigDouble[] INVESTOR_SALARY_BASE = {0, 5, 26, 100, 360};
    

    // CONSTANTS FOR ADVERTISMENT METHODS
    public const int AD_DURATION_LONG = 30; //seconds
    public const int AD_DURATION_MEDIUM = 15; //seconds
    public const int AD_DURATION_SHORT = 5; //seconds

    // COLORS
    public static readonly Color32 WHITE_COLOR = new Color32(255,255,255,255);
    public static readonly Color32 BLUE_COLOR = new Color32(83,133,255,255);
    public static readonly Color32 CURRENCY_ADD_COLOR = new Color32(16,255,0,255);
    public static readonly Color32 CURRENCY_SUBTRACT_COLOR = new Color32(255,0,0,255);

    // GAME CONTENT
    public static readonly string[] RESEARCH_TITLE = {"Test A", 
        "Test 2", 
        "Test 3", 
        "Test 4", 
        "Test 5", 
        "Test 6"
    };

    public static readonly string[] RESEARCH_DESCRIPTION = {
        "Forskning på når Joakim får Corona hvis han fortsetter med kjøret sitt.",
        "Forskning på hvorfor Sigurd ikke får pult.",
        "Hvorfor er himmelen blå og sola gul?",
        "Skal du høre en vits? Katta med slips. Vil du høre en til?",
        "En, To, Tre, Fire, Fem, Seks, Sju, Åtte, Ni, Ti, Elleve, Tolv.",
        "Forskning på kreft som kurerer kreft med mer kreft.",
    };

    public static readonly string[] FINANCE_TITLE = {"Finance A", 
        "Finance 2", 
        "Finance 3", 
        "Test 4", 
        "Test 5", 
        "Test 6"
    };

    public static readonly string[] FINANCE_DESCRIPTION = {
        "Invester forskningen på craig's list.",
        "Invester forskning hos en kompis",
        "Selg forskningen til en videregående skole",
        "Auksjoner bort forskning",
        "Oprett forskning.no, tjen cash",
        "En, To, Tre, Fire, Fem, Seks, Sju, Åtte, Ni, Ti, Elleve, Tolv.",
    };

    public static readonly string[] suffices =
    {"K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc", "Ud",
    "Dd", "Td", "Qad", "Qid", "Sxd", "Spd", "Od", "Nd", "V", "Uv", "Dv",
    "Tv", "Qav", "Qiv", "Sxv", "Spv", "Ov", "Nv", "Tg", "Utg", "Dtg", "Ttg",
    "Qatg", "Qitg", "Sxtg", "Sptg", "Otg", "Ntg", "Qaa", "Uqa", "Dqa", "Tqa",
    "Qaqa", "Qiqa", "Sxqa", "Spqa", "Oqa", "Nqa", "Qia", "Uqi", "Dqi",
    "Tqi", "Qaqi", "Qiqi", "Sxqi", "Spqi", "Oqi", "Nqi", "Sxa", "Usx",
    "Dsx", "Tsx", "Qasx", "Qisx", "Sxsx", "Spsx", "Osx", "Nsx", "Spa",
    "Usp", "Dsp", "Tsp", "Qasp", "Qisp", "Sxsp", "Spsp", "Osp", "Nsp",
    "Og", "Uog", "Dog", "Tog", "Qaog", "Qiog", "Sxog", "Spog", "Oog",
    "Nog", "Na", "Un", "Dn", "Tn", "Qan", "Qin", "Sxn", "Spn", "On",
    "Nn", "Ct", "Uc"};

    public static readonly string[] sufficies2 = 
    {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
		
    #region MULTIPLIERS
    // Multiplier for calculating cost of next station level 
    public static readonly BigDouble[,] STATION_LEVEL_UPGRADE_MULTIPLIER = new BigDouble[,] {
        {1, 1e8},
        {1, 1e3},
        {1, 1e3},
        {1, 1e3},
        {1, 1e3},
        {1, 1e3}
    };
    
    //COMMENT: Hva er dette til? Er Topic denne bonusen vi snakket om? f.eks. ved 25/50/100/200 etc?
    // SVAR: Nei, dette er multiplier for hver soft prestige (research på kreft -> klamydiakur for Joakim)
    // Multipliers for calculating click / scientist rewards after research prestige 


    

    #endregion
 */   
}
