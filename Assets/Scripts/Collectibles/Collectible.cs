using System;
using DG.Tweening;
using Ebleme.KBB3DRunner.Ant;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10;

    [SerializeField] private float rotateDuration = 1f;
    [SerializeField] private float bounceDuration = 1f;


    [SerializeField] private float energyIncrease = 10;


    /*
     * + Karınca temas ettiği an
     * + Yok olacak
     * + Particle fx
     * + Ses fx
     * + Karıncanın enerjisi artacak (EnergyBar yönetecek) Ne kadar?
     * + Idle - Etrafında dönme animasyonu
     * + Yukarı aşağı hareket
     */

    private Sequence seq;
    private void Start()
    {
        // rotateTween = transform.DORotate(new Vector3(0, 360, 0), rotateDuration, RotateMode.FastBeyond360)
        //     .SetEase(Ease.Linear).SetLoops(-1);

        seq = DOTween.Sequence();
        seq.Append(transform.DOMoveY(1, bounceDuration));
        seq.Insert(0,
            transform.DORotate(new Vector3(0, 360, 0), rotateDuration, RotateMode.FastBeyond360));
        seq.AppendInterval(.2f);
        seq.Append(transform.DOMoveY(0, bounceDuration));
        seq.Insert(1, transform.DORotate(new Vector3(0, -360, 0), rotateDuration, RotateMode.FastBeyond360));
        seq.SetLoops(-1);

        // transform.DOPunchPosition(Vector3.up, bounceDuration, 0).SetLoops(-1);

    }
    

    // private void Update()
    // {
    //     transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    //     
    // }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Karınca temas etti");
        Destroy(gameObject);

        // FindAnyObjectByType<Player>().Collected(energyIncrease);

        Player.Instance.Collected(energyIncrease);
    }

    private void OnDestroy()
    {
       seq.Kill();
    }
}