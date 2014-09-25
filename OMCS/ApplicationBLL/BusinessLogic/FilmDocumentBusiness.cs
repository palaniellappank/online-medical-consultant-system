using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Drawing;

namespace OMCS.BLL
{
    public class FilmDocumentBusiness : BaseBusiness
    {
        public void SaveFilmDocumentFromBase64String(string imgBase64, string serverPath)
        {
            imgBase64 = imgBase64.Split(',')[1];
            int mod4 = imgBase64.Length % 4;
            if (mod4 > 0)
            {
                imgBase64 += new string('=', 4 - mod4);
            }

            byte[] buffer = Convert.FromBase64String(imgBase64);

            MemoryStream ms = new MemoryStream(buffer, 0, buffer.Length);

            System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)Image.FromStream(ms);

            ms.Close();

            // convert to image first and store it to disk
            using (MemoryStream mOutput = new MemoryStream())
            {
                bitmap.Save(mOutput, System.Drawing.Imaging.ImageFormat.Png);
                using (FileStream fs = System.IO.File.Create(serverPath))
                using (BinaryWriter bw = new BinaryWriter(fs))
                    bw.Write(mOutput.ToArray());
            }
        }
    }
}
