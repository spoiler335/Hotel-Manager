using UnityEditor;
using UnityEngine;

public class BuildScript
{
    [MenuItem("Build/Build Android")]
    public static void BuildAndroid()
    {
        string version = PlayerSettings.bundleVersion;
        string path = "Builds/Hotel-Manager_" + version + ".apk";
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = new[] { "Assets/Scenes/GamePlay.unity" }, // Add your scenes here
            locationPathName = path,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        Debug.Log("Build completed: " + path);
    }
}
