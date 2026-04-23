// RocketBuilder.cs
using UnityEngine;

public class RocketBuilder : MonoBehaviour
{
    public static RocketBuilder Instance { get; private set; }

    public EnginePart selectedEngine;
    public FuelTankPart selectedTank;
    public NosePart selectedNose;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
}