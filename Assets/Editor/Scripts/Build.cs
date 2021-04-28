using System.Diagnostics;
using UnityEditor;

namespace Editor.Scripts
{
    public static class Build
    {
        [MenuItem("Build/WebGL build and upload")]
        private static void WebGlBuild()
        {
            BuildTheGame(BuildTarget.WebGL);
            UploadToItchIo();
        }

        [MenuItem("Build/Mac")]
        private static void MacBuild()
        {
            BuildTheGame(BuildTarget.StandaloneOSX);
        }

        [MenuItem("Build/Windows")]
        private static void WindowsBuild()
        {
            BuildTheGame(BuildTarget.StandaloneWindows64);
        }

        private static void BumpVersion()
        {
            var versionParts = PlayerSettings.bundleVersion.Split('.');

            versionParts[1] = (int.Parse(versionParts[1]) + 1).ToString();

            PlayerSettings.bundleVersion = string.Join(".", versionParts);
        }

        private static void BuildTheGame(BuildTarget buildTarget)
        {
            var path = $"{System.IO.Directory.GetCurrentDirectory()}/Builds/{buildTarget.ToString()}/{PlayerSettings.productName}";

            BuildPipeline.BuildPlayer(GetScenes(), path, buildTarget, BuildOptions.None);
        }

        private static void UploadToItchIo()
        {
            SpawnShellProcess("upload");
        }
        
        private static void SpawnShellProcess(string processName)
        {
            var process = new Process()
            {
                StartInfo =
                {
                    FileName = "/bin/sh",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Arguments =
                        $"{System.IO.Directory.GetCurrentDirectory()}/{processName}.sh {PlayerSettings.bundleVersion}"
                }
            };

            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            var errorOutput = process.StandardError.ReadToEnd();

            process.WaitForExit();
            process.Close();

            if (errorOutput != "")
            {
                UnityEngine.Debug.LogError("Error: " + errorOutput);
            }

            UnityEngine.Debug.Log(output);
        }

        private static string[] GetScenes()
        {
            var sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;

            var scenes = new string[sceneCount];

            for (var i = 0; i < sceneCount; i++)
            {
                var sceneName =
                    System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility
                        .GetScenePathByBuildIndex(i));

                scenes[i] = ($"Assets/Scenes/{sceneName}.unity");
            }

            return scenes;
        }
    }
}