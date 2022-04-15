using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    TowerPlacement towerPlacement;
    public GameObject _towerUpgradeUI;
    public TowerUpgradeUI _towerUpgrade;
    public static TowerUpgradeUI towerUpgrade;
    static GameObject towerUpgradeUI;
    private void Awake()
    {
        towerPlacement = GetComponent<TowerPlacement>();
        towerUpgradeUI = _towerUpgradeUI;
        towerUpgrade = _towerUpgrade;
        //towerUpgradeUI = FindObjectOfType<TowerUpgradeUI>().gameObject;
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
    //this is because buttons cannot call static functions
    public void XBtn()
    {
        DisableUpgradeUI();
    }
    public static void EnableUpgradeUI(GameObject turret)
    {
        towerUpgrade.towerToUpgrade = turret.GetComponent<TowerUpgrade>();
        towerUpgrade.setUI();
        towerUpgradeUI.SetActive(true);
    }
    public static void DisableUpgradeUI()
    {
        towerUpgrade.towerToUpgrade = null;
        towerUpgradeUI.SetActive(false);
    }
}
