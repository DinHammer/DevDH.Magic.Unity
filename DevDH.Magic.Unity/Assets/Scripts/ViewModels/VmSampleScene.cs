using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VmSampleScene : BaseMonoBehaviour
{
    [SerializeField] private BaseButton _btn;

    private void Awake()
    {
        _btn.Init(OnBtnClicked);
    }

    private void OnBtnClicked()
    {
        prtDbgLog( this,"ololo");
    }
}
