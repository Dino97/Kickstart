using UnityEngine;
using System.Collections.Generic;

public class RandomPool<T>
{
    private List<T> _pool;



    public RandomPool(IEnumerable<T> collection)
    {
        _pool = new List<T>(collection);
    }

    public T GetRandom()
    {
        if (_pool.Count > 0)
        {
            int randomId = Random.Range(0, _pool.Count);
            T randomObj = _pool[randomId];
            _pool.RemoveAt(randomId);

            return randomObj;
        }

        return default;
    }
}