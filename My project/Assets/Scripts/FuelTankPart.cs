using UnityEngine;

[CreateAssetMenu(fileName = "FuelTank", menuName = "Rocket/Fuel Tank Part")]
public class FuelTankPart : ScriptableObject
{
    public string partName;
    public float dryMass;
    public float fuelCapacity;
    public GameObject visualPrefab;
}