using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    TowerPlacement towerPlacement;

    static GameObject towerUpgradeUI;
    private void Awake()
    {
        towerPlacement = GetComponent<TowerPlacement>();
        towerUpgradeUI = FindObjectOfType<TowerUpgradeUI>().gameObject;
        DisableUpgradeUI();
    }
    private void Update()
    {
        if (towerPlacement.tower != null)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            GameObject turret = Player.GetTowerClickedOn();
            if (turret != null)
            {
                EnableUpgradeUI(turret);
            }
        }
    }

    public static void EnableUpgradeUI(GameObject turret)
    {
        towerUpgradeUI.GetComponent<TowerUpgradeUI>().towerToUpgrade = turret.GetComponent<TowerUpgrade>();
        towerUpgradeUI.GetComponent<TowerUpgradeUI>().setUI();
        towerUpgradeUI.SetActive(true);
    }
    public static void DisableUpgradeUI()
    {
        towerUpgradeUI.GetComponent<TowerUpgradeUI>().towerToUpgrade = null;
        towerUpgradeUI.SetActive(false);
    }
}
