using System;
using Xunit;
using ImplementationIClosedList;

namespace TestProjectClosedList
{
    public class TestClosedList
    {
        /// <summary>
        /// �������� ������ MoveNext
        /// </summary>
        [Fact]
        public void MoveNextTestWithStandartStep()
        {
            IClosedList<string> currentClassClosedList = new ClassClosedList<string>();
            currentClassClosedList.Add("firstElement");
            currentClassClosedList.Add("secondElement");
            currentClassClosedList.Add("thirdElement");
            currentClassClosedList.Add("fourthElement");
            currentClassClosedList.Add("fifthElement");

            var expected = "secondElement";
            currentClassClosedList.MoveNext();
            var actual = currentClassClosedList.Current;

            Assert.Equal(expected, actual);
        }
        /// <summary>
        /// �������� ������ MoveBack
        /// </summary>
        [Fact]
        public void MoveBackTestWithStandartStep()
        {
            IClosedList<string> currentClassClosedList = new ClassClosedList<string>();
            currentClassClosedList.Add("firstElement");
            currentClassClosedList.Add("secondElement");
            currentClassClosedList.Add("thirdElement");
            currentClassClosedList.Add("fourthElement");
            currentClassClosedList.Add("fifthElement");

            var expected = "fifthElement";
            currentClassClosedList.MoveBack();
            var actual = currentClassClosedList.Current;

            Assert.Equal(expected, actual);
        }
        /// <summary>
        /// �������� ������ MoveNext � ���������������� �����
        /// </summary>
        /// <param name="step"> ��� </param>
        [Theory]
        [InlineData(3)]
        public void MoveNextTestWithUserStep(int step)
        {
            IClosedList<string> currentClassClosedList = new ClassClosedList<string>();
            currentClassClosedList.Add("firstElement");
            currentClassClosedList.Add("secondElement");
            currentClassClosedList.Add("thirdElement");
            currentClassClosedList.Add("fourthElement");
            currentClassClosedList.Add("fifthElement");

            var expected = "fourthElement";
            currentClassClosedList.MoveNext(step);
            var actual = currentClassClosedList.Current;

            Assert.Equal(expected, actual);
        }
        /// <summary>
        /// �������� ������ MoveBack � ���������������� �����
        /// </summary>
        /// <param name="step"> ��� </param>
        [Theory]
        [InlineData(3)]
        public void MoveBackTestWithUserStep(int step)
        {
            IClosedList<string> currentClassClosedList = new ClassClosedList<string>();
            currentClassClosedList.Add("firstElement");
            currentClassClosedList.Add("secondElement");
            currentClassClosedList.Add("thirdElement");
            currentClassClosedList.Add("fourthElement");
            currentClassClosedList.Add("fifthElement");

            var expected = "thirdElement";
            currentClassClosedList.MoveBack(step);
            var actual = currentClassClosedList.Current;

            Assert.Equal(expected, actual);
        }
        /// <summary>
        /// �������� �������� Next
        /// </summary>
        [Fact]
        public void NextElementTest() 
        {
            IClosedList<string> currentClassClosedList = new ClassClosedList<string>();
            currentClassClosedList.Add("firstElement");
            currentClassClosedList.Add("secondElement");
            currentClassClosedList.Add("thirdElement");
            currentClassClosedList.Add("fourthElement");
            currentClassClosedList.Add("fifthElement");

            var expected = "secondElement";
            var actual = currentClassClosedList.Next;
            Assert.Equal(expected, actual);
        }
        /// <summary>
        /// �������� �������� Previous
        /// </summary>
        [Fact]
        public void PreviousElementTest()
        {
            IClosedList<string> currentClassClosedList = new ClassClosedList<string>();
            currentClassClosedList.Add("firstElement");
            currentClassClosedList.Add("secondElement");
            currentClassClosedList.Add("thirdElement");
            currentClassClosedList.Add("fourthElement");
            currentClassClosedList.Add("fifthElement");

            var expected = "fifthElement";
            var actual = currentClassClosedList.Previous;
            Assert.Equal(expected, actual);
        }
        /// <summary>
        /// �������� �������� Head
        /// </summary>
        [Fact]
        public void HeadElementTest()
        {
            IClosedList<string> currentClassClosedList = new ClassClosedList<string>();
            currentClassClosedList.Add("firstElement");
            currentClassClosedList.Add("secondElement");
            currentClassClosedList.Add("thirdElement");
            currentClassClosedList.Add("fourthElement");
            currentClassClosedList.Add("fifthElement");

            var expected = "firstElement";
            var actual = currentClassClosedList.Head;
            Assert.Equal(expected, actual);
        }
        /// <summary>
        /// �������� ������������ ���������� ���� IndexOutOfRangeException ��� ������� ��������� � ��������������� ��������
        /// </summary>
        [Fact]
        public void GetElementByIndexOutOfRangeExceptionTest()
        {
            IClosedList<string> currentClassClosedList = new ClassClosedList<string>();
            currentClassClosedList.Add("firstElement");
            currentClassClosedList.Add("secondElement");
            currentClassClosedList.Add("thirdElement");
            currentClassClosedList.Add("fourthElement");
            currentClassClosedList.Add("fifthElement");

            Assert.Throws<IndexOutOfRangeException>(() => currentClassClosedList[5]);
        }
        /// <summary>
        /// �������� ������ ������� ��� ������� ����� ������� � ������� �������� ��� ������� MoveNext
        /// </summary>
        [Fact]
        public void RaiseEventMoveNextTest() 
        {
            IClosedList<string> currentClassClosedList = new ClassClosedList<string>();
            currentClassClosedList.Add("firstElement");
            currentClassClosedList.Add("secondElement");
            currentClassClosedList.Add("thirdElement");
            currentClassClosedList.Add("fourthElement");
            currentClassClosedList.Add("fifthElement");

            bool eventRaised = false;
            currentClassClosedList.HeadReached += (obj, eventArgs) => eventRaised = true;
            currentClassClosedList.MoveNext(6);
            Assert.True(eventRaised);
        }

        /// <summary>
        /// �������� ������ ������� ��� ������� ����� ������� � ������� �������� ��� ������� MoveBack
        /// </summary>
        [Fact]
        public void RaiseEventMoveBackTest()
        {
            IClosedList<string> currentClassClosedList = new ClassClosedList<string>();
            currentClassClosedList.Add("firstElement");
            currentClassClosedList.Add("secondElement");
            currentClassClosedList.Add("thirdElement");
            currentClassClosedList.Add("fourthElement");
            currentClassClosedList.Add("fifthElement");

            bool eventRaised = false;
            currentClassClosedList.HeadReached += (obj, eventArgs) => eventRaised = true;
            currentClassClosedList.MoveBack();
            Assert.True(eventRaised);
        }
    }
}
