using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform planetCenter;
    public float planetRadius;
    public Vector3 spawnDirection = Vector3.right;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Vector3 pos = planetCenter.position + spawnDirection.normalized * planetRadius;
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, spawnDirection);
        GameObject rocket = Instantiate(rocketPrefab, pos, rot);
        rocket.AddComponent<RocketGravity>();
        Camera.main.GetComponent<OrbitCamera>().target = rocket.transform;
    }
}