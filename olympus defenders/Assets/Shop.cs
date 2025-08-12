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
        Debug.Log("Zeus Purchased!");
        buildManager.SelectTurretToBuild(standardTurret); //Zeus turret
    }
    public void SelectHephaestusTurret()
    {
        Debug.Log("Hephastus Purchased!");
        buildManager.SelectTurretToBuild(hephaestusTurret); //Hephaestus turret
    }
}
