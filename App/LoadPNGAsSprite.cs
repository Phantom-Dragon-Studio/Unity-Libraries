using System.IO;
using UnityEngine;
namespace App
{
    public class LoadPNGAsSprite
    {
        public static Sprite LoadPNG(string filePath)
        {

            Texture2D tex = null;
            Sprite logoSprite = null;
            byte[] fileData;

            if (File.Exists(filePath))
            {
                fileData = File.ReadAllBytes(filePath);
                tex = new Texture2D(250, 250);
                tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
                logoSprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            }
            return logoSprite;
        }
    }
}