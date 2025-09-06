using UnityEngine;
using UnityEngine.EventSystems; 

public class Node : MonoBehaviour
{ // creating a class called node which inherits from monobehaviour
    public Color hoverColor;
    public Color notEnoughMoneyColor; // color for when user does not have enough money to build
    public Vector3 positionOffset;
    
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start() // runs when the object is created
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color; // resets the color of the node back to its original color when game is started/restarted

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition() // sets the turret position to be in the center of the node
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown() // when the mouse is clocked on the node this function runs
    {
        if (EventSystem.current.IsPointerOverGameObject()) // if mouse hovers over ui turret will not be built
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild()); // calls build turret function
    }

    void BuildTurret(TurretBlueprint blueprint) // function to build the turret
    {
        GetComponent<Renderer>().material.color = hoverColor; // darkens the node color when turret is built on it
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!"); // sends a text in console if not enough money to build turret
            return;
        }

        PlayerStats.Money -= blueprint.cost; // subtracts cost of turret from players money

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret; // sets turret to turret that was just built

        turretBlueprint = blueprint;

        Debug.Log("Tower Placed!");
    }

    public void UpgradeTurret() // function to upgrade the turret
    {
        GetComponent<Renderer>().material.color = hoverColor; // darkens the node color when turret is upgraded
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret); // destroys old turret

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity); // builds the upgraded turret
        turret = _turret;

        isUpgraded = true;

        Debug.Log("Tower Upgraded!");
    }

    public void SellTower () // function to sell the turret
    {
        rend.material.color = startColor;
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        //spawn a cool effect

        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;
    }
    void OnMouseEnter() // when mouse hovers over the node this function runs
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
            
        if (!buildManager.CanBuild)
            return;

        // Only change color on mouse hover if no turret is placed
        if (turret == null)
        {
            if (buildManager.HasMoney)
            {
                GetComponent<Renderer>().material.color = hoverColor;
            }
            else
            {
                GetComponent<Renderer>().material.color = notEnoughMoneyColor; // change to red if not enough money
            }
        }
    }

    void OnMouseExit() // when mouse stops hovering over the node this function runs
    {
        // Only reset color if no turret placed, otherwise keep the darkened color for turret
        if (turret == null)
        {
            rend.material.color = startColor;
        }
    }

}
