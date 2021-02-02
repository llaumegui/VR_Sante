using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody _rb;
	public float Speed;

	[Header("GroundCheck")]
	[Range(0,1)] public float CheckDistance;
	public Transform Foot;

	void Start()
    {
		_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		if(!GameMaster.OnMenu)
			Move();
    }

	void Move()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = base.transform.right * x + base.transform.forward * z;

		//_rb.velocity = move * Speed * Time.deltaTime;

		_rb.MovePosition(base.transform.position + move * Speed * Time.deltaTime);

		if (!GroundCheck())
			_rb.velocity += Physics.gravity * Time.deltaTime;
		else
			_rb.velocity = Vector3.down;
	}

	bool GroundCheck()
	{
		bool hit;
		Vector3 pos;
		if (Foot == null)
			pos = transform.position;
		else
			pos = Foot.position;

		hit = Physics.Raycast(pos, Vector3.down, CheckDistance);

		return hit;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;

		Gizmos.DrawRay(transform.position, Vector3.down * CheckDistance);
	}
}
