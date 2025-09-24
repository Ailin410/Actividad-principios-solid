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

    //Movimiento con mouse

    //Movimiento inicial
    public class movimiento : MonoBehaviour
{
   

}
