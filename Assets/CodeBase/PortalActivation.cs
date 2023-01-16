using System;
using DG.Tweening;
using UnityEngine;

namespace CodeBase
{
    public class PortalActivation : MonoBehaviour
    {
        private Sequence _sequence;
        private void Start()
        {
            _sequence.Append(transform.DOScale(Vector3.one, 2f))
                .Join(transform.DORotate(new Vector3(180, 0, 0), 0.5f).SetLoops(7,LoopType.Incremental));


        }
    }
}
