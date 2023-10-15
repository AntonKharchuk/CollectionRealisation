using System.Collections.Generic;

namespace CollectionRealisation;

public class StackTests
{
    [Fact]
    public void Count_Property_Should_Return_Correct_Value()
    {
        var stack = new MyStack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.Equal(3, stack.Count);
    }
    [Fact]
    public void IsReadOnly_Property_Should_Always_Return_False()
    {
        var stack = new MyStack<int>();

        Assert.False(stack.IsReadOnly);
    }
    [Fact]
    public void IsSynchronized_Property_Should_Always_Return_False()
    {
        var stack = new MyStack<int>();

        Assert.False(stack.IsSynchronized);
    }
    [Fact]
    public void SyncRoot_Property_Should_Return_This_Instance()
    {
        var stack = new MyStack<int>();

        Assert.Same(stack, stack.SyncRoot);
    }

    [Fact]
    public void Clear_Should_Clear_Stack_And_Invoke_Cleared_Event()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        stack.Clear();

        Assert.Empty(stack);
    }

    [Fact]
    public void Clear_Should_Invoke_Cleared_Event()
    {
        var stack = new MyStack<int>();
        bool clearedEventInvoked = false;
        stack.Cleared += () => clearedEventInvoked = true;

        stack.Push(1);
        stack.Clear();

        Assert.True(clearedEventInvoked);
    }
    [Fact]
    public void Contains_Should_Return_True_When_Item_Exists()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.True(stack.Contains(2));
    }

    [Fact]
    public void Contains_Should_Return_False_When_Item_Does_Not_Exist()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.False(stack.Contains(4));
    }

    [Fact]
    public void Contains_Should_Return_False_For_Empty_Stack()
    {
        var stack = new MyStack<int>();

        Assert.False(stack.Contains(1));
    }

    [Fact]
    public void GetEnumerator_Should_Return_Enumerator_For_Generic_Enumerable()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        IEnumerator<int> enumerator = stack.GetEnumerator();

        Assert.NotNull(enumerator);
    }

    [Fact]
    public void GetEnumerator_Should_Return_Non_Generic_Enumerator()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        IEnumerator<int> enumerator = ((IEnumerable<int>)stack).GetEnumerator();

        Assert.NotNull(enumerator);
    }

    [Fact]
    public void GetEnumerator_Should_Traverse_Stack_Elements()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        List<int> elements = new List<int>();
        foreach (int item in stack)
        {
            elements.Add(item);
        }

        Assert.Equal(new List<int> { 3, 2, 1 }, elements);
    }

    [Fact]
    public void Peek_Should_Return_Top_Element_Without_Removing_It()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        var peekedValue = stack.Peek();

        Assert.Equal(3, peekedValue); 
        Assert.Equal(3, stack.Count); 
    }

    [Fact]
    public void Peek_Should_Throw_InvalidOperationException_On_Empty_Stack()
    {
        var stack = new MyStack<int>();

        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void Pop_Should_Return_Top_Element_And_Remove_It()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        var poppedValue = stack.Pop();

        Assert.Equal(3, poppedValue); 
        Assert.Equal(2, stack.Count); 
    }

    [Fact]
    public void Pop_Should_Throw_InvalidOperationException_On_Empty_Stack()
    {
        var stack = new MyStack<int>();

        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }
}