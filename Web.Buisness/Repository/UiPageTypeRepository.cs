using Dapper;
using System.Data;
using WebBuisness.Infrastructure;
using WebBuisness.Models;
using WebBuisness.Repository.Interface;

namespace WebBuisness.Repository
{
    public class UiPageTypeRepository : IUiPageTypeRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UiPageTypeRepository(IConnectionFactory connectionFactory)
        {
           _connectionFactory = connectionFactory;
        }
        public UiPageType Create(UiPageType uiPageType)
        {
            IDbConnection db = _connectionFactory.GetConnection;
            db.Execute("Insert Into UiPageType (Name) Values (@Name)", uiPageType);
            return uiPageType;
        }
        public int Delete(int id)
        {
            IDbConnection db = _connectionFactory.GetConnection;
            db.Execute("Delete From UiPageType Where Id = @id", id);
            return 1;
        }
        public UiPageType Get(int id)
        {
            IDbConnection db = _connectionFactory.GetConnection;
             var result = db.Query<UiPageType>("select * from UiPageType where Id = @id", id).FirstOrDefault();
            return result;
        }

        public List<UiPageType> Get()
        {
            IDbConnection db = _connectionFactory.GetConnection;
            var result = db.Query<UiPageType>("select * from UiPageType").ToList();
            return result;
        }

        public UiPageType Update(UiPageType uiPageType)
        {
            IDbConnection db = _connectionFactory.GetConnection;
            db.Execute("update UiPageType Set Name = @Name where Id = @Id", uiPageType);
            return uiPageType;
        }
    }
}
