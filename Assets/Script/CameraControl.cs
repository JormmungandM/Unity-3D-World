using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject Player;
    private Vector3 rod;

    private float camAngleX;   
    private float camAngleX0;  
    private float camAngleY;
    private const float VertSens = 1.0f;
    private const float HorSens = 1.0f;

    private float zoomMax = 1.0f;
    private float zoomMin = 0.1f;
    private float zoomSens = 1.0f;
    private float zoom = 1.0f;

    void Start()
    {
        Player = GameObject.Find("Player");
        rod = this.transform.position - Player.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        camAngleX0 = camAngleX = this.transform.eulerAngles.y;    
        camAngleY = this.transform.eulerAngles.x;
    }
    private void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * VertSens * Time.timeScale;
        float mouseX = Input.GetAxis("Mouse X") * HorSens * Time.timeScale;
        camAngleY -= mouseY;
        camAngleX += mouseX;

        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSens;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);
    }
    void LateUpdate()
    {
        transform.position = Player.transform.position
            + Quaternion.Euler(0, camAngleX - camAngleX0, 0) * rod * zoom;

        transform.eulerAngles = new Vector3(camAngleY, camAngleX, 0);
        if (Input.GetMouseButtonDown(0))
        {   

        }else if (Input.GetMouseButtonDown(2))
        {

        }
        else
        {
            Vector3 pf = Quaternion.Euler(0, -camAngleX0, 0) * this.transform.forward;
            pf.y = 0;
            Player.transform.forward = pf.normalized;
        }
    }
}
