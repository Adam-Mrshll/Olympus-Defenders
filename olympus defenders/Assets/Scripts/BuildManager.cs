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
    private Node selectedNode;

    public NodeUI nodeUI; // reference to node UI script

    public bool CanBuild { get { return turretToBuild != null; } } // property, (can only get something from this variable)
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    public void SelectNode (Node node) // function to select a node when clicked in game
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }    
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node); // sets the target of node ui to the node that was clicked on
    }

    public void DeselectNode() // function to deselect the node when clicked elsewhere in game          
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild (TurretBlueprint turret) // function to select the turret to build when clicked in the shop UI  
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild() // function to get the turret to build when clicked in the shop UI    
    {
        return turretToBuild;
    }

}
