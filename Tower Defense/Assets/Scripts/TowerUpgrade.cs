using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public UpgradeTree[] trees;

    Turret turret;

    int treeOneUpgradeCount;
    int treeTwoUpgradeCount;
    int treeThreeUpgradeCount;

    private void Start()
    {
        turret = GetComponent<Turret>();
    }
    public bool IsTreeMaxOut(int _treeIndex)
    {
        if (_treeIndex > 2 || _treeIndex < 0)
            return false;

        int _upgradeIndex = 0;

        if (_treeIndex == 0)
        {
            _upgradeIndex = treeOneUpgradeCount;
        }
        if (_treeIndex == 1)
        {
            _upgradeIndex = treeTwoUpgradeCount;
        }
        if (_treeIndex == 2)
        {
            _upgradeIndex = treeThreeUpgradeCount;
        }
        if (_upgradeIndex > trees[_treeIndex].upgrades.Length - 1)
            return true;
        else
            return false;
    }
    public void UpgradeTower(int _treeIndex)
    {
        int _upgradeIndex = 0;

        if (_treeIndex == 0)
        {
            _upgradeIndex = treeOneUpgradeCount;
            treeOneUpgradeCount++;
        }
        if (_treeIndex == 1)
        {
            _upgradeIndex = treeTwoUpgradeCount;
            treeTwoUpgradeCount++;
        }
        if (_treeIndex == 2)
        {
            _upgradeIndex = treeThreeUpgradeCount;
            treeThreeUpgradeCount++;
        }

        ApplyUpgrade(trees[_treeIndex].upgrades[_upgradeIndex]);
    }

    void ApplyUpgrade(Upgrade upgrade)
    {
        print("Applyed");
        if(upgrade.newTowerProjectile != null)
            turret.bulletPrefab = upgrade.newTowerProjectile;

        turret.range += upgrade.addedRange;
        turret.fireRate += upgrade.addedFireRate;
    }

    [System.Serializable]
    public class UpgradeTree
    {
        public Upgrade[] upgrades;
    }

    [System.Serializable]
    public class Upgrade
    {
        //public GameObject newTowerModel;
        public GameObject newTowerProjectile;
        public float addedRange;
        public float addedFireRate;
    }
}
