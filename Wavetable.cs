namespace DMW_Converter
{
    internal static class Wavetable
    {
        internal static int[] ReadBinaryFile(FileInfo file)
        {
            using FileStream stream = File.OpenRead(file.FullName);
            using BinaryReader reader = new(stream);
            byte[] bytes = reader.ReadBytes((int)file.Length);
            bool isNewFormat = bytes[4] == 0xFF;
            int sampleCount = bytes[0];
            int sampleSize = isNewFormat ? 4 : 1;
            int sampleStart = isNewFormat ? 7 : 5;
            int sampleEnd = sampleStart + (sampleCount * sampleSize) - 1;
            int[] samples = new int[sampleCount];

            for (int i = sampleStart; i <= sampleEnd; i += sampleSize)
            {
                int sample = isNewFormat ? BitConverter.ToInt32(bytes, i) : bytes[i];
                samples[(i - sampleStart) / sampleSize] = sample / 2;
            }

            return samples;
        }

        internal static FileInfo WriteTextFile(int[] samples, DirectoryInfo directory, string fileName)
        {
            string path = Path.Combine(directory.FullName, fileName);
            using TextWriter writer = File.CreateText(path);
            writer.Write(string.Join(' ', samples));
            return new FileInfo(path);
        }
    }
}
