using ModuleUnknown1_WorkWithFileSystem.Constants;
using System;
using System.Text;

namespace ModuleUnknown1_WorkWithFileSystem;

// Любой набор информации в компьютере можно представить в виде потока байт.
// В c# для этого используется класс Stream, это базовый класс,
// который используют наследники, например, файловые потоки (потоки ввода-вывода), или потоки в памяти.
public class StreamUnderstanding
{
    private const string Text = "Here is write file result.";

    // Рассмотрим потоки на примере работы с файлами файла
    public async Task WorkWithFile()
    {
        // Для начала создадим путь к файлу
        var pathToRead = GetPathToStaticFiles(FileNames.SimpleTextFile);
        // var path2 = Path.Combine(Environment.CurrentDirectory, DirectoryNames.StaticFiles, FileNames.SimpleTextFile);

        // И открываем файл в виде байтового потока 
        var readStream = File.Open(pathToRead, FileMode.Open);

        // выделяем буффер для записа байт из потока
        var readBuffer = new byte[readStream.Length];
        // считываем
        await readStream.ReadAsync(readBuffer);
        
        // декодируем байты в строку
        var simpleTextFromFile = Encoding.Default.GetString(readBuffer);
        // и выводим на консоль
        Console.WriteLine(simpleTextFromFile);
        
        // не забываем закрыть поток, чтобы освободить память, выделенную под него
        readStream.Close();
        
        // теперь запись
        var pathToWrite = GetPathToStaticFiles("write-file-example.txt");
        var writeStream = File.Open(pathToWrite, FileMode.OpenOrCreate);

        // процесс записи противоположен чтению
        var writeBuffer = Encoding.Default.GetBytes(Text);
        await writeStream.WriteAsync(writeBuffer);
        
        writeStream.Close();
    }

    public async Task StreamReaderWriter()
    {
        var pathToRead = GetPathToStaticFiles(FileNames.SimpleTextFile);

        var readStream = File.Open(pathToRead, FileMode.Open);
        var reader = new StreamReader(readStream);

        while (reader.EndOfStream == false)
        {
            Console.WriteLine(await reader.ReadLineAsync());
        }
        
        reader.Close();

        var writePath = GetPathToStaticFiles("file-for-stream-writer.txt");
        var writeStream = File.Open(writePath, FileMode.OpenOrCreate);
        var writer = new StreamWriter(writeStream);
        await writer.WriteLineAsync(Text);
        
        writer.Close();
    }

    private static string GetPathToStaticFiles(string fileName) => Path.Combine(Directory.GetCurrentDirectory(), DirectoryNames.StaticFiles, fileName);
}