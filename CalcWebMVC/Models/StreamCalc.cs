using System.IO;

namespace CalcWebMVC.Models
{
    /// <summary>
    /// Класс с общей характиристикой для производных его класса.
    /// </summary>
    public class StreamCalc
    {
        /// <summary>
        /// Проверка на существование файла
        /// (false: Он создаёт путь и файл; true: создаёт только файл)
        /// </summary>
        /// <param name="paths"></param>
        public static void ExitsFiles(string paths)
        {
            FileInfo fl = new FileInfo(paths);
            string namefold = fl.Name;
            string folder = fl.FullName.Replace(namefold,"");
           
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                if (!File.Exists(folder + "/" + namefold))
                {
                    StreamWriter sw = new StreamWriter(paths);
                    sw.Close();
                }
            }
        }
    }
}