using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using App.Common;

namespace App.TitleScene
{
    public class TitleSceneController : MonoBehaviour
    {
        [SerializeField]
        private Text _countText = null;

        private int _count = 0;

        private void Start()
        {
            SoundManager.Instance.PlayBGM(1);
        }

        public void OnClickButton()
        {
            SoundManager.Instance.PlaySE(0);
            SceneManager.LoadScene("MainScene");
        }

        public void OnClickVRButton()
        {
            SoundManager.Instance.PlaySE(0);
            SceneManager.LoadScene("RunningScene");
        }

        public void OnClickAddTenButton()
        {
            // Unityエディタ上なら何もしない
#if UNITY_EDITOR
            Debug.Log("NOT IOS. DO NOTHING.");
#elif UNITY_IOS
            _count = _count + IOSPluginCallManager.PlusTen();
#endif
            _countText.text = _count.ToString();
        }
    }
}
