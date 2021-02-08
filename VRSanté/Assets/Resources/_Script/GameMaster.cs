using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
	public static bool OnMenu;
	public Transform UIPos;
	public Transform Player;
	Vector3 GamePos = new Vector3(0,1,0);

	[Header("MainMenu")]
	public GameObject Menu;
	Camera _cam;

	GameObject _menuOpened;

	private void Start()
	{
		_cam = Camera.main;
		PlayMenu(Menu);
	}

	void PlayMenu(GameObject UI)
	{
		_menuOpened = UI;
		UI.transform.position = UIPos.position;
		UI.transform.rotation = UIPos.rotation;

		UI.SetActive(true);
		OnMenu = true;
	}

	void CloseMenu()
	{
		_menuOpened.SetActive(false);
		OnMenu = false;
	}

	public void MenuSelect(MenuAction.Action act)
	{
		if(act == MenuAction.Action.Play)
		{
			Player.position = GamePos;
			CloseMenu();
		}
		if (act == MenuAction.Action.Quit)
			Application.Quit();
	}

}
