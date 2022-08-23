using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Time.timeScale = 0;
        GameIsLost();
    }

    public void GameIsLost()
    {
        IdleManager.instance.totalGain = 50;
        ScreensManager.instance.ChangeScreen(Screens.LOSE);
    }
}
