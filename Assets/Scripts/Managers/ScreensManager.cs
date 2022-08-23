using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreensManager : MonoBehaviour
{
    private GameObject currentSceen;

    [Header("UI Attributes")]
    public GameObject mainScreen;
    public GameObject gameScreen;
    public GameObject endScreen;
    public GameObject loseScreen;

    public Button enginePowerButton;
    public Button bodyWeightButton;
    public Button gearUpButton;

    public Text gameScreenMoney;

    public Text enginePowerValueText;
    public Text enginePowerCostText;

    public Text bodyWeightValueText;
    public Text bodyWeightCostText;

    public Text gearUpValueText;
    public Text gearUpCostText;

    public Text endScreenMoney;
    public Text endScreenLoseMoney;

    private int gameCount;

    [Header("Outside Attributes")]
    [SerializeField] public GameObject gearUpSign;

    [SerializeField] public Slider counterSlider;

    [SerializeField] public GameObject carBrokenSign;

    /*--------------------------------------------------------------------*/

    public static ScreensManager instance;
    private void Awake()
    {
        if (ScreensManager.instance)
            Destroy(base.gameObject);
        else
            ScreensManager.instance = this;

        currentSceen = mainScreen;
        gearUpSign.SetActive(false);
    }

    void Start()
    {
        CheckIdles();
        UpdateTexts();
    }

    /*--------------------------------------------------------------------*/

    public void ChangeScreen(Screens screen)
    {
        currentSceen.SetActive(false);
        switch (screen)
        {
            case Screens.MAIN:
                currentSceen = mainScreen;
                UpdateTexts();
                CheckIdles();
                break;

            case Screens.GAME:
                currentSceen = gameScreen;
                gameCount++;
                break;

            case Screens.END:
                currentSceen = endScreen;
                SetEndScreenMoney();
                break;

            case Screens.LOSE:
                currentSceen = loseScreen;
                SetLoseScreenMoney();
                break;

        }
        currentSceen.SetActive(true);
    }

    public void SetEndScreenMoney()
    {
        endScreenMoney.text = "$" + IdleManager.instance.totalGain;
    }

    public void SetLoseScreenMoney()
    {
        endScreenLoseMoney.text = "$" + IdleManager.instance.totalGain;
    }
    
    public void CheckIdles()
    {
        int enginePowerCost = IdleManager.instance.enginePowerCost;
        int bodyWeightCost = IdleManager.instance.bodyWeightCost;
        int gearUpCost = IdleManager.instance.gearUpCost;
        int wallet = IdleManager.instance.wallet;

        if (wallet < enginePowerCost)
            enginePowerButton.interactable = false;
        else
            enginePowerButton.interactable = true;

        if (wallet < bodyWeightCost)
            bodyWeightButton.interactable = false;
        else
            bodyWeightButton.interactable = true;

        if (wallet < gearUpCost)
            gearUpButton.interactable = false;
        else
            gearUpButton.interactable = true;
    }

    public void UpdateTexts()
    {
        gameScreenMoney.text = "$" + IdleManager.instance.wallet;

        enginePowerCostText.text = "$" + IdleManager.instance.enginePowerCost;
        enginePowerValueText.text = IdleManager.instance.enginePower + " HP";

        bodyWeightCostText.text = "$" + IdleManager.instance.bodyWeightCost;
        bodyWeightValueText.text = IdleManager.instance.bodyWeight + " Tonne";

        gearUpCostText.text = "$" + IdleManager.instance.gearUpCost;
        gearUpValueText.text = IdleManager.instance.gearUp + " GP";
    }

    public void GearUpSetActive(bool a)
    {
        gearUpSign.SetActive(a);
    }

}
