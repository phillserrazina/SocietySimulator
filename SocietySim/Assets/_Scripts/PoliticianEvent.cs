using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

class PoliticianEvent {
    // VARIABLES
    public enum EventTypes {
        Income_Change
    }

    private EventTypes eventType;
    private Actor[] targets;

    public string eventTypeInfo { get; private set; }
    public string targetInfo { get; private set; }
    public float eventStrength { get; private set; }

    private static Random random = new Random();

    // EXECUTION FUNCTIONS
    public PoliticianEvent() {
        var eValues = System.Enum.GetValues(typeof(EventTypes));
        eventType = (EventTypes)eValues.GetValue(new System.Random().Next(eValues.Length));

        targets = GetTargets();
        eventStrength = GetEventStrength(0f, 0.2f);

        eventTypeInfo = GetEventInfo();
    }

    // METHODS
    public void ExecuteEvent() {
        switch (eventType)
        {
            case EventTypes.Income_Change: IncomeChange(); break;

            default:
                Console.WriteLine("PoliticianEvent::ExecuteEvent() -- Invalid Event Type.");
                break;
        }
    }

    private void IncomeChange() {
        foreach (Actor t in targets) {
            t.economicHandler.currentIncome *= eventStrength;
        }
    }

    private Actor[] GetTargets() {
        var allActors = SocietyTracker.allActors.ToArray();
        targetInfo = "Everyone";

        // === TARGET EVERYONE ===
        if (random.Next(100) < 33) return allActors;

        // === TARGET AN ETHNICITY ===
        var ethnicityValues = System.Enum.GetValues(typeof(Ethnicities));
        var ethnicityTarget = (Ethnicities)ethnicityValues.GetValue(random.Next(ethnicityValues.Length));
        targetInfo = ethnicityTarget.ToString();
        
        if (random.Next(100) < 66) 
            return allActors.Where(targets => targets.ethnicityHandler.ethnicity == ethnicityTarget) as Actor[];
        
        // === TARGET A RELIGION ===
        var religionValues = System.Enum.GetValues(typeof(Religions));
        var religionTarget = (Religions)religionValues.GetValue(random.Next(religionValues.Length));
        targetInfo = religionTarget.ToString();

        return allActors.Where(targets => targets.religion == religionTarget) as Actor[];
    }

    private float GetEventStrength(float min, float max) {
        eventStrength = (float)(random.NextDouble() * (max - min) + min);
        return (float)Math.Round(eventStrength * 100f) / 100f;
    }

    private string GetEventInfo() {
        switch (eventType)
        {
            case EventTypes.Income_Change:
                if (eventStrength > 1) return "increase the income";
                else return "decrease the income";

            default:
                Console.WriteLine("PoliticianEvent::ExecuteEvent() -- Invalid Event Type.");
                return null;
        }
    }
}