using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAction : MonoBehaviour
{
	public enum Action
	{
		Play,
		Quit,
		Next,
	}

	public Action action;
}
