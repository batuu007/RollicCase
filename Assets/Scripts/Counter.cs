using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private int _ballCount=0;
    public int BallCount => _ballCount;

    [SerializeField] private int _needCount;
    public int NeedCount => _needCount;
    [SerializeField] private TextMeshPro _ballCountText;
    [SerializeField] private int _counter;

    private void Start()
    {
        _ballCountText.text = "" + _ballCount + "/" + _needCount;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Balls"))
        {
            Destroy(other.gameObject, 4f);
            _ballCount++;
            _ballCountText.text = "" + _ballCount + "/" + _needCount;
        }
    }
}
