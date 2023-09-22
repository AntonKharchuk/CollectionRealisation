// See https://aka.ms/new-console-template for more information
using CollectionRealisation;
using CollectionRealisation.ConsoleDemo;

Console.WriteLine("Hello, World!");

//create int list
var myIntList = new MyList<int>() {1,2,3,4,5 };

ShowArrays<int>.Show(myIntList);

//create double list
var myDoubleList = new MyList<double>() { 1.3, 2.3, 3.3, 4.3, 5.3 };

ShowArrays<double>.Show(myDoubleList);

//create char list
var myCharList = new MyList<char>();

for (int i = 0; i < 5; i++)
{
    myCharList.Add((char)(97 + i));
}

ShowArrays<char>.Show(myCharList);


//set char to serch
var charToSerch = 'a';

Console.WriteLine();

//Contains
//check if myCharList Contains charToSerch
if (myCharList.Contains(charToSerch))
{
    Console.WriteLine(string.Format("myCharList contains {0}", charToSerch));
}
else
{
    Console.WriteLine(string.Format("myCharList do not {0}", charToSerch));
}


Console.WriteLine();

//Insert
Console.WriteLine("insert 'y' to list");

myCharList.Insert(3, 'y');

ShowArrays<char>.Show(myCharList);

//IndexOf
Console.WriteLine("index of 'y' is {0}", myCharList.IndexOf('y'));

ShowArrays<char>.Show(myCharList);


//CopyTo
var destArr = new char[10];

for (int i = 0; i < destArr.Length; i++)
{
    destArr[i] = (char)(110 + i);
}
Console.WriteLine("destArr");
ShowArrays<char>.Show(destArr);

myCharList.CopyTo(destArr, 0);  

Console.WriteLine("myCharList.CopyTo(destArr, 0);");
Console.WriteLine();    
Console.WriteLine("destArr after CopyTo");

ShowArrays<char>.Show(destArr);


//Remove
Console.WriteLine("remove 'a' from list");

myCharList.Remove(charToSerch);

ShowArrays<char>.Show(myCharList);


//RemoveAt
Console.WriteLine("remove 1-st elem from list");

myCharList.RemoveAt(1);

ShowArrays<char>.Show(myCharList);


//Clear
Console.WriteLine("remove all elems from list");

myCharList.Clear();

ShowArrays<char>.Show(myCharList);
