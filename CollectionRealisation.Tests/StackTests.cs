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
}