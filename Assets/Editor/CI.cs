using System.Linq;
using UnityEditor;

public class CI
{
    [MenuItem("CI/Build")]
    public static void Build()
    {
        BuildPipeline.BuildPlayer(ScenePaths, "Build/Application.apk", BuildTarget.Android, BuildOptions.CompressWithLz4);
    }

    static string[] ScenePaths => EditorBuildSettings.scenes.Select(scene => scene.path).ToArray();
}