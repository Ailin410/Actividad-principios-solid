# Actividad-principios-solid

En el codigo inicial estaba todo en una sola clase, en esta actividad dividi de la siguiente manera las tareas:
Con el Principio de Responsabilidad Única, implemente lo siguiente: 
- Una clase nueva, la cual solo controla la estamina, con este sistema esta clase solo se encarga de regenerar y disminuir la estamina del personaje.
- Una clase del movimiento de la camara con el mouse, por lo que solo se encarga de que esto suceda.
- Y la clase del movimiento del jugador, el cual solo tiene la logoca del movimiento y la utilización de las otras clases.

Con el Principio de Inversión de Dependencias, implemente la interfaz de la camara, la cual logra que el movimiento del jugador no dependa del movimiento del mouse sino de la interfaz de la camara, es decir que podemos con estop cambiar el tipo de camara.
