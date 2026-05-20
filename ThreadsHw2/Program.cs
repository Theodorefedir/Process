namespace ThreadsHw2
{
    internal class Program
    {
        class DataFile {
            private int words;
            public int Words
            {
                get { return words; }
                set {
                    if (value >= 0)
                        words = value;
                    else { 
                        words = 0;
                    }
                }
            }
            private int lines;
            public int Lines
            {
                get { return lines; }
                set
                {
                    if (value >= 0)
                        lines = value;
                    else
                    {
                        lines = 0;
                    }
                }
            }
            private int punkt;
            public int Punkt
            {
                get { return punkt; }
                set
                {
                    if (value >= 0)
                        punkt = value;
                    else
                    {
                        punkt = 0;
                    }
                }
            }


        }
        static object locker = new object();
        static void TextAnalyze(string text, DataFile DF) { 
            int lines = text.Split('\n').Length;
            string[] words = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;
            int symbCount=0;
            foreach (char c in text)
            {
                if (c >= '0' && c <= '9' || c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z') {
                    continue;
                }
                symbCount++;
            }
            lock (locker) {
                DF.Words += wordCount;
                DF.Lines += lines;
                DF.Punkt += symbCount;
            }
            Console.WriteLine($"Words: {wordCount}, Lines: {lines}, Symbols: {symbCount}");
        }
        static void Main(string[] args)
        {
            DataFile DF = new DataFile();
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/step/test");
            Thread[] threads = new Thread[files.Length];
            for(int i = 0; i<files.Length; i++)
            {
                Console.WriteLine(files[i]);
                string text = File.ReadAllText(files[i]);
                threads[i] = new Thread(() => TextAnalyze(text, DF));
                threads[i].Start();
            }
            Console.ReadKey();
        }
    }
}
