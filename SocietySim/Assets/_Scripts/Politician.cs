using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Politician : MonoBehaviour
{
    private string pName;
    private PoliticianEvent pEvent = new PoliticianEvent();

    private void Start() {
        Debug.Log("I will " + pEvent.eventTypeInfo + " by " + pEvent.eventStrength + "% of " +  pEvent.targetInfo.ToLower() + " people!");
    }
}
