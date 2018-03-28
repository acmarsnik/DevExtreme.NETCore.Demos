using System;
using System.Collections.Generic;

namespace DevExtreme.NETCore.Demos.Models.SampleData {
    public partial class SampleData {
        public static List<EmployeeTask> Tasks {
            get {
                return new List<EmployeeTask> {
                    new EmployeeTask {
                        Subject = "Website Re-Design Plan",
                        Priority = Priority.High,
                        StartDate = new DateTime(2015, 5, 25, 9, 0, 0),
                        DueDate = new DateTime(2015, 5, 25, 11, 30, 0)
                    },
                    new EmployeeTask {
                        Subject = "Book Flights to San Fran for Sales Trip",
                        Priority = Priority.High,
                        StartDate = new DateTime(2015, 5, 25, 12, 0, 0),
                        DueDate = new DateTime(2015, 5, 25, 13, 0, 0)
                    },
                    new EmployeeTask {
                        Subject = "Install New Router in Dev Room",
                        Priority = Priority.Low,
                        StartDate = new DateTime(2015, 5, 25, 14, 30, 0),
                        DueDate = new DateTime(2015, 5, 25, 15, 30, 0)
                    },
                    new EmployeeTask {
                        Subject = "Approve Personal Computer Upgrade Plan",
                        Priority = Priority.High,
                        StartDate = new DateTime(2015, 5, 26, 10, 0, 0),
                        DueDate = new DateTime(2015, 5, 26, 11, 0, 0)
                    },
                    new EmployeeTask {
                        Subject = "Final Budget Review",
                        Priority = Priority.High,
                        StartDate = new DateTime(2015, 5, 26, 12, 0, 0),
                        DueDate = new DateTime(2015, 5, 26, 13, 35, 0)
                    },
                    new EmployeeTask {
                        Subject = "New Brochures",
                        Priority = Priority.High,
                        StartDate = new DateTime(2015, 5, 26, 14, 30, 0),
                        DueDate = new DateTime(2015, 5, 26, 15, 45, 0)
                    },
                    new EmployeeTask {
                        Subject = "Install New Database",
                        Priority = Priority.Low,
                        StartDate = new DateTime(2015, 5, 27, 9, 45, 0),
                        DueDate = new DateTime(2015, 5, 27, 11, 15, 0)
                    },
                    new EmployeeTask {
                        Subject = "Approve New Online Marketing Strategy",
                        Priority = Priority.High,
                        StartDate = new DateTime(2015, 5, 27, 12, 0, 0),
                        DueDate = new DateTime(2015, 5, 27, 14, 0, 0)
                    },
                    new EmployeeTask {
                        Subject = "Upgrade Personal Computers",
                        Priority = Priority.Low,
                        StartDate = new DateTime(2015, 5, 27, 15, 15, 0),
                        DueDate = new DateTime(2015, 5, 27, 16, 30, 0)
                    },
                    new EmployeeTask {
                        Subject = "Prepare 2015 Marketing Plan",
                        Priority = Priority.High,
                        StartDate = new DateTime(2015, 5, 28, 11, 0, 0),
                        DueDate = new DateTime(2015, 5, 28, 13, 30, 0)
                    },
                    new EmployeeTask {
                        Subject = "Brochure Design Review",
                        Priority = Priority.Low,
                        StartDate = new DateTime(2015, 5, 28, 14, 0, 0),
                        DueDate = new DateTime(2015, 5, 28, 15, 30, 0)
                    },
                    new EmployeeTask {
                        Subject = "Create Icons for Website",
                        Priority = Priority.High,
                        StartDate = new DateTime(2015, 5, 29, 10, 0, 0),
                        DueDate = new DateTime(2015, 5, 29, 11, 30, 0)
                    },
                    new EmployeeTask {
                        Subject = "Upgrade Server Hardware",
                        Priority = Priority.Low,
                        StartDate = new DateTime(2015, 5, 29, 14, 30, 0),
                        DueDate = new DateTime(2015, 5, 29, 16, 0, 0)
                    },
                    new EmployeeTask {
                        Subject = "Submit New Website Design",
                        Priority = Priority.High,
                        StartDate = new DateTime(2015, 5, 29, 16, 30, 0),
                        DueDate = new DateTime(2015, 5, 29, 18, 0, 0)
                    },
                    new EmployeeTask {
                        Subject = "Launch New Website",
                        Priority = Priority.High,
                        StartDate = new DateTime(2015, 5, 29, 12, 20, 0),
                        DueDate = new DateTime(2015, 5, 29, 14, 0, 0)
                    }
                };
            }
        }
    }
}