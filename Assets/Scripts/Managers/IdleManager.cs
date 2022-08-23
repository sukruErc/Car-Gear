using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IdleManager : MonoBehaviour
{
    [HideInInspector]
    public int enginePower;

    [HideInInspector]
    public int bodyWeight;

    [HideInInspector]
    public int gearUp;

    [HideInInspector]
    public int gasPedal;

    [HideInInspector]
    public int gasPedalUpTime;

    [HideInInspector]
    public int enginePowerCost;

    [HideInInspector]
    public int bodyWeightCost;

    [HideInInspector]
    public int gearUpCost;

    [HideInInspector]
    public int wallet;

    [HideInInspector]
    public int totalGain;

    [HideInInspector]
    public int AILevel;

    [HideInInspector]
    public int AImotorForce;

    [HideInInspector]
    public int AIrbMass;

    [HideInInspector]
    public int AImaxPushCounter;

    [HideInInspector]
    public int AItotalGearUp;

    [SerializeField] PlayerController player;

    [SerializeField] AICarController AI;

    [SerializeField] GasPedal Gp;

    [SerializeField] TextMeshPro LevelText;
    
    private int[] costs = new int[]
  {
        120,
        151,
        197,
        250,
        324,
        414,
        537,
        687,
        892,
        1145,
        1484,
        1911,
        2479,
        3196,
        4148,
        5359,
        6954,
        9000,
        11687,
        13799,
        16851,
        23528

  };

    /*--------------------------------------------------------------------*/

    public static IdleManager instance;
    private void Awake()
    {

        //RestartGame();

        if (IdleManager.instance)
            UnityEngine.Object.Destroy(gameObject);
        else
            IdleManager.instance = this;

        enginePower = PlayerPrefs.GetInt("EnginePower", 50);
        bodyWeight = PlayerPrefs.GetInt("BodyWeight", 10);
        gearUp = PlayerPrefs.GetInt("GearUp", 1000);

        gasPedalUpTime = PlayerPrefs.GetInt("GasPedalUpTime", 1);
        gasPedal = PlayerPrefs.GetInt("GasPedal", 50);

        AImotorForce = PlayerPrefs.GetInt("AIMotorForce", 50);
        AIrbMass = PlayerPrefs.GetInt("AIRbMass", 10);
        AImaxPushCounter = PlayerPrefs.GetInt("AIMaxPushCounter", 1);
        AItotalGearUp = PlayerPrefs.GetInt("AITotalGearUp", 500);

        AILevel = PlayerPrefs.GetInt("AILevel", 1);

        LevelText.SetText(AILevel.ToString());

        enginePowerCost = costs[enginePower / 5 - 10];
        bodyWeightCost = costs[bodyWeight - 10];
        gearUpCost = costs[gearUp / 100 - 10];

        wallet = PlayerPrefs.GetInt("Wallet", 0);


    }

    /*--------------------------------------------------------------------*/

    public void BuyEnginePower()
    {
        enginePower+=5;
        gasPedal++;
        wallet -= enginePowerCost;       
        enginePowerCost = costs[enginePower/5 - 10];

        PlayerPrefs.SetInt("EnginePower", enginePower);
        PlayerPrefs.SetInt("GasPedal", gasPedal);

        PlayerPrefs.SetInt("Wallet", wallet);

        
        player.UpdateCar();
        Gp.UpdateGasPedal();

        ScreensManager.instance.ChangeScreen(Screens.MAIN);

    }

    public void BuyBodyWeight()
    {
        bodyWeight++;
        wallet -= bodyWeightCost;
        bodyWeightCost = costs[bodyWeight-10];
        PlayerPrefs.SetInt("BodyWeight", bodyWeight);
        PlayerPrefs.SetInt("Wallet", wallet);
        ScreensManager.instance.ChangeScreen(Screens.MAIN);

        player.UpdateCar();
    }

    public void BuyGearUp()
    {
        gearUp = gearUp + 100;
        gasPedalUpTime ++;
        wallet -= gearUpCost;

        gearUpCost = costs[gearUp / 100 - 10];

        PlayerPrefs.SetInt("GearUp", gearUp);
        PlayerPrefs.SetInt("Wallet", wallet);

        PlayerPrefs.SetInt("GasPedalUpTime", gasPedalUpTime);
        ScreensManager.instance.ChangeScreen(Screens.MAIN);


        player.UpdateCar();
        Gp.UpdateGasPedal();
    }

    public void CollectMoney()
    {
        wallet += totalGain;
        PlayerPrefs.SetInt("Wallet", wallet);
        SceneManager.LoadScene(0);
    }

    public void AIUpdate()
    {
        AImotorForce += 10;
        AIrbMass += 2;
        AImaxPushCounter += 1;
        AItotalGearUp += 25;
        AILevel++;

        PlayerPrefs.SetInt("AILevel", AILevel);
        PlayerPrefs.SetInt("AIMotorForce", AImotorForce);
        PlayerPrefs.SetInt("AIRbMass", AIrbMass);
        PlayerPrefs.SetInt("AIMaxPushCounter", AImaxPushCounter);
        PlayerPrefs.SetInt("AITotalGearUp", AItotalGearUp);

        AI.UpdateTheAI();
    }

    public void RestartGame()
    {
        PlayerPrefs.DeleteAll();
    }

}
