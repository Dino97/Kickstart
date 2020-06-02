using UnityEngine;
using System.Collections;

namespace Kickstart
{
	public class GameObjectPool
	{
		private GameObject[] _pool;



		public GameObjectPool(GameObject prefab, int capacity)
		{
			_pool = new GameObject[capacity];

			for (int i = 0; i < capacity; i++)
			{
				_pool[i] = Object.Instantiate(prefab);
				_pool[i].SetActive(false);
			}
		}

		public GameObject Get()
		{
			throw new System.NotImplementedException();
		}

		public void Return(GameObject g)
		{
			throw new System.NotImplementedException();
		}
	}
}