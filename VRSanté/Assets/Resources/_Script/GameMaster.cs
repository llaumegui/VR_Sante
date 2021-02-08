using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
	public static bool OnMenu;
	public Transform UIPos;
	public Transform Player;
	public GameObject Background;
	Vector3 GamePos = new Vector3(0,1,0);

	[Header("Menu")]
	public GameObject[] Menus;
	Camera _cam;

	GameObject _menuOpened;

	private void Start()
	{
		ClearMenu();
		_cam = Camera.main;
		PlayMenu(Menus[0]);
	}

	void ClearMenu()
	{
		foreach (GameObject menu in Menus)
			menu.SetActive(false);

		if(_menuOpened != null)
		_menuOpened.SetActive(false);

		OnMenu = false;
		Background.SetActive(false);
	}
	void PlayMenu(GameObject UI)
	{
		_menuOpened = UI;
		UI.transform.position = UIPos.position;
		UI.transform.rotation = UIPos.rotation;

		UI.SetActive(true);
		OnMenu = true;
		Background.SetActive(true);
	}

	public void MenuSelect(MenuAction.Action act)
	{
		if(act == MenuAction.Action.Play)
		{
			ClearMenu();
			PlayMenu(Menus[1]);
		}
		if (act == MenuAction.Action.Quit)
			Application.Quit();
		if (act == MenuAction.Action.Next)
		{
			ClearMenu();
			Player.position = GamePos;
		}
			
	}

}
