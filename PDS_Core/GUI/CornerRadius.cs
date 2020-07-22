namespace PhantomDragonStudio.Core.GUI
{
    public class DrawableImage
    {
        private Texture2D _texture;
        public Color ClearColor = Color.clear;
        private bool _initialized;
        public int Width;
        public int Height;

        public void SetSize(int width, int height)
        {
            Width = width;
            Height = height;
            var newTex = CreateTexture(width, height);
            _texture = newTex;
            _initialized = true;
        }

        public virtual void Refresh()
        {
            if (!_initialized) return;
            _texture.Apply();
        }

        public void ApplyTo(Image image)
        {
            if (!_initialized) return;
            image.sprite = CreateSprite(_texture);
            image.SetNativeSize();
        }



        Sprite CreateSprite(Texture2D texture) => Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        private Texture2D CreateTexture(int width, int height) => new Texture2D(width, height, TextureFormat.ARGB32, false);

        void SetAllPixelsTo(Texture2D tex, Color col)
        {
            if (!_initialized) return;
            for (int i = 0; i < tex.width; i++)
            for (int j = 0; j < tex.height; j++)
                tex.SetPixel(i, j, col);
        }

        public void DrawCircle(int x, int y, int radius, Color c) => DrawCircle(_texture, x, y, radius, c);

        public void DrawCircle(Texture2D tex, int x, int y, int radius, Color col)
        {
            float rSquared = radius * radius;
            for (int u = x - radius; u < x + radius + 1; u++)
            for (int v = y - radius; v < y + radius + 1; v++)
                if ((x - u) * (x - u) + (y - v) * (y - v) < rSquared)
                {
                    tex.SetPixel(u, v, OverBlend(tex.GetPixel(u, v), col));
                }
        }

        Color OverBlend(Color background, Color foreground)
        {
            float r = (foreground.r * foreground.a) + (background.r * (1.0f - foreground.a));
            float g = (foreground.g * foreground.a) + (background.g * (1.0f - foreground.a));
            float b = (foreground.b * foreground.a) + (background.b * (1.0f - foreground.a));
            return new Color(r, g, b);
        }

        public void DrawEllipse(float x, float y, float w, float h, Color color)
        {
            DrawCircle((int) x, (int) y, (int) w, color);
        }


        public void SetPixel(int x, int y, Color color) => _texture.SetPixel(x, y, color);
    }
}