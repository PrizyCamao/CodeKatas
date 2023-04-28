using System.Text;

public class OrderedJobs
{
    private Dictionary<char, List<char>> jobDependencies = new Dictionary<char, List<char>>();

    public void Register(char dependentJob, char independentJob)
    {
        if (!jobDependencies.ContainsKey(dependentJob))
        {
            jobDependencies[dependentJob] = new List<char>();
        }

        if (!jobDependencies.ContainsKey(independentJob))
        {
            jobDependencies[independentJob] = new List<char>();
        }

        jobDependencies[dependentJob].Add(independentJob);

        // Check for circular dependencies
        if (HasCircularDependency(dependentJob))
        {
            throw new InvalidOperationException("Circular dependency detected.");
        }
    }

    public void Register(char job)
    {
        if (!jobDependencies.ContainsKey(job))
        {
            jobDependencies[job] = new List<char>();
        }
    }

    public string Sort()
    {
        var sortedJobs = new StringBuilder();

        while (jobDependencies.Count > 0)
        {
            // Find a job that has no dependencies
            var independentJob = jobDependencies.Keys.FirstOrDefault(job => jobDependencies[job].Count == 0);

            if (independentJob == '\0')
            {
                // We couldn't find any independent jobs, which means we have a circular dependency
                throw new InvalidOperationException("Circular dependency detected.");
            }

            // Remove the job from our dependencies
            jobDependencies.Remove(independentJob);

            // Add the job to our sorted list
            sortedJobs.Append(independentJob);

            // Remove the job as a dependency for any other jobs
            foreach (var dependentJob in jobDependencies.Keys)
            {
                jobDependencies[dependentJob].Remove(independentJob);
            }
        }

        return sortedJobs.ToString();
    }

    private bool HasCircularDependency(char job, HashSet<char> visitedJobs = null)
    {
        if (visitedJobs == null)
        {
            visitedJobs = new HashSet<char>();
        }

        if (visitedJobs.Contains(job))
        {
            return true;
        }

        visitedJobs.Add(job);

        foreach (var dependentJob in jobDependencies[job])
        {
            if (HasCircularDependency(dependentJob, visitedJobs))
            {
                return true;
            }
        }

        visitedJobs.Remove(job);

        return false;
    }
}
