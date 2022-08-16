namespace TestProject2.Core.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        public IPersonRepository PersonRepository { get; }
        public IGroupRepository GroupRepository { get; }
    }
}
