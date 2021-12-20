using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Models;

public class CharacterControllerScript : MonoBehaviour
{
    private CharacterController characterController;
    private DefaultInput defaultInput;
    public Vector2 input_Movement;
    public Vector2 input_View;

    private Vector3 newCameraRotation;
    private Vector3 newCharacterRotation;

    [Header("References")]
    public Transform cameraHolder;
    public GameObject FadeIn;
    public GameObject Resistencias;
    public AudioSource hoja;
    public AudioSource pasos;

    [Header("Settings")]
    public PlayerSettingsModel playerSettings;
    public float viewClampYMin;
    public float viewClampYMax;

    [Header("Gravity")]
    public float gravityAmount;
    public float gravityMin;
    public float playerGravity;

    private bool Hactivo;
    private bool Vactivo;
    public bool showResistencias = false;

    private void Awake() 
    {
        defaultInput = new DefaultInput();

        defaultInput.Character.Movement.performed += e => input_Movement = e.ReadValue<Vector2>();
        defaultInput.Character.View.performed += e => input_View = e.ReadValue<Vector2>();

        defaultInput.Enable();

        newCameraRotation = cameraHolder.localRotation.eulerAngles;
        newCharacterRotation = transform.localRotation.eulerAngles;

        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        FadeIn.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("space"))
        {
            hoja.Play();
            showResistencias = !showResistencias;
        }

        if (showResistencias == true)
        {
            Resistencias.GetComponent<Animator>().Play("PaperRedAnimation");
        }
        else 
        {
            Resistencias.GetComponent<Animator>().Play("PaerRedAnimationBack");
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            if (Vactivo == false)
            {
                pasos.Play();
                Hactivo = true;
            }
        }

        if (Input.GetButtonDown("Vertical"))
        {
            if (Hactivo == false)
            {
                pasos.Play();
                Vactivo = true;
            }
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            Hactivo = false;

            if (Vactivo == false)
            {
                pasos.Stop();
            }
        }

        if (Input.GetButtonUp("Vertical"))
        {
            Vactivo = false;

            if (Hactivo == false)
            {
                pasos.Stop();
            }
        }

        CalculateView();
        CalculateMovement();
    }

    private void CalculateView()
    {
        newCharacterRotation.y += playerSettings.ViewXSensitivity * (playerSettings.ViewXInverted ? -input_View.x : input_View.x) * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(newCharacterRotation);

        newCameraRotation.x += playerSettings.ViewYSensitivity * (playerSettings.ViewYInverted ? input_View.y : -input_View.y) * Time.deltaTime;
        newCameraRotation.x = Mathf.Clamp(newCameraRotation.x, viewClampYMin, viewClampYMax);

        cameraHolder.localRotation = Quaternion.Euler(newCameraRotation);
    }

    private void CalculateMovement()
    {
        var verticalSapeed = playerSettings.WalkingForwardSpeed * input_Movement.y * Time.deltaTime;
        var horizontalSpeed = playerSettings.WalkingStrafeSpeed * input_Movement.x * Time.deltaTime;

        var movementSpeed = new Vector3(horizontalSpeed, 0, verticalSapeed);
        var newMovementSpeed = transform.TransformDirection(movementSpeed);

        if (playerGravity > gravityMin) 
        {
            playerGravity -= gravityAmount * Time.deltaTime;
        }

        if (playerGravity<-1 && characterController.isGrounded)
        {
            playerGravity = -1;
        }

        newMovementSpeed.y += playerGravity;

        characterController.Move(newMovementSpeed);
    }
}
