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
        politicianInfo.text = string.Format("<color=red><i>{0} to {1}</i></color> of all <color=blue>{2}</color> people!", pEvent.eventStrength, pEvent.eventTypeInfo, pEvent.targetInfo);
    }
}
