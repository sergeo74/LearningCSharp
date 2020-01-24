using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace DataParallelismWithForEach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // Используется для сообщения всем рабочим потокам о необходимости останова!
            cancelToken.Cancel();
        }
        private void cmdProcess_Click(object sender, EventArgs e)
        {
            // Запустить новую "задачу" для обработки файлов.
            Task.Factory.StartNew(() => ProcessFiles());
        }

        private void ProcessFiles()
        {
            // Использовать экземпляр ParallelOptions для хранения CancellationToken.
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancelToken.Token;
            parallelOptions.MaxDegreeOfParallelism = Environment.ProcessorCount;

            string[] files = Directory.GetFiles(@".\TestPictures",
                "*.jpg", SearchOption.AllDirectories);
            string newDir = @".\ModifledPictures";

            Directory.CreateDirectory(newDir);

            try
            {
                Parallel.ForEach(files, parallelOptions, currFile =>
                    {
                        parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                        string filename = Path.GetFileName(currFile);

                        using (Bitmap bitmap = new Bitmap(currFile))
                        {
                            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            bitmap.Save(Path.Combine(newDir, filename));

                            this.Dispatcher.Invoke((Action)delegate
                            {
                                this.Title = $"Processing {filename} on thread" +
                                $" {Thread.CurrentThread.ManagedThreadId}";
                            }
                            );
                        }

                    }
                    );
                this.Dispatcher.Invoke((Action)delegate { this.Title = "Done!"; });
            }
            catch (OperationCanceledException ex)
            {
                this.Dispatcher.Invoke((Action)delegate { this.Title = ex.Message; });
            }
        }
    }
}
