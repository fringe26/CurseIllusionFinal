using System;
using DG.Tweening;
using UnityEngine;

namespace CodeBase
{
    public class PortalActivation : MonoBehaviour
    {
        private void Start()
        {
            
            transform.DOScale(Vector3.one, 2f);
        }
    }
}
