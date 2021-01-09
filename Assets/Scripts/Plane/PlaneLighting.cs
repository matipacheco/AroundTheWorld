using UnityEngine;
using System.Collections;

public class PlaneLighting : MonoBehaviour {
    StarsLighting dayLighting;

    [SerializeField] float blinkInterval = .5f;
    [SerializeField] private Light[] planeLights;

    private void Start() {
        dayLighting = FindObjectOfType<StarsLighting>();
        StartCoroutine(BlinkLights());
    }

    private IEnumerator BlinkLights() {
        while (true) {
            if (dayLighting.GetIsDay()) {
                yield return new WaitForSeconds(blinkInterval);

                foreach(Light light in planeLights) {
                    Blink(light);
                }
            }
        }
    }

    private void Blink(Light light) {
        light.enabled = !(light.enabled);
        Debug.Log("blink");
    }
}
