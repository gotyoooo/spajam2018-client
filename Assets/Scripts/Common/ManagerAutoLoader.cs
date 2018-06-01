using UnityEngine;
using UnityEngine.SceneManagement;

namespace App.Common
{
    /// <summary>
    /// Awake前にManagerを自動でロードするクラス
    /// </summary>
    public class ManagerAutoLoader : MonoBehaviour
    {

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateSelf()
        {
            //Managerという名前のPrefabをResources以下に作成しておき、それをロード、インスタンスを生成する
            var obj = Object.Instantiate(Resources.Load<GameObject>("Manager"));
            Object.DontDestroyOnLoad(obj);
        }

    }
}
