using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using myEngine;

using ImGuiNET;

using Num = System.Numerics;

namespace zzMathVisu
{
    public class Scene_SphereCoordinates : IScene
    {
        //FIELDS
        Camera3D camera;
        Object3D globe;
        Object3D cursor;

        Text t;

        //CONSTRUCTOR
        public Scene_SphereCoordinates()
        {
            Engine.game.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            Engine.game.GraphicsDevice.BlendState = BlendState.AlphaBlend;
            Engine.game.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;

            Settings.BACKGROUND_COLOR = Color.AliceBlue;
            camera = new Camera3D(Engine.game, new Vector3(0, 0, -4), Vector3.Zero, 10);
            camera.isActive = false;

            Floor f = new Floor(Engine.game.GraphicsDevice, camera, 4, 4, 1);
            f.transform3D.position = new Vector3(0, -3, 0);

            globe = new Object3D(camera);
            globe.model = Ressources.Load<Model>("myContent/3D/earthV2/source/Earth");
            globe.effect.Texture = Ressources.Load<Texture2D>("myContent/3D/earthV2/textures/1_earth_8k");
            globe.effect.TextureEnabled = true;

            globe.transform3D.position = new Vector3(0, 0, 0);
            globe.transform3D.rotation.X = -90;
            globe.transform3D.scale = new Vector3(1, 1, 1);
            globe.effect.Alpha = 1f;

            globe.drawOrder = 10;

            cursor = new Object3D(camera);
            cursor.model = Ressources.Load<Model>("myContent/3D/sphere");

            cursor.transform3D.position = new Vector3(0, 0, 0);
            cursor.transform3D.scale = new Vector3(0.02f, 0.02f, 0.02f);

            cursor.effect.DiffuseColor = Color.Red.ToVector3();
            cursor.effect.Alpha = 1f;
            cursor.drawOrder = 0;

            Object3D.GlobalEffect.FogEnabled = true;
            Object3D.GlobalEffect.FogColor = Color.AliceBlue.ToVector3();
            Object3D.GlobalEffect.FogStart = 0f;
            Object3D.GlobalEffect.FogEnd = 20f;

            Object3D.GlobalEffect.LightingEnabled = true; // turn on the lighting subsystem.
            Object3D.GlobalEffect.DirectionalLight0.DiffuseColor = new Vector3(1, 1, 1);
            Object3D.GlobalEffect.DirectionalLight0.Direction = new Vector3(1, 0, 0);  
            Object3D.GlobalEffect.DirectionalLight0.SpecularColor = new Vector3(1, 1, 1);

            Object3D.GlobalEffect.AmbientLightColor = Color.AliceBlue.ToVector3();

            /*
            Object3D defaultCube = new Object3D(camera);
            defaultCube.model = Ressources.Load<Model>("myContent/3D/DEFAULT_CUBE");
            defaultCube.effect.DiffuseColor = Color.CornflowerBlue.ToVector3();
            defaultCube.effect.Alpha = 0.5f;

            defaultCube.drawOrder = 5;
            */

            t = new Text();
        }

        float latitude;
        float longitude;
        float sphereRotation = 90f;

        //METHODS
        public override void Update()
        {
            SetCoordPos();

            if (Input.GetKeyDown(Microsoft.Xna.Framework.Input.Keys.Tab))
            {
                camera.isActive = camera.isActive == true ? false : true;
            }
        }

        private Vector3 RotateAround(float latitude, float longitude)
        {
            latitude = latitude % 360;
            longitude = longitude % 360;

            float posX = (float)Math.Sin(MathHelper.ToRadians(-latitude)) *
                         (float)Math.Sin(MathHelper.ToRadians(longitude));

            float posY = (float)Math.Cos(MathHelper.ToRadians(-latitude));

            float posZ = (float)Math.Sin(MathHelper.ToRadians(-latitude)) *
                         (float)Math.Cos(MathHelper.ToRadians(longitude));

            return new Vector3(posX, posY, posZ);
        }

        private void SetCoordPos()
        {
            t.s = "" + Math.Floor(-latitude) + ", " + Math.Floor(longitude);

            cursor.transform3D.position = RotateAround(latitude, longitude) * 0.8f * radius;

            cursor.transform3D.scale = Vector3.One * 0.01f * scale;

            globe.transform3D.rotation = new Vector3(globe.transform3D.rotation.X, sphereRotation, globe.transform3D.rotation.Z);
        }

        private string name = "osef";

        private float scale = 2f;
        private float radius = 1.300f;

        public override void DrawGUI()
        {
            ImGui.SetNextWindowSize(new Num.Vector2(300, Settings.SCREEN_HEIGHT));
            ImGui.SetNextWindowPos(new Num.Vector2((Settings.SCREEN_WIDTH - 300), 0));

            ImGui.GetStyle().WindowRounding = 0.0f;
            ImGui.GetStyle().ChildRounding = 0.0f;
            ImGui.GetStyle().FrameRounding = 0.0f;
            ImGui.GetStyle().GrabRounding = 0.0f;
            ImGui.GetStyle().PopupRounding = 0.0f;
            ImGui.GetStyle().ScrollbarRounding = 0.0f;

            ImGuiWindowFlags window_flags = 0;

            window_flags |= ImGuiWindowFlags.NoResize;
            window_flags |= ImGuiWindowFlags.NoCollapse;
            window_flags |= ImGuiWindowFlags.NoMove;

            ImGui.Begin("WINDOW", window_flags);
            //ImGui.Begin("NAME");

            ImGui.Text("Cursor Coordinates");

            //ImGui.InputText("Name", ref name, 100);

            ImGui.SliderFloat("Latitude", ref latitude, -180, 180f);
            ImGui.SliderFloat("Longitude", ref longitude, -180f, 180f);

            //
            ImGui.Text("Cursor Properties");
            ImGui.SliderFloat("Scale", ref scale, 0, 10f);
            ImGui.SliderFloat("Radius", ref radius, 0, 3);

            ImGui.Text("Earth Properties");
            ImGui.SliderFloat("Earth Rotation", ref sphereRotation, -180f, 180f);

            if (ImGui.Button("Set Marker"))
            {
                Console.WriteLine("PRESSED");
                SetCoordPos();

                //Scene_EarthMap.SpawnPinAtCoords(System.Text.Encoding.UTF8.GetString(_textBuffer, 0, _textBuffer.Length), new Coord(latitude, longitude));
                //MVUtil.SpawnPinAtCoords(name, new Coord(latitude, longitude));
            }

            ImGui.End();
        }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
        }
    }
}