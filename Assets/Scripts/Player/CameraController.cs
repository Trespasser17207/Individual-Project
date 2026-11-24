using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float sensX;
    public float sensY;

    private float xRot;
    Vector2 look;
    Mouse mouse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouse = Mouse.current;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        look = mouse.delta.ReadValue();
        Debug.Log(look);

        xRot -= look.y;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        transform.parent.rotation = Quaternion.Euler(0f, 0f, look.y);
    }
}
