using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    private float gravitationalConstant = 0.01f;

    [SerializeField] private Vector3 initialVelocity;

    private Rigidbody rb;
    private static List<GravityBody> allBodies = new List<GravityBody>();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = initialVelocity;
    }

    private void OnEnable()
    {
        allBodies.Add(this);
    }

    private void OnDisable()
    {
        allBodies.Remove(this);
    }

    private void FixedUpdate()
    {
        foreach (GravityBody other in allBodies)
        {
            if (other == this) continue;

            Vector3 direction = other.rb.position - rb.position;
            float distance = direction.magnitude;
            if (distance < 0.01f) continue;

            float forceMagnitude = gravitationalConstant * rb.mass * other.rb.mass / (distance * distance);
            Vector3 force = direction.normalized * forceMagnitude;
            rb.AddForce(force);
        }
    }
}