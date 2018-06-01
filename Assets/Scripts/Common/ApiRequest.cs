using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace App.Common
{
    public class ApiRequest : MonoBehaviour
    {
        public bool IsBusy = false;
        public string ResponseData = "";
        //[System.Serializable]
        //public class MyName
        //{
        //    public string name;
        //}

        ////public MyName myObject = new MyName();
        ////myObject.name = "name";
        ////string myjson = JsonUtility.ToJson(myObject);
        //public void SetJson()
        //{

        //}

        public IEnumerator SendRequest(string url = "", string bodyJsonString = "", Action callback = null)
        {
            IsBusy = true;

            //byte[] postData = System.Text.Encoding.UTF8.GetBytes(bodyJsonString);
            var request = new UnityWebRequest(url, "GET");
            //request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            // 通信エラーチェック
            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                if (request.responseCode == 200)
                {
                    // UTF8文字列として取得する
                    ResponseData = request.downloadHandler.text;
                }
            }
            IsBusy = false;

            if (callback != null)
            {
                callback();
            }
        }
    }    
}
