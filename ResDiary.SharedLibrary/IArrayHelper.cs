using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResDiary.SharedLibrary
{
    public interface IArrayHelper
    {
        /// <summary>
        /// Used to split an input array into equal arrays with the remainder in the last array.
        /// </summary>
        /// <typeparam name="T">  Object the array holds. </typeparam>
        /// <param name="input"> The input array. </param>
        /// <param name="arrayOutputCount"> Number of output arrays. </param>
        /// <returns> An Array of arrays. </returns>
        T[][] GroupArrayElements<T>(T[] input, int arrayOutputCount);
    }
}
