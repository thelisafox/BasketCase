using UnityEngine;

public class Rotateable : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, -Input.GetAxis("Horizontal") * speed);
    }
}
