﻿using System.Drawing;

namespace CleanCode.Names
{
    public class Names
    {
        public Bitmap GenerateImage(string path)
        {
            var bitmap = new Bitmap(path);
            var graphics = Graphics.FromImage(bitmap);
            graphics.DrawString("a", SystemFonts.DefaultFont, SystemBrushes.Desktop, new PointF(0, 0));
            graphics.DrawString("b", SystemFonts.DefaultFont, SystemBrushes.Desktop, new PointF(0, 20));
            graphics.DrawString("c", SystemFonts.DefaultFont, SystemBrushes.Desktop, new PointF(0, 30));
            return bitmap;
        }
    }
}

/* Names
- Not too short not too long
- meningful
- revela intention
-chosen from problem domain
*/