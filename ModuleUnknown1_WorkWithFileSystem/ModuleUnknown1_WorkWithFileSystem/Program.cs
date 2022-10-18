using ModuleUnknown1_WorkWithFileSystem;

var fileSystemUnderstanding = new FileSystemUnderstanding();
fileSystemUnderstanding.FileExample();
fileSystemUnderstanding.FileInfoExample();

var streamUnderstanding = new StreamUnderstanding();
await streamUnderstanding.WorkWithFile();