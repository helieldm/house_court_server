using HouseCourt.Context;

namespace HouseCourt.Service;

public class TaskService
{
    private readonly HouseCourtContext _context;

    public TaskService(HouseCourtContext context)
    {
        _context = context;
    }

    public List<Entities.Task> GetTasksToSend(String houseMacAdress)
    {
        return _context.Tasks.Where(x => x.HouseMACAdress == houseMacAdress && x.Sent == false).ToList();
    }
    
    public void UpdateTask(Entities.Task task)
    {
        _context.Tasks.Update(task);

        _context.SaveChanges();
    }
}