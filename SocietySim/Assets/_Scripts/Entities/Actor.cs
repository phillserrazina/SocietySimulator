using System;
using UnityEngine;

public class Actor : MonoBehaviour
{
    // VARIABLES

    public Religions religion { get; private set; }
    public PoliticalStances politicalStance { get; private set; }

    public EconomicHandler economicHandler { get; private set; }
    public EthnicityHandler ethnicityHandler { get; private set; }

    // EXECUTION FUNCTIONS

    private void Start() {
        Initialize();
    }

    // METHODS

    private void Initialize() {
        var rValues = Enum.GetValues(typeof(Religions));
        religion = (Religions)rValues.GetValue(UnityEngine.Random.Range(0, rValues.Length));

        var psValues = Enum.GetValues(typeof(PoliticalStances));
        politicalStance = (PoliticalStances)psValues.GetValue(UnityEngine.Random.Range(0, psValues.Length));

        economicHandler = GetComponent<EconomicHandler>();
        ethnicityHandler = GetComponent<EthnicityHandler>();

        economicHandler.Initialize();
        ethnicityHandler.Initialize();
        GetComponent<AppearanceGenerator>().Initialize();
    }
}
