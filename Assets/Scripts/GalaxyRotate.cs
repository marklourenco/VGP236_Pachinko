using UnityEngine;

public class GalaxyRotate : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 100.0f;

    [SerializeField]
    private bool rotateClockwise = true;

    void Update()
    {
        float direction = rotateClockwise ? -1 : 1;

        transform.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime);
    }
}
