using DMW_Converter;

const int exitCodeSuccess = 0;
const int exitCodeError = 1;

if (args.Length < 2)
{
    Console.WriteLine("Please specify <directory> and <extension> arguments.");
    return exitCodeError;
}

try
{
    DirectoryInfo directory = new(args[0]);
    string extension = args[1];

    if (!directory.Exists)
    {
        Console.WriteLine($"The directory '{directory}' does not exist.");
        return exitCodeError;
    }

    DirectoryInfo exportDirectory = directory.CreateSubdirectory("Export");

    foreach (FileInfo file in directory.GetFiles())
    {
        int[] samples = Wavetable.ReadBinaryFile(file);
        FileInfo exportedFile = Wavetable.WriteTextFile(samples, exportDirectory, Path.ChangeExtension(file.Name, extension));
        Console.WriteLine($"Exported {exportedFile.FullName}");
    }

    Console.WriteLine("\nFinished.");
    return exitCodeSuccess;
}
catch (Exception e)
{
    Console.WriteLine($"The process failed: {e}");
    return exitCodeError;
}
