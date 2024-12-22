using DG.Tweening;
using Ebleme.KBB3DRunner.Ant;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10;

    [SerializeField] private float rotateDuration = 1f;
    [SerializeField] private float bounceDuration = 1f;


    [SerializeField] private float energyIncrease = 10;


    private Sequence seq;
    private void Start()
    {
        seq = DOTween.Sequence();
        seq.Append(transform.DOMoveY(1, bounceDuration));
        seq.Insert(0,
            transform.DORotate(new Vector3(0, 360, 0), rotateDuration, RotateMode.FastBeyond360));
        seq.AppendInterval(.2f);
        seq.Append(transform.DOMoveY(0, bounceDuration));
        seq.Insert(1, transform.DORotate(new Vector3(0, -360, 0), rotateDuration, RotateMode.FastBeyond360));
        seq.SetLoops(-1);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        Player.Instance.Collected(energyIncrease);
    }

    private void OnDestroy()
    {
       seq.Kill();
    }
}