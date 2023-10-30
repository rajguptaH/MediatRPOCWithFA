using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBuisness.Models;

namespace WebBuisness.Repository.Interface
{
    public interface IUiPageTypeRepository
    {
        UiPageType Create(UiPageType uiPageType);
        UiPageType Update(UiPageType uiPageType);
        int Delete(int id);
        UiPageType Get(int id);
        List<UiPageType> Get();
    }
}
