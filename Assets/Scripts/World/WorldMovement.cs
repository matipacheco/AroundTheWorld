using UnityEngine;

public class WorldMovement : MonoBehaviour {
    [SerializeField] private float speed = 50f;

    void Update() {
        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}