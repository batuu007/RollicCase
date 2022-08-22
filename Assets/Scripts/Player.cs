using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] public GameObject powerUpLeft,powerUpRight;
    private void Update()
    {
        if (powerUpLeft.activeInHierarchy == true)
        {
            powerUpLeft.transform.DORotate(new Vector3(0, 360f, 0), 5f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetRelative()
                .SetEase(Ease.Linear);
            powerUpRight.transform.DORotate(new Vector3(0, -360f, 0), 5f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetRelative()
                .SetEase(Ease.Linear);
        }
    }
}
