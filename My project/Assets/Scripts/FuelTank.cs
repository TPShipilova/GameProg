using UnityEngine;

public class FuelTank : MonoBehaviour
{
    public FuelTankPart tankData;
    public float currentFuel;

    private Rigidbody rocketRb;

    public void Initialize(FuelTankPart data)
    {
        tankData = data;
        currentFuel = data.fuelCapacity;
        rocketRb = GetComponentInParent<Rigidbody>();
        UpdateMass();
    }

    public void ConsumeFuel(float amount)
    {
        currentFuel = Mathf.Max(0, currentFuel - amount);
        UpdateMass();
    }

    private void UpdateMass()
    {
        var builder = RocketBuilder.Instance;
        float dryMass = builder.selectedEngine.mass + builder.selectedTank.dryMass + builder.selectedNose.mass;
        rocketRb.mass = dryMass + currentFuel;
    }
}