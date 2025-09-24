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


    //Movimiento inicial
    public class movimiento : MonoBehaviour
{
   

}
