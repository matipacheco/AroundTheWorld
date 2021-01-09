using UnityEngine;
using System.Collections;

public class PlaneLighting : MonoBehaviour {
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
