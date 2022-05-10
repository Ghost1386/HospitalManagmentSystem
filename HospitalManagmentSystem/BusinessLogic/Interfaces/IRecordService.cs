using System.Collections.Generic;
using HospitalManagmentSystem.Common.Models;

namespace HospitalManagmentSystem.BusinessLogic.Interfaces
{
    public interface IRecordService
    {
        IEnumerable<Record> GetPatientRecord(int id);

        IEnumerable<Record> GetEmployeeRecord(int id);

        Record Get(int id);

        void Delete(int id);

        void Create(Record record);

        void Edit(Record record);
    }
}
