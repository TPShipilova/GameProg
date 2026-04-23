// RocketUI.cs
using UnityEngine;
using UnityEngine.UI;

public class RocketUI : MonoBehaviour
{
    public Text fuelText;
    public Text engineText;

    void Update()
    {
        var rocket = GameObject.FindGameObjectWithTag("Rocket");
        if (rocket != null)
        {
            var engine = rocket.GetComponentInChildren<RocketEngine>();
            var tank = rocket.GetComponentInChildren<FuelTank>();
            if (engine != null && tank != null)
            {
                fuelText.text = $"Fuel: {tank.currentFuel} kg";
                engineText.text = $"Engine: {(engine.isRunning ? "ON" : "OFF")}";
            }
        }
    }
}