using UnityEngine;

// TODO: implement IEnumerable and IEnumerator

namespace Kickstart
{
	[System.Serializable]
	public class ObjectPool<T> where T : Object
	{
		public int Capacity { get; private set; }
		public int Count { get; private set; }

		private (T obj, bool taken)[] _pool;



		public ObjectPool(T prefab, int capacity)
		{
			Capacity = capacity;
			_pool = new (T, bool)[capacity];

			for (int i = 0; i < capacity; i++)
			{
				_pool[i].obj = Object.Instantiate(prefab);
			}
		}

		~ObjectPool()
		{
			for (int i = 0; i < Capacity; i++)
				if (_pool[i].obj != null)
					Object.Destroy(_pool[i].obj);
		}

		public T Get()
		{
			if (Count == Capacity)
				return null;

			for (int i = 0; i < Capacity; i++)
			{
				if (_pool[i].taken == false)
				{
					_pool[i].taken = true;
					Count++;

					return _pool[i].obj;
				}
			}

			return null;
		}

		public void Return(T gameObject)
		{
			for (int i = 0; i < Capacity; i++)
			{
				if (_pool[i].obj.GetInstanceID() == gameObject.GetInstanceID())
				{
					_pool[i].taken = false;
					Count--;

					break;
				}
			}
		}

		public void ForEach(System.Action<T> action)
		{
			for (int i = 0; i < Capacity; i++)
				action.Invoke(_pool[i].obj);
		}
	}
}