using ModuleUnknown1_WorkWithFileSystem.Constants;

namespace ModuleUnknown1_WorkWithFileSystem;

// Для работы с файлами есть класс File (статический) и FileInfo
// Для работы с директориями есть аналогичные классы File и FileInfo
public class FileSystemUnderstanding
{
    public void FileExample()
    {
        Console.WriteLine(nameof(FileExample));
        Console.WriteLine($"Does file {FileNames.NotExistingFile} exist? - {File.Exists(FileNames.NotExistingFile)}");
    }
    
    public void FileInfoExample()
    {
        Console.WriteLine(nameof(FileInfoExample));
        var file = new FileInfo(FileNames.NotExistingFile);
        Console.WriteLine($"Does file {FileNames.NotExistingFile} exist? - {file.Exists}");
    }
}