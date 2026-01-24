using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private readonly Queue<Person> _queue = new();
    
    public int Length => _queue.Count;

    public void AddPerson(string name, int turns)
    {
        _queue.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        Person person = _queue.Dequeue();
        
        if (person.Turns > 1) // Finite turns and will have turns left after this one
        {
            person.Turns--;
            _queue.Enqueue(person);
        }
        else if (person.Turns <= 0) // Infinite turns (0 or negative)
        {
            _queue.Enqueue(person);
        }
        // If Turns == 1, don't re-add (they've used their last turn)
        
        return person;
    }
}
