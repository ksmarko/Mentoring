using System;
using System.Text;
using NUnit.Framework;
using Structures = DataStructures.LinkedList;

namespace DataStructures.Test.LinkedList
{
    [TestFixture]
    class LinkedListTests
    {
        [Test]
        public void Length_should_return_0_if_list_is_empty()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            var expectedLength = 0;

            //Act
            var length = list.Length;

            //Assert
            Assert.AreEqual(expectedLength, length);
        }

        [Test]
        public void Count_should_return_count_of_elements_if_list_is_not_empty()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            list.AddLast(1);
            list.AddLast(1);
            var expectedLength = 2;

            //Act
            var length = list.Length;

            //Assert
            Assert.AreEqual(expectedLength, length);
        }

        [Test]
        public void AddFirst_should_return_list_with_one_element_if_it_was_empty()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            list.AddFirts(1);
            var expectedLength = 1;

            //Act
            var length = list.Length;

            //Assert
            Assert.AreEqual(expectedLength, length);
        }

        [Test]
        public void AddFirst_should_add_data_on_first_position()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            list.AddFirts(1);
            list.AddFirts(2);
            var expectedContent = "21";

            //Act
            var content = GetStringOfElements(list);

            //Assert
            Assert.AreEqual(expectedContent, content);
        }

        [Test]
        public void AddLast_should_return_list_with_one_element_if_it_was_empty()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            list.AddLast(1);
            var expectedLength = 1;

            //Act
            var length = list.Length;

            //Assert
            Assert.AreEqual(expectedLength, length);
        }

        [Test]
        public void AddLast_should_add_data_on_last_position()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            var expectedContent = "12";

            //Act
            var content = GetStringOfElements(list);

            //Assert
            Assert.AreEqual(expectedContent, content);
        }

        [Test]
        public void AddAt_should_return_false_if_index_is_out_of_range()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            int index = -1;
            int data = 0;

            //Act
            var actionResult = list.AddAt(index, data);

            //Assert
            Assert.False(actionResult);
        }

        [Test]
        public void AddAt_should_add_element_on_first_position_if_list_is_empty()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            int index = 0;
            int data = 0;

            //Act
            var actionResult = list.AddAt(index, data);

            //Assert
            Assert.True(actionResult);
        }

        [Test]
        public void AddAt_should_increment_length_if_success()
        {
            //Arrange
            var list = GetIntegerList();
            var expectedLength = list.Length + 1;
            int index = 1;
            int data = 0;

            //Act
            list.AddAt(index, data);
            var length = list.Length;

            //Assert
            Assert.AreEqual(expectedLength, length);
        }

        [Test]
        public void AddAt_should_return_false_if_element_has_not_been_added()
        {
            //Arrange
            var list = GetIntegerList();
            int index = -1;
            int data = 0;

            //Act
            bool result = list.AddAt(index, data);

            //Assert
            Assert.False(result);
        }

        [Test]
        public void AddAt_should_return_true_if_element_has_been_added()
        {
            //Arrange
            var list = GetIntegerList();
            int index = 1;
            int data = 0;

            //Act
            bool result = list.AddAt(index, data);

            //Assert
            Assert.True(result);
        }


        [Test]
        public void InsertBefore_should_return_false_if_list_is_empty()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            int target = 0;
            int data = 0;

            //Act
            var actionResult = list.InsertBefore(target, data);

            //Assert
            Assert.False(actionResult);
        }

        [Test]
        public void InsertBefore_should_increment_length_if_success()
        {
            //Arrange
            var list = GetIntegerList();
            var expectedLength = list.Length + 1;
            int target = 1;
            int data = 0;

            //Act
            list.InsertBefore(target, data);
            var length = list.Length;

            //Assert
            Assert.AreEqual(expectedLength, length);
        }

        [Test]
        public void InsertBefore_should_return_false_if_target_element_does_not_exist()
        {
            //Arrange
            var list = GetIntegerList();
            int target = -1;
            int data = 0;

            //Act
            bool result = list.InsertBefore(target, data);

            //Assert
            Assert.False(result);
        }

        [Test]
        public void InsertBefore_should_add_element_before_target()
        {
            //Arrange
            var list = GetIntegerList();
            int target = 5;
            int data = 0;
            var expectedContent = "01234056789";

            //Act
            list.InsertBefore(target, data);

            //Assert
            var content = GetStringOfElements(list);
            Assert.AreEqual(expectedContent, content);
        }

        [Test]
        public void InsertBefore_should_return_true_on_success()
        {
            //Arrange
            var list = GetIntegerList();
            int target = 5;
            int data = 0;

            //Act
            var result = list.InsertBefore(target, data);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void InsertAfter_should_return_false_if_list_is_empty()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            int target = 0;
            int data = 0;

            //Act
            var actionResult = list.InsertAfter(target, data);

            //Assert
            Assert.False(actionResult);
        }

        [Test]
        public void InsertAfter_should_increment_length_if_success()
        {
            //Arrange
            var list = GetIntegerList();
            var expectedLength = list.Length + 1;
            int target = 1;
            int data = 0;

            //Act
            list.InsertAfter(target, data);
            var length = list.Length;

            //Assert
            Assert.AreEqual(expectedLength, length);
        }

        [Test]
        public void InsertAfter_should_return_false_if_target_element_does_not_exist()
        {
            //Arrange
            var list = GetIntegerList();
            int target = -1;
            int data = 0;

            //Act
            bool result = list.InsertAfter(target, data);

            //Assert
            Assert.False(result);
        }

        [Test]
        public void InsertAfter_should_add_element_before_target()
        {
            //Arrange
            var list = GetIntegerList();
            int target = 5;
            int data = 0;
            var expectedContent = "01234506789";

            //Act
            list.InsertAfter(target, data);

            //Assert
            var content = GetStringOfElements(list);
            Assert.AreEqual(expectedContent, content);
        }

        [Test]
        public void InsertAfter_should_return_true_if_success()
        {
            //Arrange
            var list = GetIntegerList();
            int target = 5;
            int data = 0;

            //Act
            var result = list.InsertAfter(target, data);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void Clear_shoul_set_count_to_0()
        {
            //Arrange
            var list = GetIntegerList();
            int expectedLength = 0;

            //Act
            list.Clear();

            //Assert
            int length = list.Length;
            Assert.AreEqual(expectedLength, length);
        }
        
        [Test]
        public void Remove_should_remove_first_occurence_of_item()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(1);
            string expectedResult = "21";

            //Act
            list.Remove(1);

            //Assert
            Assert.AreEqual(expectedResult, GetStringOfElements(list));
        }

        [Test]
        public void Remove_should_return_true_if_item_has_been_deleted()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            list.AddLast(1);

            //Act
            var result = list.Remove(1);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void Remove_should_return_false_if_item_does_not_exist()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            list.AddLast(1);

            //Act
            var result = list.Remove(2);

            //Assert
            Assert.False(result);
        }

        [Test]
        public void Remove_should_decrease_count_if_success()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            list.AddLast(1);
            var expectedLength = list.Length - 1;

            //Act
            list.Remove(1);
            var length = list.Length;

            //Assert
            Assert.AreEqual(expectedLength, length);
        }

        [Test]
        public void RemoveAt_should_return_false_if_index_if_out_of_range()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            list.AddLast(1);
            int index = -1;

            //Act
            bool result = list.RemoveAt(index);

            //Assert
            Assert.False(result);
        }

        [Test]
        public void RemoveAt_should_return_true_if_item_has_been_deleted()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            list.AddLast(1);
            int index = 0;

            //Act
            bool result = list.RemoveAt(index);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void RemoveAt_should_decrease_count_if_success()
        {
            //Arrange
            Structures.LinkedList<int> list = GetIntegerList();
            int index = 0;
            list.AddLast(1);
            var expectedLength = list.Length - 1;

            //Act
            list.RemoveAt(index);
            var length = list.Length;

            //Assert
            Assert.AreEqual(expectedLength, length);
        }

        [Test]
        public void ElementAt_should_throw_IndexOutOfRangException_if_index_is_less_than_0()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            int index = -1;

            //Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => list.ElementAt(index));
        }

        [Test]
        public void ElementAt_should_throw_IndexOutOfRangException_if_index_is_greater_than_count()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            int index = list.Length + 1;

            //Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => list.ElementAt(index));
        }

        [Test]
        public void ElementAt_should_throw_IndexOutOfRangException_if_index_is_equal_to_count()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            int index = list.Length;

            //Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => list.ElementAt(index));
        }

        [Test]
        public void ElementAt_should_return_item_data_on_specified_position()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            int data = 1;
            list.AddLast(data);
            int index = 0;

            //Act
            var item = list.ElementAt(index);

            //Assert
            Assert.AreEqual(data, item);
        }

        [Test]
        public void GetEnumerator_should_return_all_items()
        {
            //Arrange
            var list = new Structures.LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            var expectedResult = "123";
            var result = "";

            //Act
            foreach (var el in list)
                result += el;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        private Structures.LinkedList<int> GetIntegerList()
        {
            var list = new Structures.LinkedList<int>();

            for (int i = 0; i < 10; i++)
                list.AddLast(i);

            return list;
        }

        private string GetStringOfElements(Structures.LinkedList<int> list)
        {
            var builder = new StringBuilder("");

            foreach (var el in list)
                builder.Append(el);

            return builder.ToString();
        }
    }
}
