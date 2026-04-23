using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuUI : MonoBehaviour
{
    public Dropdown engineDropdown;
    public Dropdown tankDropdown;
    public Dropdown noseDropdown;

    public List<EnginePart> engineOptions;
    public List<FuelTankPart> tankOptions;
    public List<NosePart> noseOptions;

    void Start()
    {
        engineDropdown.ClearOptions();
        engineDropdown.AddOptions(engineOptions.ConvertAll(e => e.partName));
        tankDropdown.ClearOptions();
        tankDropdown.AddOptions(tankOptions.ConvertAll(t => t.partName));
        noseDropdown.ClearOptions();
        noseDropdown.AddOptions(noseOptions.ConvertAll(n => n.partName));
    }

    public void OnBuildAndRun()
    {
        RocketBuilder.Instance.selectedEngine = engineOptions[engineDropdown.value];
        RocketBuilder.Instance.selectedTank = tankOptions[tankDropdown.value];
        RocketBuilder.Instance.selectedNose = noseOptions[noseDropdown.value];
        SceneManager.LoadScene("Main");
    }
}