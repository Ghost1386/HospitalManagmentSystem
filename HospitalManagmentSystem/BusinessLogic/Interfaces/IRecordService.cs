using System.Collections.Generic;
using HospitalManagmentSystem.Common.Models;

namespace HospitalManagmentSystem.BusinessLogic.Interfaces
{
    public interface IRecordService
    {
        IEnumerable<Record> GetRecord();

        Record Get(int id);

        void Delete(int id);

        void Create(Record record);

        void Edit(Record record);
    }
}
