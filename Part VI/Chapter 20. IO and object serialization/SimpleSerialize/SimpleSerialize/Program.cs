using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace SimpleSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Serialization *****\n");
            JamesBondCar jamesBondCar = new JamesBondCar();
            jamesBondCar.canFly = true;
            jamesBondCar.canSubmerge = false;
            jamesBondCar.theRadio.stationPresets = new double[] {89.9, 107.7, 101.2};
            jamesBondCar.theRadio.hasTweeters = true;

            SaveAsBinaryFormat(jamesBondCar, "CarData.dat");
            LoadFromBinaryFile("CarData.dat");
            Console.ReadLine();
        }

        static void SaveAsBinaryFormat(object objGraph, string fileName)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binaryFormatter.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in binary format!");
        } 

        static void LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using ( Stream fStream = File.OpenRead(fileName))
            {
                JamesBondCar jamesBondCarFromDisk = 
                    (JamesBondCar)binaryFormatter.Deserialize(fStream);
                Console.WriteLine($"Can this car fly? : {jamesBondCarFromDisk.canFly}");
            }
        }
    }

    [Serializable]
    public class Radio
    {
        public bool hasTweeters { get; set; }
        public bool hasSubWoofers;
        public double[] stationPresets;

        [NonSerialized]
        public readonly string radioID = "XF-552RR6";
    }

    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }

    [Serializable]
    public class JamesBondCar: Car 
    {
        public bool canFly;
        public bool canSubmerge;
    }

}
