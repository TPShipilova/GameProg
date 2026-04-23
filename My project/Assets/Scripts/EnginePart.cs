using UnityEngine;

[CreateAssetMenu(fileName = "Engine", menuName = "Rocket/Engine Part")]
public class EnginePart : ScriptableObject
{
    public string partName;
    public float mass; 
    public float thrust;
    public float fuelConsumptionRate;
    public GameObject visualPrefab;
}