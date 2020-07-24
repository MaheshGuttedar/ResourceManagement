namespace ResourceManagement.Repository.Contract
{
    public interface IUnitOfWork
    {
        ISeatRepository SeatRepository { get; }
        IFloorRepository FloorRepository { get;}
        IEmployeeRepository EmployeeRepository { get; }
        ILoginRepository LoginRepository { get; }

    }
}
