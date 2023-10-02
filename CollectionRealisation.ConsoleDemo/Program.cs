// See https://aka.ms/new-console-template for more information
using CollectionRealisation;
using CollectionRealisation.ConsoleDemo;

#region ListDemo

////create int list
//var myIntList = new MyList<int>() {1,2,3,4,5 };

//ShowIEnumerable<int>.Show(myIntList);

////create double list
//var myDoubleList = new MyList<double>() { 1.3, 2.3, 3.3, 4.3, 5.3 };

//ShowIEnumerable<double>.Show(myDoubleList);

////create char list
//var myCharList = new MyList<char>();

//for (int i = 0; i < 5; i++)
//{
//    myCharList.Add((char)(97 + i));
//}

//ShowIEnumerable<char>.Show(myCharList);


////set char to serch
//var charToSerch = 'a';

//Console.WriteLine();

////Contains
////check if myCharList Contains charToSerch
//if (myCharList.Contains(charToSerch))
//{
//    Console.WriteLine(string.Format("myCharList contains {0}", charToSerch));
//}
//else
//{
//    Console.WriteLine(string.Format("myCharList do not {0}", charToSerch));
//}


//Console.WriteLine();

////Insert
//Console.WriteLine("insert 'y' to list");

//myCharList.Insert(3, 'y');

//ShowIEnumerable<char>.Show(myCharList);

////IndexOf
//Console.WriteLine("index of 'y' is {0}", myCharList.IndexOf('y'));

//ShowIEnumerable<char>.Show(myCharList);


////CopyTo
//var destArr = new char[10];

//for (int i = 0; i < destArr.Length; i++)
//{
//    destArr[i] = (char)(110 + i);
//}
//Console.WriteLine("destArr");
//ShowIEnumerable<char>.Show(destArr);

//myCharList.CopyTo(destArr, 0);  

//Console.WriteLine("myCharList.CopyTo(destArr, 0);");
//Console.WriteLine();    
//Console.WriteLine("destArr after CopyTo");

//ShowIEnumerable<char>.Show(destArr);


////Remove
//Console.WriteLine("remove 'a' from list");

//myCharList.Remove(charToSerch);

//ShowIEnumerable<char>.Show(myCharList);


////RemoveAt
//Console.WriteLine("remove 1-st elem from list");

//myCharList.RemoveAt(1);

//ShowIEnumerable<char>.Show(myCharList);


////Clear
//Console.WriteLine("remove all elems from list");

//myCharList.Clear();

//ShowIEnumerable<char>.Show(myCharList);

#endregion

#region StackDemo

var myIntStack = new MyStack<int>();

for (int i = 1; i <= 5; i++)
{
    myIntStack.Push(i);
}

ShowIEnumerable<int>.Show(myIntStack);

//create double list
var myDoubleStack = new MyStack<double>();

var rendom = new Random();  
for (int i = 1; i <= 5; i++)
{
    myDoubleStack.Push(i + rendom.NextDouble());
}

ShowIEnumerable<double>.Show(myDoubleStack);

//create char list
var myCharStack = new MyStack<char>();

myCharStack.Pushed += item => Console.WriteLine($"Pushed: {item}");
myCharStack.Popped += item => Console.WriteLine($"Popped: {item}");
myCharStack.Cleared += () => Console.WriteLine("Cleared");




for (int i = 0; i < 5; i++)
{
    myCharStack.Push((char)(97 + i));
}

ShowIEnumerable<char>.Show(myCharStack);

//Peek

var topElement = myCharStack.Peek();

Console.WriteLine(string.Format("the Peeked element from the stack is {0}", topElement));

ShowIEnumerable<char>.Show(myCharStack);


//Pop

topElement = myCharStack.Pop();

Console.WriteLine(string.Format("the Poped element from the stack is {0}", topElement));

ShowIEnumerable<char>.Show(myCharStack);

Console.WriteLine("#as you see the size of the stack decreases");
Console.WriteLine();

//Push

myCharStack.Push('O');

Console.WriteLine("myCharStack.Push('O');");

ShowIEnumerable<char>.Show(myCharStack);



var charToSerch = 'a';

//Contains
//check if myCharList Contains charToSerch
if (myCharStack.Contains(charToSerch))
{
    Console.WriteLine(string.Format("myCharStack contains {0}", charToSerch));
}
else
{
    Console.WriteLine(string.Format("myCharStack do not {0}", charToSerch));
}
Console.WriteLine();

//CopyTo
var destArr = new char[10];

for (int i = 0; i < destArr.Length; i++)
{
    destArr[i] = (char)(110 + i);
}
Console.WriteLine("destArr");
ShowIEnumerable<char>.Show(destArr);

myCharStack.CopyTo(destArr, 0);

Console.WriteLine("myCharStack.CopyTo(destArr, 0);");
Console.WriteLine();
Console.WriteLine("destArr after CopyTo");

ShowIEnumerable<char>.Show(destArr);


//Clear
Console.WriteLine("remove all elems from stack");

myCharStack.Clear();

ShowIEnumerable<char>.Show(myCharStack);


#endregion
