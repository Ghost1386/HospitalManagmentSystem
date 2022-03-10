using System;
using System.Globalization;
using HospitalManagmentSystem.BusinessLogic.Interfaces;
using HospitalManagmentSystem.Common.Models;
using HospitalManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagmentSystem.Controllers
{
    [Authorize(Roles = "Employee")]
    public class RecordController : Controller
    {
        private readonly IRecordService _recordService;

        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }
        
        public IActionResult Index()
        {
            return View(_recordService.GetRecord());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(RecordViewModel recordViewModel)
        {
            if (ModelState.IsValid)
            {
                _recordService.Create(new Record()
                {
                    UserId = recordViewModel.UserId,
                    Department = recordViewModel.Department,
                    EmployeeId = recordViewModel.EmployeeId,
                    DateAndTime = Convert.ToDateTime(recordViewModel.DateAndTime),
                    RecordStatus = Convert.ToInt32(recordViewModel.RecordStatus)
                });

                return RedirectToAction(nameof(Index));
            }

            return View(recordViewModel);
        }

        public IActionResult Edit(int id)
        {
            Record record = _recordService.Get(id);

            return View(new RecordViewModel()
            {
                UserId = record.UserId,
                Department = record.Department,
                EmployeeId = record.EmployeeId,
                DateAndTime = record.DateAndTime.ToString(CultureInfo.CurrentCulture),
                RecordStatus = record.RecordStatus
            });
        }

        public IActionResult Edit(RecordViewModel recordViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                _recordService.Edit(new Record()
                {
                    Id = id,
                    UserId = recordViewModel.UserId,
                    Department = recordViewModel.Department,
                    EmployeeId = recordViewModel.EmployeeId,
                    DateAndTime = Convert.ToDateTime(recordViewModel.DateAndTime),
                    RecordStatus = recordViewModel.RecordStatus
                });

                return RedirectToAction(nameof(Index));
            }

            try
            {
                return View(recordViewModel);
            }
            catch
            {
                return View();
            }
        }
    }
}
