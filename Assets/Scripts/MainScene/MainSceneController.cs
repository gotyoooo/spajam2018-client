using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using App.Common;

namespace App.MainScene
{
    public class MainSceneController : MonoBehaviour
    {
        [SerializeField]
        private ApiRequest _apiRequest = null;

        private void Start()
        {
            SoundManager.Instance.PlayBGM(0);
        }

        public void OnClickButton()
        {
            SoundManager.Instance.PlaySE(0);

            StartCoroutine(_apiRequest.SendRequest("https://api.myjson.com/bins/190cn2", "", () => {
                Debug.Log(_apiRequest.ResponseData);
                SceneManager.LoadScene("TitleScene");
            }));
        }
    }    
}
