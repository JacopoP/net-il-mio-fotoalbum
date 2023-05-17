namespace net_il_mio_fotoalbum.Helper
{
    public static class ImgHelper
    {
        public static string SavePhoto(IFormFile file)
        {
            bool b = true;
            uint index = 1;
            string fileName = file.FileName;
            do
            {
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName)))
                {
                    int idx = fileName.LastIndexOf('.');
                    fileName = fileName.Substring(0, idx) + index + fileName.Substring(idx);
                    index++;
                }
                else
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    b = false;
                }
            } while (b);
            return fileName;
        }

        public static void DeletePhoto(string? s)
        {
            if (s != null && File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", s)))
                File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", s));
        }
    }
}