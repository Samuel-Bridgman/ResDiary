namespace ResDiary.SharedLibrary
{
    public class ArrayHelper : IArrayHelper
    {
        /// <summary>
        /// Used to split an input array into equal arrays with the remainder in the last array.
        /// </summary>
        /// <typeparam name="T">  Object type the array holds. </typeparam>
        /// <param name="input"> The input array. </param>
        /// <param name="arrayOutputCount"> Number of output arrays. </param>
        /// <returns> An Array of arrays. </returns>
        public T[][] GroupArrayElements<T>(T[] input, int arrayOutputCount)
        {
            var inputCount = input.Count();
            int arraySize = Convert.ToInt16(Math.Ceiling((double)input.Count() / arrayOutputCount));
            int remainederArraySize = 0;
            if ((arraySize * arrayOutputCount) > inputCount)
            {
                var remainder = inputCount - (arraySize * (arrayOutputCount - 1));
                remainederArraySize = remainder > 0 && remainder < arraySize ? remainder : 0; 
            }

            T[][] returnArray = new T[arrayOutputCount][];

            int currentIndex = 0;
            for (int i = 0; i < arrayOutputCount; i++)
            {
                if(currentIndex < (inputCount - remainederArraySize)) {
                    returnArray[i] = Slice(input, currentIndex, arraySize);
                    currentIndex = currentIndex + arraySize;
                }
                else
                {
                    break;
                }
            }

            if(remainederArraySize > 0)
                returnArray[arrayOutputCount - 1] = Slice(input, currentIndex, remainederArraySize);

            return returnArray;
        }

        /// <summary>
        /// Take a subsection of an array. 
        /// I used stackoverflow to find this solution -
        /// https://stackoverflow.com/questions/11207526/how-to-split-an-array-into-chunks-of-specific-size
        /// </summary>
        /// <typeparam name="T"> Object type the array holds. </typeparam>
        /// <param name="source"> The full array to be split. </param>
        /// <param name="index"> The index to start the slice at. </param>
        /// <param name="length"> The length of the slice. </param>
        /// <returns></returns>
        private T[] Slice<T>(T[] source, int index, int length)
        {
            T[] slice = new T[length];
            Array.Copy(source, index, slice, 0, length);
            return slice;
        }
    }
}
