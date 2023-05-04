using System.Collections.Generic;

namespace Contracts.Service.Abstract
{
    public interface ISelectAllViews<ViewGetModel>
    {
        List<ViewGetModel> SelectAllViews();
    }

    public interface ISelectAllWithDependencyView<ViewGetModel>
    {
        List<ViewGetModel> SelectAllViews(int RelationId);
    }
}