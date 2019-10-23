using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Politician : MonoBehaviour
{
    private string pName;
    private PoliticianEvent pEvent = new PoliticianEvent();
    [SerializeField] private Text politicianInfo = null;

    private void Start() {
        politicianInfo.text = string.Format("{0} to {1} of all {2} people!", pEvent.eventStrength, pEvent.eventTypeInfo, pEvent.targetInfo);
    }
}
