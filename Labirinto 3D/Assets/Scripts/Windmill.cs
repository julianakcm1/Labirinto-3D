using UnityEngine;

public class WindmillBladeController : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidade de rotação das pás

    void Update()
    {
        // Rotaciona as pás do catavento continuamente no sentido horário em torno do eixo local Z
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}

