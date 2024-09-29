using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
///////////////////////////////////////////////////////////////////////

    // Player movement properties
    public Camera playerCamera;     public float walkSpeed = 6f;
    public float runSpeed = 12f;    public float jumpPower = 7f;
    public float gravity = 10f;     public float maxSpeed = 100f;
    public float crouchSpeed = 3f;  public float crouchHeight = 1f;
    public float normalHeight = 2f; public float lookSpeed = 2f;
    public float lookXLimit = 45f;  private Rigidbody rb;
    public bool canMove = true;     public bool DEBUG = false;
    private bool isGrounded;        float rotationX = 0;
///////////////////////////////////////////////////////////////////////
    // Stamina system
    public Image staminaBar;        private bool canRun = true;
    public float stamina = 100f;    public float maxStamina = 100f;
    
    public float staminaCost = 15f;  // Stamina used per second while running
    public float staminaRegenRate = 10f;  // Stamina regenerated per second

///////////////////////////////////////////////////////////////////////
/// EASTER
    public bool swapIt = false;
    private float maxStamEx = 75f;
    private float stamEx = 75f;
///////////////////////////////////////////////////////////////////////
    //Character Controller
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
///////////////////////////////////////////////////////////////////////

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        rb = GetComponent<Rigidbody>();
        stamina = maxStamina;
        staminaBar.fillAmount = 1f;
        swapIt = false;
    }

    void Update()
    {
        #region Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        characterController.Move(moveDirection * Time.deltaTime);


        // Check if the player is holding LeftShift and can run
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && canRun;

        // Adjust speed based on movement state
        float curSpeedX = canMove ? (Input.GetKey(KeyCode.LeftControl) ? crouchSpeed : (isRunning ? runSpeed : walkSpeed)) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (Input.GetKey(KeyCode.LeftControl) ? crouchSpeed : (isRunning ? runSpeed : walkSpeed)) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Move character
        characterController.Move(moveDirection * Time.deltaTime);

        #endregion

        #region Handles Stamina and Running
        if (isRunning && (curSpeedX != 0 || curSpeedY != 0))  // If moving and running
        {
            // Drain stamina
            stamina -= staminaCost * Time.deltaTime;
            if (stamina <= 0)
            {
                stamina = 0;
                canRun = false;  // Disable running when stamina is depleted
            }
        }
        else
        {
            // Regenerate stamina when not running
            stamina += staminaRegenRate * Time.deltaTime;
            if (stamina >= maxStamina)
            {
                stamina = maxStamina;
                canRun = true;  // Enable running when stamina is restored
            }
        }

        // Update the stamina bar UI
        staminaBar.fillAmount = stamina / maxStamina;

        #endregion

        #region Handles Jumping
        if (characterController.isGrounded)
        {
            moveDirection.y = 0; // Reset vertical movement when grounded

            if (Input.GetButton("Jump") && canMove)
            {
                moveDirection.y = jumpPower; // Jump
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime; // Apply gravity when not grounded
        }
        #endregion



        #region Handles Rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);              
            //playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        }
        #endregion

        #region EASTER
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            if(swapIt == false)
            {
                swapIt = true;
                maxStamina = maxStamEx;
                stamina = stamEx; 
            }
            else
            {
                swapIt = false;
                Debug.Log("CAM SWAP");
            }
        }
        #endregion
    }
}