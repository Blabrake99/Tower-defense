using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public UpgradeTree[] trees;

    Turret turret;
    TowerUpgradeUI ui;
    int treeOneUpgradeCount;
    int treeTwoUpgradeCount;
    int treeThreeUpgradeCount;
    int upgradeAmount;
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
    public int UpgradeCost(int _treeIndex)
    {

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
        if (_upgradeIndex <= trees[_treeIndex].upgrades.Length - 1)
            return trees[_treeIndex].upgrades[_upgradeIndex].cost;
        else
            return 0;
    }   
    public void Sell()
    {
        int sellAmount = 0;
        if(upgradeAmount == 0)
        {
            sellAmount = getSellAmount();
        }


        Player.UpdateCurrency(sellAmount);
        GameManager.DisableUpgradeUI();
        Destroy(gameObject);
    }
    public int getSellAmount()
    {
        float amount = turret.cost;
        if (upgradeAmount > 0)
        { 
            if(treeOneUpgradeCount > 0)
            {
                for(int i = 0; i < treeOneUpgradeCount;i++)
                {
                    amount += trees[0].upgrades[i].cost;
                }
            }
            if(treeTwoUpgradeCount > 0)
            {
                for (int i = 0; i < treeTwoUpgradeCount; i++)
                {
                    amount += trees[1].upgrades[i].cost;
                }
            }
            if(treeThreeUpgradeCount > 0)
            {
                for (int i = 0; i < treeThreeUpgradeCount; i++)
                {
                    amount += trees[2].upgrades[i].cost;
                }
            }
        }
        //you wont get a full refund but pretty close
        amount *= .75f;
        return Mathf.RoundToInt(amount);
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
        upgradeAmount++;
        if (upgrade.newTowerProjectile != null)
            turret.bulletPrefab = upgrade.newTowerProjectile;
        Player.UpdateCurrency(-upgrade.cost);
        turret.range += upgrade.addedRange;
        turret.fireRate += upgrade.addedFireRate;

        FindObjectOfType<TowerUpgradeUI>().UpdateText();
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
        public int cost;
    }
}
