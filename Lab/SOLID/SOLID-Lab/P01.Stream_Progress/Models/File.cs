using P01.Stream_Progress.Models.Contracts;

namespace P01.Stream_Progress.Models
{
    public class File : IStream
    {
        private string name;

        public File(string name, int length, int bytesSent)
        {
            this.name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
