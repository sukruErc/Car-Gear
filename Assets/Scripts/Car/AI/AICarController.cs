using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarController : CarController
{
    public float totalGearUp;
    public float maxPushCounter = 2f;

    public int AILevel;
    
    [SerializeField] public GameObject[] AIBody;

    /*--------------------------------------------------------------------*/

    private void Awake()
    {        
        UpdateTheAI();

        if (AILevel < AIBody.Length)
        {
            AIBody[AILevel - 1].SetActive(true);

            if (AILevel >= 2)
            {
                AIBody[AILevel - 2].SetActive(false);
            }
        }

        if (AILevel >= AIBody.Length)
        {
            AIBody[AIBody.Length - 1].SetActive(true);
        }

    }

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f+ UnityEngine.Random.Range(0,maxPushCounter));
            AddForceToAI();
        }
    }

    /*--------------------------------------------------------------------*/

    public void AddForceToAI()
    {
        rb.AddForce(transform.forward * (totalGearUp + UnityEngine.Random.Range(-totalGearUp , (totalGearUp/2))));
    }

    public void UpdateTheAI()
    {
        motorForce= IdleManager.instance.AImotorForce;

        float rbValue = (IdleManager.instance.AIrbMass/2);
        rb.mass = 5 + rbValue;

        float maxPush = 2.1f - (IdleManager.instance.AImaxPushCounter / 10) ;
        maxPushCounter = IdleManager.instance.AImaxPushCounter;

        totalGearUp = IdleManager.instance.AItotalGearUp;

        int level = IdleManager.instance.AILevel;

        AILevel = level;
    }

}
