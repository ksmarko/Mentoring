using System;
using System.Collections.Generic;
using NUnit.Framework;
using Structures = DataStructures.HashTable;

namespace DataStructures.Test.HashTable
{
    [TestFixture]
    class HashTableTest
    {
        [Test]
        public void HashTable_should_throw_ArgumentException_if_size_is_less_than_0()
        {
            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Structures.HashTable<int, int>(-1));
        }

        [Test]
        public void HashTable_should_throw_ArgumentException_if_size_is_equal_to_0()
        {
            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Structures.HashTable<int, int>(0));
        }

        [Test]
        public void Count_should_return_0_if_table_is_empty()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            int expectedCount = 0;

            //Act
            var count = table.Count;

            //Assert
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void Count_should_return_count_of_items_if_table_is_not_empty()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");
            int expectedCount = 1;

            //Act
            var count = table.Count;

            //Assert
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void Get_should_throw_ArgumentException_if_key_does_not_exist()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            string value;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => value = table[1]);
        }

        [Test]
        public void Get_should_return_value_by_index_if_key_exists()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");

            //Act
            var result = table[1];

            //Act & Assert
            Assert.AreEqual("1", result);
        }

        [Test]
        public void Set_should_throw_ArgumentException_if_key_does_not_exist()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => table[1] = "1");
        }

        [Test]
        public void Set_should_remove_entry_by_key_if_value_is_null()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");

            //Act
            table[1] = null;

            //Act & Assert
            Assert.False(table.Contains(1));
        }

        [Test]
        public void Set_should_replace_entry_by_key_if_value_is_not_null()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "2");
            var value = "3";
            var expectedValue = value;

            //Act
            table[1] = value;

            //Act & Assert
            Assert.AreEqual(expectedValue, table[1]);
        }

        [Test]
        public void Add_should_throw_ArgumentException_if_key_exists()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");

            //Act & Assert
            Assert.Throws<ArgumentException>(() => table.Add(1, "2"));
        }

        [Test]
        public void Add_should_add_item_if_key_does_not_exist()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");
            int expectedCount = 2;

            //Act
            table.Add(2, "1");
            var count = table.Count;

            //Assert
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void Add_should_increase_count_if_success()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");
            int expectedCount = table.Count + 1;

            //Act
            table.Add(2, "1");
            var count = table.Count;

            //Assert
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void Contains_should_return_true_if_key_exists()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");

            //Act
            var result = table.Contains(1);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void Contains_should_return_false_if_key_does_not_exist()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");

            //Act
            var result = table.Contains(2);

            //Assert
            Assert.False(result);
        }

        [Test]
        public void TryGet_should_return_false_if_key_does_not_exist()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");

            //Act
            var result = table.TryGet(2, out var value);

            //Assert
            Assert.False(result);
        }

        [Test]
        public void TryGet_should_return_null_object_if_key_does_not_exist()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");

            //Act
            var result = table.TryGet(2, out var value);

            //Assert
            Assert.Null(value);
        }

        [Test]
        public void TryGet_should_return_true_if_key_exists()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");

            //Act
            var result = table.TryGet(1, out var value);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void TryGet_should_return_value_if_key_exists()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "2");

            //Act
            var result = table.TryGet(1, out var outValue);

            //Assert
            Assert.AreEqual("2", outValue);
        }

        [Test]
        public void Remove_should_throw_ArgumentException_if_key_does_not_exist()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");

            //Act & Assert
            Assert.Throws<ArgumentException>(() => table.Remove(2));
        }

        [Test]
        public void Remove_should_remove_item_if_key_exists()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");
            var expectedCount = 0;

            //Act
            table.Remove(1);
            var count = table.Count;

            //Assert
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void Remove_should_decrease_count_if_success()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");
            var expectedCount = 0;

            //Act
            table.Remove(1);
            var count = table.Count;

            //Assert
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void Clear_should_set_count_to_0()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");
            var expectedCount = 0;

            //Act
            table.Clear();
            var count = table.Count;

            //Assert
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void Clear_should_remove_all_items()
        {
            //Arrange
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "1");
            var expectedCount = 0;

            //Act
            table.Clear();
            var count = table.Count;

            //Assert
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void GetEnumerator_should_return_all_values()
        {
            //Arrange
            var expectedValues = new List<string>() { "2", "4", "6", "8" };
            var values = new List<string>();
            var table = new Structures.HashTable<int, string>();
            table.Add(1, "2");
            table.Add(2, "4");
            table.Add(3, "6");
            table.Add(4, "8");

            //Act
            foreach(var el in table)
            {
                values.Add(el);
            }

            //Assert
            Assert.AreEqual(expectedValues, values);
        }
    }
}
