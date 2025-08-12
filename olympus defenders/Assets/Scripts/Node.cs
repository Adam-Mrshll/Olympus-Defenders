using UnityEngine;
using UnityEngine.EventSystems; 

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor; // color for when user does not have enough money to build
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }


        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
            
        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            GetComponent<Renderer>().material.color = hoverColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = notEnoughMoneyColor; // change to red if not enough money
        }

            GetComponent<Renderer>().material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
