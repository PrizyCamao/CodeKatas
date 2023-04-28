namespace Ordered_Jobs;

interface IOrderedJobs
{
    void Register(char dependentJob, char independentJob);
    void Register(char job);

    string Sort();
}
