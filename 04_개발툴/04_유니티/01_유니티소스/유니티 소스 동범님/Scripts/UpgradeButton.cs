using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public DataController dataController;

    public Text upgradeDisplayer;
    public string upgradeName; //item slot

    public int goldByUpgrade;
    public int startGoldByUpgrade = 1; //item cost

    public int currentCost;
    public int startCurrentCost = 1;

    public int level = 1;

    public float upgradePow = 1.07f; //click per gold
    public float costPow = 3.14f; //upgrade cost
    
    void Start()
    {
        dataController.LoadUpgradeButton(this);
        UpdateUI();
    }
    
    public void PurchaseUpgrade()
    {
        if (dataController.GetGold() >= currentCost)
        {
            dataController.SubGold(currentCost);
            level++;
            dataController.AddGoldPerClick(goldByUpgrade);
            UpdateUpgrade();
            dataController.SaveUpgradeButton(this);
            Debug.Log("Purchased Level " + level);
        }
    }

    public void UpdateUpgrade()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level-1);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level-1);
        UpdateUI();
    }

    public void UpdateUI()
    {
        upgradeDisplayer.text = "UPGRADE : "+upgradeName + "\nCurrent Cost: "+currentCost + "\nLevel: "+level + "\nUpgrade Amount: "+goldByUpgrade;
    }

}
