using UnityEngine;
using constString = ConstStrings;

public class BaseMonoBehaviour : MonoBehaviour
{
    #region Methods

    private string GetPathFromMonoBehavior(MonoBehaviour monoBehaviour)
        => $"{monoBehaviour.name}::{monoBehaviour.GetType().Name}";
    
    protected virtual void prtDbgLog(MonoBehaviour monoBehaviour, string str)
        => prtDbgLog($"{GetPathFromMonoBehavior(monoBehaviour)}::{str}");
    protected virtual void prtDbgLog(string str)
        => Debug.Log($"{constString.StrAppName}::{str}");


    protected virtual void prtDbgLogError(MonoBehaviour monoBehaviour, string str)
        => prtDbgLogError($"{GetPathFromMonoBehavior(monoBehaviour)}::{str}");
    protected virtual void prtDbgLogError(string str)
        => Debug.LogError($"{constString.StrAppName}::error::{str}");
    
    #endregion
}
