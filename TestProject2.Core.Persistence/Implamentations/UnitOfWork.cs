using TestProject2.Core.Application.Interfaces.Repositories;
using TestProject2.Infrastructure.Persistence.Implamentations.Repositories;

namespace TestProject2.Infrastructure.Persistence.Implamentations
{
    internal class UnitOfWork : IUnitOfWork
    {
        private IPersonRepository _personRepository;
        private IGroupRepository _groupRepository;


        private readonly DataContext _context;
        public UnitOfWork(DataContext context) => this._context = context;

        public IPersonRepository PersonRepository => _personRepository ??= new PersonRepository(_context);
        public IGroupRepository GroupRepository => _groupRepository ??= new GroupRepository(_context);
    }
}
