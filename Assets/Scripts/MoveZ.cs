using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZ : MonoBehaviour
{
    public static float VELOCITY = -17;
    public static float DOWNHILL_VELOCITY_MULTIPLIER = 2f;

    [HideInInspector] public bool isDownHill = false;
    [SerializeField] private List<Transform> moveList = new List<Transform>();
    [SerializeField] private float _multiplier = 1;
    public float TrueSpeed => VELOCITY * _multiplier;

    public float Multiplier => _multiplier;



    private void FixedUpdate()
    {
        if (GameController.Instance.playerMoving) moveList.ForEach(t => t.position = t.position + (Vector3.forward * TrueSpeed * Time.deltaTime));
    }

    public void SetMultiplier(float multiplier)
    {
        _multiplier = multiplier;
    }

    public void RestoreMultiplierDefault()
    {
        SetMultiplier(1);
    }
}
