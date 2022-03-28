public class FileData
{
    public string FileName { get; set; }
    public string FileSize { get; set; }

    public FileData(string fileName, string fileSize)
    {
        if (String.IsNullOrWhiteSpace(fileName))
        {
            throw new Exception($"Invalid {nameof(fileName)}");
        }
        if (String.IsNullOrWhiteSpace(fileSize))
        {
            throw new Exception($"Invalid {nameof(fileSize)}");
        }

        FileName = fileName;
        FileSize = fileSize;
    }
}
