using UnityEngine;

public class Rotateable : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.RotateAround(transform.position, transform.right, Input.GetAxis("Vertical") * speed);
        if (transform.childCount != 0) transform.GetChild(0).RotateAround(transform.position, transform.forward, -Input.GetAxis("Horizontal") * speed);
    }
}
