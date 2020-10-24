using UnityEngine;

public class Paddle : MonoBehaviour {
    // Configuration Parameters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    // Update is called once per frame
    void Update() {
        float mousePositonXInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = transform.position;
        paddlePosition.x = Mathf.Clamp(mousePositonXInUnits, minX, maxX);
        transform.position = paddlePosition;
    }
}
