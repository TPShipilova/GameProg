using UnityEngine;
using System.Collections.Generic;

public class RocketGravity : MonoBehaviour
{
    public float G = 0.01f;
    private Rigidbody rb;
    private List<Rigidbody> planets = new List<Rigidbody>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        foreach (var planet in FindObjectsOfType<GravityBody>())
            planets.Add(planet.GetComponent<Rigidbody>());
    }

    void FixedUpdate()
    {
        foreach (var planet in planets)
        {
            Vector3 dir = planet.position - rb.position;
            float dist = dir.magnitude;
            if (dist < 0.1f) continue;
            float forceMag = G * rb.mass * planet.mass / (dist * dist);
            rb.AddForce(dir.normalized * forceMag);
        }
    }
}