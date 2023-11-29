using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
        Debug.Log("Standard Turret Selected.");

    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected.");
        buildManager.SelectTurretToBuild(missileLauncher);

    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected.");
        buildManager.SelectTurretToBuild(laserBeamer);

    }
}
