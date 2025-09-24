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



    //Movimiento inicial
    public class movimiento : MonoBehaviour
{
   

}
