using UnityEngine;

public class WorldMovement : MonoBehaviour {
    [SerializeField] private float speed = 100f;

    void Update() {
        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}