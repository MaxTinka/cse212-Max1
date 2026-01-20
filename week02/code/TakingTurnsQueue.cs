using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public int Turns { get; set; }

    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }
}

public class TakingTurnsQueue
{
    private readonly Queue<Person> _queue = new Queue<Person>();
    
    public int Length => _queue.Count;

    public void AddPerson(string name, int turns)
    {
        _queue.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        // Get the person at the front
        Person person = _queue.Dequeue();
        
        // Handle turn logic
        if (person.Turns > 1)
        {
            // Finite turns and still has turns left after this one
            person.Turns--;
            _queue.Enqueue(person);
        }
        else if (person.Turns <= 0)
        {
            // Infinite turns (0 or negative) - re-add with same turn count
            _queue.Enqueue(person);
        }
        // If Turns == 1, don't re-add (they've used their last turn)
        
        return person;
    }
}
