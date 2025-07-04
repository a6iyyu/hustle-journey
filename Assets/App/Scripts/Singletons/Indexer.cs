namespace Assets.App.Scripts.Singletons
{
	using System.Collections.Generic;
	using UnityEngine;
	using System;
    using Assets.App.Entities;

	public class Indexer : MonoBehaviour
	{
		private static Indexer _instance;

		public static Indexer Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = FindAnyObjectByType<Indexer>();
					if (_instance == null)
					{
						var go = new GameObject("Indexer");
						_instance = go.AddComponent<Indexer>();
						DontDestroyOnLoad(go);
					}
				}
				return _instance;
			}
		}
		private void Awake()
		{
			if (_instance != null && _instance != this)
			{
				Destroy(gameObject);
				return;
			}
			_instance = this;
			DontDestroyOnLoad(gameObject);

			Characters = new Dictionary<Guid, Character>();
			Pets = new Dictionary<Guid, Pet>();
		}
		public Dictionary<Guid, Character> Characters { get; private set; }
		public Dictionary<Guid, Pet> Pets { get; private set; }
	}
}