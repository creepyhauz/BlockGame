using BlockGame.Buffers;
using BlockGame.Shaders;
using BlockGame.Textures;
using BlockGame.VertexStructs;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

BlockGame.Program.Instance = new BlockGame.Program();

namespace BlockGame
{
    public class Program
    {
        public static Program Instance;

        OpenGLActionContex ActionContex = new OpenGLActionContex();

        public Player Camera { get; } = new Player();

        GameWindow GameWindow { get; }

        Shader Shader;

        public Program()
        {
            GameWindow = new GameWindow(new GameWindowSettings(), new NativeWindowSettings() { WindowState = WindowState.Maximized });
            //GameWindow.UpdateFrequency = 60;
            GameWindow.UpdateFrame += Game_UpdateFrame;
            GameWindow.RenderFrame += Game_RenderFrame;
            GameWindow.Load += Game_Load;
            GameWindow.Resize += Game_Resize;
            GameWindow.Run();
        }

        private void Game_UpdateFrame(FrameEventArgs args)
        {
            if (GameWindow.KeyboardState.IsKeyDown(Keys.Escape))
                GameWindow.Close();
            Camera.UpdateInput(GameWindow.KeyboardState, GameWindow.MouseState, args);
        }

        World world;
        private void Game_Load()
        {
            Shader = new Shader("Shaders/Shader.vert", "Shaders/Shader.frag", ActionContex);

            TextureAtlas.Generate(new Vector2i(16, 16));

            Chunk.BlockRenderer = new BlockRenderer();

            GameWindow.CursorState = CursorState.Grabbed;


            world = new World();

            GL.Enable(EnableCap.DepthTest);
            //GL.FrontFace(FrontFaceDirection.Cw);
            //GL.Enable(EnableCap.CullFace);
            //GL.CullFace(CullFaceMode.Back);
        }
        Matrix4 DrawTransform;
        float i = 0;
        private void Game_RenderFrame(OpenTK.Windowing.Common.FrameEventArgs obj)
        {
            GL.ClearColor(Color4.LightBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Shader.Use();

            world.Render(Shader, Camera);

            GameWindow.SwapBuffers();
        }



        public Vector2 Size => new Vector2(GameWindow.Size.X, GameWindow.Size.Y);

        private void Game_Resize(OpenTK.Windowing.Common.ResizeEventArgs obj)
        {
            GL.Viewport(0, 0, obj.Width, obj.Height);
            Camera.Size = new Vector2(obj.Width, obj.Height);
        }
    }
}
