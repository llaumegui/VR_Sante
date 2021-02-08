using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

	public float MouseSensitivity = 100;

	public Transform Player;

	float _xRotation = 0;


    // Start is called before the first frame update
    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
		Rotation();
	}

	void Rotation()
	{
		float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

		_xRotation -= mouseY;
		_xRotation = Mathf.Clamp(_xRotation, -90, 75);

		Player.Rotate(Vector3.up * mouseX);
		transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

	}
}
