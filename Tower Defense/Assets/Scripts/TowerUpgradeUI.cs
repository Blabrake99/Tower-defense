using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradeUI : MonoBehaviour
{
    public TowerUpgrade towerToUpgrade;

    public Button btnOne;
    public Button btnTwo;
    public Button btnThree;

    private void OnEnable()
    {
        if (!towerToUpgrade.IsTreeMaxOut(0))
        {
            btnOne.gameObject.SetActive(true);
            btnOne.onClick.RemoveAllListeners();
            btnOne.onClick.AddListener(ButtonOne);
        }
        else
        {
            btnOne.gameObject.SetActive(false);
        }
        if (!towerToUpgrade.IsTreeMaxOut(1))
        {
            btnTwo.gameObject.SetActive(true);
            btnTwo.onClick.RemoveAllListeners();
            btnTwo.onClick.AddListener(ButtonTwo);
        }
        else
        {
            btnTwo.gameObject.SetActive(false);
        }
        if (!towerToUpgrade.IsTreeMaxOut(2))
        {
            btnThree.gameObject.SetActive(true);
            btnThree.onClick.RemoveAllListeners();
            btnThree.onClick.AddListener(ButtonThree);
        }
        else
        {
            btnThree.gameObject.SetActive(false);
        }
    }
    public void ButtonOne()
    {
        if (!towerToUpgrade.IsTreeMaxOut(0))
            towerToUpgrade.UpgradeTower(0);
    }
    public void ButtonTwo()
    {
        if (!towerToUpgrade.IsTreeMaxOut(1))
            towerToUpgrade.UpgradeTower(1);
    }
    public void ButtonThree()
    {
        if (!towerToUpgrade.IsTreeMaxOut(2))
            towerToUpgrade.UpgradeTower(2);
    }

    //this class will be used later
    [System.Serializable]
    public class UpgradeButton
    {
        public Text description;
        public Image upgradeImg;
    }
}
