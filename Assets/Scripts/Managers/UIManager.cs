
using System;
using System.Collections;
using UnityEngine;

using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        /// <summary>
        /// Panels
        /// </summary>
        [SerializeField] private GameObject _loadingPanel;
        [SerializeField] private GameObject _homePanel;
        [SerializeField] private GameObject _controlImage;
        
        /// <summary>
        /// Buttons
        /// </summary>
        [SerializeField] private Button _newGameButton;
        [SerializeField] private Button _showControlsButton;
        
        [SerializeField] private Image _loadingWord;
        private void Start()
        {
            _newGameButton.onClick.AddListener(() =>
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                _homePanel.SetActive(false);
            });
            
            _showControlsButton.onClick.AddListener(() =>
            {
                _controlImage.gameObject.SetActive(true);
            });
            StartCoroutine(LoadingBar());
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.G))
            {
                _controlImage.gameObject.SetActive(false);
            }
        }

        private IEnumerator LoadingBar()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.5f);
                _loadingWord.transform.GetChild(0).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                _loadingWord.transform.GetChild(1).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                _loadingWord.transform.GetChild(2).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                _loadingWord.transform.GetChild(0).gameObject.SetActive(false);
                _loadingWord.transform.GetChild(1).gameObject.SetActive(false);
                _loadingWord.transform.GetChild(2).gameObject.SetActive(false);
            }
            
            _loadingPanel.SetActive(false);
            _homePanel.SetActive(true);
        }
    }
}
