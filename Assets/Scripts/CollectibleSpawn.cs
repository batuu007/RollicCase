using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _collectible;
    [SerializeField] private GameObject[] _collectibles;
    [SerializeField] private Vector3[] _positions;
    [SerializeField] private bool _isRandom;
    [SerializeField] private GameObject _parent;
    void Start()
    {
        ObjectsSpawner();
    }

    public void ObjectsSpawner()
    {
        if (!_isRandom)
        {
            for (int i = 0; i < _positions.Length; i++)
            {
                var spawner = Instantiate(_collectible, transform.position + _positions[i], transform.rotation);
                spawner.transform.parent = transform.parent;
            }
        }
        else
        {
            int random = Random.Range(0, _collectibles.Length);
            for (int i = 0; i < _positions.Length; i++)
            {
                var spawner = Instantiate(_collectibles[random], transform.position + _positions[i], transform.rotation);
                spawner.transform.parent = transform.parent;
            }
        }
    }
}
