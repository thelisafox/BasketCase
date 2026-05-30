using UnityEngine;
using UnityEngine.InputSystem;

public class Rotateable : MonoBehaviour
{
    public float speed;

    private void OnMove(InputAction.CallbackContext context)
    {
        transform.RotateAround(transform.position, transform.up, Input.GetAxis("Mouse X") * Time.deltaTime * speed);
    }
}
