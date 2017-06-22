namespace TeloneioApp.Models
{
    public class FileInfoEDE
    {
        internal uint length;

        public FileInfoEDE()
        {
        }

        public string Name { get; internal set; }
        public string DirectoryName { get; internal set; }
        public string FullName { get; internal set; }
        public string Extension { get; internal set; }
    }
}