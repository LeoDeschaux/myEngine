using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public static class SceneManager_Utils
    {
        private static List<Type> scenes = new List<Type>()
        {
            typeof(Scene_2DCamera),
            typeof(Scene_2DShader),
            typeof(Scene_3D),
            typeof(Scene_A),
            typeof(Scene_Animation),
            typeof(Scene_B),
            typeof(Scene_Button),
            typeof(Scene_CameraShake),
            typeof(Scene_Default),
            typeof(Scene_DrawSimpleShape),
            typeof(Scene_Event),
            typeof(Scene_NewTween),
            typeof(Scene_Paralax),
            typeof(Scene_ParentTransform),
            typeof(Scene_ParticleEditor),
            typeof(Scene_ParticleSystem),
            typeof(Scene_PerlinNoise),
            typeof(Scene_PhysiqueEngine),
            typeof(Scene_PostProcessing),
            typeof(Scene_SaveSystem),
            typeof(Scene_TextUI),
            typeof(Scene_Tweening),
            typeof(Scene_TwoBitCoding),
            typeof(Scene_WindowSizes)
        };

        public static int GetSceneIndex(Type scene)
        {
            Predicate<Type> predicat = delegate (Type a) { return a == scene; };
            int currentSceneIndex = scenes.FindIndex(predicat);

            return currentSceneIndex;
        }

        public static void ChangeToNextScene()
        {
            int currentSceneIndex = GetSceneIndex(SceneManager.currentScene.GetType());

            int i = currentSceneIndex;
            if (i < scenes.Count - 1)
                SceneManager.ChangeScene(scenes[i+1]);
        }

        public static void ChangeToPreviousScene()
        {
            int currentSceneIndex = GetSceneIndex(SceneManager.currentScene.GetType());

            int i = currentSceneIndex;
            if (i > 0)
                SceneManager.ChangeScene(scenes[i-1]);
        }
    }
}
