using TMPro;
using UnityEngine;

public class PointsGenerator : MonoBehaviour
{
    public PointsManager pointsManager;
    public TMP_Text upgradePPSCostText;
    public int upgradePointsPerSecondCost = 1;
    public float pointsAddInterval = 1;
    public int pointsPerUpgrade = 1;
    private int pointsPerSecond;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upgradePPSCostText.text = upgradePointsPerSecondCost.ToString();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > pointsAddInterval)
        {
            pointsManager.GeneratePoints(pointsPerSecond);
            timer = 0;
        }
    }

    public void UpgradePointsPerSecond()
    {
        if (pointsManager.TrySpendPoints(upgradePointsPerSecondCost))
        {
            pointsPerSecond += pointsPerUpgrade;
            upgradePointsPerSecondCost *= 2;
            upgradePPSCostText.text = upgradePointsPerSecondCost.ToString();
        }
    }
}
