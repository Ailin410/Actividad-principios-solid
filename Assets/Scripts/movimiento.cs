using UnityEngine;
using UnityEngine.InputSystem;

//Sistema de estamina
//Con esta clase especifica, la estamina solo se encarga de regenerarse y disminuir. 
public class StaminaSystem
{
    private float maxStamina;
    private float stamina;
    private float bajaStamina; //Baja la estamina por segundo.
    private float subeStamina; //Sube la estamina por segundo.

    public StaminaSystem(float max, float baja, float sube)
    {
        //Es la estamina al iniciar
        maxStamina = max;
        stamina = max;
        bajaStamina = baja;
        subeStamina = sube;

        public float CurrentStamina => stamina; //Devuelve cuanta estamina tiene
        public bool HasStamina => stamina > 0f; //Devuelve verdadero si hay estamina, sino devuelve falso

        public void Baja(float deltaTime)
        {
             //Resta estamina y si baja de cero lo corrigue y lo deja en 0
            stamina -= bajaStamina * deltaTime;
            if (stamina < 0f) stamina = 0f;
        }

        public void Sube(float deltaTime)
        {
            //Suma estamina y cuando supera el maximo se corrigue y lo deja en el valor maximo
            stamina += subeStamina * deltaTime;
            if (stamina > maxStamina) stamina = maxStamina;
        }

}

//Interfaz de la camara
//Con esta interfaz, el jugador depende de esta y no de un metodo en concreto
public interface ICameraController
    {
        void Look(Transform playerTransform, Camera playerCamera);
    }

    //Movimiento de la camara con mouse
    //Con esta clase, solo se encarga del movimiento de la camara con el mouse

    public class MouseCameraController : ICameraController
    {
        private float sensitivity;
        private float xRotation = 0f;

        public MouseCameraController(float sensitivity)
        {
            this.sensitivity = sensitivity;
        }

        public void Look(Transform playerTransform, Camera playerCamera)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue() * sensitivity;

            xRotation -= mouseDelta.y;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerTransform.Rotate(Vector3.up * mouseDelta.x);
        }
    }


    //Codigo base
    public class movimiento : MonoBehaviour
{
        public float walkSpeed = 2f;
        public float runSpeed = 6f;

        public float maxStamina = 50f;
        public float staminaDism = 10f;
        public float staminaRegen = 5f;

        public Camera playerCamera;
        public float mouseSensitivity = 0.2f;
        private Rigidbody rb;
        private Vector2 moveInput;
        private StaminaSystem staminaSystem;
        private ICameraController cameraController;


        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

            // Stamina (SRP)
            staminaSystem = new StaminaSystem(maxStamina, staminaDism, staminaRegen);

            // Cámara (DIP)
            cameraController = new MouseCameraController(mouseSensitivity);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            // Usamos la abstracción
            cameraController.Look(transform, playerCamera);
            
        }

        private void FixedUpdate()
        {
            bool isRunning = Keyboard.current.shiftKey.isPressed && staminaSystem.HasStamina;
            float currentSpeed = isRunning ? runSpeed : walkSpeed;

            if (isRunning)
                staminaSystem.Baja(Time.fixedDeltaTime);
            else
                staminaSystem.Sube(Time.fixedDeltaTime);

            Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
            if (move.magnitude > 1f) move.Normalize();

            rb.MovePosition(rb.position + move * currentSpeed * Time.fixedDeltaTime);
        }

        public void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
        }



    }
