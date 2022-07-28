using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if  UNITY_IOS && UNITY_EDITOR
using System.IO;
using UnityEditor.iOS.Xcode;
using UnityEditor.Callbacks;
using UnityEditor;
public class EdtPostBuildSteps : MonoBehaviour
{
    /// <summary>
    /// Description for IDFA request notification 
    /// [sets NSUserTrackingUsageDescription]
    /// </summary>
    const string TrackingDescription =
        "This identifier will be used to deliver personalized ads to you. ";

    
    [PostProcessBuild(1)]
    public static void OnPostprocessBuild(BuildTarget buildTarget, string pathToXcode)
    {
        if (buildTarget == BuildTarget.iOS)
        {
            //ActXcode(pathToXcode);
        }
    }

    static void ActXcode(string pathToXcode)
    {
        string strPlistPath = GetPlistPath(pathToXcode);
        PlistDocument plistDoc =  GetPlistDocument(strPlistPath);

        AddBool(plistDoc.root);
        AddString(plistDoc.root);
 
        WrightPlistFile(strPlistPath,plistDoc);
    }

    #region ActionXcode

    private static string GetPlistPath(string path2Xcode)
    {
        string plistPath = $"{path2Xcode}/Info.plist";
        return plistPath;
    }

    private static PlistDocument GetPlistDocument(string plistPath)
    {
        PlistDocument plistDocument = new PlistDocument();
        plistDocument.ReadFromString(File.ReadAllText(plistPath));
        return plistDocument;
    }
    
    static PlistElementDict AddBool(PlistElementDict plistRoot)
    {
        plistRoot.SetBoolean("Ololo",false);
        return plistRoot;
    }
    
    static PlistElementDict AddString(PlistElementDict plistRoot)
    {
        plistRoot.SetString("Pish",@"Pish");
        return plistRoot;
    }
    
    private static void WrightPlistFile(string strPlistPath, PlistDocument plistDoc)
    {
        File.WriteAllText(strPlistPath, plistDoc.WriteToString());
    }


    #endregion
}

#endif