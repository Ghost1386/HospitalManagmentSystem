using HospitalManagmentSystem.BusinessLogic.Interfaces;
using HospitalManagmentSystem.BusinessLogic.Services;
using HospitalManagmentSystem.Common.Enums;
using HospitalManagmentSystem.Common.Models;
using HospitalManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagmentSystem.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordService _recordService;

        public static int UserRecordId;
        
        public static int EmployeeRecordId;

        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        public IActionResult GetPatientId()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult GetPatientId(int id)
        {
            UserRecordId = id;
            return RedirectToAction("GetPatientRecord", "Record");
        }
        
        public IActionResult GetPatientRecord()
        {
            return View(_recordService.GetPatientRecord(UserRecordId));
        }
        
        public IActionResult GetEmployeeId()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult GetEmployeeId(int id)
        {
            EmployeeRecordId = id;
            return RedirectToAction("GetEmployeeRecord", "Record");
        }
        
        public IActionResult GetEmployeeRecord()
        {
            return View(_recordService.GetEmployeeRecord(EmployeeRecordId));
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RecordViewModel recordViewModel)
        {
            _recordService.Create(new Record()
            {
                UserId = recordViewModel.UserId,
                Department = (int)recordViewModel.Department,
                EmployeeId = recordViewModel.EmployeeId,
                DateAndTime = recordViewModel.DateAndTime,
                RecordStatus = (int)recordViewModel.RecordStatus
            });

           return RedirectToAction("HomePage", "Home");      
        }

        public IActionResult Edit(int id)
        {
            Record record = _recordService.Get(id);

            RecordService.RecordId = record.Id;

            return View(new RecordViewModel()
            {
                UserId = record.UserId,
                Department = (Department)record.Department,
                EmployeeId = record.EmployeeId,
                DateAndTime = record.DateAndTime,
                RecordStatus = (RecordStatus)record.RecordStatus
            });
        }

        [HttpPost]
        public IActionResult Edit(RecordViewModel recordViewModel)
        {
            _recordService.Edit(new Record()
            {
                Id = RecordService.RecordId,
                UserId = recordViewModel.UserId,
                Department = (int)recordViewModel.Department,
                EmployeeId = recordViewModel.EmployeeId,
                DateAndTime = recordViewModel.DateAndTime,
                RecordStatus = (int)recordViewModel.RecordStatus
            });

            return RedirectToAction("HomePage", "Home");
        }
        
        public IActionResult Delete()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _recordService.Delete(id);

            return RedirectToAction("HomePage", "Home");
        }
        
        public IActionResult Details(int id)
        {
            Record record = _recordService.Get(id);

            return View(new RecordViewModel()
            {
                UserId = record.UserId,
                Department = (Department)record.Department,
                EmployeeId = record.EmployeeId,
                DateAndTime = record.DateAndTime,
                RecordStatus = (RecordStatus)record.RecordStatus
            });
        }
    }
}
