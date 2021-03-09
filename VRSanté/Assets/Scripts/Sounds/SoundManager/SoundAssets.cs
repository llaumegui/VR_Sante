﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAssets : MonoBehaviour
{

	static SoundAssets _i;
	public static SoundAssets i
	{ get
		{
			if(_i == null)
			{
				_i = Instantiate(Resources.Load<SoundAssets>("Prefabs/SoundAssets")); //glisser le script dans un prefab dans le dossier 'Resources'
			}
			return _i;
		}
	}

	public AnimationCurve SpacializedCurve;

	public List<GameObject> AudioLoops;

	[HideInInspector] public Dictionary<Vector3, float> spacializedGizmos = new Dictionary<Vector3, float>();

	public string Hello()
	{
		return "Hello World";
	}
	
	[System.Serializable]
	public class SoundAudioClip //classe de la base de donnée des sons
	{
		public SoundManager.Sound sound;
		public AudioClip audioClip;
	}

	public SoundAudioClip[] soundAudioClips;

	private void OnDrawGizmos()
	{
		if(spacializedGizmos.Count>=1)
		{
			foreach (KeyValuePair<Vector3, float> spatial in spacializedGizmos)
			{
				Gizmos.color = Color.cyan;
				Gizmos.DrawWireSphere(spatial.Key, spatial.Value);
			}
		}
	}

}
