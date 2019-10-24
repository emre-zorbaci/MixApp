﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixApp.Fonksiyonlar
{
    class Resimler
    {
        public byte[] ResimYukleme(Image resim)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                resim.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public Image ResimGetirme(byte[] gelenByteArray)
        {
            using (MemoryStream ms = new MemoryStream(gelenByteArray))
            {
                Image resim = Image.FromStream(ms);
                return resim;
            }
        }
    }
}
