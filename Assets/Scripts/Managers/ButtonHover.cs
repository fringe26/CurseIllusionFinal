using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Managers
{
    public class ButtonHover : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            Transform child = transform.GetChild(0);
            Image buttonBg = child.GetComponent<Image>();

            DOTween.To(() => buttonBg.fillAmount, x => buttonBg.fillAmount = x, 1, 0.5f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Transform child = transform.GetChild(0);
            Image buttonBg = child.GetComponent<Image>();

            DOTween.To(() => buttonBg.fillAmount, x => buttonBg.fillAmount = x, 0, 0.5f);
        }
    }
}
