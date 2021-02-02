using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMouse : MonoBehaviour
{
	public GameMaster GM;
	public GameObject Pointer;
	public GameObject Player;
	public float MaxDistance = 10;
	public LayerMask InterractiveMasks;

	RaycastHit _hitInfo;

	[HideInInspector] public bool Dragging;

	GameObject _menuSelected;
	GameObject _feedbackMenu;

	private void Update()
	{
		if (!Dragging && !GameMaster.OnMenu)
			AimInGame();
		else
		{
			Pointer.SetActive(false);
			AimMenu();
		}
			
	}

	void AimInGame()
	{
		if(Hit())
		{
			if(_hitInfo.transform.tag == "Ground")
			{
				Pointer.SetActive(true);
				Pointer.transform.position = _hitInfo.point;

				if (Input.GetMouseButtonDown(1))
					Player.transform.position = _hitInfo.point +(Vector3.up);
			}
			else
				Pointer.SetActive(false);
		}
		else
			Pointer.SetActive(false);
	}

	void AimMenu()
	{
		if (Hit())
		{
			if (_hitInfo.transform.tag == "UI")
			{
				if (_menuSelected != _hitInfo.transform.gameObject)
				{
					if(_feedbackMenu != null)
						_feedbackMenu.SetActive(false);
					_menuSelected = _hitInfo.transform.gameObject;
					if(_menuSelected.transform.childCount>0)
						_feedbackMenu = _menuSelected.transform.GetChild(0).gameObject;

					_feedbackMenu.SetActive(true);
				}

				if(Input.GetMouseButtonDown(0))
				{
					if (_hitInfo.transform.gameObject.TryGetComponent(out MenuAction action))
						GM.MenuSelect(action.action);

				}
			}
			else
			{
				_menuSelected = null;
				if (_feedbackMenu != null)
					_feedbackMenu.SetActive(false);
			}
		}
		else
		{
			_menuSelected = null;
			if (_feedbackMenu != null)
				_feedbackMenu.SetActive(false);
		}
	}

	bool Hit()
	{
		bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hitInfo, MaxDistance, InterractiveMasks);

		if (hit)
			return true;
		else
			return false;
	}
}
