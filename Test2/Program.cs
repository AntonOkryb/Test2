using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class Program
    {
        class File
        {
            protected string name;
            protected string extention;
            protected string size;

            public File()
            {

            }

            public virtual string To_String()
            {
                string s = "";
                s += $"{name}.{extention}({size});";
                return s;
            }
        }

        class FileTxt : File
        {
            private string content;
            
            public FileTxt()
            {

            }

            public void Pars(string str)
            {
                string[] strArr = str.Split(new char[] { ':', '.', ';', '(', ')' });
                name = strArr[1];
                extention = strArr[2];
                size = strArr[3];
                content = strArr[4];
            }

            public override string To_String()
            {
                string s = "Text file\n:";
                s += base.To_String() + $" {content}";
                return s;
            }
        }

        class FileMovies : File
        {
            private string lenght;
            private string resolution;


            public FileMovies()
            {

            }

            public void Pars(string str)
            {
                string[] strArr = str.Split(new char[] { ':', '.', ';', '(', ')' });
                name = strArr[1];
                name+= strArr[2];
                extention = strArr[3];
                size = strArr[4];
                resolution = strArr[5];
                lenght = strArr[6];
            }

            public override string To_String()
            {
                string s = "Movies:\n";
                //s += $"{name}.{extention}({size}); {resolution}; {lenght}";
                return s;
            }
        }

        class FileImages : File
        {

            private string resolution;

            public FileImages()
            {

            }

            public void Pars(string str)
            {
                string[] strArr = str.Split(new char[] { ':', '.', ';', '(', ')' });
                name = strArr[1];
                extention = strArr[2];
                size = strArr[3];
                resolution = strArr[4];
            }

            public override string To_String()
            {
                string s = "Images:";
                s += $"{name}.{extention}({size}); {resolution}";
                return s;
            }
        }

        static void Main(string[] args)
        {
            string s = @"Text:file.txt(6B);Some string content
Image:img.bmp(19MB);1920x1080
Text:data.txt(12B);Another string
Text:data1.txt(7B);Yet another string
Movie:logan.2017.mkv(19GB);1920x1080;2h12m";

            var arr = s.Split();
            foreach (var item in arr)
            {
                if (item.StartsWith("Image:"))
                {
                    new FileImages().Pars(item);
                }

                if (item.StartsWith("Text:"))
                {
                    new FileTxt().Pars(item);
                }

                if (item.StartsWith("Movie:"))
                {
                    new FileMovies().Pars(item);
                }
            }
            foreach (var item in arr)
               Console.WriteLine(item);
        }
    }
}
