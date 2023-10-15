namespace CollectionRealisation.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestFixture]
        public class InitializationTests
        {
            [Test]
            public void MyList_Initialization_IntType()
            {
                // Arrange & Act
                var myList = new MyList<int>();

                // Assert
                Assert.IsNotNull(myList);
            }

            [Test]
            public void MyList_Initialization_StringType()
            {
                // Arrange & Act
                var myList = new MyList<string>();

                // Assert
                Assert.IsNotNull(myList);
            }

            [Test]
            public void MyList_Initialization_DoubleType()
            {
                // Arrange & Act
                var myList = new MyList<double>();

                // Assert
                Assert.IsNotNull(myList);
            }

            [Test]
            public void MyList_Initialization_CustomObjectType()
            {
                // Arrange & Act
                var myList = new MyList<MyCustomObject>();

                // Assert
                Assert.IsNotNull(myList);
            }

            // Define a custom object for testing
            public class MyCustomObject
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }
        }

        [TestFixture]
        public class AddTests
        {
            // ... (Other test methods)

            [Test]
            public void MyList_Add_Item()
            {
                // Arrange
                var myList = new MyList<int>();

                // Act
                myList.Add(42);

                // Assert
                Assert.AreEqual(1, myList.Count);
                Assert.AreEqual(42, myList[0]);
            }

            [Test]
            public void MyList_Add_MultipleItems()
            {
                // Arrange
                var myList = new MyList<string>();

                // Act
                myList.Add("apple");
                myList.Add("banana");
                myList.Add("cherry");

                // Assert
                Assert.AreEqual(3, myList.Count);
                Assert.AreEqual("apple", myList[0]);
                Assert.AreEqual("banana", myList[1]);
                Assert.AreEqual("cherry", myList[2]);
            }

            [Test]
            public void MyList_Add_Resize()
            {
                // Arrange
                var myList = new MyList<int>(2); // Initial capacity of 2

                // Act
                myList.Add(1);
                myList.Add(2);
                myList.Add(3); // Should trigger a resize

                // Assert
                Assert.AreEqual(3, myList.Count);
                Assert.AreEqual(1, myList[0]);
                Assert.AreEqual(2, myList[1]);
                Assert.AreEqual(3, myList[2]);
            }
        }

        [TestFixture]
        public class RemoveTests
        {
            // ... (Other test methods)

            [Test]
            public void MyList_Remove_ItemExists()
            {
                // Arrange
                var myList = new MyList<int>();
                myList.Add(1);
                myList.Add(2);
                myList.Add(3);

                // Act
                bool removed1 = myList.Remove(1);
                bool removed3 = myList.Remove(3);

                // Assert
                Assert.IsTrue(removed1);
                Assert.IsTrue(removed3);
                Assert.AreEqual(1, myList.Count);
                Assert.AreEqual(2, myList[0]);
            }

            [Test]
            public void MyList_Remove_ItemNotInList()
            {
                // Arrange
                var myList = new MyList<string>();
                myList.Add("apple");
                myList.Add("banana");
                myList.Add("cherry");

                // Act
                bool removedGrape = myList.Remove("grape");

                // Assert
                Assert.IsFalse(removedGrape); // Grape is not in the list
                Assert.AreEqual(3, myList.Count);
            }

            [Test]
            public void MyList_Remove_EmptyList()
            {
                // Arrange
                var myList = new MyList<double>();

                // Act
                bool removed = myList.Remove(42.0);

                // Assert
                Assert.IsFalse(removed); // Item not found in an empty list
            }
        }

        [TestFixture]
        public class IndexOfTests
        {
            // ... (Other test methods)

            [Test]
            public void MyList_IndexOf_ItemInList()
            {
                // Arrange
                var myList = new MyList<string>();
                myList.Add("apple");
                myList.Add("banana");
                myList.Add("cherry");

                // Act
                int indexApple = myList.IndexOf("apple");
                int indexCherry = myList.IndexOf("cherry");
                int indexGrape = myList.IndexOf("grape");

                // Assert
                Assert.AreEqual(0, indexApple);
                Assert.AreEqual(2, indexCherry);
                Assert.AreEqual(-1, indexGrape); // Grape is not in the list
            }

            [Test]
            public void MyList_IndexOf_EmptyList()
            {
                // Arrange
                var myList = new MyList<int>();

                // Act
                int index = myList.IndexOf(42);

                // Assert
                Assert.AreEqual(-1, index); // Item not found in an empty list
            }

            [Test]
            public void MyList_IndexOf_NullItem()
            {
                // Arrange
                var myList = new MyList<string>();
                myList.Add("apple");
                myList.Add(null);
                myList.Add("cherry");

                // Act
                int indexNull = myList.IndexOf(null);

                // Assert
                Assert.AreEqual(1, indexNull); // Null item found at index 1
            }
        }


        [TestFixture]
        public class ClearTests
        {
            [Test]
            public void MyList_Clear_NonEmptyList()
            {
                // Arrange
                var myList = new MyList<int>();
                myList.Add(1);
                myList.Add(2);
                myList.Add(3);

                // Act
                myList.Clear();

                // Assert
                Assert.AreEqual(0, myList.Count);
            }

            [Test]
            public void MyList_Clear_EmptyList()
            {
                // Arrange
                var myList = new MyList<string>();

                // Act
                myList.Clear();

                // Assert
                Assert.AreEqual(0, myList.Count);
            }

            [Test]
            public void MyList_Clear_ThenAddItems()
            {
                // Arrange
                var myList = new MyList<int>();
                myList.Add(1);
                myList.Add(2);
                myList.Add(3);

                // Act
                myList.Clear();
                myList.Add(4);
                myList.Add(5);

                // Assert
                Assert.AreEqual(2, myList.Count);
                Assert.AreEqual(4, myList[0]);
                Assert.AreEqual(5, myList[1]);
            }
        }
        [TestFixture]
        public class ContainsTests
        {
            [Test]
            public void MyList_Contains_ItemInList()
            {
                // Arrange
                var myList = new MyList<string>();
                myList.Add("apple");
                myList.Add("banana");
                myList.Add("cherry");

                // Act
                bool containsApple = myList.Contains("apple");
                bool containsBanana = myList.Contains("banana");
                bool containsCherry = myList.Contains("cherry");
                bool containsGrape = myList.Contains("grape");

                // Assert
                Assert.IsTrue(containsApple);
                Assert.IsTrue(containsBanana);
                Assert.IsTrue(containsCherry);
                Assert.IsFalse(containsGrape);
            }

            [Test]
            public void MyList_Contains_EmptyList()
            {
                // Arrange
                var myList = new MyList<int>();

                // Act
                bool containsZero = myList.Contains(0);

                // Assert
                Assert.IsFalse(containsZero);
            }

            [Test]
            public void MyList_Contains_NullItem()
            {
                // Arrange
                var myList = new MyList<string>();
                myList.Add("apple");
                myList.Add(null);
                myList.Add("cherry");

                // Act
                bool containsNull = myList.Contains(null);

                // Assert
                Assert.IsTrue(containsNull);
            }
        }
        [TestFixture]
        public class CopyToTests
        {
            [Test]
            public void MyList_CopyTo_ValidArray()
            {
                // Arrange
                var myList = new MyList<int>();
                myList.Add(1);
                myList.Add(2);
                myList.Add(3);
                var destinationArray = new int[5];
                int arrayIndex = 1;

                // Act
                myList.CopyTo(destinationArray, arrayIndex);

                // Assert
                Assert.AreEqual(0, destinationArray[0]); // Check that the destinationArray has not been modified before the specified index.
                Assert.AreEqual(1, destinationArray[1]);
                Assert.AreEqual(2, destinationArray[2]);
                Assert.AreEqual(3, destinationArray[3]);
                Assert.AreEqual(0, destinationArray[4]); // Check that the destinationArray has not been modified after the specified index.
            }

            [Test]
            public void MyList_CopyTo_NullArray()
            {
                // Arrange
                var myList = new MyList<int>();
                myList.Add(1);
                myList.Add(2);
                myList.Add(3);
                int arrayIndex = 1;

                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => myList.CopyTo(null, arrayIndex));
            }

            [Test]
            public void MyList_CopyTo_ShortArray()
            {
                // Arrange
                var myList = new MyList<int>();
                myList.Add(1);
                myList.Add(2);
                myList.Add(3);
                int[] destinationArray = new int[2];
                int arrayIndex = 1;

                // Act & Assert
                
                Assert.Throws<ArgumentException>(() => myList.CopyTo(destinationArray, arrayIndex));
            }
        }
        [TestFixture]
        public class InsertTests
        {
            // ... (Other test methods)

            [Test]
            public void MyList_Insert_ValidIndex()
            {
                // Arrange
                var myList = new MyList<int>();
                myList.Add(1);
                myList.Add(3);

                // Act
                myList.Insert(1, 2);

                // Assert
                Assert.AreEqual(3, myList.Count);
                Assert.AreEqual(1, myList[0]);
                Assert.AreEqual(2, myList[1]);
                Assert.AreEqual(3, myList[2]);
            }

            [Test]
            public void MyList_Insert_IndexEqualsCount()
            {
                // Arrange
                var myList = new MyList<string>();
                myList.Add("apple");
                myList.Add("cherry");

                // Act
                myList.Insert(2, "banana");

                // Assert
                Assert.AreEqual(3, myList.Count);
                Assert.AreEqual("apple", myList[0]);
                Assert.AreEqual("cherry", myList[1]);
                Assert.AreEqual("banana", myList[2]);
            }

            [Test]
            public void MyList_Insert_IndexOutOfRange()
            {
                // Arrange
                var myList = new MyList<double>();
                myList.Add(1.0);
                myList.Add(2.0);

                // Act & Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => myList.Insert(-1, 0.5));
                Assert.Throws<ArgumentOutOfRangeException>(() => myList.Insert(3, 3.5));
            }
        }
    }
}
