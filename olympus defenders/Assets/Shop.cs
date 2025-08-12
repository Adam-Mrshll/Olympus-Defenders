using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint hephaestusTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectZeusTurret()
    {
        Debug.Log("Selected: Zeus");
        buildManager.SelectTurretToBuild(standardTurret); //Zeus turret
    }
    public void SelectHephaestusTurret()
    {
        Debug.Log("Selected: Hephaestus");
        buildManager.SelectTurretToBuild(hephaestusTurret); //Hephaestus turret
    }
}
