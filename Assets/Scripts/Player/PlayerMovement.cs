using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Unity.Mathematics;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 inputDirection; // X and Y values from input system
    private Rigidbody rb; // rigidbody
    private Vector3 playerMove; // vector3 used for setting the above input direction (2 dimentional) as a 3 dimentional vector

    public float speedMultiplier; // public player speed attribute


    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // get and set the players rigid body
    }

    /*
     * Move function uses the new unity "Input Action" system, specifically the one that comes pre packaged with every project.
     * in this context, the move function will return a vector 2 output from the WASD keys.
     * A and D will return (1,0) and (-1,0) respectively.
     * W and S will also return (0,1) and (0,-1) respectively.
     * 
     * This function is only called when pressing the key and letting go, any ticks where the the button is held it is not called.
     */
    public void Move(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>(); // read value from Input Action
        playerMove = new Vector3(inputDirection.x, 0, inputDirection.y); // setting the player move values
        Debug.Log(inputDirection);
    }

    private void Update()
    {
        rb.linearVelocity = (playerMove * speedMultiplier); // due to Move not being continous, actual changes to velocity are handled in update.
    }
}
