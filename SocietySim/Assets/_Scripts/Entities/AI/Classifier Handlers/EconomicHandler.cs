using UnityEngine;

public class EconomicHandler : MonoBehaviour
{
    private float currentTotalMoney;
    public float currentIncome;
    public float perDayCosts;

    public EconomicPosition economicPosition { get; private set; }

    public void CalculateEndOfDay() {
        currentTotalMoney += currentIncome;
        currentTotalMoney -= perDayCosts;
    }

    public void Initialize() {
        var ecoValues = System.Enum.GetValues(typeof(EconomicPosition));
        economicPosition = (EconomicPosition)ecoValues.GetValue(Random.Range(0, ecoValues.Length));

        currentIncome = GetIncome();
        perDayCosts = GetPerDayCosts();

        TimeManager.endOfDayListeners += CalculateEndOfDay;
    }

    private float GetIncome() {
        if (economicPosition == EconomicPosition.Low_Income) return Random.Range(600f, 800f);

        return (economicPosition == EconomicPosition.Mid_Income) ? 
                Random.Range(800f, 2000f) : Random.Range(2000f, 5000f);
    }

    private float GetPerDayCosts() {
        if (economicPosition == EconomicPosition.Low_Income) return Random.Range(300f, 500f);

        float answer;
        answer = (economicPosition == EconomicPosition.Mid_Income) ? 
                Random.Range(500f, 1500f) : Random.Range(1500f, 3000f);
        
        if (answer >= currentIncome) answer = currentIncome - 300;

        return answer;
    }
}
