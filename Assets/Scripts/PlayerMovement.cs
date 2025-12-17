using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2f;
    public float horizontalSpeed = 3f;
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;
    [SerializeField] bool isRunning;

    void Update()
    {
        if (isRunning == false)
        {
            isRunning = true;
            StartCoroutine(AddDistance());
        }

        // Movimiento constante hacia adelante (espacio mundo)
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        Vector3 position = transform.position;

        // Movimiento lateral izquierdo
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && position.x > leftLimit)
        {
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed, Space.World);
        }

        // Movimiento lateral derecho
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && position.x < rightLimit)
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed, Space.World);
        }
    }

    IEnumerator AddDistance()
    {
        yield return new WaitForSeconds(0.35f);
        MasterInfo.distanceRun += 1;
        isRunning = false;
    }
}
