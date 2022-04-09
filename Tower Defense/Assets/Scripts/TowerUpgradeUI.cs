using System;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradeUI : MonoBehaviour
{
    public TowerUpgrade towerToUpgrade;

    public Button btnOne;
    public Text txtOne;

    public Button btnTwo;
    public Text txtTwo;

    public Button btnThree;
    public Text txtThree;

    public Text txtSell;

    public void setUI()
    {
        if (towerToUpgrade == null)
            return;

        if (!towerToUpgrade.IsTreeMaxOut(0))
        {
            btnOne.interactable = true;
            btnOne.onClick.RemoveAllListeners();
            btnOne.onClick.AddListener(ButtonOne);
            txtOne.text = towerToUpgrade.UpgradeCost(0) + Environment.NewLine + "Fire Rate";
        }
        else
        {
            btnOne.interactable = false;
            txtOne.text = "Maxed out";
        }
        if (!towerToUpgrade.IsTreeMaxOut(1))
        {
            btnTwo.interactable = true;
            btnTwo.onClick.RemoveAllListeners();
            btnTwo.onClick.AddListener(ButtonTwo);
            txtTwo.text = towerToUpgrade.UpgradeCost(1) + Environment.NewLine + "Range";
        }
        else
        {
            btnTwo.interactable = false;
            txtTwo.text = "Maxed out";
        }
        if (!towerToUpgrade.IsTreeMaxOut(2))
        {
            btnThree.interactable = true;
            btnThree.onClick.RemoveAllListeners();
            btnThree.onClick.AddListener(ButtonThree);
            txtThree.text = towerToUpgrade.UpgradeCost(2) + Environment.NewLine + "Fire Rate & Range";
        }
        else
        {
            btnThree.interactable = false;
            txtThree.text = "Maxed out";
        }
        if (towerToUpgrade != null)
            txtSell.text = "Sell for" + Environment.NewLine + towerToUpgrade.getSellAmount();
    }
    public void ButtonOne()
    {
        if (!towerToUpgrade.IsTreeMaxOut(0) && Player.HaveEnoughMoney(towerToUpgrade.UpgradeCost(0)))
            towerToUpgrade.UpgradeTower(0);
    }
    public void ButtonTwo()
    {
        if (!towerToUpgrade.IsTreeMaxOut(1) && Player.HaveEnoughMoney(towerToUpgrade.UpgradeCost(1)))
            towerToUpgrade.UpgradeTower(1);
    }
    public void ButtonThree()
    {
        if (!towerToUpgrade.IsTreeMaxOut(2) && Player.HaveEnoughMoney(towerToUpgrade.UpgradeCost(2)))
            towerToUpgrade.UpgradeTower(2);
    }
    public void Sell()
    {
        towerToUpgrade.Sell();
    }
    public void UpdateText()
    {
        if (!towerToUpgrade.IsTreeMaxOut(0))
            txtOne.text = towerToUpgrade.UpgradeCost(0) + Environment.NewLine + "Fire Rate";
        else
        {
            btnOne.interactable = false;
            txtOne.text = "Maxed out";
        }
        if (!towerToUpgrade.IsTreeMaxOut(1))
        
            txtTwo.text = towerToUpgrade.UpgradeCost(1) + Environment.NewLine + "Range";
        else
        {
            btnTwo.interactable = false;
            txtTwo.text = "Maxed out";
        }
        if (!towerToUpgrade.IsTreeMaxOut(2))
            txtThree.text = towerToUpgrade.UpgradeCost(2) + Environment.NewLine + "Fire Rate & Range";
        else
        {
            btnThree.interactable = false;
            txtThree.text = "Maxed out";
        }
        if(towerToUpgrade != null)
            txtSell.text = "Sell for" + Environment.NewLine +  towerToUpgrade.getSellAmount();
    }
    //this class will be used later
    [System.Serializable]
    public class UpgradeButton
    {
        public Text description;
        public Image upgradeImg;
    }
}
