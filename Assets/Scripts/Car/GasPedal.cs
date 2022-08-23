using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class GasPedal : MonoBehaviour
{
    [SerializeField] PlayerController playerPush;
    
    [SerializeField] ScreensManager screenManager;
    
    private float counter;

    private float breakCounter;


    private bool startCountDown;

    public bool gameIsOn;


    public float gasPedalSpeed;

    public float gearUpTime;


    /*--------------------------------------------------------------------*/

    private void Awake()
    {
        UpdateGasPedal();
    }

    void Start()
    {
        counter = 0;
        breakCounter = 0;
    }

    private void Update()
    {
        screenManager.counterSlider.value = counter;

        if (gameIsOn && IsPointerOverUIObject())
        {
            if (CrossPlatformInputManager.GetButton("GasPedal")||CrossPlatformInputManager.GetButtonDown("GasPedal"))
            {
                startCountDown = false;
                counter += Time.deltaTime * gasPedalSpeed;
            }        

            if (CrossPlatformInputManager.GetButtonUp("GasPedal"))
            {

                if (counter < 60)
                    StartCoroutine(GasPedalDown(0));

                if (counter >= 60 && counter <= 80)
                {
                    StartCoroutine(GasPedalDown(1));                                      
                }

                if (counter >= 80 && counter <= 101)
                {
                    StartCoroutine(GasPedalDown(0.5f));
                }
            }
        }     

        if (startCountDown)
        {
            counter -= Time.deltaTime * gasPedalSpeed * 2;
        }

        if (counter < 0)
        {
            counter = 0;
        }

        if (counter < 80)
        {
            breakCounter = 0;
        }

        if (counter >= 80 && counter <= 101)
        {
            breakCounter += Time.deltaTime;

            if (breakCounter >= 2.5f)
            {
                playerPush.BreakTheCar();
                screenManager.carBrokenSign.SetActive(true);
                screenManager.GearUpSetActive(false);
                startCountDown = true;
                gameIsOn = false;
            }
        }

        if (counter >= 100)
        {
            counter = 100;
        }

    }

    /*--------------------------------------------------------------------*/

    IEnumerator GasPedalDown(float gas)
    {
        gameIsOn = false;
        startCountDown = true;
        playerPush.PushTheCar(gas);

        screenManager.GearUpSetActive(true);

        yield return new WaitForSeconds(gearUpTime);

        screenManager.GearUpSetActive(false);

        gameIsOn = true;
    }

    public void UpdateGasPedal()
    {
        gasPedalSpeed = IdleManager.instance.gasPedal;

        float gup = IdleManager.instance.gasPedalUpTime;

        gearUpTime = 2 - (gup/10);
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

}
