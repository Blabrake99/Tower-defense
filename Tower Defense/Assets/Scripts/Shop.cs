using UnityEngine;
public class Shop : MonoBehaviour
{
    public ShopTurret[] turrets;

    public void PurchaseTurret(int turretIndex)
    {
        GameManager.DisableUpgradeUI();
        if (Player.CurrencyRemaining() < turrets[turretIndex].cost)
        {
            return;
        }
        TowerPlacement placement = FindObjectOfType<TowerPlacement>();
        //make sure to make a if that'll check if you have enough money
        if (placement.tower == null)
        {
            placement.tower = Instantiate(turrets[turretIndex].gameObject);
            placement.tower.GetComponent<Turret>().active = false;
            placement.towerCost = turrets[turretIndex].cost;
        }
        else
        {
            if (placement.tower.name == turrets[turretIndex].gameObject.name + "(Clone)")
            {
                Destroy(placement.tower);
            }
            else
            {
                Destroy(placement.tower);
                placement.tower = Instantiate(turrets[turretIndex].gameObject);
                placement.tower.GetComponent<Turret>().active = false;
            }
        }
    }

    [System.Serializable]
    public class ShopTurret
    {
        public GameObject gameObject;
        public int cost;
    }
}
