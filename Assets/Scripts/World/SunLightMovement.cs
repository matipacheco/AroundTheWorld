using UnityEngine;

public class SunLightMovement : MonoBehaviour {
    [SerializeField] private Color dayColor = new Color(170f, 200f, 230f, 0f);
    [SerializeField] private Color sunsetColor = new Color(200f, 100f, 70f, 0f);
    [SerializeField] private Color nightColor = new Color(10f, 50f, 50f, 0f);
    [SerializeField] private Color dawnColor = new Color(250f, 230f, 180f, 0f);

    private float timer = 0.0f;
    private const float dayDuration = 60f;

    private Camera mainCamera;

    private Gradient gradient;
    private GradientColorKey[] colorKey;
    private GradientAlphaKey[] alphaKey;

    private void Start() {
        mainCamera = GetComponent<Camera>();

        gradient = new Gradient();

        colorKey = new GradientColorKey[4];

        colorKey[0].color = dayColor;
        colorKey[0].time = 0.0f;

        colorKey[1].color = sunsetColor;
        colorKey[1].time = 0.35f;

        colorKey[2].color = nightColor;
        colorKey[2].time = 0.70f;

        colorKey[3].color = dawnColor;
        colorKey[3].time = 1.0f;

        alphaKey = new GradientAlphaKey[4];

        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;

        alphaKey[1].alpha = 0.70f;
        alphaKey[1].time = 0.35f;

        alphaKey[2].alpha = 0.35f;
        alphaKey[2].time = 0.70f;

        alphaKey[3].alpha = 0.0f;
        alphaKey[3].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);
    }

    private void Update() {
        timer += Time.deltaTime;
        mainCamera.backgroundColor = gradient.Evaluate(timer / dayDuration);
    }
}
