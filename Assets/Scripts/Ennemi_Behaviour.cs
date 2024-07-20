using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class Ennemi_Behaviour : MonoBehaviour
{
    private NavMeshAgent _Agent;
    [SerializeField] private float timerValue = 1;
    private Transform _PlayerTransform;
    private float timer;
    private void Start()
    {
        _Agent = GetComponent<NavMeshAgent>();
        timer = timerValue;
        _PlayerTransform = FindObjectOfType<XROrigin>().transform;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = timerValue;
            _Agent.SetDestination(_PlayerTransform.position);
        }
    }
}
