using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class GenericNpcController : MonoBehaviour, INpcController
{
    [SerializeField] private string[] _lowMoralLines;
    [SerializeField] private string[] _mediumMoralLines;
    [SerializeField] private string[] _highMoralLines;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {

    }
}
