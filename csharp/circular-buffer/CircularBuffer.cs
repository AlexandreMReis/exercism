using System;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    private readonly int _capacity;
    private readonly Queue<T> _buffer;
    public CircularBuffer(int capacity)
    {
        _buffer= new Queue<T>();
        _capacity = capacity;
    }

    public T Read() => _buffer.Count == 0 ? throw new InvalidOperationException() : _buffer.Dequeue();

    public void Write(T value)
    {
        if(_buffer.Count == _capacity) throw new InvalidOperationException();
        _buffer.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (_buffer.Count < _capacity)
        {
            Write(value);
            return;
        }

        _buffer.Dequeue();
        _buffer.Enqueue(value);
    }

    public void Clear() => _buffer.Clear();
}