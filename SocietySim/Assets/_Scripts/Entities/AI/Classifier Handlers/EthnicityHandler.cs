using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthnicityHandler : MonoBehaviour
{
    public Ethnicities ethnicity { get; private set; }

    public void Initialize() {
        var eValues = System.Enum.GetValues(typeof(Ethnicities));
        ethnicity = (Ethnicities)eValues.GetValue(Random.Range(0, eValues.Length));
    }
}
