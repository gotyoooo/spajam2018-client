using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace App.Common
{
    public class IOSPluginCallManager
    {

        // iOS側で用意したメソッド定義
        [DllImport("__Internal")]
        static extern int addTen();

        [DllImport("__Internal")]
        static extern int subTen();

        public static int PlusTen()
        {
            return addTen();
        }

        public static int MinusTen()
        {
            return subTen();
        }
    }    
}
