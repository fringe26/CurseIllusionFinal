using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class CemraRaycastChanger : MonoBehaviour
    {
        [SerializeField] private float rayRange;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private Image _deActiveAim;
        [SerializeField] private Image _activeAim;
        private GameObject _fireSymbol;
        public bool IsOnHint { get; set; } = false;
        private new Camera _camera;
        private void Start()
        {
            _camera = Camera.main;
            _fireSymbol = GameObject.FindGameObjectWithTag("FireSymbol");
            
        }

        void LateUpdate()
        {
            Debug.DrawRay(_camera.transform.position, _camera.transform.forward*int.MaxValue, Color.cyan);

            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, rayRange, layerMask))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Symbols"))
                {
                    if (Input.GetKey(KeyCode.X))
                    {
                        hit.transform.gameObject.SetActive(false);
                    }
                   
                }else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("TargetableNoCollision"))
                {
                    if (Input.GetKey(KeyCode.X))
                    {
                        _fireSymbol.SetActive(false);
                    }
                }
                if (IsOnHint)
                {
                   _deActiveAim.gameObject.SetActive(false);
                   _activeAim.gameObject.SetActive(true);
                }
                
                Debug.Log(hit.collider.gameObject.name);
                if (Input.GetKey(KeyCode.X) && IsOnHint)
                {
                    hit.collider.gameObject.SetActive(false);
                }
            }
            else
            {
                _activeAim.gameObject.SetActive(false);
                _deActiveAim.gameObject.SetActive(true);
            }
            
        }
    }
}
