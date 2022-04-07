using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    static int currency = 500;
    public int startMoney = 500;

    static int lives = 250;
    public int startLives = 250;

    static Text moneyText;
    public Text _moneyText;

    static Text livesText;
    public Text _livesTText;

    public static LayerMask towerMask;
    public LayerMask _towerMask;
    // Start is called before the first frame update
    void Start()
    {
        moneyText = _moneyText;
        livesText = _livesTText;
        towerMask = _towerMask;
        UpdateMoneyText();
        UpdateLivesText();
    }

    #region Currency
    public static void UpdateCurrency(int amountToAdd)
    {
        currency += amountToAdd;
        UpdateMoneyText();
    }
    public static void UpdateMoneyText()
    {
        moneyText.text = "Money : " + currency;
    }
    public static int CurrencyRemaining()
    {
        return currency;
    }
    public static bool HaveEnoughMoney(int cost)
    {
        if (currency >= cost)
            return true;
        else
            return false;
    }
    #endregion

    #region Lives
    public static void UpdateLives(int amountToSubtract)
    {
        lives -= amountToSubtract;
        UpdateLivesText();
    }
    public static void UpdateLivesText()
    {
        livesText.text = "Lives : " + lives;
    }
    public static int LivesRemaining()
    {
        return lives;
    }
    #endregion

    #region ClickOnTowerCheck
    public static bool ClickingOnTower()
    {
        Ray camray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit HitInfo;
        if (Physics.Raycast(camray, out HitInfo, 100f, towerMask))
        {
            return true;
        }
        return false;
    }
    public static bool ClickingOnTower(GameObject SelectedTower)
    {
        Ray camray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] Hits;
        Hits = Physics.RaycastAll(camray, 100, towerMask);
        print(Hits.Length);
        for(int i = 0; i < Hits.Length;i++)
        {
            if (SelectedTower != Hits[i].transform.gameObject)
                return true;
        }
        return false;
    }
    public static GameObject GetTowerClickedOn()
    {
        Ray camray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit HitInfo;
        if (Physics.Raycast(camray, out HitInfo, 100f, towerMask))
        {
            return HitInfo.transform.gameObject;
        }
        return null;
    }
    #endregion
    public void ResetGame()
    {
        currency = startMoney;
        UpdateMoneyText();

        lives = startLives;
        UpdateLivesText();
    }
}
