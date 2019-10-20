using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Tooltip("Cooldown In Between Days (in seconds)")]
    [SerializeField] private float nextDayCooldown = 0;
    private float currentCooldown;
    public int currentDay { get; private set; }

    public delegate void OnDayEndDelegate();
    public static event OnDayEndDelegate endOfDayListeners;

    private void Start() {
        currentDay = 0;
        currentCooldown = nextDayCooldown;
    }

    private void Update() {
        AdvanceTime();
    }

    private void AdvanceTime() {
        if (currentCooldown > 0) {
            currentCooldown -= Time.deltaTime;
            return;
        }

        currentDay++;
        currentCooldown = nextDayCooldown;
        if (endOfDayListeners != null) endOfDayListeners();
    }
}
