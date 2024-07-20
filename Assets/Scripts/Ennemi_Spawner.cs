using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _EnemiPrefab;
    [SerializeField] private float _SpawnRadius = 10;
    [SerializeField] private float _BaseTimer = 3;
    [SerializeField] private AnimationCurve _SpawnTimerCurve;
    [SerializeField] private float _MaxTimeOnCurve = 100;
    [SerializeField] private int _MaxNumOfUnitSpawned = 3;
    [SerializeField] private int _MinNumOfUnitSpawned = 1;
    private float timePassed;


    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
    }

    IEnumerator SpawnCoroutine()
    {
        float timeValue = Mathf.Min(timePassed / _MaxTimeOnCurve, 1);
        yield return new WaitForSeconds(_SpawnTimerCurve.Evaluate(timeValue));
        for(int i = 0; i < Random.Range(_MinNumOfUnitSpawned, _MaxNumOfUnitSpawned); i++)
        {
            Vector3 spawnPoint = Random.insideUnitCircle * _SpawnRadius + (Vector2)transform.position;
            Instantiate(_EnemiPrefab, spawnPoint, Quaternion.identity);
        }
        StartCoroutine(SpawnCoroutine());
    }

}
