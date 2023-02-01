using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private float _maxSpawnPositionY;

    private float _elepsedTime = 0;

    private void Start()
    {
        Instalize(_template);
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if(_elepsedTime > _secondsBetweenSpawn)
        {
            if(TryGetObject(out GameObject pipe))
            {
                _elepsedTime = 0;

                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                Debug.Log("spawn");
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;

                DisableObjectAborderSceen();
            }
        }
    }
}
