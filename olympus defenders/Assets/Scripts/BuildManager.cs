using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab; // Zeus turret
    public GameObject hephaestusTurretPrefab; // Hephaestus turret

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } } // property, (can only get something from this variable)

    public void BuildTurretOn (Node node)
    {
        GameObject  turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

}
