// NosePart.cs
using UnityEngine;

[CreateAssetMenu(fileName = "Nose", menuName = "Rocket/Nose Part")]
public class NosePart : ScriptableObject
{
    public string partName;
    public float mass = 100f;
    public GameObject visualPrefab;
}