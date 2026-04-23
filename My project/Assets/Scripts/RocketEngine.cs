using UnityEngine;

public class RocketEngine : MonoBehaviour
{
    public EnginePart engineData;
    public ParticleSystem exhaust;
    public FuelTank fuelTank;
    public bool isRunning = false;

    private Rigidbody rocketRb;
    private Transform engineTransform;
    private float thrustPitch = 0f, thrustYaw = 0f;
    public float maxThrustAngle = 15f;
    public float steeringSpeed = 5f;

    public void Initialize(EnginePart data)
    {
        engineData = data;
        rocketRb = GetComponentInParent<Rigidbody>();
        exhaust = FindAnyObjectByType<ParticleSystem>();
        exhaust.Stop();
        engineTransform = transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRunning = !isRunning;

            if (isRunning && exhaust != null && fuelTank != null && fuelTank.currentFuel > 0)
            {
                exhaust.Play();
            }
        }

        float pitch = Input.GetAxis("Vertical");
        float yaw = Input.GetAxis("Horizontal");
        
        thrustPitch = pitch * maxThrustAngle;
        thrustYaw = yaw * maxThrustAngle;

        thrustPitch = Mathf.Clamp(thrustPitch, -maxThrustAngle, maxThrustAngle);
        thrustYaw = Mathf.Clamp(thrustYaw, -maxThrustAngle, maxThrustAngle);
    }

    void FixedUpdate()
    {
        if (isRunning && fuelTank != null && fuelTank.currentFuel > 0)
        {
            float fuelBurn = engineData.fuelConsumptionRate * Time.fixedDeltaTime;
            fuelTank.ConsumeFuel(fuelBurn);

            Quaternion thrustRot = Quaternion.Euler(thrustPitch, thrustYaw, 0);
            Vector3 localDir = thrustRot * Vector3.up;
            Vector3 worldDir = rocketRb.transform.TransformDirection(localDir);
            Vector3 force = worldDir * engineData.thrust;
            rocketRb.AddForceAtPosition(force, engineTransform.position);

            if (fuelTank.currentFuel <= 0) isRunning = false;
        }
        else
        {
            if (exhaust != null)
            {
                exhaust.Stop();
            }
        }
    }
}