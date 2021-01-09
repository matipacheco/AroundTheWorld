using UnityEngine;

public class HelixRotation : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 300f;

    private void Update() {
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
    }
}
