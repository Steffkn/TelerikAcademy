namespace CohesionAndCoupling
{
    public class FileManager
    {
        public static string GetFileExtension(string fileName)
        {
            string extension = string.Empty;
            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot != -1)
            {
                extension = fileName.Substring(indexOfLastDot + 1);
            }

            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            string resultName = string.Empty;

            if (indexOfLastDot == -1)
            {
                resultName = fileName;
            }
            else
            {
                resultName = fileName.Substring(0, indexOfLastDot);
            }

            return resultName;
        }
    }
}
