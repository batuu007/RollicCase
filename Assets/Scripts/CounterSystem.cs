using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterSystem : MonoBehaviour
{
    [SerializeField] public bool isEntered = false;
    [SerializeField] private Counter _counter;
    [SerializeField] private GameObject _platform, _accessBarLeft, _accessBarRight;
    [SerializeField] private Vector3 _objects;
    [SerializeField] private CollectibleSpawn _collectibleSpawn;

    private Sequence _seq;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isEntered)
        {
            isEntered = true;
            GameController.Instance.playerMoving = false;
            ThrowObjects();
            StartCoroutine(CounterCheck());
            Player.Instance.powerUpLeft.SetActive(false);
            Player.Instance.powerUpRight.SetActive(false);
        }
    }
    IEnumerator CounterCheck()
    {
        yield return new WaitForSeconds(5f);
        if (_counter.BallCount < _counter.NeedCount)
        {
            Level.Instance.LevelFailed();
            Debug.Log("Level Failed");
            Destroy(GameObject.FindGameObjectWithTag("Balls"));
            _collectibleSpawn.ObjectsSpawner();
            GameController.Instance.touchToStartCanvas.SetActive(false);
            GameController.Instance.initialTouch = true;
        }
        if (_counter.BallCount >= _counter.NeedCount)
        {
            yield return new WaitForSeconds(1f);
            PlatformMovement();
            yield return new WaitForSeconds(4f);
            PowerUpAnimation();
            yield return new WaitForSeconds(1.5f);
            GameController.Instance.NextLevelSteps();
            GameController.Instance.playerMoving = true; 
        }
    }
    private void ThrowObjects()
    {
        Collider[] hit = Physics.OverlapBox(transform.position, _objects);

        foreach (Collider collider in hit)
        {
            if (collider.gameObject.CompareTag("Balls"))
            {
                collider.GetComponent<Rigidbody>().velocity += Vector3.forward * 10f;
            }
        }
    }
    private void PlatformMovement()
    {
        _seq = DOTween.Sequence();
        _seq.Append(_platform.transform.DOLocalMove(new Vector3(0, 0.77f, 136.89f), 1f))
               .Append(_platform.transform.DOScale(new Vector3(12, 1, 10f), 1f).SetEase(Ease.OutBack))
               .Append(_platform.transform.DOScale(new Vector3(10, 0.7f, 8f), 1f).SetEase(Ease.OutCubic));
    }
    private void PowerUpAnimation()
    {
        _accessBarLeft.GetComponent<Animator>().enabled = true;
        _accessBarRight.GetComponent<Animator>().enabled = true;
    }
}
