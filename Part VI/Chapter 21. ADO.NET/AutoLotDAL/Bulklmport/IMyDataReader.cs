using System.Collections.Generic;
using System.Data;

namespace AutoLotDAL.Bulklmport
{
    public interface IMyDataReader<T> : IDataReader
    {
        List<T> Records { get; set; }
    }
}
