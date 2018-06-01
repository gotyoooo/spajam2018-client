using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using App.Common;

namespace App.TitleScene
{
    public class TitleSceneController : MonoBehaviour
    {
        private void Start()
        {
            SoundManager.Instance.PlayBGM(1);
        }

        public void OnClickButton()
        {
            SoundManager.Instance.PlaySE(0);
            SceneManager.LoadScene("MainScene");
        }

        public void OnClickARButton()
        {
            SoundManager.Instance.PlaySE(0);
            SceneManager.LoadScene("ARScene");
        }
    }
}
