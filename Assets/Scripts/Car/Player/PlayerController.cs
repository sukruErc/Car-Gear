using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CarController
{
    public int enginePower;
    public int bodyWeight;
    public int gearUp;

    /*--------------------------------------------------------------------*/

    private void Awake()
    {
        UpdateCar();
    }

    /*--------------------------------------------------------------------*/

    public void UpdateCar()
    {
        enginePower = IdleManager.instance.enginePower;
        bodyWeight = IdleManager.instance.bodyWeight;
        gearUp = IdleManager.instance.gearUp;

        motorForce = enginePower;
        
        float bodyWeightValue = (float)bodyWeight;

        rb.mass = bodyWeightValue + 1f;
    }

    public void PushTheCar(float multiplier)
    {
        rb.AddForce(transform.forward * gearUp * multiplier);
    }

    public void BreakTheCar()
    {
        motorForce = 0;
        rb.AddForce(-transform.forward * (200));
    }

}
