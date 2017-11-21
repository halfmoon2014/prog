using System;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Drawing;

using System.Windows.Media.Imaging;
using System.Windows.Media;
public partial class testjpg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    

    public enum ImageColorFormat
    {
        Rgb,
        Cmyk,
        Indexed,
        Grayscale
    }

    public static ImageColorFormat IsCMYK(System.Drawing.Image img)
    {
        
        // Check image flags
        var flags = (ImageFlags)img.Flags;
        ImageColorFormat iCF;
        if (flags.HasFlag(ImageFlags.ColorSpaceCmyk) || flags.HasFlag(ImageFlags.ColorSpaceYcck))
        {
            iCF = ImageColorFormat.Cmyk; ;
        }
        else if (flags.HasFlag(ImageFlags.ColorSpaceGray))
        {
            iCF = ImageColorFormat.Grayscale;
        }

        //http://stackoverflow.com/questions/5065371/how-to-identify-cmyk-images-in-asp-net-using-c-sharp
        const int pixelFormatIndexed = 0x00010000;
        const int pixelFormat32bppCMYK = 0x200F;
        const int pixelFormat16bppGrayScale = (4 | (16 << 8));

        var pixelFormat = (int)img.PixelFormat;
        
        if (pixelFormat == pixelFormat32bppCMYK)
        {
            iCF = ImageColorFormat.Cmyk;
        }
        else if ((pixelFormat & pixelFormatIndexed) != 0)
        {
            iCF = ImageColorFormat.Indexed;
        }
        else if (pixelFormat == pixelFormat16bppGrayScale)
        {
            iCF = ImageColorFormat.Grayscale;
        }
        else
        {
            iCF = ImageColorFormat.Rgb;
        }

        return iCF;
    }
    //asp.net 把图片RGB格式转换成CMYK印刷格式 
    //http://blog.sina.com.cn/s/blog_78106bb10101d61t.html
    public static void convert2Cmyk()
    {
        Stream imageStream = new FileStream(@"C:\Users\min\Desktop\RGB.jpg", FileMode.Open, FileAccess.Read, FileShare.Read);
        BitmapSource myBitmapSource = BitmapFrame.Create(imageStream);

        FormatConvertedBitmap newFormatedBitmapSource = new FormatConvertedBitmap();
        newFormatedBitmapSource.BeginInit();
        newFormatedBitmapSource.Source = myBitmapSource;
        newFormatedBitmapSource.DestinationFormat = PixelFormats.Cmyk32;
        newFormatedBitmapSource.EndInit();
        BitmapEncoder encoder = new TiffBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(newFormatedBitmapSource));

        Stream cmykStream = new FileStream(@"C:\Users\min\Desktop\Cmyk32.jpg", FileMode.Create, FileAccess.Write, FileShare.Write);
        encoder.Save(cmykStream);
        cmykStream.Close();
    }
    //真正判断文件类型的关键函数
    public static bool IsAllowedExtension(FileUpload hifile)
    {
        string path = hifile.PostedFile.FileName;
        //只能访问服务器的文件系统
        //本地测试是 ie hifile.PostedFile.FileName; 返回完整路径, chrome 中得到的是文件名
        //path = @"e:\2015072709244673595997.jpg";
        System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        System.IO.BinaryReader r = new System.IO.BinaryReader(fs);
        string fileclass = "";
        //这里的位长要具体判断.
        byte buffer;
        try
        {
            buffer = r.ReadByte();
            fileclass = buffer.ToString();
            buffer = r.ReadByte();
            fileclass += buffer.ToString();

        }
        catch
        {

        }
        r.Close();
        fs.Close();
        if (fileclass == "255216" || fileclass == "7173")//说明255216是jpg;7173是gif;6677是BMP,13780是PNG;7790是exe,8297是rar
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        #region 可以实现真正意义上的文件类型判断。
        try
        {            
            //判断是否已经选取文件
            if (FileUpload1.HasFile)
            {
                

                if (IsAllowedExtension(FileUpload1))
                {
                    string path = Server.MapPath("~/images/");
                    FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
                    Response.Write("<script>alert('上传成功');</script>");


                    Bitmap bmp = new Bitmap(path + FileUpload1.FileName);
                    IsCMYK(bmp);
                }
                else
                {
                    Response.Write("<script>alert('您只能上传jpg或者gif图片');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('你还没有选择文件');</script>");
            }
        }
        catch (Exception error)
        {
            Response.Write(error.ToString());
        }
        #endregion
    }


}