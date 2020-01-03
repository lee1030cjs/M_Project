using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public DataController dataController;
    public UpgradeButton upgradeButton;

    public void OnClick()
    {
        dataController.SetGold(0);
        dataController.SetGoldPerClick(1);
        //upgradeButton.goldByUpgrade = upgradeButton.startGoldByUpgrade;
        //upgradeButton.currentCost = upgradeButton.startCurrentCost;
        upgradeButton.level = 1;
        upgradeButton.UpdateUpgrade();
        dataController.SaveUpgradeButton(upgradeButton);
    }
}
