using UnityEngine;

public class HelixMovement : MonoBehaviour {
    [SerializeField] private float speed = 300f;

    private void Update() {
        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}
