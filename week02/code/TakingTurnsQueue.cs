/// <summary>
/// Get the next person in the queue and return them. The person should
/// go to the back of the queue again unless the turns variable shows that they 
/// have no more turns left.  Note that a turns value of 0 or less means the 
/// person has an infinite number of turns.  An error exception is thrown 
/// if the queue is empty.
/// </summary>
public Person GetNextPerson()
{
    if (_people.IsEmpty())
    {
        throw new InvalidOperationException("No one in the queue.");
    }

    // Dequeue the next person
    Person person = _people.Dequeue();

    // TODO Problem 1 - Fix defects found in test cases
    // Defects Found:
    // 1. People with Turns <= 0 (infinite turns) were not being re-enqueued.
    // 2. People with Turns == 1 were never re-enqueued correctly (last turn not handled properly).
    // 3. People with finite Turns > 1 were decremented correctly but logic did not cover infinite turns.
    //
    // Fix Applied:
    // - Re-enqueue person if Turns <= 0 (infinite turns) or if Turns > 1 (still has remaining finite turns)
    // - Only decrement Turns if they are finite (Turns > 1)
    // - Do not re-enqueue people whose Turns == 1 (last turn)

    if (person.Turns <= 0)
    {
        _people.Enqueue(person); // Infinite turns, do not decrement, re-add to the queue
    }
    else if (person.Turns > 1)
    {
        person.Turns -= 1; // Finite turns, decrement and re-add
        _people.Enqueue(person);
    }
    // If Turns == 1, person is not re-enqueued (last turn), as required

    return person;
}