using Microsoft.Extensions.Options;
using ResourceManagement.Repository.Contract;

namespace ResourceManagement.Repository.Methods
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Pravate Variables
        private readonly IOptions<ReadConfig> _sqlConnString;
        private  ISeatRepository _seatRepository;
        private IFloorRepository _floorRepository;
        private IEmployeeRepository _employeeRepository;
        private ILoginRepository _loginRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// UnitOfWork
        /// </summary>
        /// <param name="connectionstring"></param>
        public UnitOfWork(IOptions<ReadConfig> connectionstring)
        {
            _sqlConnString = connectionstring;
        }
        #endregion

        #region public Members
        /// <summary>
        /// SeatRepository Property
        /// </summary>
        public ISeatRepository SeatRepository =>
                                           _seatRepository = _seatRepository ?? new SeatRepository(_sqlConnString.Value.ConnectionString);

        /// <summary>
        /// FloorRepository Property
        /// </summary>
        public IFloorRepository FloorRepository => 
                                           _floorRepository = _floorRepository ?? new FloorRepository(_sqlConnString.Value.ConnectionString);

        public IEmployeeRepository EmployeeRepository =>
                                           _employeeRepository = _employeeRepository ?? new EmployeeRepository(_sqlConnString.Value.ConnectionString);
        public ILoginRepository LoginRepository =>
                                          _loginRepository = _loginRepository ?? new LoginRepository(_sqlConnString.Value.ConnectionString);



        #endregion
    }
}
