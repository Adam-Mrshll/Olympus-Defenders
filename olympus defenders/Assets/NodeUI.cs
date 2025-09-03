using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    // creating gameobjects which I will reference later on in code
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;
    
    private Node target;

    public void SetTarget(Node _target) // sets the target node when clicked on in game 
    {
        this.target = _target;

        transform.position = target.GetBuildPosition(); // sets the position of the UI to the position of the node

        

        if (target.isUpgraded)
        {
            upgradeCost.text = "MAX";
            upgradeButton.interactable = false; 
        }
        else {
            upgradeCost.text = "UPGRADE: $" + target.turretBlueprint.upgradeCost; // displays text then the upgrade value
            upgradeButton.interactable = true;
        }

        sellAmount.text = "SELL: $" + target.turretBlueprint.GetSellAmount(); // displays text then the sell value

            ui.SetActive(true);
    }

    public void Hide() // hides the UI
    {
        ui.SetActive(false);
    }

    public void Upgrade() // function to upgrade the turrret
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

public void sell () // function to sell the turret
{
    target.SellTower();
    BuildManager.instance.DeselectNode();
}
}
