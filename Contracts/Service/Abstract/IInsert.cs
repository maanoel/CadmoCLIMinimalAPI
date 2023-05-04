namespace Contracts.Service.Abstract
{
    public interface IInsert<ViewModel>
    {
        bool NewRecord(ViewModel ViewModel);
    }
}