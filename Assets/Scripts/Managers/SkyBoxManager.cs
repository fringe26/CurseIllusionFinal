using System;
using DG.Tweening;
using UnityEditor;
using UnityEngine;


namespace Managers
{
    public class SkyBoxManager : MonoBehaviour
    {
        private float _blend;
        private static readonly int Blend = Shader.PropertyToID("_Blend");
        private float _changeValue;
        private Color _skyColor;
        private Color _equatorColor;
        private Color _groundColor;
        private Sequence _sequenceEnter;
        private Sequence _sequenceExit;

        private void Start()
        {
            _skyColor = RenderSettings.ambientSkyColor;
            _equatorColor = RenderSettings.ambientEquatorColor;
            _groundColor = RenderSettings.ambientGroundColor;
            _blend = RenderSettings.skybox.GetFloat(Blend);
            EditorApplication.playModeStateChanged += DefaultSkyBoxTurn;
        }

        private void DefaultSkyBoxTurn(PlayModeStateChange modeState)
        {
            if (modeState == PlayModeStateChange.ExitingPlayMode)
            {
                RenderSettings.skybox.SetFloat(Blend,0);
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _blend = RenderSettings.skybox.GetFloat(Blend);
                _changeValue = _blend == 1f ? 0f : 1f;
               
                
                //Change Sky Color
                _sequenceEnter.Append(
                        DOTween.To(() => _skyColor, x => RenderSettings.ambientSkyColor = x,
                            new Color32(94, 47, 3, 255),
                            1f))
                    .Join(DOTween.To(() => _equatorColor, x => RenderSettings.ambientEquatorColor = x,
                        new Color32(152, 82, 82, 255),
                        1f))
                    .Join(DOTween.To(() => _groundColor, x => RenderSettings.ambientGroundColor = x,
                        new Color32(17, 2, 1, 255),
                        1f))
                    .Join( DOTween.To(() => _blend, x => RenderSettings.skybox.SetFloat(Blend, x), _changeValue, 3f));

            }
        }

        private void OnTriggerExit(Collider other)
        {
            _blend = RenderSettings.skybox.GetFloat(Blend);
            _changeValue = _blend == 1f ? 0f : 1f;
            _skyColor = RenderSettings.ambientSkyColor;
            _equatorColor = RenderSettings.ambientEquatorColor;
            _groundColor = RenderSettings.ambientGroundColor;
                
            //Change Sky Color
            _sequenceExit.Append(
                    DOTween.To(() => _skyColor, x => RenderSettings.ambientSkyColor = x,
                        new Color32(165, 235, 255, 255),
                        1f))
                .Join(DOTween.To(() => _equatorColor, x => RenderSettings.ambientEquatorColor = x,
                    new Color32(217, 232, 233, 255),
                    1f))
                .Join(DOTween.To(() => _groundColor, x => RenderSettings.ambientGroundColor = x,
                    new Color32(45, 42, 34, 255),
                    1f))
                .Join( DOTween.To(() => _blend, x => RenderSettings.skybox.SetFloat(Blend, x), _changeValue, 3f));

        }
    }
}
