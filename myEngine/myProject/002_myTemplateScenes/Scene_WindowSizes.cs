using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using ImGuiNET;
using Microsoft.Xna.Framework.Graphics;

namespace myEngine
{
    public class Scene_WindowSizes : IScene
    {
        //FIELDS

        //CONSTRUCTOR
        public Scene_WindowSizes()
        {
            Settings.BACKGROUND_COLOR = Color.DarkKhaki;

            current_item = screenRes;

            Sprite sprite = new Sprite();
            sprite.texture = Ressources.Load<Texture2D>("myContent/ParticleSystem/star");
            sprite.transform.position = Settings.Get_Screen_Center();
            sprite.transform.scale =  Vector2.One * 2;
        }

        string screenRes = Settings.SCREEN_WIDTH + "x" + Settings.SCREEN_HEIGHT;
        string[] items = { "720x480", "1280x720", "1920x1280" };
        string current_item = null;

        bool fullScreen = false;

        //GUI
        public override void DrawGUI()
        {
            ImGuiWindowFlags flags = new ImGuiWindowFlags();

            /*
            flags |= ImGuiWindowFlags.NoMove;
            flags |= ImGuiWindowFlags.NoResize;
            flags |= ImGuiWindowFlags.NoCollapse;
            */

            ImGui.GetStyle().WindowRounding = 0.0f;
            ImGui.GetStyle().FrameRounding = 0.0f;
            ImGui.GetStyle().GrabRounding = 0.0f;
            ImGui.GetStyle().PopupRounding = 0.0f;

            ImGui.Begin("Windo Resize", flags);
            ImGui.SetWindowSize(new System.Numerics.Vector2(300, 200));
            //ImGui.SetWindowPos(new System.Numerics.Vector2(50, 50));

            ImGui.Text("Params");

            if (ImGui.BeginCombo("Resolution", current_item)) // The second parameter is the label previewed before opening the combo.
            {
                for (int n = 0; n < items.Length; n++)
                {
                    bool is_selected = (current_item == items[n]); // You can store your selection however you want, outside or inside your objects

                    if (ImGui.Selectable(items[n], is_selected))
                    {
                        current_item = items[n];
                        if (current_item == "720x480")
                            Settings.SetScreenSize(720, 480);
                        else if (current_item == "1280x720")
                            Settings.SetScreenSize(1280, 720);
                        else if (current_item == "1920x1280")
                            Settings.SetScreenSize(1920, 1280);
                    }
                    if (is_selected)
                        ImGui.SetItemDefaultFocus();   // You may set the initial focus when opening the combo (scrolling + for keyboard navigation support)
                }
                ImGui.EndCombo();
            }

            if (ImGui.Checkbox("FullScreen", ref fullScreen))
            {
                Engine.graphics.IsFullScreen = fullScreen;
                Engine.graphics.ApplyChanges();
            }

            ImGui.End();
        }
    }
}
