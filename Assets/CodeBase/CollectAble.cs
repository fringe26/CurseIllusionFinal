using System;
using DG.Tweening;
using UnityEngine;

namespace CodeBase
{
    public class CollectAble : MonoBehaviour
    {
        private void Start()
        {
            transform.DOLocalRotate(new Vector3(0, 90, 0), 0.5f).SetLoops(-1, LoopType.Incremental);
        }

        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
        }
    }
}
