using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : MonoBehaviour
{
	public bool PlayBreathe;

	private void Start()
	{
		int rdm = Random.Range(0, 2);

		if (rdm != 0)
			PlayBreathe = true;

		Breathe();
	}

	void Breathe()
	{
		if (PlayBreathe)
			SoundManager.PlayLoop("Breathing", SoundManager.Sound.Breathing, 1, false, true, transform.position,3);
	}
}
