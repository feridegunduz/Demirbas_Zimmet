using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data.Abstract
{
    public interface IDmrbsRepository : IRepository<Demirbas>
    {
        Task<List<Demirbas>> GetCustomDmrbsList();
        Task<List<Demirbas>> GetCustomDmrbsList(Expression<Func<Demirbas, bool>> expression);

        Task<Demirbas> GetCustomDmrbs(int id);


    }
}
