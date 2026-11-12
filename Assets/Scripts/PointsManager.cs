using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    // int - liczba ca³kowita
    // float - liczba z przecinkiem
    // string - tekst
    // bool - zmienna logiczna true/false

    public TMP_Text pointsText;
    public TMP_Text upgradeCostText;
    public int points = 0; // = to przypisanie wartoœci
    private int pointsPerClick = 1;
    private int upgradeCost = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string hello = "hello";
        print("Hello");
        Debug.Log("World");
        upgradeCostText.text = upgradeCost.ToString();
        pointsText.text = points.ToString();
    }

    public void GeneratePoints(int addedPoints)
    {
        points += addedPoints;
        pointsText.text = points.ToString();
        print(points);
    }

    public bool TrySpendPoints(int amount)
    {
        if (points >= amount)
        {
            points -= amount;
            pointsText.text = points.ToString();
            return true;
        }
        return false;
    }

    public void GeneratePointsPerClick()
    {
        GeneratePoints(pointsPerClick);
    }

    public void UpgradePointsPerClick()
    {
        if (points >= upgradeCost)
        {
            points -= upgradeCost;
            pointsText.text = points.ToString();
            upgradeCost *= 2;
            upgradeCostText.text = upgradeCost.ToString();
            pointsPerClick += 1; // to samo co pointsPerClick++;
        }
        else
        {
            Debug.LogWarning("Not enough points");
        }
    }


}
