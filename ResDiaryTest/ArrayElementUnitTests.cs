using ResDiary.SharedLibrary;
using Xunit;

namespace ResDiary.Test
{
    public class ArrayElementUnitTests
    {
        private int[] _testArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        ArrayHelper CreateSut()
        {
            return new ArrayHelper();
        }

        [Fact]
        public void GroupArrayElements_WhenEquallySplit_ThenReturnCorrectArrays()
        {
            var localTestArray = new int[] { 1, 2, 3, 4, 5, 6 };

            var sut = CreateSut();

            var actual = sut.GroupArrayElements(localTestArray, 3);

            Assert.Equal(3, actual.Length);
            Assert.Equal(actual[0], new int[] { 1, 2 });
            Assert.Equal(actual[1], new int[] { 3, 4 });
            Assert.Equal(actual[2], new int[] { 5, 6 });
        }

        [Fact]
        public void GroupArrayElements_WhenNotEquallySplit_ThenReturnCorrectArrays()
        {
            var sut = CreateSut();

            var actual = sut.GroupArrayElements(_testArray, 3);

            Assert.Equal(3, actual.Length);
            Assert.Equal(actual[0], new int[] { 1, 2, 3, 4, 5 });
            Assert.Equal(actual[1], new int[] { 6, 7, 8, 9, 10 });
            Assert.Equal(actual[2], new int[] { 11, 12, 13, 14 });
        }

        [Fact]
        public void GroupArrayElements_WhenNotEquallySplit_LastGroupOffByMoreThanOne_ThenReturnCorrectArrays()
        {
            var sut = CreateSut();

            var actual = sut.GroupArrayElements(_testArray, 4);

            Assert.Equal(4, actual.Length);
            Assert.Equal(actual[0], new int[] { 1, 2, 3, 4 });
            Assert.Equal(actual[1], new int[] { 5, 6, 7, 8 });
            Assert.Equal(actual[2], new int[] { 9, 10, 11, 12 });
            Assert.Equal(actual[3], new int[] { 13, 14 });
        }

        [Fact]
        public void GroupArrayElements_WhenOneLessNumbersThanGroups_ThenReturnCorrectArrays()
        {
            var localTestArray = new int[] { 1, 2, 3 };

            var sut = CreateSut();

            var actual = sut.GroupArrayElements(localTestArray, 4);

            Assert.Equal(4, actual.Length);
            Assert.Equal(actual[0], new int[] { 1 });
            Assert.Equal(actual[1], new int[] { 2 });
            Assert.Equal(actual[2], new int[] { 3 });
            Assert.Null(actual[3]);
        }

        [Fact]
        public void GroupArrayElements_WhenLessNumbersThanGroups_ThenReturnCorrectArrays()
        {
            var localTestArray = new int[] { 1, 2, 3 };

            var sut = CreateSut();

            var actual = sut.GroupArrayElements(localTestArray, 5);

            Assert.Equal(5, actual.Length);
            Assert.Equal(actual[0], new int[] { 1 });
            Assert.Equal(actual[1], new int[] { 2 });
            Assert.Equal(actual[2], new int[] { 3 });
            Assert.Null(actual[3]);
            Assert.Null(actual[4]);
        }

        [Fact]
        public void GroupArrayElements_WhenLeftOverDoesntFitFinalGroups_ThenReturnCorrectArrays()
        {
            var localTestArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            var sut = CreateSut();

            var actual = sut.GroupArrayElements(localTestArray, 7);

            Assert.Equal(7, actual.Length);
            Assert.Equal(actual[0], new int[] { 1, 2, 3 });
            Assert.Equal(actual[1], new int[] { 4, 5, 6 });
            Assert.Equal(actual[2], new int[] { 7, 8, 9 });
            Assert.Equal(actual[3], new int[] { 10, 11, 12 });
            Assert.Equal(actual[4], new int[] { 13, 14, 15 });
            Assert.Null(actual[5]);
            Assert.Null(actual[6]);
        }
    }
}
