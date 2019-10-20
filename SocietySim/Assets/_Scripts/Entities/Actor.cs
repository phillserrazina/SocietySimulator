using System;
using UnityEngine;

public class Actor : MonoBehaviour
{
    // VARIABLES

    public Ethnicities ethnicity { get; private set; }
    public Religions religion { get; private set; }
    public PoliticalStances politicalStance { get; private set; }

    // EXECUTION FUNCTIONS

    private void Start() {
        Initialize();
    }

    // METHODS

    private void Initialize() {
        var eValues = Enum.GetValues(typeof(Ethnicities));
        ethnicity = (Ethnicities)eValues.GetValue(UnityEngine.Random.Range(0, eValues.Length));

        var rValues = Enum.GetValues(typeof(Religions));
        religion = (Religions)rValues.GetValue(UnityEngine.Random.Range(0, rValues.Length));

        var psValues = Enum.GetValues(typeof(PoliticalStances));
        politicalStance = (PoliticalStances)psValues.GetValue(UnityEngine.Random.Range(0, psValues.Length));

        GetComponent<EconomicHandler>().Initialize();
        GetComponent<AppearanceGenerator>().Initialize();
    }
}
