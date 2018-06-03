using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using App.Common;
using System.IO;
using System;

namespace App.ResultScene
{
    public class ResultSceneController : MonoBehaviour
    {

        private void Start()
        {
            //SoundManager.Instance.PlayBGM(1);

        }

        public void OnClickTitleButton()
        {
            //SoundManager.Instance.PlaySE(0);
            SceneManager.LoadScene("TitleScene");
        }
    }
}
