using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] GasPedal gasPedal;

    [SerializeField] 

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartEngine()
    {
        Time.timeScale = 1;
        ScreensManager.instance.ChangeScreen(Screens.GAME);
        StartCoroutine(StartTheGame());
    }

    IEnumerator StartTheGame()
    {
        yield return new WaitForSeconds(0.2f);
        gasPedal.gameIsOn = true;

    }
   
}
