using System;

namespace LazyObjectlnstantiation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine ("***** Fun with Lazy Instantiation *****\n");
            
            //В этом вызывающем коде получение всех композиций не производится,
            // но косвенно все равно создаются 10 000 объектов!
            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Play();
            
            // Размещение объекта AllTracks происходит
            // только в случае вызова метода GetAllTracks().
            MediaPlayer yourPlayer = new MediaPlayer();
            AllTracks yourMusic = yourPlayer.GetAllTracks();
            Console.ReadLine();
        }
    }
    
    // Представляет одиночную композицию.
    class Song
    {
        public string Artist { get; set; }
        public string TrackName { get; set; }
        public double TrackLength { get; set; }
    }
    
    // Представляет все композиции в проигрывателе.
    class AllTracks
    {
        // Наш проигрыватель может содержать
        // максимум 10 000 композиций,
        private Song[] _allSongs = new Song[10000];
        public AllTracks()
        {
        // Предположим, что здесь производится
        // заполнение массива объектов Song.
            Console.WriteLine("Filling up the songs!");
        }
    }
    
    // Объект MediaPlayer имеет объекты AllTracks.
    class MediaPlayer
    {
        // Предположим, что эти методы делают что-то полезное,
        public void Play(){/* Воспроизведение композиции */}

        public void Pause(){/* Пауза в воспроизведении */}

        public void Stop(){/* Останов воспроизведения */}

        // Использовать лямбда-выражение для добавления дополнительного
        // кода, который выполняется при создании объекта AllTracks.
        private Lazy<AllTracks> allSongs = new Lazy<AllTracks>(() =>
        {
            Console.WriteLine("Creating AllTracks object! ");
            return new AllTracks();
        });

        public AllTracks GetAllTracks()
        {
            // Возвратить все композиции,
            return allSongs.Value;
        }
    }

}    