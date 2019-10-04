using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    // VARIABLES

    public enum Alignment {
        Evil,
        Neutral,
        Good
    }

    public Alignment currentAlignment;

    private float currentAlignmentPoints;
    private const float EVIL_ALIGNMENT_VALUE = -50;
    private const float NEUTRAL_ALIGNMENT_VALUE = 50;
    private const float GOOD_ALIGNMENT_VALUE = 100;

    // EXECUTION FUNCTIONS

    private void Start() {
        currentAlignmentPoints = Random.Range(-100f, 100f);
        currentAlignment = GetAlignment();
    }

    // METHODS

    private Alignment GetAlignment() {
        if (currentAlignmentPoints < EVIL_ALIGNMENT_VALUE) {
            return Alignment.Evil;
        }
        else if (currentAlignmentPoints < NEUTRAL_ALIGNMENT_VALUE) {
            return Alignment.Neutral;
        }
        
        return Alignment.Good;
    }
}
