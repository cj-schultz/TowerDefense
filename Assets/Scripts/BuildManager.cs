using UnityEngine;
using System.Collections;

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

    public GameObject buildEffect;

    public bool CanBuild { get { return turretToBuild != null; } }

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost;  } }

    private TurretBlueprint turretToBuild;

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turretGO = (GameObject) Instantiate(turretToBuild.prefab, node.BuildPosition, Quaternion.identity);
        node.turret = turretGO;

        GameObject buildEffectGO = (GameObject)Instantiate(buildEffect, node.BuildPosition, Quaternion.identity);
        Destroy(buildEffectGO, 4f);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
