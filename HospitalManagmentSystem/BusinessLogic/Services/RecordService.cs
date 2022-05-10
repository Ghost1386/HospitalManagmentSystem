using System.Collections.Generic;
using HospitalManagmentSystem.BusinessLogic.Interfaces;
using HospitalManagmentSystem.Common.Models;
using HospitalManagmentSystem.DAL.Interfaces;

namespace HospitalManagmentSystem.BusinessLogic.Services
{
    public class RecordService : IRecordService
    {
        public static int RecordId;

        private readonly IRecordRepository _recordRepository;

        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public IEnumerable<Record> GetPatientRecord(int id)
        {
            return _recordRepository.GetPatientRecord(id);
        }

        public IEnumerable<Record> GetEmployeeRecord(int id)
        {
            return _recordRepository.GetEmployeeRecord(id);
        }

        public Record Get(int id)
        {   
            return _recordRepository.Get(id);
        }

        public void Delete(int id)
        {
            _recordRepository.Delete(id);
        }

        public void Create(Record record)
        {
            _recordRepository.Create(record);
        }        

        public void Edit(Record record)
        {
            _recordRepository.Edit(record);
        }
    }
}
