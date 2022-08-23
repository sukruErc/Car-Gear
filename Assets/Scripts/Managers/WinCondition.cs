using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] IdleManager aiCarControllerStats;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Time.timeScale = 0;
        GameIsWin();
    }

    public void GameIsWin()
    {
        aiCarControllerStats.AIUpdate();
        IdleManager.instance.totalGain = 300;
        ScreensManager.instance.ChangeScreen(Screens.END);
    }
}
