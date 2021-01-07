using UnityEngine;

public class HelixMovement : MonoBehaviour {
    [SerializeField] private float speed = 200f;

    void Update() {
        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}
