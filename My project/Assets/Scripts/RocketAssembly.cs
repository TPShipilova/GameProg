// RocketAssembly.cs
using UnityEngine;

public class RocketAssembly : MonoBehaviour
{
    public Transform rocketRoot;
    public Transform engineAttachPoint;
    public Transform tankAttachPoint;
    public Transform noseAttachPoint;

    void Start()
    {
        Build();
    }

    void Build()
    {
        var builder = RocketBuilder.Instance;
        if (builder == null) return;

        foreach (Transform child in rocketRoot) 
            if (child != engineAttachPoint && child != tankAttachPoint && child != noseAttachPoint && child.GetComponent<ParticleSystem>() == null)
                Destroy(child.gameObject);

        GameObject engineObj = Instantiate(builder.selectedEngine.visualPrefab, engineAttachPoint);
        engineObj.transform.localPosition = Vector3.zero;
        var engineComp = engineObj.AddComponent<RocketEngine>();
        engineComp.Initialize(builder.selectedEngine);

        GameObject tankObj = Instantiate(builder.selectedTank.visualPrefab, tankAttachPoint);
        tankObj.transform.localPosition = Vector3.zero;
        var tankComp = tankObj.AddComponent<FuelTank>();
        tankComp.Initialize(builder.selectedTank);

        GameObject noseObj = Instantiate(builder.selectedNose.visualPrefab, noseAttachPoint);
        noseObj.transform.localPosition = Vector3.zero;
        var noseComp = noseObj.AddComponent<NoseCone>();
        noseComp.Initialize(builder.selectedNose);

        engineComp.fuelTank = tankComp;

        Rigidbody rb = rocketRoot.GetComponent<Rigidbody>();
        float totalMass = builder.selectedEngine.mass + builder.selectedTank.dryMass + builder.selectedNose.mass + builder.selectedTank.fuelCapacity;
        rb.mass = totalMass;
    }
}