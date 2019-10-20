using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class AppearanceGenerator : MonoBehaviour
{
    public void Initialize() {
        var mat = GetComponent<MeshRenderer>().materials[0];
        mat.color = GetSkinColor();
    }

    private Color GetSkinColor() {
        var actor = GetComponent<Actor>();

        switch (actor.ethnicity)
        {
            case Ethnicities.Black: return new Color(0.5f, 0.2f, 0f);
            case Ethnicities.White: return new Color(0.9f, 0.8f, 0.7f);
            case Ethnicities.Yellow: return new Color(1f, 0.9f, 0.5f);
            default:
                Debug.LogError("AppearanceGenerator::GetSkinColor() -- Invalid actor.ethnicity");
                break;
        }

        return new Color(0.9f, 0, 1f);
    }
}
