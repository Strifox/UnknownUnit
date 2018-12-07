using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField]
    private float cameraSpeed = 0;

    //Max camera X limit
    private float xMaxLimit;
    //Max camera Y limit
    private float yMinLimit;


    // Update is called once per frame
    private void Update()
    {
        GetInput();
    }

    //Moves camera when pressing down the key
    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, xMaxLimit), Mathf.Clamp(transform.position.y, yMinLimit, 0), -10);
    }

    public void SetCameraLimits(Vector3 maxTile)
    {
        //Right button corner on screen
        Vector3 worldPointPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));

        xMaxLimit = maxTile.x - worldPointPosition.x;
        yMinLimit = maxTile.y - worldPointPosition.y;
    }
}
