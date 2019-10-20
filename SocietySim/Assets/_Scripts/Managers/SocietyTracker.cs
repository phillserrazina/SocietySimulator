using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocietyTracker
{
    private static List<Actor> _allActors = new List<Actor>();
    private static Dictionary<Ethnicities, List<Actor>> _skinColorList = new Dictionary<Ethnicities, List<Actor>>();
    private static Dictionary<Religions, List<Actor>> _religionList = new Dictionary<Religions, List<Actor>>();
    private static Dictionary<PoliticalStances, List<Actor>> _politicalList = new Dictionary<PoliticalStances, List<Actor>>();
    private static Dictionary<EconomicPosition, List<Actor>> _economicalRangeList = new Dictionary<EconomicPosition, List<Actor>>();

    public static List<Actor> allActors { get { return _allActors; } }
    public static Dictionary<Ethnicities, List<Actor>> skinColorList { get { return _skinColorList; } }
    public static Dictionary<Religions, List<Actor>> religionList { get { return _religionList; } }
    public static Dictionary<PoliticalStances, List<Actor>> politicalList { get { return _politicalList; } }
    public static Dictionary<EconomicPosition, List<Actor>> economicalRangeList { get { return _economicalRangeList; } }

    public static void Add(Actor a) {
        _allActors.Add(a);

        // === ETHINICITY LIST ===
        if (!_skinColorList.ContainsKey(a.ethnicityHandler.ethnicity))
            _skinColorList.Add(a.ethnicityHandler.ethnicity, new List<Actor>());
        
        _skinColorList[a.ethnicityHandler.ethnicity].Add(a);

        // === RELIGION LIST ===
        if (!_religionList.ContainsKey(a.religion))
            _religionList.Add(a.religion, new List<Actor>());
        
        _religionList[a.religion].Add(a);

        // === POLITICAL STANCE LIST ===
        if (!_politicalList.ContainsKey(a.politicalStance))
            _politicalList.Add(a.politicalStance, new List<Actor>());
        
        _politicalList[a.politicalStance].Add(a);

        // === ECONOMICAL POSITION LIST ===
        if (!_economicalRangeList.ContainsKey(a.economicHandler.economicPosition))
            _economicalRangeList.Add(a.economicHandler.economicPosition, new List<Actor>());
        
        _economicalRangeList[a.economicHandler.economicPosition].Add(a);
    }
}
