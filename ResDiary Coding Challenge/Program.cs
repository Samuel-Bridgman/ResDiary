using ResDiary.SharedLibrary;

namespace ResDiary_Coding_Challenge 
{ 
    public class Program
    {
        private static int[] testArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        public static void Main(string[] args)
        {
            var arrayHelper = new ArrayHelper();

            var arrayOfArrays = arrayHelper.GroupArrayElements(testArray, 7);

            foreach (var array in arrayOfArrays)
            {
                Console.WriteLine(string.Join(",", array));
            }

            Console.ReadKey();
        }
    }
}