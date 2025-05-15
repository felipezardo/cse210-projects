using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;
    private List<Job> _jobs = new List<Job>();

    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}
