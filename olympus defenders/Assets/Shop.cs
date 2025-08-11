using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseZeusTurret()
    {
        Debug.Log("Zeus Purchased!");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab); //Zeus turret
    }
    public void PurchaseHephaestusTurret()
    {
        Debug.Log("Hephastus Purchased!");
        buildManager.SetTurretToBuild(buildManager.hephaestusTurretPrefab); //Hephaestus turret
    }
}
