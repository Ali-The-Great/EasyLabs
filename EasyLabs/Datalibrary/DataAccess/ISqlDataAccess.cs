namespace Datalibrary.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "LabDB");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "LabDB");
    }
}