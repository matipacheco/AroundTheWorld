using UnityEngine;
using System.Collections;

public class PlaneLighting : MonoBehaviour {
    // Note: for reasons I do not know, Unity hates more than one light on the same object.
    // To change this, you have to change the Pixel Light Count on Edit > Project Settings > Quality
    // https://answers.unity.com/questions/813903/unity-hates-more-than-2-spotlights.html?sort=votes

    private bool lightsOff;
    private StarsLighting dayLighting;

    [SerializeField] float blinkInterval = .5f;
    [SerializeField] private Light[] planeLights;

    private void Start() {
        dayLighting = FindObjectOfType<StarsLighting>();
        TurnLightsOff();

        StartCoroutine(BlinkLights());
    }

    private IEnumerator BlinkLights() {
        while (true) {
            yield return new WaitForSeconds(blinkInterval);

            if (dayLighting.GetIsDay()) {
                if (!lightsOff) {
                    TurnLightsOff();
                }
            } else {
                Blink();
            }
        }
    }

    private void TurnLightsOff() {
        lightsOff = true;

        foreach(Light light in planeLights) {
            light.enabled = false;
        }
    }

    private void Blink() {
        lightsOff = false;

        foreach(Light light in planeLights) {
            light.enabled = !(light.enabled);
        }
    }
}
