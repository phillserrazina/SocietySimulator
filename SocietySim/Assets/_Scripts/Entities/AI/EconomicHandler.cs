using UnityEngine;

public class EconomicHandler : MonoBehaviour
{
    private float currentIncome;

    public EconomicPosition economicPosition { get; private set; }

    public void Initialize() {
        var ecoValues = System.Enum.GetValues(typeof(EconomicPosition));
        economicPosition = (EconomicPosition)ecoValues.GetValue(Random.Range(0, ecoValues.Length));

        currentIncome = GetIncome();
    }

    private float GetIncome() {
        if (economicPosition == EconomicPosition.Low_Income) return Random.Range(600f, 800f);

        return (economicPosition == EconomicPosition.Mid_Income) ? 
                Random.Range(800f, 2000f) : Random.Range(2000f, 5000f);
    }
}
